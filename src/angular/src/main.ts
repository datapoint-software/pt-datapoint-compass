/// <reference types="@angular/localize" />

import { pre } from "@app/app.pre";

window.onload = () => {

  const preloader = document.getElementById("preloader");

  Promise.all([

    import("@angular/platform-browser").then(x => x.bootstrapApplication),
    import("@app/app.component").then(x => x.AppComponent),
    import("@app/app.config").then(x => x.appConfig),
    import("rxjs").then(x => ({ filter: x.filter, first: x.first })),
    import("@angular/router").then(x => ({ Router: x.Router, ActivationEnd: x.ActivationEnd })),

    pre({
      fonts: [
        "assets/fonts/MaterialSymbolsSharp/static/MaterialSymbolsSharp-ExtraLight.woff2",
        "assets/fonts/Roboto/static/Roboto-Latin-ExtraLight.woff2",
        "assets/fonts/Roboto/static/Roboto-Latin-Light.woff2",
        "assets/fonts/Roboto/static/Roboto-Latin-Regular.woff2",
        "assets/fonts/Roboto/static/Roboto-Latin-Bold.woff2"
      ],
      images: [
        "assets/datapoint-software.svg",
        "assets/datapoint-software-dark.svg"
      ],
      styles: [
        "assets/dashly/css/theme.bundle.51f56c4cae8ccd2090b46d2c8b9bef9f.css"
      ]
    })

  ]).then(([ bootstrapApplication, AppComponent, appConfig, { filter, first }, { Router, ActivationEnd } ]) => {
    bootstrapApplication(AppComponent, appConfig)
      .then(() => preloader!.remove())
      .catch((err) => console.error(err));
  });
};
