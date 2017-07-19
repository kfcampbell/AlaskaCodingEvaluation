using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightSearch.Models
{
    public class Airport
    {
        public string Code;
        public string Name;

        public Airport(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}