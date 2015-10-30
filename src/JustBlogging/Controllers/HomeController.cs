using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogService;

namespace JustBlogging.Controllers
{
    public class HomeController : Controller
    {
        private IBlogManager _blogManager;
        public IBlogManager BlogManager
        {
            get { return _blogManager ?? (_blogManager = BlogManagerFactory.CreateManager()); }
            set { _blogManager = value; }
        }

        public ActionResult Index()
        {
            if (User.Identity.Name != null && Request.IsAuthenticated)
                return RedirectToAction("Index","Blog", new {userId = BlogManager.GetUserId(User.Identity.Name)});
            return RedirectToAction("Login", "Account");

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}