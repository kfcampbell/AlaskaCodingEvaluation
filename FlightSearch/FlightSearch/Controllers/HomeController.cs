using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlightSearch.Enums;
using FlightSearch.Helpers;
using FlightSearch.Models;
using FlightSearch.ViewModels;

namespace FlightSearch.Controllers
{
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
            var sortedFlights = filteredFlights;

            switch (sortingOrder)
            {
                case SortBy.DepartureEarlyToLate:
                    sortedFlights = SortingHelper.SortFlightsByDepartureTimeEarlyToLate(filteredFlights);
                    break;
                case SortBy.DepartureLateToEarly:
                    sortedFlights = SortingHelper.SortFlightsByDepartureTimeLateToEarly(filteredFlights);
                    break;
                case SortBy.MainCabinLowToHigh:
                    sortedFlights = SortingHelper.SortFlightsByMainCabinPriceLowToHigh(filteredFlights);
                    break;
                case SortBy.MainCabinHighToLow:
                    sortedFlights = SortingHelper.SortFlightsByMainCabinPriceHighToLow(filteredFlights);
                    break;
                case SortBy.FirstClassLowToHigh:
                    sortedFlights = SortingHelper.SortFlightsByFirstClassPriceLowToHigh(filteredFlights);
                    break;
                case SortBy.FirstClassHighToLow:
                    sortedFlights = SortingHelper.SortFlightsByFirstClassPriceHighToLow(filteredFlights);
                    break;
            }

            // TODO:
            // then populate table based on results of json
            // show message if flights are blank

            return Json(new { success = true, flights = sortedFlights });
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