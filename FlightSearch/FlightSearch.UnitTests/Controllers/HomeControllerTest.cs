using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlightSearch;
using FlightSearch.Controllers;
using FlightSearch.Helpers;
using FlightSearch.Models;
using FlightSearch.ViewModels;
using Moq;
using Shouldly;
using NUnit;
using NUnit.Framework;

namespace FlightSearch.UnitTests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index_ValidParameters_ReturnsNotNull()
        {
            // Arrange
            var csvMock = new Mock<ICsvLoader>();
            csvMock.Setup(a => a.GetAirports()).Returns(new List<Airport>());
            var filterMock = new Mock<IFilterHelper>();
            HomeController controller = new HomeController(filterMock.Object, csvMock.Object);

            // Act
            ViewResult result = controller.Index(new HomeViewModel()) as ViewResult;

            // Assert
            result.ShouldNotBeNull();
        }
    }
}
