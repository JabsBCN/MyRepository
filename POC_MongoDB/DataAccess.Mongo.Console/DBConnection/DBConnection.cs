using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace DataAccess.BackEnd
{
    public class DBConnection : IDBConnection<IMongoDatabase>
    {
        private IMongoClient _client;

        public bool OpenConnection()
        {
            this._client = new MongoClient();
            return true;
        }

        public bool CloseConnection()
        {
            throw new NotImplementedException();
        }

        public IMongoDatabase GetDataBase(string dbName)
        {
            return this._client.GetDatabase(dbName);
        }
    }
}
