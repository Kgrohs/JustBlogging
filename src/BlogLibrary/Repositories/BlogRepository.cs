using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BlogLibrary.Contracts;
using BlogLibrary.Models;
using ServiceStack.Logging;
using ServiceStack.OrmLite.Dapper;

namespace BlogLibrary.Repositories
{
    public class BlogRepository : BaseRepository, IBlogRepository
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(BlogRepository));

        public IEnumerable<string> GetAllComments()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entry> GetAllBlogs()
        {
            try
            {
                var qryResults = DbConnection.Query<Entry>("SELECT * FROM [dbo].[Entry] WHERE UserId = 1 ORDER BY Date DESC").ToList();
                return qryResults;
            }
            catch (SqlException e)
            {
                _log.Error(e.Message, e);
                return new List<Entry>();
            }
        }

        public IEnumerable<Entry> GetAllBlogs(int userId)
        {
            var sqlString = "SELECT * FROM [dbo].[Entry] WHERE UserId = @userId ORDER BY Date DESC";
            try
            {
                var qryResults = DbConnection.Query<Entry>(
                   sqlString, new{ userId }
                   );
                return qryResults;
            }
            catch (SqlException e)
            {
                _log.Error(e.Message, e);
                return new List<Entry>();
            }
        }

        public bool IsCurrentUser(string userName, int userId)
        {
            var sqlString = "SELECT count(*) as COUNT FROM [dbo].[User] WHERE UserId = @userId AND UserName = @userName";
            try
            {
                var qryResults = DbConnection.Query<int>( sqlString, new { userId, userName = userName.ToLower() } ).FirstOrDefault();
                return qryResults > 0;
            }
            catch (SqlException e)
            {
                _log.Error(e.Message, e);
                return false;
            }
        }

        public bool AddEntry(int userId, string entry, DateTime date)
        {
            var sqlString = "INSERT INTO dbo.Entry(UserId,EntryText,Date)VALUES(@userId,@entry,@date)";
            try
            {
                DbConnection.Query<int>(sqlString, new { userId, entry, date });
                return true;
            }
            catch (SqlException e)
            {
                _log.Error(e.Message, e);
                return false;
            }
        }

        public int GetUserId(string userName)
        {
            var sqlString = "SELECT UserId FROM [dbo].[User] WHERE UserName = @name";
            try
            {
                var qryResults = DbConnection.Query<int>(sqlString, new { name = userName.ToLower() }).FirstOrDefault();
                return qryResults;
            }
            catch (SqlException e)
            {
                _log.Error(e.Message, e);
                return 0;
            }
        }

        public bool CreateUser(string userName)
        {
            var sqlString = "INSERT INTO [dbo].[User]([UserName])VALUES(@name)";
            try
            {
                var qryResults = DbConnection.Query<int>(sqlString, new { name = userName.ToLower() }).FirstOrDefault();
                return true;
            }
            catch (SqlException e)
            {
                _log.Error(e.Message, e);
                return false;
            }
        }

        public string GetUserName(int userId)
        {
            var sqlString = "SELECT UserName FROM [dbo].[User] WHERE UserId = @userId";
            try
            {
                var qryResults = DbConnection.Query<string>(sqlString, new { userId }).FirstOrDefault();
                return qryResults;
            }
            catch (SqlException e)
            {
                _log.Error(e.Message, e);
                return "Example";
            }
        }
    }
}
