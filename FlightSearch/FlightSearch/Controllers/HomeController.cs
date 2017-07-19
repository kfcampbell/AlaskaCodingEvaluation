using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlightSearch.Helpers;
using FlightSearch.Models;
using FlightSearch.ViewModels;

namespace FlightSearch.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(HomeViewModel homeViewModel)
        {
            // use csv loader to get airports and flights.
            // put these in a viewmodel
            // return View(viewmodel)
            // then in view, can use viewmodel.airports and viewmodel.flights to populate elements.
            Helpers.CsvLoader csvHelper = new Helpers.CsvLoader();
            var airports = csvHelper.GetAirports();
            var flights = csvHelper.GetFlights();

            /*var filteredFlights = SortingHelper.FilterFlightsByAirportPair("SEA", "LAX", flights);
            var cheapFlights = SortingHelper.SortFlightsByMainCabinPriceLowToHigh(flights);
            var expensiveFlights = SortingHelper.SortFlightsByMainCabinPriceHighToLow(flights);
            var cheapFirstClassFlights = SortingHelper.SortFlightsByFirstClassPriceLowToHigh(flights);
            var expensiveFirstClassFlights = SortingHelper.SortFlightsByFirstClassPriceHighToLow(flights);

            var earlyFlights = SortingHelper.SortFlightsByDepartureTimeEarlyToLate(flights);
            var lateFlights = SortingHelper.SortFlightsByDepartureTimeLateToEarly(flights);*/

            homeViewModel.Airports = GetSelectListItemsAirports(airports);
            homeViewModel.Flights = flights;
            return View(homeViewModel);
        }
        private IEnumerable<SelectListItem> GetSelectListItemsAirports(IEnumerable<Airport> airports)
        {
            return airports.Select(element => new SelectListItem
            {
                Value = element.Code,
                Text = element.Name
            }).ToList();
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