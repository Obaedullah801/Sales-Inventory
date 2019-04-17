


$(document).ready(function () {
    $.ajax({
        url: "/Districts/getDistrict",
        type: "POST",
        contentType: "Application/Json; charset=utf-8",
        data: JSON.stringify(),
        success: function (rData) {
            if (rData != undefined && rData != "") {

                $("#districtId").empty();
                $("#districtId").append('<option></option>');

                $.each(rData, function (k, v) {
                    $("#districtId").append("<option value='" + v.DistrictID + "'>" + v.DistrictName + "</option>");
                    //$("#BookID").append(v.BookName);
                })

            }
        }



    })


});
