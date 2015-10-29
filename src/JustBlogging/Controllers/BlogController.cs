using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JustBlogging.Models;

namespace JustBlogging.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            var blogs = new List<Blog>
            {
                new Blog { Id = 1, Comment = "I like turtles."},
                new Blog { Id = 2, Comment = "I like sheep."},
                new Blog { Id = 3, Comment = "I like dragons."},
                new Blog { Id = 4, Comment = "I like hobbits."},
            };

            return View(blogs);
        }
    }
}