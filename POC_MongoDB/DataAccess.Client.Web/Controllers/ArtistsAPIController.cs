using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using DataAccess.BackEnd;

namespace DataAccess.Client.Web.Controllers
{
    public class ArtistsAPIController : ApiController
    {
        private IList<Artists> _artistsData;

        // GET: api/ArtistsAPI
        public async Task<IHttpActionResult> Get()
        {
            var result = await Task.Factory.StartNew(() => new ArtistsBL().GetAll());

            return Ok(result);
        }

        // GET: api/ArtistsAPI/5
        public string Get(int id)
        {
            _artistsData = new List<Artists>();

            var myThreat = new Thread(new ThreadStart(GetAllArtistsData));

            myThreat.Start();

            return _artistsData.ToString();
        }

        public async Task<IHttpActionResult> GetById(int id)
        {
            var result = await Task.FromResult(new ArtistsBL().GetAll());

            return Ok(result);
        }

        private void GetAllArtistsData()
        {
            this._artistsData = new ArtistsBL().GetAll();

        }

        // POST: api/ArtistsAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ArtistsAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ArtistsAPI/5
        public void Delete(int id)
        {
        }

        public IList<Artists> ArtistsView
        {
            get
            {
                return _artistsData;
            }
            set
            {
                _artistsData = value;
            }
        }
    }
}
