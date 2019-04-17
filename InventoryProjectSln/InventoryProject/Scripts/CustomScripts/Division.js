

$(document).ready(function () {



    $("#DivisionPartialCreate").click(function () {

        $(".custom_loader").show();
        $.ajax({
            type: "GET",
            url: "../../Division/GetDivisionPartialCreate",
            contentType: "application/JSON; charset=utf-8",
            data: JSON.stringify(),
            success: function (Data) {

                $("#pView").html(Data);
                $(".custom_loader").hide();

            }

        });


    });

    $(document).on("submit", "#DivisionCreateForm", function (e) {

        e.preventDefault();
        $(".custom_loader").show();

        $.ajax({
            type: "POST",
            url: "../../Division/Create",
            data: $(this).serialize(),
            datatype: "html",
            success: function (data) {
                if (data) {
                    $('.msgSaved').html(data);
                    $(".custom_loader").fadeOut();
                    $('#DivisionCreateForm').trigger("reset");
                    getDivisionLastEight(); // Load Data after Saving
                    setTimeout(function () {
                        $('.msgSaved').html("");
                        $('#DivisionCreateForm').trigger("reset");
                        //  console.log(data);
                    }, 5000);

                } else {
                    $(".custom_loader").fadeOut();
                    $('.msgNotSaved').html(data);
                    $('#DivisionCreateForm').trigger("reset");
                    setTimeout(function () { // this method for msg hide after 5 second
                        $('.msgNotSaved').html("");
                        // console.log(data);
                    }, 5000);

                }

            }
        });


    });

    function getDivisionLastFive() {
        $.ajax({
            type: "POST",
            url: "../../Division/GetDivisionLastFive",
            contentType: "application/JSON; charset=utf-8",
            data: JSON.stringify(),
            success: function (Data) {

                $("#DivisionDetails").html(Data);
                $(".custom_loader").hide();

            }

        });
    }

    getDivisionLastFive();

});

