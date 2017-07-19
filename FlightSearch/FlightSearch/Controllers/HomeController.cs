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
    enum SortBy
    {
        MainCabinLowToHigh,
        MainCabinHighToLow,
        FirstClassLowToHigh,
        FirstClassHighToLow,
        DepartureEarlyToLate,
        DepartureLateToEarly
    }
    public class HomeController : Controller
    {
        private readonly CsvLoader _csvHelper = new CsvLoader();

        public ActionResult Index(HomeViewModel homeViewModel)
        {
            var airports = _csvHelper.GetAirports();
            var flights = _csvHelper.GetFlights();

            // add a table to display filtered flights.
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

        public ActionResult GetFilteredFlights(string departureAirportCode, string arrivalAirportCode, int sortBy)
        {
            SortBy sortingOrder = (SortBy)sortBy;
            var initialFlights = _csvHelper.GetFlights();
            var filteredFlights = SortingHelper.FilterFlightsByAirportPair(departureAirportCode, arrivalAirportCode, initialFlights);

            // TODO:
            // move enum class to separate file/folder
            // add switch statement here for sorting
            // in view, add onchange to each dropdown (including sort order dropdown)
            // then populate table based on results of json

            return Json(new { success = true, flights = filteredFlights });
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