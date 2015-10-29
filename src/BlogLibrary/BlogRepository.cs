using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogLibrary
{
    public class BlogRepository //: BaseRepository, IBlogRepository
    {
        //ILog log = LogManager.GetLogger(typeof(BlogRepository));

        //public IEnumerable<Blog> GetAllLogs()
        //{
        //    try
        //    {
        //        var qryResults = DbConnection.Query<Blog>("SELECT TOP 50 * FROM Log ORDER BY Date DESC").ToList();
        //        return qryResults;
        //    }
        //    catch (SqlException e)
        //    {
        //        return new List<Blog>();
        //    }
        //}

    }
}
