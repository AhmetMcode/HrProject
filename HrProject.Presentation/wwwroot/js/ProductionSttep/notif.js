$(document).ready(function () {
    $('.form-check-input').change(function () {
        var id = $(this).closest('tr').find('.modelId').val(); // ilgili sat�r�n Id'sini al
        var type = $(this).attr('data-type'); // ilgili s�tunun tipini al (Web, Mail, SMS, Mobil)
        var sonuc = $(this).prop('checked'); // checkbox'�n i�aretli olup olmad���n� al

        // AJAX iste�i g�nder
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
                        title: "G�ncelleme!",
                        text: "G�ncelleme Tamamland�!",
                        icon: "success",
                        dangerMode: false,
                    }).then(() => {
                        location.reload();
                    });
                } else if (response === "hata") {
                    Swal.fire({
                        title: "G�ncelleme!",
                        text: "G�ncelleme Tamamlanmad�!",
                        icon: "error", // Hata durumunda "error" ikonunu g�ster
                        dangerMode: true,
                    }).then(() => {
                        // Hata durumunda yap�lacak i�lemler
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
            text: "Bu veri taban�na kay�tl� bir tekliftir silmek istedi�inizden emin misiniz!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Evet, Sil",
            cancelButtonText: "Vazge�"
        }).then((result) => {
            if (result.isConfirmed) {
                debugger;
                if (id !== "0" && id != "") {
                    // id 0 de�ilse, veritaban�na git
                    $.ajax({
                        url: '/ProductionStep/DeleteNotif/' + id,
                        type: 'GET',
                        success: function (data) {
                            debugger;
                            Swal.fire(
                                "Sil!",
                                "��lem Tamamland�!",
                                "success"
                            ).then(() => {
                                location.reload();
                            });
                            // Ba�ar�l� bir �ekilde silindi�inde yap�lacak i�lemler
                        },
                        error: function () {
                            Swal.fire(
                                "Hata!",
                                "Silme i�lemi ger�ekle�tirilemedi.",
                                "error"
                            );
                        }
                    });
                } else {
                    // id 0 ise, sadece g�r�nt�y� g�ncelle
                }
            } else {
                Swal.fire(
                    "��lem �ptal Edildi!",
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
                        text: "Ekleme Tamamland�!",
                        icon: "success",
                        dangerMode: false,
                    }).then(() => {
                        location.reload();
                    });
                } else if (response === "hata") {
                    swal.fire({
                        title: "Ekle!",
                        text: "Ekle Tamamlanmad�!",
                        icon: "error", // Hata durumunda "error" ikonunu g�ster
                        dangerMode: true,
                    }).then(() => {
                        // Hata durumunda yap�lacak i�lemler
                    });
                }

                // �ste�e ba�l� olarak sayfay� yenile
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
