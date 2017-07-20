using System.Collections.Generic;
using FlightSearch.Models;

namespace FlightSearch.Helpers
{
    public interface IFilterHelper
    {
        List<Flight> GetFilteredFlights(string departureAirportCode, string arrivalAirportCode, int sortBy, List<Flight> initialFlights);
    }
}