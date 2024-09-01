$(".card-link").click(function (event) {
    event.preventDefault(); // Ba�lant�n�n varsay�lan davran���n� engeller

    swal({
        title: 'Emin misiniz?',
        text: "��lemi ger�ekle�tirmek istedi�inizden emin misiniz?",
        icon: 'warning',
        buttons: {
            cancel: '�ptal',
            confirm: 'Evet, devam et!'
        },
        dangerMode: true,
    }).then((willContinue) => {
        if (willContinue) {
            var url = $(this).attr("action-url");
            debugger;
            // AJAX iste�i g�nderme
            $.ajax({
                url: url,
                type: "GET", // veya "POST" olarak belirleyin
                success: function (data) {
                    location.reload();
                },
                error: function () {
                    swal(
                        'Hata!',
                        'AJAX iste�i s�ras�nda bir hata olu�tu. L�tfen tekrar deneyin.',
                        'error'
                    );
                }
            });
        }
    });
});
$(window).on('load', function () {
    $('#overlay').fadeOut('slow');
});

$(document).on('submit', 'form', function () {
    $('#overlay').fadeIn('slow');
});
$(document).on('click', '.icmalRapor', function () {
    debugger;
    $('#overlay').fadeIn('slow');
});
$('.icmalRapor').on("click", function () {
    debugger;
    $('#overlay').fadeIn('slow');
    //post code
});
function confirmAction(url) {
    Swal.fire({
        title: 'Emin misiniz?',
        text: "Bu i�lemi ba�latmak istedi�inizden emin misiniz?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Evet, ba�lat!',
        cancelButtonText: '�ptal'
    }).then((result) => {
        if (result.isConfirmed) {
            // Perform the action by redirecting to the URL
            window.location.href = url;
        }
    });
}
