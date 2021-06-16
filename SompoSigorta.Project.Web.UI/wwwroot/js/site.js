$(document).ready(function () {
    $('#sendRequest').click(function (e) {
        e.preventDefault();
        var result = true;
        var checkUrunVal = $("#urunNo").val();
        if (checkUrunVal == "" || checkUrunVal == null) result = false;
        var checkTeklifVal = $("#teklifNo").val();
        if (checkTeklifVal == "" || checkTeklifVal == null) result = false;
        var checkYenilemeVal = $("#yenilemeNo").val();
        if (checkYenilemeVal == "" || checkYenilemeVal == null) result = false;
        var checkZeyilVal = $("#zeyilNo").val();
        if (checkZeyilVal == "" || checkZeyilVal == null) result = false;
        if (result === true) {
            try {
                var model = {
                    ProposalNo: $("#teklifNo").val(),
                    RenewalNo: $("#yenilemeNo").val(),
                    EndorsNo: $("#zeyilNo").val(),
                    ProductNo: $("#urunNo").val(),
                }
                $.ajax({
                    url: "/Home/SendProposal",
                    type: "post",
                    dataType: 'json',
                    contentType: 'application/json',
                    data: JSON.stringify(model),
                    success: function (data) {
                        $("#olumluTable").empty();
                        $("#bilgiTable").empty();
                        $("#olumsuzTable").empty();
                        $.each(data, function (i, item) {
                            if (data[i].status.value === '2') {
                                $("#bilgiTable").append("<tr><td>" + data[i].code + "</td><td>" + data[i].description + "</td></tr>");
                            }
                            if (data[i].status.value === '1') {
                                $("#olumluTable").append("<tr><td>" + data[i].code + "</td><td>" + data[i].description + "</td></tr>");
                            }
                            if (data[i].status.value === '3') {
                                $("#olumsuzTable").append("<tr><td>" + data[i].code + "</td><td>" + data[i].description + "</td></tr>");
                            }
                        });
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert("Problem!")
                    }
                });

            } catch { }
        }
        else {
            alert("Hatalı Giriş!");
        }
    });
});