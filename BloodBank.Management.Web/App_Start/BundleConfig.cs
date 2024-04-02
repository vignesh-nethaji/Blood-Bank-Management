using System.Web;
using System.Web.Optimization;

namespace BloodBank.Management.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scipts/Inventory/inventory.create.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"
                      //, "~/Content/site.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/inventory").Include(
                        "~/Scripts/Inventory/inventory.create.js"));
            bundles.Add(new ScriptBundle("~/bundles/Donation").Include(
                       "~/Scripts/Donation/donation.create.js"));

            bundles.Add(new ScriptBundle("~/bundles/chart").Include(
                       "~/Scripts/chart.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/Home").Include("~/Scripts/Home/home.index.js"));
            /// Added Comments in the file

        }
    }
}
