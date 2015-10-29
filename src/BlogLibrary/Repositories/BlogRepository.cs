using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogLibrary.Contracts;
using BlogLibrary.Models;
using BlogLibrary.Repositories;
using ServiceStack.Logging;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Dapper;


namespace BlogLibrary
{
    public class BlogRepository : BaseRepository, IBlogRepository
    {
        ILog log = LogManager.GetLogger(typeof(BlogRepository));

        public IEnumerable<string> GetAllComments()
        {
            try
            {
                var qryResults = DbConnection.Query<string>("SELECT TOP 50 Comment FROM Blog ORDER BY Id DESC").ToList();
                return qryResults;
            }
            catch (SqlException e)
            {
                log.Error(e.Message, e);
                return new List<string>();
            }
        }

        public IEnumerable<Blog> GetAllBlogs()
        {
            try
            {
                var qryResults = DbConnection.Query<Blog>("SELECT TOP 50 * FROM Blog ORDER BY Id DESC").ToList();
                return qryResults;
            }
            catch (SqlException e)
            {
                log.Error(e.Message, e);
                return new List<Blog>();
            }
        }
    }
}
