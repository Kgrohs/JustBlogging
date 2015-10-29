using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogLibrary.Models;
using ServiceStack.Data;

namespace BlogLibrary.Contracts
{
    public interface IBlogRepository : IRepositoryBase
    {
        IDbConnectionFactory DbFactory { get; set; }

        IEnumerable<string> GetAllComments();
        IEnumerable<Blog> GetAllBlogs();
    }
}
