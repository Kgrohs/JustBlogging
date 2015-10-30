using System;
using System.Collections.Generic;
using BlogLibrary.Models;

namespace BlogService
{
    public interface IBlogManager
    {
        IEnumerable<string> GetAllComments();
        IEnumerable<Entry> GetAllBlogs();

        IEnumerable<Entry> GetAllBlogs(int userId);
        bool IsCurrentUser(string name, int userId);
        int GetUserId(string userName);
        bool AddEntry(int userId, string comment, DateTime date);
        bool CreateUser(string email);
        string GetUserName(int value);
    }
}