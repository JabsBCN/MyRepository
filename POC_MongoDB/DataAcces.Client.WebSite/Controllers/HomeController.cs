using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataAcces.Client.WebSite.Controllers
{
    public class HomeController : Controller
    {
        // GET: MenageArtistsInfo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowAllArtists()
        {
            
        }
    }
}