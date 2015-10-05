using System.Collections.Generic;
using MongoDB.Bson;

namespace DataAccess.BackEnd.Queries
{
    public class MongoQuery 
    {
        public BsonDocument CreateFilterQuery(IList<QueryInfo> filterParams)
        {
            BsonDocument filterQuery = new BsonDocument();

            foreach (var item in filterParams)
            {
                BsonDocument newFilter = new BsonDocument(item.Key, new BsonDocument(item.QueryOperator, item.Value));
                filterQuery.AddRange(newFilter);
            }
            return filterQuery;
        }
    }
}
