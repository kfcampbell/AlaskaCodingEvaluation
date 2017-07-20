using System.Collections.Generic;
using FlightSearch.Models;

namespace FlightSearch.Helpers
{
    public interface ICsvLoader
    {
        List<Airport> GetAirports();
        List<Flight> GetFlights();
    }
}