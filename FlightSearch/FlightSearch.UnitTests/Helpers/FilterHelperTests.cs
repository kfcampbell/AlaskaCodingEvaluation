using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSearch.Enums;
using FlightSearch.Helpers;
using FlightSearch.Models;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace FlightSearch.UnitTests.Helpers
{
    [TestFixture]
    public class FilterHelperTests
    {
        [Test]
        public void GetFilteredFlights_MainCabinHighToLow_ReturnsFilteredFlights()
        {
            // Arrange
            var firstFlight = new Flight
            {
                DepartureAirportCode = "SEA",
                ArrivalAirportCode = "PHX",
                MainCabinPrice = 0.0
            };
            var secondFlight = new Flight
            {
                DepartureAirportCode = "SEA",
                ArrivalAirportCode = "PHX",
                MainCabinPrice = 8.0
            };
            var initialFlights = new List<Flight> {firstFlight, secondFlight};
            var sortBy = SortBy.MainCabinHighToLow;

            var sortingMock = new Mock<ISortingHelper>();
            sortingMock.Setup(
                    f => f.FilterFlightsByAirportPair(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<Flight>>()))
                .Returns(initialFlights);
            sortingMock.Setup(f => f.SortFlightsByMainCabinPriceHighToLow(It.IsAny<List<Flight>>())).Returns(initialFlights);

            var filterHelper = new FilterHelper(sortingMock.Object);

            // Act
            var filteredFlights = filterHelper.GetFilteredFlights("SEA", "PHX", (int)sortBy, initialFlights);

            // Assert
            filteredFlights.ShouldBe(initialFlights);
        }
    }
}
