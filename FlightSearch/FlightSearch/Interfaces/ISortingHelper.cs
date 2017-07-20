using System.Collections.Generic;
using FlightSearch.Models;

namespace FlightSearch.Helpers
{
    public interface ISortingHelper
    {
        List<Flight> FilterFlightsByAirportPair(string departureAirport, string arrivalAirport, List<Flight> flights);
        List<Flight> SortFlightsByMainCabinPriceLowToHigh(List<Flight> flights);
        List<Flight> SortFlightsByMainCabinPriceHighToLow(List<Flight> flights);
        List<Flight> SortFlightsByFirstClassPriceLowToHigh(List<Flight> flights);
        List<Flight> SortFlightsByFirstClassPriceHighToLow(List<Flight> flights);
        List<Flight> SortFlightsByDepartureTimeEarlyToLate(List<Flight> flights);
        List<Flight> SortFlightsByDepartureTimeLateToEarly(List<Flight> flights);
    }
}