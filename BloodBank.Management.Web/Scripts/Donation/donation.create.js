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
        success: function(res) {
            $("#QuantityInfo").html('<div class="alert alert-primary" role="alert">'
                + res +
                '<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>'
                +'</div>');
        },
        error: function() {
            alert("Error while inserting data");
        }
    });
}
