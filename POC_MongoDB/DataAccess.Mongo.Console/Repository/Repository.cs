using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.BackEnd.Queries;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataAccess.BackEnd.Repository
{
    public class Repository<T>
    {
        private IMongoDatabase mongoDatabase;
        private string document;

        public Repository(IMongoDatabase mongoDatabase, string document)
        {
            this.mongoDatabase = mongoDatabase;
            this.document = document;
        }

        public Task<IEnumerable<BsonDocument>> GetById(string id)
        {
            var filterParam = new QueryInfo("_id", id, "$eq");
            IList<QueryInfo> filterParams = new List<QueryInfo>() { filterParam };

            var filterQuery = new MongoQuery().CreateFilterQuery(filterParams);
            var mongoQuery = this.MongoQuery(filterQuery);
            Task.WaitAll(mongoQuery);
            return mongoQuery;
        }

        public Task<IEnumerable<BsonDocument>> GetFiltered(IList<QueryInfo> filterParams)
        {
            var filterQuery = new MongoQuery().CreateFilterQuery(filterParams);
            var mongoQuery = this.MongoQuery(filterQuery);
            Task.WaitAll(mongoQuery);
            return mongoQuery;
        }

        public Task<IEnumerable<BsonDocument>> GetAll()
        {
            var filterParam = new QueryInfo("_id", "0", "$ne");
            IList<QueryInfo> filterParams = new List<QueryInfo>() { filterParam };

            var filterQuery = new MongoQuery().CreateFilterQuery(filterParams);
            var mongoQuery = this.MongoQuery(filterQuery);
            
            return mongoQuery;
        }

        private async Task<IEnumerable<BsonDocument>> MongoQuery(BsonDocument filter)
        {
            IEnumerable<BsonDocument> batch = new List<BsonDocument>();
            var collection = this.mongoDatabase.GetCollection<BsonDocument>(this.document);

            using (var cursor = await collection.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    batch = cursor.Current;
                    return batch;
                }
            }

            return batch;
        }

        public bool Create(T recurse)
        {
            return false;
        }
    }
}
