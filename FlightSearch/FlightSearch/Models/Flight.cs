using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CsvHelper.Configuration;

namespace FlightSearch.Models
{
    public class Flight
    {
        public string DepartureAirportCode { get; set; }
        public string ArrivalAirportCode { get; set; }
        public int FlightNumber { get; set; }
        public DateTime ScheduledDepartureTime { get; set; }
        public DateTime ScheduledArrivalTime { get; set; }
        public double MainCabinPrice { get; set; }
        public double FirstClassPrice { get; set; }

        public Flight()
        {
            
        }
    }

    public sealed class FlightMap: CsvClassMap<Flight>
    {
        public FlightMap()
        {
            Map(m => m.DepartureAirportCode).Name("From");
            Map(m => m.ArrivalAirportCode).Name("To");
            Map(m => m.FlightNumber).Name("FlightNumber");
            Map(m => m.ScheduledDepartureTime).Name("Departs");
            Map(m => m.ScheduledArrivalTime).Name("Arrives");
            Map(m => m.MainCabinPrice).Name("MainCabinPrice");
            Map(m => m.FirstClassPrice).Name("FirstClassPrice");
        }
    }
}