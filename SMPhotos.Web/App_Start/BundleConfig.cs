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

			bundles.Add(new ScriptBundle("~/Scripts/imageLoad/js").Include(
						"~/Scripts/jquery-2.1.3.min.js",
						"~/Scripts/imageLoad.js"));

			bundles.Add(new ScriptBundle("~/Scripts/passwordValidation/js").Include(
						"~/Scripts/passwordValidation.js"));

			bundles.Add(new ScriptBundle("~/Scripts/modalValidation/js").Include(
						"~/Scripts/passwordValidation.js",
						"~/Scripts/modal.js"));

			bundles.Add(new ScriptBundle("~/Scripts/modal/js").Include(
			"~/Scripts/modal.js"));

			bundles.Add(new ScriptBundle("~/Scripts/fancyBox/js")
				.Include("~/Scripts/jquery.fancybox.js")
				.Include("~/Scripts/jquery.fancybox.pack.js")
				.Include("~/Scripts/jquery.fancybox-buttons.js")
				.Include("~/Scripts/jquery.fancybox-media.js")
				.Include("~/Scripts/jquery.fancybox-thumbs.js")
				.Include("~/Scripts/jquery.mousewheel-3.0.6.pack.js"));

			bundles.Add(new StyleBundle("~/Content/login/css").Include(
						"~/Content/login.css"));

			bundles.Add(new StyleBundle("~/Content/join/css").Include(
						"~/Content/join.css"));

			bundles.Add(new StyleBundle("~/Content/main/css").Include(
						"~/Content/main.css"));

			bundles.Add(new StyleBundle("~/Content/admin/css").Include(
						"~/Content/admin.css"));

			bundles.Add(new StyleBundle("~/Content/about/css").Include(
			"~/Content/about.css"));

			bundles.Add(new StyleBundle("~/Content/loadImage/css").Include(
			"~/Content/load.css"));

			bundles.Add(new StyleBundle("~/Content/base/css").Include(
						"~/Content/base.css",
						"~/Content/bootstrap.min.css"));

			bundles.Add(new StyleBundle("~/Content/fancyBox/css")
				.Include("~/Content/jquery.fancybox*"));
		}
	}
}