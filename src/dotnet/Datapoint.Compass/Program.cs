using Datapoint.AspNetCore.ErrorResponses;
using Datapoint.Compass.EntityFrameworkCore;
using Datapoint.Compass.Handlers;
using Datapoint.Compass.Middleware;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;

namespace Datapoint.Compass
{
    internal static class Program
    {
        private static string DefaultLanguageCode = "en";

        private static readonly HashSet<string> LanguageCodes = new ()
        {
            { "en" },
            { "pt" }
        };

        private static readonly Dictionary<string, byte[]> StaticFileContents = new();

        private static readonly Dictionary<string, string> StaticFileContentTypes = new();

        internal static void Main(string[] args)
        {
            var hostConfiguration = new ConfigurationBuilder()
                .AddCommandLine(args)
                .AddEnvironmentVariables("ASPNETCORE_")
                .AddEnvironmentVariables("COMPASS_")
                .Build();

            new WebHostBuilder()
                .UseConfiguration(hostConfiguration)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel()

                .Configure((hostContext, app) =>
                {
                    app.UseResponseHeaders();

                    app.UseStaticFiles();

                    app.UseErrorResponses((responses) =>
                    {
                        responses.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                    });

                    app.UseExceptionLogger();

                    app.UseAuthentication();

                    app.UseRouting();

                    app.UseAuthorization();

                    app.UseEndpoints((endpoints) =>
                    {
                        endpoints.MapControllers();

                        endpoints.MapAngular();
                    });
                })

                .ConfigureServices((hostContext, services) =>
                {
                    services.AddAuthentication()
                    
                        .AddCookie((options) =>
                        {
                            options.Cookie.HttpOnly = true;
                            options.Cookie.IsEssential = true;
                            options.Cookie.Name = "auth";
                            options.Cookie.Path = "/api";
                            options.Cookie.SecurePolicy = hostContext.HostingEnvironment.IsDevelopment()
                                ? CookieSecurePolicy.SameAsRequest
                                : CookieSecurePolicy.Always;
                        });

                    services.AddAuthorizationBuilder()
                        .AddDefaultPolicy("Default", (policy) => policy.RequireAuthenticatedUser())
                        .AddFallbackPolicy("Fallback", (policy) => policy.RequireAuthenticatedUser());

                    services.AddCompassContext((compass) =>
                    {
                        var connectionString = hostContext.Configuration.GetConnectionString("Compass");

                        if (string.IsNullOrEmpty(connectionString))
                        {
                            if (!hostContext.HostingEnvironment.IsDevelopment())
                                throw new InvalidOperationException("A connection string must be set for this environment.");

                            connectionString = "Server=127.0.0.1; Port=3306; Database=Compass; Uid=compass-app; Pwd=815c3306-f775-4bf5-9d87-1e9e70899fbc";
                        }

                        compass.UseMySQL(connectionString, (mysql) =>
                        {
                            mysql.CommandTimeout(5);
                            mysql.EnableRetryOnFailure();
                        });
                    });

                    services.AddControllers();

                    services.AddLogging((logging) =>
                    {
                        logging.AddConsole();
                    });

                    services.AddMiddleware();

                    services.AddRouting();

                    services.AddScoped<IAuthorizationMiddlewareResultHandler, AuthorizationMiddlewareResultHandler>();
                })

                .Build()
                .Run();
        }

        private static string? GetCookiesLanguageCode(HttpContext httpContext)
        {
            if (!httpContext.Request.Cookies.TryGetValue("app.language", out var languageCode))
                return null;

            if (string.IsNullOrEmpty(languageCode))
                return null;

            if (!LanguageCodes.Contains(languageCode))
                return null;

            return languageCode;
        }

        private static string? GetAcceptLanguageCode(HttpContext httpContext) =>

            httpContext.Request.GetTypedHeaders()
                .AcceptLanguage
                .OrderByDescending(h => h.Quality ?? 1)
                .Where(h => h.Value.HasValue && !string.IsNullOrEmpty(h.Value.Value))
                .Where(h => LanguageCodes.Contains(h.Value.Value!))
                .Select(h => h.Value.Value!)
                .FirstOrDefault();

        private static string GetLanguageCode(HttpContext httpContext) =>

            GetCookiesLanguageCode(httpContext)
                ?? GetAcceptLanguageCode(httpContext)
                ?? DefaultLanguageCode;

        private static byte[] GetStaticFileContent(HttpContext httpContext, string staticFilePath)
        {
            var webHostEnvironment = httpContext.RequestServices.GetRequiredService<IWebHostEnvironment>();

            if (!StaticFileContents.TryGetValue(staticFilePath, out var staticFileContent))
            {
                var staticFile = webHostEnvironment.WebRootFileProvider.GetFileInfo(staticFilePath);

                StaticFileContents.Add(staticFilePath, staticFileContent = staticFile.Exists
                    ? File.ReadAllBytes(staticFile.PhysicalPath!)
                    : []);
            }

            return staticFileContent;
        }

