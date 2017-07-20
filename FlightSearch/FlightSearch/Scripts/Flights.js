function getFilteredFlights() {
    console.log("entered get filtered flights function")
    jQuery.ajax({
        url: requestUrl,
        type: 'POST',
        data: { departureAirportCode: document.getElementById("ddlDepartureAirports").value, arrivalAirportCode: document.getElementById("ddlArrivalAirports").value, sortBy: document.getElementById("sortingDropdown").value },
        async: false,
        success: function(response) {
            if (response != null && response.success) {
                if (response.flights.length < 1) {
                    // show message here
                    $("#errorMessage").html("<h2>Select valid airport parameters to view flights.</h2>");
                    $("#displayedFlights").html("");
                    return;
                }

                // populate table with flight data here
                var flights = response.flights;
                var flightTableData = '';
                flightTableData += '<tr>';
                flightTableData += '<td>Flight Number</td>';
                flightTableData += '<td>Departure Airport</td>';
                flightTableData += '<td>Arrival Airport</td>';
                flightTableData += '<td>Scheduled Departure Time</td>';
                flightTableData += '<td>Scheduled Arrival Time</td>';
                flightTableData += '<td>Main Cabin Price</td>';
                flightTableData += '<td>First Class Price</td>';
                flightTableData += '</tr>';

                for (var i = 0; i < flights.length; i++) {
                    flightTableData += '<tr>';
                    flightTableData += '<td>' + flights[i].FlightNumber + '</td>';
                    flightTableData += '<td>' + flights[i].DepartureAirportCode + '</td>';
                    flightTableData += '<td>' + flights[i].ArrivalAirportCode + '</td>';
                    flightTableData += '<td>' + flights[i].ScheduledDepartureTime + '</td>';
                    flightTableData += '<td>' + flights[i].ScheduledArrivalTime + '</td>';
                    flightTableData += '<td>$' + flights[i].MainCabinPrice + '</td>';
                    flightTableData += '<td>$' + flights[i].FirstClassPrice + '</td>';
                    flightTableData += '</tr>';
                }

                $("#errorMessage").html("");
                $("#displayedFlights").html(flightTableData);
            }
        },
        error: function(data) {
            $("#errorMessage").html("<h2>Error retrieving available flights.</h2>");
        }
    });
}

getFilteredFlights();