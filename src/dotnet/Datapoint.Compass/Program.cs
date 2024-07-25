using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
                    app.UseStaticFiles();

                    app.UseRouting();

                    app.UseEndpoints((endpoints) =>
                    {
                        endpoints.MapAngular();
                    });
                })

                .ConfigureServices((hostContext, services) =>
                {
                    services.AddRouting();
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
