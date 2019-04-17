$(function () {
    $("#loaderbody").addClass('hide');
    $(document).bind('ajaxStart', function () {
        $("#loaderbody").removeClass('hide');
    }).bind('ajaxStop', function () {
        $("#loaderbody").addClass('hide');
    });
});



function ShowImagePreview(imageUploader, previewImage) {
    if (imageUploader.files && imageUploader.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader.files[0]);
    }
}


// Sabbir vi
//$("#formData").click(function () {
//     //get field
//    var Name = $('#Name').val();

//    var Position = $('#Position').val();

//    var Office = $('#Office').val();

//    var Salary = $('#Salary').val();
//    var validate = '';

//     //validation
//    if (Name == '') {
//        validate = validate + 'Eoployee Name is required!';
//    }
//    if (Position == '') {
//        validate = validate + 'Position name is required !';
//    }
//    if (Office == '') {
//        validate = validate + 'Office name is required !';
//    }
//    if (Salary == '') {
//        validate = validate + 'Salary is required !';
//    }

//    if (validate == '') {
//        var dataString = {
//            Name: Name,
//            Position: Position,
//            Office: Office,
//            Salary: Salary,
//        };


//        $.ajax({
//            type: "POST",
//            url: '/Employee/AddOrEdit',
//            data: dataString,
//            dataType: "json",
//            cache: false, // refresh
//            success: function (result) {
//                $('#massage').html('Success !!');

//                console.log(result);


//            }, error: function (xhr, status, error) {
//                alert(error);
//            },
//        });
//    }
//    else {
//        alert(validate);
//    }
//})


function jQueryAjaxPost(form) {
    $.validator.unobtrusive.parse(form);
    if ($(form).valid()) {
        var ajaxConfig = {
            type: 'POST',
            url: form.action,
            //data: new FormData(form),
            success: function (response) {

                if (response.success) {
                    $("#firstTab").html(response.html);
                    refreshAddNewTab($(form).attr('data-restUrl'), true);
                    $.notify(response.message, "success");

                    if (typeof activatejQueryTable !== 'undefined' && $.isFunction(activatejQueryTable)) {
                        activatejQueryTable();

                    }
                }
                else {
                    $.notify(response.message, "Errors");

                }
            }
        }
        if ($(form).attr('enctype') == "multipart/form-data") {
            ajaxConfig["contentType"] = false;
            ajaxConfig["processData"] = false;
        }
        $.ajax(ajaxConfig);
    }
    return false;
}
function refreshAddNewTab(resetUrl, showViewTab) {
    $.ajax({
        type: "GET",
        url: resetUrl,
        success: function (response) {
            $("#secondTab").html(response);
            $('ul.nav.nav-tabs a:eq(1)').html('Add New');
            if (showViewTab)
                $('ul.nav.nav-tabs a:eq(0)').tab('show');
        }
    });
}
function Edit(url) {
    $.ajax({
        type: "GET",
        url: url,
        success: function (response) {
            $("#secondTab").html(response);
            $('ul.nav.nav-tabs a:eq(1)').html('Edit');
            $('ul.nav.nav-tabs a:eq(1)').tab('show');
        }
    });

}

function Delete(url) {
    if (confirm('Are you sure delete this record?') == true) {
        $.ajax({
            type: "POST",
            url: url,
            success: function (response) {
                if (response.success) {
                    $("#firstTab").html(response.html);
                    $.notify(response.message, "warn");
                    if (typeof activatejQueryTable !== 'undefined' && $.isFunction(activatejQueryTable)) {
                        activatejQueryTable();
                    }
                }
                else {
                    $.notify(response.message, "Error!");
                }

            }
        });
    }
}


function openForm() {
    document.getElementById("myForm").style.display = "block";
}

function closeForm() {
    document.getElementById("myForm").style.display = "none";
}