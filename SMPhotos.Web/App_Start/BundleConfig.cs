using System.Web;
using System.Web.Optimization;

namespace Guestbook
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/Scripts/base/js").Include(
						"~/Scripts/jquery-2.1.3.min.js",
						"~/Scripts/modernizr-2.6.2.js",
						"~/Scripts/bootstrap.min.js"));

			bundles.Add(new ScriptBundle("~/Scripts/upload/js").Include(
						"~/Scripts/fileinput.js",
						"~/Scripts/some.js"));

			bundles.Add(new ScriptBundle("~/Scripts/passwordValidation/js").Include(
						"~/Scripts/passwordValidation.js"));

			bundles.Add(new StyleBundle("~/Content/login/css").Include(
						"~/Content/login.css"));

			bundles.Add(new StyleBundle("~/Content/join/css").Include(
						"~/Content/join.css"));

			bundles.Add(new StyleBundle("~/Content/main/css").Include(
						"~/Content/main.css"));

			bundles.Add(new StyleBundle("~/Content/admin/css").Include(
						"~/Content/admin.css"));

			bundles.Add(new StyleBundle("~/Content/base/css").Include(
						"~/Content/base.css",
						"~/Content/bootstrap.min.css"));
		}
	}
}