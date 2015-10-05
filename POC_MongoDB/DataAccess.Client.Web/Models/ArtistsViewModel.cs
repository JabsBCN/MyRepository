using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Client.Web.Models
{
    public class ArtistsViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }
        public string Year { get; set; }
    }
}