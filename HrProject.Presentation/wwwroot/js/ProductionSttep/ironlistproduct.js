$(document).ready(function () {
    $('.baslaToplu').click(function () {
        var selectedIds = []; // Se�ili ID'leri tutacak dizi

        // Her bir checkbox i�in d�ng�
        $(this).closest('.modal-content').find('.ids:checked').each(function () {
            // Se�ili olan checkbox'�n ID de�erini diziye ekle
            selectedIds.push($(this).attr('id'));
        });
        var $modal = $(this).closest('.modal'); // Modal elementini se�in

        debugger;
        $.ajax({
            url: '/ProductionStep/StartStepToplu',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(selectedIds),
            success: function (response) {
                $.each(response.ErrorList, function (id, hasError) {
                    if (hasError) {
                        // Hata olu�an ID'ye g�re uygun mesaj� olu�tur
                        $(document).Toasts('create', {
                            class: 'bg-danger',
                            title: 'Hata Olu�tu',
                            subtitle: 'Uyar�',
                            body: 'ID: ' + id + ' i�lem s�ras�nda hata olu�tu'
                        });
                    }
                    else {
                        $(document).Toasts('create', {
                            class: 'bg-success',
                            title: '��lem Ba�ar�l�',
                            subtitle: 'Tamam',
                            body: 'ID: ' + id + ' i�lem ba�ar�yla tamamland�'
                        });
                    }

                });
                $modal.find('.modal-close').trigger('click');


            },
            error: function (xhr, status, error) {
                console.error(error); // Hata mesaj�n� konsola yazd�r
                // Gerekirse kullan�c�ya hata mesaj�n� g�sterebilir veya ba�ka bir i�lem yapabilirsiniz
            }
        });
    });
    $('.bitirToplu').click(function () {
        var selectedIds = []; // Se�ili ID'leri tutacak dizi
        var $modal = $(this).closest('.modal'); // Modal elementini se�in
        $(this).closest('.modal-content').find('.ids:checked').each(function () {
            selectedIds.push($(this).attr('id'));
        });
        debugger;
        $.ajax({
            url: '/ProductionStep/EndStepToplu', // �ste�in g�nderilece�i URL'yi ayarlay�n
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(selectedIds),
            success: function (response) {
                $.each(response.ErrorList, function (id, hasError) {
                    debugger;
                    if (hasError) {
                        // Hata olu�an ID'ye g�re uygun mesaj� olu�tur
                        $(document).Toasts('create', {
                            class: 'bg-danger',
                            title: 'Hata Olu�tu',
                            subtitle: 'Uyar�',
                            body: 'ID: ' + id + ' i�lem s�ras�nda hata olu�tu'
                        });
                    }
                    else {
                        $(document).Toasts('create', {
                            class: 'bg-success',
                            title: '��lem Ba�ar�l�',
                            subtitle: 'Tamam',
                            body: 'ID: ' + id + ' i�lem ba�ar�yla tamamland�'
                        });
                    }
                });
                $modal.find('.modal-close').trigger('click');
            },
            error: function (xhr, status, error) {
                console.error(error); // Hata mesaj�n� konsola yazd�r
            }
        });
    });
    $('.kaliteToplu').click(function () {
        var selectedIds = []; // Se�ili ID'leri tutacak dizi

        // Her bir checkbox i�in d�ng�
        $(this).closest('.modal-content').find('.ids:checked').each(function () {
            // Se�ili olan checkbox'�n ID de�erini diziye ekle
            selectedIds.push($(this).attr('id'));
        });
        debugger;
        // Se�ili ID'leri i�eren diziyi g�nder
        $.ajax({
            url: '/Quality/KaliteToplu', // �ste�in g�nderilece�i URL'yi ayarlay�n
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(selectedIds),
            success: function (response) {
                $.each(response.ErrorList, function (id, hasError) {
                    if (hasError) {
                        // Hata olu�an ID'ye g�re uygun mesaj� olu�tur
                        $(document).Toasts('create', {
                            class: 'bg-danger',
                            title: 'Hata Olu�tu',
                            subtitle: 'Uyar�',
                            body: 'ID: ' + id + ' i�lem s�ras�nda hata olu�tu'
                        });
                    }
                    else {
                        $(document).Toasts('create', {
                            class: 'bg-success',
                            title: '��lem Ba�ar�l�',
                            subtitle: 'Tamam',
                            body: 'ID: ' + id + ' i�lem ba�ar�yla tamamland�'
                        });
                    }
                });
            },
            error: function (xhr, status, error) {
                // Hata durumunda yap�lacak i�lemler
                console.error(error); // Hata mesaj�n� konsola yazd�r
                // Gerekirse kullan�c�ya hata mesaj�n� g�sterebilir veya ba�ka bir i�lem yapabilirsiniz
            }
        });
    });
    $('.indir').click(function () {
        // HTML2Canvas k�t�phanesiyle modal i�eri�ini g�r�nt�ye d�n��t�r
        html2canvas($('#budur')[0]).then(function (canvas) {
            // Canvas verisini PDF'e d�n��t�rmek i�in jsPDF k�t�phanesini kullan
            var imgData = canvas.toDataURL('image/png');
            var imgWidth = 148; // A5 boyutlar�: 148mm x 210mm (dikey olarak)
            var imgHeight = canvas.height * imgWidth / canvas.width;

            var doc = new jsPDF('p', 'mm', [imgWidth, imgHeight]);
            doc.addImage(imgData, 'PNG', 0, 0, imgWidth, imgHeight);

            // PDF'i indir
            doc.save('etiket.pdf');
        });
    });
    $('.resimYukle').click(function () {
        var itemId = $(this).data('merhaba'); // Se�ilen ��enin Id'sini al
        var fileInput = $(this).closest('td').find('input[type=file]')[0];
        var file = fileInput.files[0];

        var formData = new FormData();
        formData.append('id', itemId);
        formData.append('resim', file);

        $.ajax({
            url: '/ProductionStep/AddImageDetail', // �ste�in g�nderilece�i URL'yi do�ru �ekilde g�ncelleyin
            type: 'POST',
            data: formData,
            contentType: false,
            processData: false,
            success: function (response) {
                // ��lem ba�ar�l� oldu�unda yap�lacak i�lemler
                alert(response);
            },
            error: function (xhr, status, error) {
                // Hata durumunda yap�lacak i�lemler
                console.error(error);
            }
        });
    });
    $('.open-modal-btn').click(function () {
        var itemId = $(this).data('merhaba'); // Se�ilen ��enin Id'sini al
        $.ajax({
            url: '/Planing/GetQrCodeInfo',
            type: 'GET',
            data: { productPlanId: itemId },
            success: function (response) {
                $('#ProjeAd').val(response.ProjeAd);
                $('#pozVerSira').val(response.PozVeSiraNo);
                $('#kalipAdi').val(response.KalipAd);

                // Resim yolu i�in bir <img> elementi olu�turup, resim yolunu ayarlay�n
                var imgElement = $('#resim');
                imgElement.attr('src', '/HR/' + response.ResimYolu);
                $('#resim').replaceWith(imgElement);
            },
            error: function (xhr, status, error) {
                console.error(error);
            }
        });
        // Burada modal� a�mak i�in gerekli kodlar� yazabilirsiniz
        // �rne�in:
        $('#exampleModal').modal('show');
        debugger;
        var qrcodeElement = document.getElementById("qrcode");
        qrcodeElement.innerHTML = ""; // i�eri�i temizle
        var qrcode = new QRCode(document.getElementById("qrcode"), {
            text: "www.erpelfbeton.com.tr/Planing/OpenManifact/" + itemId,
            width: 200,
            height: 200,
            colorDark: "#000000",
            colorLight: "#ffffff",
            correctLevel: QRCode.CorrectLevel.H
        });
        // �stedi�iniz �ekilde itemId'yi kullanabilirsiniz.
    });
    $('.toggle-details').click(function () {
        var row = $(this).closest('tr'); // Butona t�klanan sat�r
        var detailsRow = row.next('.details-row'); // Detaylar� i�eren sat�r
        detailsRow.toggle(); // Detaylar� g�ster/gizle, "slow" animasyonuyla

        // �kon de�i�imi i�in
        var icon = $(this).find('i'); // �konu bul
        if (icon.hasClass('fa-plus')) {
            icon.removeClass('fa-plus').addClass('fa-minus');
        } else {
            icon.removeClass('fa-minus').addClass('fa-plus');
        }
    });
    $('.toggle-details2').click(function () {
        var itemId = $(this).attr('id').split('_')[1]; // D��menin itemId'sini al
        var detailsRow = $('.details-gunluk_' + itemId); // Ayn� itemId'ye sahip '.details-row2' sat�rlar�n� bul

        detailsRow.toggle('slow'); // '.details-row2' sat�rlar�n�n g�r�n�rl���n� de�i�tir

        var icon = $(this).find('i');
        icon.toggleClass('fa-plus fa-minus');
    });
    $('.toggle-gunluk').click(function () {
        var itemId = $(this).attr('id').split('_')[1]; // D��menin itemId'sini al
        var detailsRow = $('.details-row2_' + itemId); // Ayn� itemId'ye sahip '.details-row2' sat�rlar�n� bul

        detailsRow.toggle('slow'); // '.details-row2' sat�rlar�n�n g�r�n�rl���n� de�i�tir

        var icon = $(this).find('i');
        icon.toggleClass('fa-plus fa-minus');
    });
});