        private static string GetStaticFileContentType(string staticFilePath)
        {
            if (!StaticFileContentTypes.TryGetValue(staticFilePath, out var staticFileContentType))
            {
                if (!new FileExtensionContentTypeProvider().TryGetContentType(staticFilePath, out staticFileContentType))
                    staticFileContentType = "application/octet-stream";

                StaticFileContentTypes.Add(staticFilePath, staticFileContentType);
            }

            return staticFileContentType;
        }

        private static string GetStaticFilePath(HttpContext httpContext) =>

            GetStaticFilePath(httpContext, httpContext.Request.Path);

        private static string GetStaticFilePath(HttpContext httpContext, string filePath) =>

            Path.Join("browser", GetLanguageCode(httpContext), filePath);

        private static IEndpointConventionBuilder MapAngular(this IEndpointRouteBuilder endpoints) =>

            endpoints.MapFallback(async (httpContext) =>
            {
                var ct = httpContext.RequestAborted;

                var staticFilePath = GetStaticFilePath(httpContext, "index.html");
                var staticFileContent = GetStaticFileContent(httpContext, staticFilePath);

                httpContext.Response.StatusCode = 200;

                if (staticFileContent.Length == 0)
                {
                    await httpContext.Response.WriteAsJsonAsync("OK");
                    return;
                }

                var staticFileContentType = GetStaticFileContentType(staticFilePath);

                httpContext.Response.Headers.CacheControl = "no-store";
                httpContext.Response.Headers.ContentType = staticFileContentType;
                httpContext.Response.Headers.Pragma = "no-cache";

                using var staticFileContentStream = new MemoryStream(staticFileContent);

                try
                {
                    await StreamCopyOperation.CopyToAsync(
                        staticFileContentStream,
                        httpContext.Response.Body,
                        staticFileContent.Length,
                        ct);
                }
                catch (OperationCanceledException) { }
                catch (Exception e)
                {
                    httpContext.RequestServices.GetRequiredService<ILogger<HttpContext>>()
                        .LogError(e, "Static file content stream copy exception.");
                }
            })
            
                .AllowAnonymous();

        private static IApplicationBuilder UseExceptionLogger(this IApplicationBuilder app) =>

            app.Use(async (httpContext, next) =>
            {
                try
                {
                    await next(httpContext);
                }
                catch (Exception e)
                {
                    httpContext.RequestServices.GetRequiredService<ILoggerFactory>()
                        .CreateLogger(nameof(Program))
                        .LogError(
                            e, 
                            "{ExceptionName}: {ExceptionMessage} ({ExceptionStackTrace})",
                            e.GetType().Name,
                            e.Message,
                            e.StackTrace);

                    throw;
                }
            });

        private static IApplicationBuilder UseResponseHeaders(this IApplicationBuilder app) =>

            app.Use((httpContext, next) =>
            {
                var webHostEnvironment = httpContext.RequestServices.GetRequiredService<IWebHostEnvironment>();

                httpContext.Response.Headers.Append("X-Compass-Environment", webHostEnvironment.EnvironmentName);
                httpContext.Response.Headers.Append("X-Compass-Host", Environment.MachineName);

                return next();
            });

        private static IApplicationBuilder UseStaticFiles(this IApplicationBuilder app) =>

            app.Use(async (httpContext, next) =>
            {
                var ct = httpContext.RequestAborted;

                if (httpContext.Request.Path.Equals("/", StringComparison.Ordinal))
                {
                    await next();
                    return;
                }

                var staticFilePath = GetStaticFilePath(httpContext);
                var staticFileContent = GetStaticFileContent(httpContext, staticFilePath);

                if (staticFileContent.Length == 0)
                {
                    await next();
                    return;
                }

                var staticFileContentType = GetStaticFileContentType(staticFilePath);

                httpContext.Response.Headers.CacheControl = "public, max-age=2592000, s-maxage=5184000, immutable";
                httpContext.Response.Headers.ContentType = staticFileContentType;
                httpContext.Response.Headers.Vary = "accept-language";

                using var staticFileContentStream = new MemoryStream(staticFileContent);

                try
                {
                    await StreamCopyOperation.CopyToAsync(
                        staticFileContentStream,
                        httpContext.Response.Body,
                        staticFileContent.Length,
                        ct);
                }
                catch (OperationCanceledException) { }
                catch (Exception e)
                {
                    httpContext.RequestServices.GetRequiredService<ILogger<HttpContext>>()
                        .LogError(e, "Static file content stream copy exception.");
                }
            });
    }
}
