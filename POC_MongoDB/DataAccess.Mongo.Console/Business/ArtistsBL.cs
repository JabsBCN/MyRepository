using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.BackEnd.Business;
using DataAccess.BackEnd.Repository;
using MongoDB.Driver;
using MongoDB.Bson;

namespace DataAccess.BackEnd
{
    public class ArtistsBL : IArtistsBL
    {
        private readonly Repository<Artists> repository;

        private readonly ArtistsMappers mapper;

        public ArtistsBL()
        {
            // Conecting with DB
            var mongoConnection = new DBConnection();

            mongoConnection.OpenConnection();

            IMongoDatabase mongoDataBase = mongoConnection.GetDataBase("test");

            // Creating Repository
            this.repository = new Repository<Artists>(mongoDataBase, "Artists");

            this.mapper = new ArtistsMappers();
        }

        public Artists GetById(string id)
        {
            var result = repository.GetById(id);

            var artistsDocument = result.Result.ToList<BsonDocument>().First();

            return mapper.Parse(artistsDocument);
        }

        public IList<Artists> GetAll()
        {
            IList<Artists> artistList = new List<Artists>();

            var result = repository.GetAll();

            var artistsDocumentList = result.Result.ToList<BsonDocument>();

            foreach (var artistsDocument in artistsDocumentList)
            {
               artistList.Add( mapper.Parse(artistsDocument));
            }
            return artistList;
        }

        public IList<Artists> GetFiltered(IList<QueryInfo> query)
        {
            IList<Artists> artistList = new List<Artists>();

            var result = repository.GetFiltered(query);

            var artistsDocumentList = result.Result.ToList<BsonDocument>();

            foreach (var artistsDocument in artistsDocumentList)
            {
                artistList.Add(mapper.Parse(artistsDocument));
            }
            return artistList;
        }
    }
}
