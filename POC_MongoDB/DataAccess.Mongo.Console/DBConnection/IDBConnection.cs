using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.BackEnd
{
    interface IDBConnection<T>
    {
        bool OpenConnection();
        bool CloseConnection();
        T GetDataBase(string dbName);
    }
}
