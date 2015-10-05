using MongoDB.Bson;

namespace DataAccess.BackEnd
{
    public class ArtistsMappers
    {
        public Artists Parse(BsonDocument resource)
        {
            return new Artists(resource["_id"].AsString,
                resource["name"].AsString,
                resource["style"].AsString,
                resource["year"].AsString);
        }

        public BsonDocument Parse(Artists resource)
        {
            return new BsonDocument()
            {
                { "_id", resource._id },
                { "name", resource.name },
                { "style", resource.style },
                { "year", resource.year }
            };
        }
    }
}
