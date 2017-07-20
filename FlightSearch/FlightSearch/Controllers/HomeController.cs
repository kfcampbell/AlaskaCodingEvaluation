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
        private readonly ICsvLoader _csvLoader;
        private readonly IFilterHelper _filterHelper;

        public HomeController(IFilterHelper filterHelper, ICsvLoader csvLoader)
        {
            _filterHelper = filterHelper;
            _csvLoader = csvLoader;
        }

        public ActionResult Index(HomeViewModel homeViewModel)
        {
            var airports = _csvLoader.GetAirports();
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
            var initialFlights = _csvLoader.GetFlights();
            var sortedFlights = _filterHelper.GetFilteredFlights(departureAirportCode, arrivalAirportCode, sortBy,
                initialFlights);

            return Json(new { success = true, flights = sortedFlights });
        }
    }
}