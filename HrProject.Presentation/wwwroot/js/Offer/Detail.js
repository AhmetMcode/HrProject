$(document).ready(function () {

    $('.mask').inputmask('numeric', {
        radixPoint: '.',
        groupSeparator: ',',
        autoGroup: true,
        digits: 2,
        digitsOptional: false,
        placeholder: '0',
    });
    calculateTotalPrice();
    // Handle button click event
    function calculateTotalPrice() {
        // Get unmasked values
        var contractPrice = 0;
        $('.price').each(function () {
            var priceValue = parseFloat($(this).inputmask('unmaskedvalue'));
            if (!isNaN(priceValue)) {
                contractPrice += priceValue;
            }
        });
        debugger;
        var kdvOrani = parseFloat($('#kdvOrani').inputmask('unmaskedvalue'));
        var tevkifat = parseFloat($('#tevkifatOrani').inputmask('unmaskedvalue'));

        if (!isNaN(contractPrice) && !isNaN(kdvOrani)) {
            var kdvDahil = contractPrice + (contractPrice * (kdvOrani / 100));
            var kdv = (contractPrice * (kdvOrani / 100));
            kdvDahil = kdvDahil - (kdv * (tevkifat / 100));
            $('#kdvDahil').val(kdvDahil.toFixed(2));
            var grtut = parseFloat($('#grTutar').inputmask('unmaskedvalue'));

            var dahil = contractPrice + grtut;
            $('#grToplamKdvsiz').val(dahil);
        } else {
            $('#kdvDahil').val('');
        }

    }

    $('.price, #kdvOrani,#tevkifatOrani').on('input', calculateTotalPrice);
    $(".onay, .btn-danger").click(function () {
        var isConfirmed = $(this).hasClass("onay"); // true if "Onay" button is clicked, false if "Red" button is clicked

        // Get values from the form
        var confirmDesc = $("#confirmDesc").val();
        var redDesc = $("#redText").val();
        var sozlesmeDosyasi = $("#sozlesmeDosyasi")[0].files[0];
        var sozlesmeDosyasiDiger = $("#sozlesmeDosyasiDiger")[0].files[0];
        var offerId = $("#offerId").val();
        var kdvOrani = $("#kdvOrani").val();
        var kdvDahil = $("#kdvDahil").val();
        var grTutar = $("#grTutar").val();
        var projeTerminTarihi = new Date($("#projeTerminTarihi").val());
        
        if (!isNaN(projeTerminTarihi)) {
            projeTerminTarihi = projeTerminTarihi.toISOString();
        } else {
            projeTerminTarihi = null; // Geçersizse null olarak ayarlayın
        }
        var tevkifatOrani = parseFloat($('#tevkifatOrani').inputmask('unmaskedvalue'));

        var GRString = grTutar.replace(/[,]/g, '');
        var DahilString = kdvDahil.replace(/[,]/g, '');
        var Dahil = parseFloat(DahilString);
        var gr = parseFloat(GRString);

        // Show confirmation dialog with SweetAlert
        Swal.fire({
            title: "Emin Misiniz?",
            icon: "question",
            showCancelButton: true,
            confirmButtonText: "Evet",
            cancelButtonText: "Hayır",
        }).then((result) => {
            if (result.isConfirmed) {
                // Prepare data for AJAX submission
                var formData = new FormData();
                formData.append("offerId", offerId);
                formData.append("confirm", isConfirmed);
                formData.append("confirmDesc", confirmDesc);
                formData.append("redDesc", redDesc);
                formData.append("projeTerminTarihi", projeTerminTarihi);
                debugger;
                if (sozlesmeDosyasi) {
                    formData.append("sozlesmeDosyasi", sozlesmeDosyasi);
                }
                if (sozlesmeDosyasiDiger) {
                    formData.append("sozlesmeDosyasiDiger", sozlesmeDosyasiDiger);
                }
                formData.append("kdvOrani", kdvOrani);
                formData.append("kdvDahil", Dahil);
                formData.append("grTutar", gr);
                $(".price").each(function () {
                    var partId = $(this).attr("partId");
                    var priceString = $(this).val().replace(/[,]/g, '');
                    var price = parseFloat(priceString);
                    formData.append(`prices[${partId}]`, price);
                });
                formData.append("tevkifatOrani", tevkifatOrani);
                debugger;
                // Make AJAX request
                $.ajax({
                    type: "POST",
                    url: "/Offer/ConfirmOffer", // Replace with your controller and action names
                    data: formData,
                    contentType: false,
                    processData: false,
                    success: function (result) {
                        Swal.fire({
                            title: 'Başarılı!',
                            text: result, // Assuming the result is text to display
                            icon: 'success',
                            confirmButtonText: 'Tamam'
                        }).then(() => {
                            location.reload(); // Reload the page after the user clicks "Tamam"
                        });
                    },
                    error: function (error) {
                        Swal.fire({
                            title: 'İşlem Başarısız Tüm Alanları Kontrol Edin!',
                            text: result, // Assuming the result is text to display
                            icon: 'danger',
                            confirmButtonText: 'Tamam'
                        }).then(() => {
                        });
                    }
                });
            }
        });
    });
});
