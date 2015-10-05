using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataAccess.BackEnd
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Creating ArtistBL
            var artistsBL = new ArtistsBL();

            var artistId = "3";

            var artistById = artistsBL.GetById(artistId);

            System.Console.WriteLine("--------------------------------");
            System.Console.WriteLine("GetById:");
            System.Console.WriteLine(artistById.name + ' ' + artistById.style + ' ' + artistById.year);

            var filterParam = new QueryInfo("name", "Black Sabbath", "$eq");

            IList<QueryInfo> filterParams = new List<QueryInfo>();
            filterParams.Add(filterParam);

            var filteredArtists = artistsBL.GetFiltered(filterParams);

            System.Console.WriteLine("--------------------------------");
            System.Console.WriteLine("GetFiltered:");
            foreach (var artist in filteredArtists)
            {
                System.Console.WriteLine(artist.name + ' ' + artist.style + ' ' + artist.year);
            }

            var allArtists = artistsBL.GetAll();

            System.Console.WriteLine("--------------------------------");
            System.Console.WriteLine("GetAll:");
            foreach (var artist in allArtists)
            {
                System.Console.WriteLine(artist.name + ' ' + artist.style + ' ' + artist.year);
            }
            System.Console.ReadLine();
        }




        #region Privete Methods

        private bool printArtistData(Artists artist)
        {

            return true;
        }

        #endregion
    }
}
