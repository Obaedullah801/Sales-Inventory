

$(document).ready(function () {
    $("#BookGroupID").change(function () {
        $.get("/BookGroup/GetBookList", { BookGroupID: $("#BookGroupID").val() }, function (data) {
            $("#BookID").empty();
            $.each(data, function (index, row) {
                $("#BookID").append("<option value='" + row.BookID + "'>" + row.BookName + "</option>")
            })
        });
    })
});


//$('.form-control search-select').on("keypress", function (e) {
//    if (e.keyCode == 13) {
//        $("#BookID").click();
//        $('#BookName').focus();
//        e.preventDefault();
//    }
//});
//$('.form-control search-select').on("keypress", function (event) {
//    $("#BookID").click();
//    $('#BookName').focus();
//    event.preventDefault();
//});

//$('.form-control search-select').on("focusin", function (event) {
//    $('#BookID').select2('open');
//    event.preventDefault();
//});