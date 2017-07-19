function getFilteredFlights() {
    console.log("entered get filtered flights function")
    jQuery.ajax({
        url: requestUrl,
        type: 'POST',
        data: { departureAirportCode: document.getElementById("ddlDepartureAirports").value, arrivalAirportCode: document.getElementById("ddlArrivalAirports").value, sortBy: document.getElementById("sortingDropdown").value },
        async: false,
        success: function(response) {
            if (response != null && response.success) {
                console.log("Got flight data!");
                console.log(response);
                /*var availableSlots;
                availableSlots = '<option>Pick available time</option>';
                for (var i = 0; i < response.timeslots.length; i++) {
                    availableSlots += '<option>' + response.timeslots[i] + '</option>';
                }
                $("#ddlTimeSlots").html(availableSlots).selectpicker('refresh');    */
            } else {
                /*var availableSlots;
                availableSlots = '<option>No available times</option>';
                $("#ddlTimeSlots").html(availableSlots).selectpicker('refresh');    */
            }
        },
        error: function(data) {
            console.log("Failed to get flight data.");
            /*var availableSlots = '<option>No available times</option>';
            $("#ddlTimeSlots").html(availableSlots).selectpicker('refresh');*/
        }
    });
}

getFilteredFlights();