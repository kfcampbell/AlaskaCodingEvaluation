using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlightSearch.Enums;
using FlightSearch.Models;

namespace FlightSearch.Helpers
{
    public class FilterHelper
    {
        public FilterHelper()
        {

        }

        public List<Flight> GetFilteredFlights(string departureAirportCode, string arrivalAirportCode, int sortBy, List<Flight> initialFlights)
        {
            SortBy sortingOrder = (SortBy) sortBy;
            var filteredFlights = SortingHelper.FilterFlightsByAirportPair(departureAirportCode, arrivalAirportCode,
                initialFlights);
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

            return sortedFlights;
        }
    }
}