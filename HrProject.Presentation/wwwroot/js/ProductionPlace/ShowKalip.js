$(".endStepBaslangic").on("click", function (e) {
    Swal.fire({
        title: 'Başlat!',
        text: 'Bu süreci bitirip bir sonraki süreci başlatmak istediğinizden emin misiniz!',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Evet, Başla',
        cancelButtonText: 'Vazgeç',
        reverseButtons: true, // İptal ve onay butonlarının sırasını değiştir
        dangerMode: true
    }).then((result) => {
        if (result.value) {
            var itemId = $(this).attr("itemid"); // Bu satırda `this` beklenen referansı vermeyebilir. Kontekst dışında kullanılıyor.

            $.ajax({
                type: "GET",
                url: "/ProductionStep/EndStep/" + itemId + "?jquery=true", // jQuery parametresi eklenmiş
                success: function (data) {
                    location.reload(); // Sayfayı yenile
                },
                error: function () {
                    Swal.fire(
                        'Hata!',
                        'AJAX isteği sırasında bir hata oluştu. Lütfen tekrar deneyin.',
                        'error'
                    );
                }
            });
        } else if (result.dismiss === Swal.DismissReason.cancel) {
            Swal.fire(
                'İptal Edildi!',
                'İşlem iptal edildi.',
                'error'
            );
        }
    });

});
$("#kalipTeslimBtn").on("click", function (e) {
    debugger;
    Swal.fire({
        title: "Başlat!",
        text: "Kalıptaki Tüm ürünlerin Bittiğinden Emin Olun. Eğer Tüm Ürünler Kalıpta ise Süreci Başlatın Aksi Halde Hata Alacaksınız!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: 'Evet, Başla',
        cancelButtonText: 'Vazgeç',
        dangerMode: true,
        reverseButtons: true
    }).then((result) => {
        if (result.value) {
            var ids = []; // ID'leri tutmak için bir dizi oluştur

            // Tüm gizli girişlerin değerlerini topla
            $(".suanIds").each(function () {
                ids.push(parseInt($(this).val())); // Değeri diziye ekle
            });

            // AJAX isteği gönder
            $.ajax({
                url: '/Quality/KaliteBeton', // İsteğin gideceği URL
                type: 'POST', // İsteğin türü
                contentType: 'application/json', // Gönderilen verinin türü
                data: JSON.stringify(ids), // Gönderilecek veriyi JSON formatına dönüştür
                success: function (response) {
                    // Başarılı istek sonrası yapılacak işlem
                    $('#myModal .modal-body').html(response);
                    $('#myModal').modal('show'); // Modalı göster
                },
                error: function (xhr, status, error) {
                    // Hata durumunda yapılacak işlem
                    console.error(xhr.responseText);
                }
            });
        } else if (result.dismiss === Swal.DismissReason.cancel) {
            Swal.fire("İşlem iptal Edildi!", '', 'error');
        }
    });

});
$('#resimYukleBtn').click(function () {
    var id = $(this).attr("detail"); // $this yerine $(this) kullanılmalıdır.
    debugger;
    Swal.fire({
        title: 'Resim Yükle',
        html: '<input type="file" id="swal-input-file" accept="image/*">',
        showCancelButton: true,
        confirmButtonText: 'Yükle',
        cancelButtonText: 'İptal',
        preConfirm: () => {
            return new Promise((resolve) => {
                var file = document.getElementById('swal-input-file').files[0];
                if (file) {
                    var formData = new FormData();
                    formData.append('resim', file);
                    // Dosya yükleme AJAX isteğini burada yapabiliriz
                    $.ajax({
                        url: '/ProductionStep/AddImageDetail/' + id, // Sunucunuzun dosyayı kabul edeceği URL
                        type: 'POST',
                        data: formData,
                        processData: false, // processData ve contentType'i false olarak ayarlamak önemli
                        contentType: false,
                        success: function (response) {
                            Swal.fire('Başarılı!', 'Dosyanız başarıyla yüklendi.', 'success');
                        },
                        error: function (xhr, status, error) {
                            Swal.fire('Hata!', 'Dosya yükleme sırasında bir hata oluştu.', 'error');
                        }
                    });
                } else {
                    Swal.showValidationMessage("Lütfen bir dosya seçin!"); // Dosya seçilmediğinde hata mesajı göster
                }
            });
        }
    });
});

$(document).ready(function () {
    // Başlat butonuna tıklama işlemi
    $('.btn-baslat').click(function () {
        var detailId = $(this).data('id');
        debugger;
        $.ajax({
            url: '/Manifact/StartManifactDetail', // Controller adını değiştirmeyi unutmayın
            type: 'POST',
            data: { detailId: detailId },
            success: function (response) {
                Swal.fire({
                    title: response,
                    icon: 'success',
                    confirmButtonText: 'Tamam'
                }).then((result) => {
                    if (result.isConfirmed) {
                        location.reload();
                    }
                });
            },
            error: function () {
                Swal.fire({
                    title: 'Bir hata oluştu',
                    icon: 'error',
                    confirmButtonText: 'Tamam'
                });
            }
        });
    });

    // Bitir butonuna tıklama işlemi
    $('.btn-bitir').click(function () {
        var detailId = $(this).data('id');

        $.ajax({
            url: '/Manifact/EndManifactDetail', // Controller adını değiştirmeyi unutmayın
            type: 'POST',
            data: { detailId: detailId },
            success: function (response) {
                Swal.fire({
                    title: response,
                    icon: 'success',
                    confirmButtonText: 'Tamam'
                }).then((result) => {
                    if (result.isConfirmed) {
                        location.reload();
                    }
                });
            },
            error: function () {
                Swal.fire({
                    title: 'Bir hata oluştu',
                    icon: 'error',
                    confirmButtonText: 'Tamam'
                });
            }
        });
    });
});