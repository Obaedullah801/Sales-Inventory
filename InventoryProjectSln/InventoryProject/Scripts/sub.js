
//Add Multiple Order.
$("#addToList").click(function (e) {
    e.preventDefault();

    if ($.trim($("#BookID").val()) == "" || $.trim($("#BookGroupID").val()) == "" || $.trim($("#price").val()) == "" || $.trim($("#quantity").val()) == "") return;
    var BookName = $("#BookID option:selected").text();
    var BookID = $("#BookID").val();
    var MainBookName = $("#BookGroupID option:selected").text();
    var BookGroupID = $("#BookGroupID").val(),

        price = $("#price").val();
        quantity = $("#quantity").val();
        commission = $("#commission").val();
        detailsTableBody = $("#detailsTable tbody");

        var percent = (parseFloat(price) * parseInt(quantity) * parseFloat(commission)) / 100;
        var percentLess = ((parseFloat(price) * parseInt(quantity)) - parseInt(percent));
        var productItem = '<tr><td>' + BookID + '</td><td>' + BookName + '</td><td>' + BookGroupID + '</td><td>' + MainBookName + '</td><td>' + price + '</td><td>' + quantity + '</td><td>' + commission + '</td><td class="subTotal">' + (parseFloat(price) * parseInt(quantity)) + '</td><td><a data-itemId="0" href="#" class="deleteItem">Edit</a></td><td><a data-itemId="0" href="#" class="deleteItem">Remove</a></td></tr>';
    detailsTableBody.append(productItem);

    //iterate through each td based on class and add the values
    var grandTotal = 0;
    var result = 0;
    var sum = 0;
    $('.subTotal').each(function () {
        //add only if the value is number for grandTotal
        var value = $(this).text(); //alert(value);
        sum += parseFloat(value);
    });
    $('#grandTotal').html(sum);
    $("#netAmount").val(sum.toFixed(2));

    // commission less = subTotal /OK
    $("#commission2").on("keyup", function () {
        var val = +this.value || 0;
        var result = $("#grandTotal").text() - $("#grandTotal").text() * val / 100
        $("#subTotal").val(result.toFixed(2));
        $("#hiddenSubtotal").val(result.toFixed(2));
        $("#netAmount").val(result.toFixed(2));

        var result2 = $("#grandTotal").text() * val / 100
        $("#commissionTotal").val(result2.toFixed(2));
        
        
    });
    //// commission Total 
    //$("#commission2").on("keyup", function () {
    //    var val = +this.value || 0;
    //    var result =  $("#grandTotal").text() * val / 100
    //    $("#commissionTotal").val(result.toFixed(2));

    //});
    // less from GrandTotal for subTotal//Ok
    $("#less").on("keyup", function () {
        var val = +this.value || 0;
        var result = $("#hiddenSubtotal").val() - val;
        // after less
        $("#hiddenNetAmount").val(result.toFixed(2));
        $("#netAmount").val(result.toFixed(2));
        
    });
       
    // less Return GrandTotal for subTotal//OK
    $("#returnLess").on("keyup", function () {
        
        var val = this.value || 0;
        var result = $("#hiddenNetAmount").val() - val;
        // after less
        $("#netAmount").val(result.toFixed());
    });
    
    clearItem();
});

//After Add A New Order In The List, Clear Clean The Form For Add More Order.
function clearItem() {
    $("#BookID").val('');
    $("#price").val('');
    $("#quantity").val('');
    //$("#commission").val('');
   // $("#BookGroupID").val('');

}