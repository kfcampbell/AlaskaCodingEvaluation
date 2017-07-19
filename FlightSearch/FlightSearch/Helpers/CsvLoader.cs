using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Razor.Text;
using CsvHelper;
using FlightSearch.Models;

namespace FlightSearch.Helpers
{
    public class CsvLoader
    {
        private CsvReader _csvReader;
        private TextReader _textReader;
        private readonly string _airportsPath = ConfigurationManager.AppSettings["AirportsFilePath"];
        private string _flightsPath = ConfigurationManager.AppSettings["FlightsFilePath"];

        public CsvLoader()
        {
        }

        public List<Airport> GetAirports()
        {
            using (CsvReader csvReader = new CsvReader(File.OpenText(_airportsPath)))
            {
                csvReader.Configuration.RegisterClassMap<AirportMap>();
                return csvReader.GetRecords<Airport>().ToList();
            }
        }

        public List<Flight> GetFlights()
        {
            using (CsvReader csvReader = new CsvReader(File.OpenText(_flightsPath)))
            {
                csvReader.Configuration.RegisterClassMap<FlightMap>();
                return csvReader.GetRecords<Flight>().ToList();
            }
        }
    }
}