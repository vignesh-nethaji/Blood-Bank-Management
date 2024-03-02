$(document).ready(function () {
    $("#DonorId").change(function () {
        $.ajax({
            type: "GET",
            url: '/Inventories/GetBloodGroupId?donorId=' + $("#DonorId").val(),
            success: function (res) {
                $("#BloodGroupId").val(res);
                //console.log(res);
                //alert(res);
            },
            error: function () {
                alert("Error while inserting data");
            }
        });
    });
});