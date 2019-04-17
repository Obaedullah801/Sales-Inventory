

$(document).ready(function () {
    $("#districtId").change(function () {
        $.get("/Districts/GetClientList", { DistrictID: $("#districtId").val() }, function (data) {
            $("#clientID").empty();
            $.each(data, function (index, row) {
                $("#clientID").append("<option value='" + row.ClientID + "'>" + row.ClientName + "</option>")
            })
        });
    })
});