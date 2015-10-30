using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using BlogLibrary.Models;

namespace JustBlogging.Models
{
    public class BlogViewModel
    {
        public bool LetMeEdit { get; set; }
        public IEnumerable<Entry> Blogs { get; set; }
        public string BlogOwner { get; set; }
    }
}