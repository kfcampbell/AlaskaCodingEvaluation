using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSearch.Helpers;
using FlightSearch.Models;
using NUnit.Framework;
using Shouldly;

namespace FlightSearch.UnitTests.Helpers
{
    [TestFixture]
    public class SortingHelperTests
    {
        [Test]
        public void FilterFlightsByAirportPair_MultipleAirportPairs_ReturnsFilteredFlights()
        {
            // Arrange
            var firstFlight = new Flight
            {
                DepartureAirportCode = "SEA",
                ArrivalAirportCode = "PHX"
            };
            var secondFlight = new Flight
            {
                DepartureAirportCode = "SEA",
                ArrivalAirportCode = "PHX"
            };
            var thirdFlight = new Flight
            {
                DepartureAirportCode = "PHX",
                ArrivalAirportCode = "LAX"
            };
            var initialFlights = new List<Flight> { firstFlight, secondFlight, thirdFlight };

            var sortingHelper = new SortingHelper();

            // Act
            var filteredFlights = sortingHelper.FilterFlightsByAirportPair("SEA", "PHX", initialFlights);

            // Assert
            filteredFlights.Count.ShouldBe(2);
            filteredFlights.ShouldNotContain(thirdFlight);
        }

    }
}
