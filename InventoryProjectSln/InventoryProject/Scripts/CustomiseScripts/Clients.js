


$(document).ready(function () {
    $.ajax({
        url: "/Clients/GetClient",
        type: "POST",
        contentType: "Application/Json; charset=utf-8",
        data: JSON.stringify(),
        success: function (rData) {
            if (rData != undefined && rData != "") {

                $("#clientID").empty();
                $("#clientID").append('<option></option>');

                $.each(rData, function (k, v) {
                    $("#clientID").append("<option value='" + v.ClientID + "'>" + v.ClientName + "</option>");
                    //$("#BookID").append(v.BookName);
                })

            }
        }



    })

});
