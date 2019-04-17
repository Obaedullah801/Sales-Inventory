


$(document).ready(function () {
    $.ajax({
        url: "/Book/GetBookList",
        type: "POST",
        contentType: "Application/Json; charset=utf-8",
        data: JSON.stringify(),
        success: function (rData) {
            if (rData != undefined && rData != "") {

                $("#BookID").empty();
                $("#BookID").append('<option>---Select---</option>');

                $.each(rData, function (k, v) {
                    $("#BookID").append("<option value='" + v.BookID + "'>" + v.BookName + "</option>");
                    //$("#BookID").append(v.BookName);
                })

            }
        }



    })

});
