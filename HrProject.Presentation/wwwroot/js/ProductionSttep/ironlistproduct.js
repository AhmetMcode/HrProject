$(document).ready(function () {
    $('.baslaToplu').click(function () {
        var selectedIds = []; // Seçili ID'leri tutacak dizi

        // Her bir checkbox için döngü
        $(this).closest('.modal-content').find('.ids:checked').each(function () {
            // Seçili olan checkbox'ýn ID deðerini diziye ekle
            selectedIds.push($(this).attr('id'));
        });
        var $modal = $(this).closest('.modal'); // Modal elementini seçin

        debugger;
        $.ajax({
            url: '/ProductionStep/StartStepToplu',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(selectedIds),
            success: function (response) {
                $.each(response.ErrorList, function (id, hasError) {
                    if (hasError) {
                        // Hata oluþan ID'ye göre uygun mesajý oluþtur
                        $(document).Toasts('create', {
                            class: 'bg-danger',
                            title: 'Hata Oluþtu',
                            subtitle: 'Uyarý',
                            body: 'ID: ' + id + ' iþlem sýrasýnda hata oluþtu'
                        });
                    }
                    else {
                        $(document).Toasts('create', {
                            class: 'bg-success',
                            title: 'Ýþlem Baþarýlý',
                            subtitle: 'Tamam',
                            body: 'ID: ' + id + ' iþlem baþarýyla tamamlandý'
                        });
                    }

                });
                $modal.find('.modal-close').trigger('click');


            },
            error: function (xhr, status, error) {
                console.error(error); // Hata mesajýný konsola yazdýr
                // Gerekirse kullanýcýya hata mesajýný gösterebilir veya baþka bir iþlem yapabilirsiniz
            }
        });
    });
    $('.bitirToplu').click(function () {
        var selectedIds = []; // Seçili ID'leri tutacak dizi
        var $modal = $(this).closest('.modal'); // Modal elementini seçin
        $(this).closest('.modal-content').find('.ids:checked').each(function () {
            selectedIds.push($(this).attr('id'));
        });
        debugger;
        $.ajax({
            url: '/ProductionStep/EndStepToplu', // Ýsteðin gönderileceði URL'yi ayarlayýn
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(selectedIds),
            success: function (response) {
                $.each(response.ErrorList, function (id, hasError) {
                    debugger;
                    if (hasError) {
                        // Hata oluþan ID'ye göre uygun mesajý oluþtur
                        $(document).Toasts('create', {
                            class: 'bg-danger',
                            title: 'Hata Oluþtu',
                            subtitle: 'Uyarý',
                            body: 'ID: ' + id + ' iþlem sýrasýnda hata oluþtu'
                        });
                    }
                    else {
                        $(document).Toasts('create', {
                            class: 'bg-success',
                            title: 'Ýþlem Baþarýlý',
                            subtitle: 'Tamam',
                            body: 'ID: ' + id + ' iþlem baþarýyla tamamlandý'
                        });
                    }
                });
                $modal.find('.modal-close').trigger('click');
            },
            error: function (xhr, status, error) {
                console.error(error); // Hata mesajýný konsola yazdýr
            }
        });
    });
    $('.kaliteToplu').click(function () {
        var selectedIds = []; // Seçili ID'leri tutacak dizi

        // Her bir checkbox için döngü
        $(this).closest('.modal-content').find('.ids:checked').each(function () {
            // Seçili olan checkbox'ýn ID deðerini diziye ekle
            selectedIds.push($(this).attr('id'));
        });
        debugger;
        // Seçili ID'leri içeren diziyi gönder
        $.ajax({
            url: '/Quality/KaliteToplu', // Ýsteðin gönderileceði URL'yi ayarlayýn
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(selectedIds),
            success: function (response) {
                $.each(response.ErrorList, function (id, hasError) {
                    if (hasError) {
                        // Hata oluþan ID'ye göre uygun mesajý oluþtur
                        $(document).Toasts('create', {
                            class: 'bg-danger',
                            title: 'Hata Oluþtu',
                            subtitle: 'Uyarý',
                            body: 'ID: ' + id + ' iþlem sýrasýnda hata oluþtu'
                        });
                    }
                    else {
                        $(document).Toasts('create', {
                            class: 'bg-success',
                            title: 'Ýþlem Baþarýlý',
                            subtitle: 'Tamam',
                            body: 'ID: ' + id + ' iþlem baþarýyla tamamlandý'
                        });
                    }
                });
            },
            error: function (xhr, status, error) {
                // Hata durumunda yapýlacak iþlemler
                console.error(error); // Hata mesajýný konsola yazdýr
                // Gerekirse kullanýcýya hata mesajýný gösterebilir veya baþka bir iþlem yapabilirsiniz
            }
        });
    });
    $('.indir').click(function () {
        // HTML2Canvas kütüphanesiyle modal içeriðini görüntüye dönüþtür
        html2canvas($('#budur')[0]).then(function (canvas) {
            // Canvas verisini PDF'e dönüþtürmek için jsPDF kütüphanesini kullan
            var imgData = canvas.toDataURL('image/png');
            var imgWidth = 148; // A5 boyutlarý: 148mm x 210mm (dikey olarak)
            var imgHeight = canvas.height * imgWidth / canvas.width;

            var doc = new jsPDF('p', 'mm', [imgWidth, imgHeight]);
            doc.addImage(imgData, 'PNG', 0, 0, imgWidth, imgHeight);

            // PDF'i indir
            doc.save('etiket.pdf');
        });
    });
    $('.resimYukle').click(function () {
        var itemId = $(this).data('merhaba'); // Seçilen öðenin Id'sini al
        var fileInput = $(this).closest('td').find('input[type=file]')[0];
        var file = fileInput.files[0];

        var formData = new FormData();
        formData.append('id', itemId);
        formData.append('resim', file);

        $.ajax({
            url: '/ProductionStep/AddImageDetail', // Ýsteðin gönderileceði URL'yi doðru þekilde güncelleyin
            type: 'POST',
            data: formData,
            contentType: false,
            processData: false,
            success: function (response) {
                // Ýþlem baþarýlý olduðunda yapýlacak iþlemler
                alert(response);
            },
            error: function (xhr, status, error) {
                // Hata durumunda yapýlacak iþlemler
                console.error(error);
            }
        });
    });
    $('.open-modal-btn').click(function () {
        var itemId = $(this).data('merhaba'); // Seçilen öðenin Id'sini al
        $.ajax({
            url: '/Planing/GetQrCodeInfo',
            type: 'GET',
            data: { productPlanId: itemId },
            success: function (response) {
                $('#ProjeAd').val(response.ProjeAd);
                $('#pozVerSira').val(response.PozVeSiraNo);
                $('#kalipAdi').val(response.KalipAd);

                // Resim yolu için bir <img> elementi oluþturup, resim yolunu ayarlayýn
                var imgElement = $('#resim');
                imgElement.attr('src', '/HR/' + response.ResimYolu);
                $('#resim').replaceWith(imgElement);
            },
            error: function (xhr, status, error) {
                console.error(error);
            }
        });
        // Burada modalý açmak için gerekli kodlarý yazabilirsiniz
        // Örneðin:
        $('#exampleModal').modal('show');
        debugger;
        var qrcodeElement = document.getElementById("qrcode");
        qrcodeElement.innerHTML = ""; // içeriði temizle
        var qrcode = new QRCode(document.getElementById("qrcode"), {
            text: "www.erpelfbeton.com.tr/Planing/OpenManifact/" + itemId,
            width: 200,
            height: 200,
            colorDark: "#000000",
            colorLight: "#ffffff",
            correctLevel: QRCode.CorrectLevel.H
        });
        // Ýstediðiniz þekilde itemId'yi kullanabilirsiniz.
    });
    $('.toggle-details').click(function () {
        var row = $(this).closest('tr'); // Butona týklanan satýr
        var detailsRow = row.next('.details-row'); // Detaylarý içeren satýr
        detailsRow.toggle(); // Detaylarý göster/gizle, "slow" animasyonuyla

        // Ýkon deðiþimi için
        var icon = $(this).find('i'); // Ýkonu bul
        if (icon.hasClass('fa-plus')) {
            icon.removeClass('fa-plus').addClass('fa-minus');
        } else {
            icon.removeClass('fa-minus').addClass('fa-plus');
        }
    });
    $('.toggle-details2').click(function () {
        var itemId = $(this).attr('id').split('_')[1]; // Düðmenin itemId'sini al
        var detailsRow = $('.details-gunluk_' + itemId); // Ayný itemId'ye sahip '.details-row2' satýrlarýný bul

        detailsRow.toggle('slow'); // '.details-row2' satýrlarýnýn görünürlüðünü deðiþtir

        var icon = $(this).find('i');
        icon.toggleClass('fa-plus fa-minus');
    });
    $('.toggle-gunluk').click(function () {
        var itemId = $(this).attr('id').split('_')[1]; // Düðmenin itemId'sini al
        var detailsRow = $('.details-row2_' + itemId); // Ayný itemId'ye sahip '.details-row2' satýrlarýný bul

        detailsRow.toggle('slow'); // '.details-row2' satýrlarýnýn görünürlüðünü deðiþtir

        var icon = $(this).find('i');
        icon.toggleClass('fa-plus fa-minus');
    });
});
