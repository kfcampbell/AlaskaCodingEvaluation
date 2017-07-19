using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsvHelper = FlightSearch.Helpers.CsvLoader;

namespace FlightSearch.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Helpers.CsvLoader csvHelper = new Helpers.CsvLoader();
            var airports = csvHelper.GetAirports();
            var flights = csvHelper.GetFlights();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}