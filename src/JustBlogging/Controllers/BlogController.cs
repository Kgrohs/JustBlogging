using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogLibrary.Models;
using BlogService;
using JustBlogging.Models;

namespace JustBlogging.Controllers
{
    public class BlogController : Controller
    {
        private IBlogManager _blogManager;
        public IBlogManager BlogManager
        {
            get
            {
                return _blogManager ?? (_blogManager = BlogManagerFactory.CreateManager());
            }
            set { _blogManager = value; }
        }
        // GET: Blog
        public ActionResult Index()
        {
            var blogs = BlogManager.GetAllBlogs();

            return View(blogs);
        }
    }
}