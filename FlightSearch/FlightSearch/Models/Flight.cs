using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightSearch.Models
{
    public class Flight
    {
        public string DepartureAirportCode;
        public string ArrivalAirportCode;
        public int FlightNumber;
        public DateTime ScheduledDepartureTime;
        public DateTime ScheduledArrivalTime;
        public Double MainCabinPrice;
        public Double FirstClassPrice;
    }
}