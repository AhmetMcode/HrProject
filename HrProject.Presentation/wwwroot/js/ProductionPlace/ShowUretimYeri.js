// Beton isteği düğmesine tıklanınca
$('.btn-primary').click(function () {
    // Kullanıcıya onay iletişim kutusu göster
    Swal.fire({
        title: "Beton İste",
        text: "Beton isteği göndermek istediğinizden emin misiniz?",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Evet, Gönder",
        cancelButtonText: "İptal",
        dangerMode: true,
    }).then((result) => {
        // Kullanıcı evet'i seçtiyse
        if (result.isConfirmed) {
            // Form verilerini topla ve AJAX isteği gönder
            sendConcreteRequest();
        }
    });
});


// Beton isteği gönderme işlemini yapan fonksiyon
function sendConcreteRequest() {
    // Form verilerini topla
    var model = {
        ConcreteRequest: {
            RequestUserId: "a",
            RequestTime: new Date(), // Şu anki zamanı alır
            ActionTime: new Date(), // Şu anki zamanı alır
            ConcreteClassId: parseInt($('#betonSinif').val()), 
            ProductionPlaceId: parseInt($('#uretimYeriId').val()), 
            Description: $('#Description').val(),
            QuantRequest: parseFloat($('#QuantRequest').val())
        },
        Ids: []
    };

    // Checkbox'ların durumunu kontrol et ve ilgili Ids'e ekle
    $('.ids').each(function () {
        if ($(this).is(':checked')) {
            model.Ids.push($(this).val());
        }
    });
    debugger;
    // Sunucuya AJAX isteği gönder
    $.ajax({
        url: '/Planing/BetonIste',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(model),
        success: function (response) {
            // Başarılı yanıt alındığında yapılacaklar
            console.log(response);
            // İsteğin başarıyla tamamlandığını bildir
            swal("Başarılı!", "Beton isteği başarıyla gönderildi!", "success");
        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacaklar
            console.error(error);
            // Hata mesajını kullanıcıya bildir
            swal("Hata!", "Bir hata oluştu, beton isteği gönderilemedi!", "error");
        }
    });
}
