
function atama(currentValueId) {
    $.get("/Offer/GetOfferPartial?id=" + currentValueId, function (data) {
        $("#modalbody").html(data);
        $("#changeModal").modal("show");
    }).fail(function () {
        alert("İstek başarısız oldu.");
    });
}
function asd(currentValueId) {

    $.get("/Offer/GetOfferAddDocumentPartial?id=" + currentValueId, function (data) {
        $("#modalbody").html(data);
        $("#changeModal").modal("show");
    }).fail(function () {
        alert("İstek başarısız oldu.");
    });
}
$(document).ready(function () {
    $('.sendProjectModule').on('click', function () {
        // Get the offerId from the button's ID or any other source
        var offerId = $(this).attr('id');

        // Show a confirmation dialog
        var confirmResult = confirm('Proje Modülüne Göndermek İstediğinizden Emin Misiniz');

        // If the user confirms, make an AJAX request and reload the page
        if (confirmResult) {
            $.ajax({
                type: 'GET', // or 'POST' depending on your controller action
                url: '/Offer/SendProjectModule?id=' + offerId,
                success: function (result) {
                    // Handle success, if needed
                    alert(result);

                    // Reload the page
                    location.reload();
                },
                error: function (error) {
                    // Handle error, if needed
                    console.error(error);
                }
            });
        }
    });
});

$(document).ready(function () {
    $('.export').click(function (e) {
        e.preventDefault();
        var url = $(this).attr('href');

        Swal.fire({
            title: 'Bu Bir Revize Mi?',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Evet',
            cancelButtonText: 'Hayır',
        }).then((result) => {
            if (result.isConfirmed) {
                window.location.href = url + '?revize=true';
            } else {
                window.location.href = url + '?revize=false';
            }
        });
    });
    $('.delete-offer').on('click', function () {
        var button = $(this);
        var offerId = button.data('id');

        Swal.fire({
            title: 'Emin misiniz?',
            text: "Bu teklifi silmek üzeresiniz!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Evet, sil!',
            cancelButtonText: 'Hayır, iptal et'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: '/Offer/DeleteOffer', // Replace with your actual controller and action
                    type: 'GET',
                    data: { id: offerId },
                    success: function (response) {
                        Swal.fire(
                            'Silindi!',
                            response.message,
                            'success'
                        );
                        // Optionally remove the deleted offer from the DOM
                        button.closest('tr').remove();
                    },
                    error: function (xhr, status, error) {
                        Swal.fire(
                            'Hata!',
                            'Bir hata oluştu, lütfen tekrar deneyin.',
                            'error'
                        );
                    }
                });
            }
        });
    });
});


