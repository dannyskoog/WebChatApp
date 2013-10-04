using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WebChatApp.App_Start
{
    internal static class BundleConfig
    {
        internal static void RegisterBundles(BundleCollection bundles)
        {
            // Scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                 "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                 "~/Scripts/angular.js",
                 "~/Scripts/angular-cookies.js"));

            bundles.Add(new ScriptBundle("~/bundles/signalr").Include(
                 "~/Scripts/jquery.signalR-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                 "~/Scripts/bootstrap.js"));

            //Styles
            bundles.Add(new StyleBundle("~/styles/bootstrap").Include(
                 "~/Content/bootstrap.css"));
        }
    }
}