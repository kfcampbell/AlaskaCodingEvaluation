using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlightSearch.Models;

namespace FlightSearch.Helpers
{
    public class SortingHelper : ISortingHelper
    {
        public List<Flight> FilterFlightsByAirportPair(string departureAirport, string arrivalAirport, List<Flight> flights)
        {
            return
                flights.Where(f => f.DepartureAirportCode == departureAirport && f.ArrivalAirportCode == arrivalAirport)
                    .ToList();
        }

        public List<Flight> SortFlightsByMainCabinPriceLowToHigh(List<Flight> flights)
        {
            return flights.OrderBy(f => f.MainCabinPrice).ToList();
        }

        public List<Flight> SortFlightsByMainCabinPriceHighToLow(List<Flight> flights)
        {
            return flights.OrderByDescending(f => f.MainCabinPrice).ToList();
        }

        public List<Flight> SortFlightsByFirstClassPriceLowToHigh(List<Flight> flights)
        {
            return flights.OrderBy(f => f.FirstClassPrice).ToList();
        }

        public List<Flight> SortFlightsByFirstClassPriceHighToLow(List<Flight> flights)
        {
            return flights.OrderByDescending(f => f.FirstClassPrice).ToList();
        }

        public List<Flight> SortFlightsByDepartureTimeEarlyToLate(List<Flight> flights)
        {
            return flights.OrderBy(f => Convert.ToDateTime(f.ScheduledDepartureTime)).ToList();
        }

        public List<Flight> SortFlightsByDepartureTimeLateToEarly(List<Flight> flights)
        {
            return flights.OrderByDescending(f => Convert.ToDateTime(f.ScheduledDepartureTime)).ToList();
        }
    }
}