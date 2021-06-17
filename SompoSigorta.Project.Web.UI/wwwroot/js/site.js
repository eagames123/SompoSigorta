$(document).ready(function () {
    $(".resultSide").css("display", "none");

    $('#sendRequest').click(function (e) {

        var element = $(this);

        var currentText = element.html();

        element.html("Sonuçlar Yükleniyor...");

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
                        element.html(currentText);

                        $(".resultSide").fadeIn().delay(100).fadeOut(100).delay(100).fadeIn(100);

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