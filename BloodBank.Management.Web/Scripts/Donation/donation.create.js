$(document).ready(function () {
    GetBloodGroupInfo();
    $("#DonorId").change(function () {
        GetBloodGroupInfo();
    });

    $("#Quantity").bind('keyup mouseup', function () {
    });

});

function GetBloodGroupInfo() {
   
    $.ajax({
        type: "GET",
        url: '/Donations/GetBloodGroupInfo?donorId=' + $("#DonorId").val(),
        success: function (res) {
            debugger;
            $("#QuantityInfo").html('<div class="alert alert-primary" role="alert">'
                + '<b>' + res.donor + '</b> is associated to <i>' + res.bloodGroup + '</i> blood group. Currently available quantity is <b>' + res.count + '</b>' +
                '<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>'
                +'</div>');
        },
        error: function() {
            alert("Error while inserting data");
        }
    });
}
