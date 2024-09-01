$(".card-link").click(function (event) {
    event.preventDefault(); // Baðlantýnýn varsayýlan davranýþýný engeller

    swal({
        title: 'Emin misiniz?',
        text: "Ýþlemi gerçekleþtirmek istediðinizden emin misiniz?",
        icon: 'warning',
        buttons: {
            cancel: 'Ýptal',
            confirm: 'Evet, devam et!'
        },
        dangerMode: true,
    }).then((willContinue) => {
        if (willContinue) {
            var url = $(this).attr("action-url");
            debugger;
            // AJAX isteði gönderme
            $.ajax({
                url: url,
                type: "GET", // veya "POST" olarak belirleyin
                success: function (data) {
                    location.reload();
                },
                error: function () {
                    swal(
                        'Hata!',
                        'AJAX isteði sýrasýnda bir hata oluþtu. Lütfen tekrar deneyin.',
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
        text: "Bu iþlemi baþlatmak istediðinizden emin misiniz?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Evet, baþlat!',
        cancelButtonText: 'Ýptal'
    }).then((result) => {
        if (result.isConfirmed) {
            // Perform the action by redirecting to the URL
            window.location.href = url;
        }
    });
}
