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
        private readonly FilterHelper _filterHelper = new FilterHelper();

        public ActionResult Index(HomeViewModel homeViewModel)
        {
            var airports = _csvHelper.GetAirports();
            homeViewModel.Airports = GetSelectListItemsAirports(airports);
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
            var initialFlights = _csvHelper.GetFlights();
            var sortedFlights = _filterHelper.GetFilteredFlights(departureAirportCode, arrivalAirportCode, sortBy,
                initialFlights);

            return Json(new { success = true, flights = sortedFlights });
        }
    }
}