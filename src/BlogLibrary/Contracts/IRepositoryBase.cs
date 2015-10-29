using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogLibrary.Contracts
{
    public interface IRepositoryBase
    {
        IDbConnection DbConnection { get; set; }
    }
}
