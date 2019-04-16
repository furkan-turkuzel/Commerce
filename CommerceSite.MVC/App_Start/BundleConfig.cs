using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace CommerceSite.MVC.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundle/jquery").Include(
                "~/Scripts/jquery.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/slick.min.js",
                "~/Scripts/nouislider.min.js",
                "~/Scripts/jquery.zoom.min.js",
                "~/Scripts/main.js",
                "~/Scripts/custom.js",
                "~/Scripts/jquery-1.10.2.min.js",
                "~/Scripts/animsition.min.js",
                "~/Scripts/popper.js",
                "~/Scripts/select2.min.js",
                "~/Scripts/contact/main.js"

                ));

            bundles.Add(new StyleBundle("~/bundle/css").Include(
                "~/Content/css/bootstrap.min.css",
                "~/Content/css/font-awesome.min.css",
                "~/Content/css/slick.css",
                "~/Content/css/slick-theme.css",
                "~/Content/css/nouislider.min.css",
                "~/Content/css/style.css",
                "~/Content/css/icon-font.min.css",
                "~/Content/css/animate.css",
                "~/Content/css/hamburgers.min.css",
                "~/Content/css/animsition.min.css",
                "~/Content/css/select2.min.css",
                "~/Content/css/daterangepicker.css",
                "~/Content/css/util.css",
                "~/Content/css/main.css"
                ));
        }
    }
}