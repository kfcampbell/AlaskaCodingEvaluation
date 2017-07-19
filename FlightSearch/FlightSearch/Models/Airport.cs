using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CsvHelper.Configuration;

namespace FlightSearch.Models
{
    public class Airport
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public Airport()
        {
            
        }
    }

    public sealed class AirportMap : CsvClassMap<Airport>
    {
        public AirportMap()
        {
            Map(m => m.Code).Name("Code");
            Map(m => m.Name).Name("Name");
        }
    }
}