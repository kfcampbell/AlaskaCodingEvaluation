using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightSearch.Enums
{
    public enum SortBy
    {
        MainCabinLowToHigh,
        MainCabinHighToLow,
        FirstClassLowToHigh,
        FirstClassHighToLow,
        DepartureEarlyToLate,
        DepartureLateToEarly
    }
}