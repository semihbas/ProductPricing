using System.Web.Optimization;

namespace ProductPricing.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Assets/Scripts/JS").Include(
                "~/Assets/Scripts/jquery-{version}.js",
                "~/Assets/Scripts/modernizr-*",
                "~/Assets/Scripts/respond.js",
                "~/Assets/Scripts/ripples.js",
                "~/Assets/Scripts/material.js",
                "~/Assets/Scripts/jquery.validate.js",
                "~/Assets/Scripts/jquery.validate.unobtrusive.js",
                "~/Assets/Scripts/angular/angular.js",
                "~/Assets/Scripts/angular/angular-route.js",
                "~/Assets/Scripts/angular/angular-resource.js",
                "~/Assets/Scripts/angular/angular-animate.js",
                "~/Assets/Scripts/angular/angular-loader.js",
                "~/Assets/Scripts/angular/angular-aria.js",
                "~/Assets/Scripts/angular/angular-cookies.js",
                "~/Assets/Scripts/angular/angular-message-format.js",
                "~/Assets/Scripts/angular/angular-messages.js",
                "~/Assets/Scripts/angular/angular-mocks.js",
                "~/Assets/Scripts/angular/angular-sanitize.js",
                "~/Assets/Scripts/angular/angular-scenario.js",
                "~/Assets/Scripts/angular/angular-touch.js",
                "~/Assets/Scripts/angular/ui-bootstrap.js",
                "~/Assets/Scripts/angular/ui-bootstrap-tpls.js",
                 "~/Assets/Scripts/angular/dirPagination.js",
                 "~/Assets/Scripts/angular/loading-bar.js",
                "~/App/app.js"
                ));

            bundles.Add(new StyleBundle("~/Assets/Styles/CSS").Include(
                "~/Assets/Styles/bootstrap.css",
                "~/Assets/Styles/roboto.css",
                "~/Assets/Styles/ripples.css",
                "~/Assets/Styles/material.css",
                "~/Assets/Styles/styles.css",
                "~/Assets/Styles/loading-bar.css"
                ));

            BundleTable.EnableOptimizations = true;
        }
    }
}