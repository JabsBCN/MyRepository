using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataAcces.Client.WebSite.Controllers
{
    public class ArtistsAPIController : ApiController
    {
        // GET: api/MenageArtistsInfoAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MenageArtistsInfoAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MenageArtistsInfoAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MenageArtistsInfoAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MenageArtistsInfoAPI/5
        public void Delete(int id)
        {
        }
    }
}
