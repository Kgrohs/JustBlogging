using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogLibrary.Models;
using BlogService;
using JustBlogging.Models;
using ServiceStack.Logging;

namespace JustBlogging.Controllers
{
    public class BlogController : Controller
    {
        private readonly ILog _log = LogManager.GetLogger("BlogController");

        private IBlogManager _blogManager;
        public IBlogManager BlogManager
        {
            get { return _blogManager ?? (_blogManager = BlogManagerFactory.CreateManager()); }
            set { _blogManager = value; }
        }

        // GET: Blog/Index/{user}
        public ActionResult Index(int? userId)
        {
            IEnumerable<Entry> blogs;
            bool letMeEdit = false;
            string owner = "Example";
            if (userId.HasValue)
            {
                blogs = BlogManager.GetAllBlogs(userId.Value);
                owner = BlogManager.GetUserName(userId.Value);
                if (User.Identity.Name != null && Request.IsAuthenticated)
                {
                    if (BlogManager.IsCurrentUser(User.Identity.Name, userId.Value))
                    {
                        letMeEdit = true;
                    }
                }
            }
            else
            {
                blogs = BlogManager.GetAllBlogs();
            }
            var model = new BlogViewModel
            {
                Blogs = blogs,
                LetMeEdit = letMeEdit,
                BlogOwner = owner
            };

            return View(model);
        }

        [HttpPost]      
        public ActionResult Index(string entry, string userName)
        {
            int userId = BlogManager.GetUserId(userName);
            bool dbInsertSuccess = false;
            if (userId != 0)
                dbInsertSuccess = BlogManager.AddEntry(userId, entry, DateTime.Now.AddHours(-6));
            if (!dbInsertSuccess)
            {
                _log.Error(String.Format("Failed to insert blog entry for {0}. Entry was {1}.", userName, entry));
            }
            return RedirectToAction("Index", "Blog", new { userId });
        }
    }
}