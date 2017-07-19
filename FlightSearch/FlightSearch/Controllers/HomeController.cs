using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlightSearch.Helpers;
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

            var filteredFlights = SortingHelper.FilterFlightsByAirportPair("SEA", "LAX", flights);
            var cheapFlights = SortingHelper.SortFlightsByMainCabinPriceLowToHigh(flights);
            var expensiveFlights = SortingHelper.SortFlightsByMainCabinPriceHighToLow(flights);
            var cheapFirstClassFlights = SortingHelper.SortFlightsByFirstClassPriceLowToHigh(flights);
            var expensiveFirstClassFlights = SortingHelper.SortFlightsByFirstClassPriceHighToLow(flights);

            var earlyFlights = SortingHelper.SortFlightsByDepartureTimeEarlyToLate(flights);
            var lateFlights = SortingHelper.SortFlightsByDepartureTimeLateToEarly(flights);
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