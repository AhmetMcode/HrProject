$(document).ready(function () {
    $('.form-check-input').change(function () {
        var id = $(this).closest('tr').find('.modelId').val(); // ilgili satýrýn Id'sini al
        var type = $(this).attr('data-type'); // ilgili sütunun tipini al (Web, Mail, SMS, Mobil)
        var sonuc = $(this).prop('checked'); // checkbox'ýn iþaretli olup olmadýðýný al

        // AJAX isteði gönder
        $.ajax({
            url: '/ProductionStep/UpdateNotifsNotf',
            type: 'POST',
            data: {
                id: id,
                type: type,
                sonuc: sonuc
            },
            success: function (response) {
                if (response === "ok") {
                    Swal.fire({
                        title: "Güncelleme!",
                        text: "Güncelleme Tamamlandý!",
                        icon: "success",
                        dangerMode: false,
                    }).then(() => {
                        location.reload();
                    });
                } else if (response === "hata") {
                    Swal.fire({
                        title: "Güncelleme!",
                        text: "Güncelleme Tamamlanmadý!",
                        icon: "error", // Hata durumunda "error" ikonunu göster
                        dangerMode: true,
                    }).then(() => {
                        // Hata durumunda yapýlacak iþlemler
                    });
                }
            },
            error: function (xhr, status, error) {
                console.error('Error:', error);
            }
        });
    });
    $('.deleteButon').click(function () {
        debugger;
        var id = parseInt($(this).attr('sil'));
        Swal.fire({
            title: "Sil!",
            text: "Bu veri tabanýna kayýtlý bir tekliftir silmek istediðinizden emin misiniz!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Evet, Sil",
            cancelButtonText: "Vazgeç"
        }).then((result) => {
            if (result.isConfirmed) {
                debugger;
                if (id !== "0" && id != "") {
                    // id 0 deðilse, veritabanýna git
                    $.ajax({
                        url: '/ProductionStep/DeleteNotif/' + id,
                        type: 'GET',
                        success: function (data) {
                            debugger;
                            Swal.fire(
                                "Sil!",
                                "Ýþlem Tamamlandý!",
                                "success"
                            ).then(() => {
                                location.reload();
                            });
                            // Baþarýlý bir þekilde silindiðinde yapýlacak iþlemler
                        },
                        error: function () {
                            Swal.fire(
                                "Hata!",
                                "Silme iþlemi gerçekleþtirilemedi.",
                                "error"
                            );
                        }
                    });
                } else {
                    // id 0 ise, sadece görüntüyü güncelle
                }
            } else {
                Swal.fire(
                    "Ýþlem Ýptal Edildi!",
                    "",
                    "info"
                );
            }
        });

    });
    $('#saveButton').click(function () {
        // Prepare the data to be sent
        var dataToSend = {
            IdentityRoleId: $('#addRoleSelect option:selected').val(),
            ProductionStepId: $('input[name="ProductionStepId"]').val(),
            BildirimBaslik: $('#notificationTitle').val(),
            BildirimIcerik: $('#notificationContent').val(),
            Mail: $('#mailNotification').is(':checked'),
            Mobil: $('#mobileNotification').is(':checked'),
            Web: $('#webNotification').is(':checked'),
            Sms: $('#smsNotification').is(':checked')
        };
        debugger;
        $.ajax({
            url: '/ProductionStep/AddNotifs', // Replace YourControllerName with the actual name of your controller
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(dataToSend),
            success: function (response) {
                debugger;
                if (response === "ok") {
                    swal.fire({
                        title: "Ekle!",
                        text: "Ekleme Tamamlandý!",
                        icon: "success",
                        dangerMode: false,
                    }).then(() => {
                        location.reload();
                    });
                } else if (response === "hata") {
                    swal.fire({
                        title: "Ekle!",
                        text: "Ekle Tamamlanmadý!",
                        icon: "error", // Hata durumunda "error" ikonunu göster
                        dangerMode: true,
                    }).then(() => {
                        // Hata durumunda yapýlacak iþlemler
                    });
                }

                // Ýsteðe baðlý olarak sayfayý yenile
                setTimeout(function () {
                    window.location.reload();
                }, 3000);
            },
            error: function (xhr, status, error) {
                // Handle error
                console.error('Error saving notification settings:', error);
            }
        });
    });

});
