using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlightSearch.Models;

namespace FlightSearch.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<SelectListItem> Airports;
        public List<Flight> Flights;
        public Airport SelectedDepartureAirport;
        public Airport SelectedArrivalAirport;
    }
}