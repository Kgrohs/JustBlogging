using System.Collections.Generic;
using System.Configuration;
using BlogLibrary;
using BlogLibrary.Contracts;
using BlogLibrary.Models;
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

        public IEnumerable<Blog> GetAllBlogs()
        {
            var blogs = BlogRepo.GetAllBlogs();
            return blogs;
        }
    }
}
