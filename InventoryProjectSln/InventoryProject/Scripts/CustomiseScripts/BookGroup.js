

$(document).ready(function () {
    $.ajax({
        url: "/BookGroup/GetBookGroupList",
        type: "POST",
        contentType: "Application/Json; charset=utf-8",
        data: JSON.stringify(),
        success: function (rData) {
            if (rData != undefined && rData != "") {

                $("#BookGroupID").empty();
                $("#BookGroupID").append('<option>---Select---</option>');

                $.each(rData, function (k, v) {
                    $("#BookGroupID").append("<option value='" + v.BookGroupID + "'>" + v.MainBookName + "</option>");
                    //$("#BookID").append(v.BookName);
                })

            }
        }



    })

});