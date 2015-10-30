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
        IEnumerable<Entry> GetAllBlogs();
        IEnumerable<Entry> GetAllBlogs(int userId);
        bool IsCurrentUser(string userName, int userId);
        bool AddEntry(int userId, string entry, DateTime date);
        int GetUserId(string userName);
        bool CreateUser(string userName);
        string GetUserName(int userId);
    }
}
