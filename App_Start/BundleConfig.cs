using System.Web;
using System.Web.Optimization;

namespace MvcExampleM1GlGroupe2
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/employejs").Include(
                        "~/Scripts/employejs.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new Bundle("~/bundles/jstemplate").Include(
                      "~/assets/vendor/apexcharts/apexcharts.min.js",
                      "~/assets/vendor/bootstrap/js/bootstrap.bundle.min.js",
                      "~/assets/vendor/chart.js/chart.umd.js",
                      "~/assets/vendor/echarts/echarts.min.js",
                      "~/assets/vendor/quill/quill.js",
                      "~/assets/vendor/simple-datatables/simple-datatables.js",
                      "~/assets/vendor/tinymce/tinymce.min.js",
                      "~/assets/vendor/php-email-form/validate.js",
                      "~/assets/js/main.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/PagedList.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/csstemplate").Include(
                     "~/assets/vendor/bootstrap/css/bootstrap.min.css",
                     "~/assets/vendor/bootstrap-icons/bootstrap-icons.css",
                     "~/assets/vendor/boxicons/css/boxicons.min.css",
                     "~/assets/vendor/quill/quill.snow.css",
                     "~/assets/vendor/quill/quill.bubble.css",
                     "~/assets/vendor/remixicon/remixicon.css",
                     "~/assets/vendor/simple-datatables/style.css",
                     "~/assets/css/style.css"));
        }
    }   
}
