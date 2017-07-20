using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlightSearch.Enums;
using FlightSearch.Models;

namespace FlightSearch.Helpers
{
    public class FilterHelper : IFilterHelper
    {
        private readonly ISortingHelper _sortingHelper;
        public FilterHelper(ISortingHelper sortingHelper)
        {
            _sortingHelper = sortingHelper;
        }

        public List<Flight> GetFilteredFlights(string departureAirportCode, string arrivalAirportCode, int sortBy, List<Flight> initialFlights)
        {
            SortBy sortingOrder = (SortBy) sortBy;
            var filteredFlights = _sortingHelper.FilterFlightsByAirportPair(departureAirportCode, arrivalAirportCode,
                initialFlights);
            var sortedFlights = filteredFlights;

            switch (sortingOrder)
            {
                case SortBy.DepartureEarlyToLate:
                    sortedFlights = _sortingHelper.SortFlightsByDepartureTimeEarlyToLate(filteredFlights);
                    break;
                case SortBy.DepartureLateToEarly:
                    sortedFlights = _sortingHelper.SortFlightsByDepartureTimeLateToEarly(filteredFlights);
                    break;
                case SortBy.MainCabinLowToHigh:
                    sortedFlights = _sortingHelper.SortFlightsByMainCabinPriceLowToHigh(filteredFlights);
                    break;
                case SortBy.MainCabinHighToLow:
                    sortedFlights = _sortingHelper.SortFlightsByMainCabinPriceHighToLow(filteredFlights);
                    break;
                case SortBy.FirstClassLowToHigh:
                    sortedFlights = _sortingHelper.SortFlightsByFirstClassPriceLowToHigh(filteredFlights);
                    break;
                case SortBy.FirstClassHighToLow:
                    sortedFlights =_sortingHelper.SortFlightsByFirstClassPriceHighToLow(filteredFlights);
                    break;
            }

            return sortedFlights;
        }
    }
}