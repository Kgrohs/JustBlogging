using System.Collections.Generic;
using BlogLibrary.Models;

namespace BlogService
{
    public interface IBlogManager
    {
        IEnumerable<string> GetAllComments();
        IEnumerable<Blog> GetAllBlogs();
    }
}