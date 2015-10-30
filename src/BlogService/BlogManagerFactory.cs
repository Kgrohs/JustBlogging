using System;
using System.Collections.Generic;
using System.Configuration;
using BlogLibrary;
using BlogLibrary.Contracts;
using BlogLibrary.Models;
using BlogLibrary.Repositories;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;

namespace BlogService
{
    public static class BlogManagerFactory
    {
        public static IBlogManager CreateManager(IBlogRepository repository = null,
            IDbConnectionFactory connectionFactory = null)
        {
            if (repository == null)
                repository = new BlogRepository();

            if (connectionFactory == null && repository.DbFactory == null)
            {
                if (ConfigurationManager.ConnectionStrings["BlogDB"] == null)
                {
                    connectionFactory =
                        new OrmLiteConnectionFactory(
                            ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                            SqlServerOrmLiteDialectProvider.Instance);
                    repository.DbFactory = connectionFactory;
                }
                else
                {
                    connectionFactory =
                        new OrmLiteConnectionFactory(
                            ConfigurationManager.ConnectionStrings["BlogDB"].ConnectionString,
                            SqlServerOrmLiteDialectProvider.Instance);

                    repository.DbFactory = connectionFactory;
                }
            }

            return new BlogManager
            {
                BlogRepo = repository
            };
        }
    }

    public class BlogManager : IBlogManager
    {
        public IBlogRepository BlogRepo { get; set; }

        public IEnumerable<string> GetAllComments()
        {
            var logs = BlogRepo.GetAllComments();
            return logs;
        }

        public IEnumerable<Entry> GetAllBlogs()
        {
            var blogs = BlogRepo.GetAllBlogs();
            return blogs;
        }

        public IEnumerable<Entry> GetAllBlogs(int userId)
        {
            var blogs = BlogRepo.GetAllBlogs(userId);
            return blogs;
        }

        public bool IsCurrentUser(string name, int userId)
        {
            var blogs = BlogRepo.IsCurrentUser(name, userId);
            return blogs;
        }

        public int GetUserId(string userName)
        {
            var blogs = BlogRepo.GetUserId(userName);
            return blogs;
        }

        public bool AddEntry(int userId, string comment, DateTime date)
        {
            var blogs = BlogRepo.AddEntry(userId, comment, date);
            return blogs;
        }

        public bool CreateUser(string email)
        {
            var blogs = BlogRepo.CreateUser(email);
            return blogs;
        }

        public string GetUserName(int userId)
        {
            var blogs = BlogRepo.GetUserName(userId);
            return blogs;
        }
    }
}
