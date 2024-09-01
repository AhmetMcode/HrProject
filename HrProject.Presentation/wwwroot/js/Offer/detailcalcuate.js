


$(document).ready(function () {
    function UstuGuncelleIstegi() {

        // Net Beton deðerini alýp float türüne dönüþtürme
        var netBeton = parseFloat($('#netBeton').val());

        // Toplam Net Beton deðerini alýp float türüne dönüþtürme
        var toplamNetBeton = parseFloat($('#toplamNetBeton').val());

        // Demir deðerini alýp float türüne dönüþtürme
        var demir = parseFloat($('#demir').val());

        // Toplam Demir deðerini alýp float türüne dönüþtürme
        var toplamDemir = parseFloat($('#toplamDemirUst').val());

        // Çelik Hasýr deðerini alýp float türüne dönüþtürme
        var celikHasir = parseFloat($('#celikHasirTop').val());

        // Toplam Çelik Hasýr deðerini alýp float türüne dönüþtürme
        var toplamCelikHasir = parseFloat($('#celikHasirTopTotal2').val());

        // Ongerme Halati deðerini alýp float türüne dönüþtürme
        var ongermeHalati = parseFloat($('#halatTop').val());

        // Toplam Ongerme Halati deðerini alýp float türüne dönüþtürme
        var toplamOngermeHalati = parseFloat($('#halatTopTotal').val());
        debugger;
        console.log("Net Beton: " + netBeton);
        console.log("Toplam Net Beton: " + toplamNetBeton);
        console.log("Demir: " + demir);
        console.log("Toplam Demir: " + toplamDemir);
        console.log("Çelik Hasýr: " + celikHasir);
        console.log("Toplam Çelik Hasýr: " + toplamCelikHasir);
        console.log("Ongerme Halati: " + ongermeHalati);
        console.log("Toplam Ongerme Halati: " + toplamOngermeHalati);

        // Deðerleri alýp iþlem yapmak için bu noktadan sonra istediðiniz kodu yazabilirsiniz
    }


    var modalPrice = parseInt($("#modelPricee").val());
    var modelId = parseInt($("#modelId").val());
    $('.deleteRow').on('click', function () {
        var itemId = $(this).attr('itemid');

        // Confirm with SweetAlert
        Swal.fire({
            title: 'Emin misiniz?',
            text: "Bu öðeyi silmek istediðinizden emin misiniz?",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Evet, sil!',
            cancelButtonText: 'Ýptal'
        }).then((result) => {
            if (result.isConfirmed) {
                // If confirmed, make AJAX request
                $.ajax({
                    url: '/Offer/DeleteDetailCalculate/' + itemId,
                    type: 'GET',
                    success: function (response) {
                        location.reload();
                    },
                    error: function (xhr, status, error) {
                        console.error(error);
                    }
                });
            }
        });
    });
    updateTotalInceKalin();
    updateTotalPriceTop();
    updateKalinAdetTotal();
    updateToplamDemirBeton();
    $(".btn.hasirkaydet").click(function () {
        // Create an array to store the data from the table
        var wickerIronCalculates = [];

        // Iterate through the table rows in the tbody
        $("table.hasir tbody tr").each(function () {
            var row = $(this);
            var en = row.find(".en").val();
            var boy = row.find(".boy").val();
            var selectedOption = row.find(".smt option:selected");

            // Seçili olan optionun data-id özniteliðini al
            var smt = selectedOption.attr("data-id");

            // smt deðiþkeninde þimdi seçili olan optionun data-id deðeri bulunmaktadýr
            console.log(smt);
            var benzer = row.find(".benzer").val();

            var ag = row.find(".ag").val();
            var id = row.find(".id").val();
            if (id == "") {
                id = 0;
            }
            // Create an object with the row data
            var rowData = {
                Id: id,
                Width: parseFloat(en),
                Length: parseFloat(boy),
                Similar: parseInt(benzer),
                Weight: parseFloat(ag),
                SteelMeshTypeId: parseInt(smt),
                SteelMeshType: null, // You can set this property to null as it's not provided in the form
                OfferCalculateId: parseInt(modelId), // Set the appropriate OfferCalculateId
                OfferCalculate: null // You can set this property to null as it's not provided in the form
            };

            if (!isNaN(rowData.Weight)) {
                wickerIronCalculates.push(rowData);
            }
        });
        var celikHasirTop = $("#celikHasirTop").val();
        var celikHasirTopTotal2 = $("#celikHasirTopTotal2").val();
        var typeId = $(".smt").val();
        var requestData = {
            wickerIronCalculates: wickerIronCalculates,
            TypeId: 1,
            celikHasirTop: parseFloat(celikHasirTop),
            celikHasirTopTotal2: parseFloat(celikHasirTopTotal2)
        };
        // Send the data to the server using a POST request
        // SweetAlert2 ile kaydetme iþlemi için onay iletisi gösterme
        Swal.fire({
            title: 'Ýþlemi Onayla',
            text: 'Kaydetmek istediðinizden emin misiniz?',
            icon: 'question',
            showCancelButton: true,
            confirmButtonText: 'Evet, kaydet',
            cancelButtonText: 'Vazgeç',
        }).then((result) => {
            if (result.isConfirmed) {
                // Kullanýcý kaydetmeyi onayladý, Ajax isteðini gönder
                $.ajax({
                    type: "POST",
                    url: "/Offer/SaveWickerIronJson", // Gerçek sunucu adresi ile deðiþtirin
                    data: JSON.stringify(requestData),
                    contentType: "application/json; charset=utf-8",
                    success: function (response) {
                        // Sunucunun cevabýný iþleyin (gerekiyorsa)
                        Swal.fire({
                            title: 'Ýþlem Baþarýlý',
                            icon: 'success'
                        }).then((result) => {
                            // Bildirimi gösterdikten sonra sayfayý yenile
                            location.reload();
                        });
                    },
                    error: function (error) {
                        // Ýstek baþarýsýz olursa hatalarý iþleyin
                        Swal.fire({
                            title: 'Ýþlem Hatalý',
                            icon: 'error'
                        }).then((result) => {
                        });
                    }
                });
            }
        });

    });
    $(".btn.halatKaydet").click(function () {
        // Create an array to store the data from the table
        var ropeIronCalculates = [];

        // Iterate through the table rows in the tbody
        $("table.halat tbody tr").each(function () {
            var row = $(this);
            var adet = row.find(".adetHalat").val();
            var boyHalat = row.find(".boyHalat").val();
            var toronDiameter = row.find(".cap").val();
            var ag = row.find(".agHalat").val();
            var id = row.find(".id").val();
            if (id == "") {
                id = 0;
            }
            // Create an object with the row data
            var rowData = {
                Id: id,
                Price: parseFloat(adet),
                Length: parseFloat(boyHalat),
                Weight: parseFloat(ag),
                OfferCalculateId: parseInt(modelId), // Set the appropriate OfferCalculateId
                ToronDiameterId: parseInt(toronDiameter),
                OfferCalculate: null // You can set this property to null as it's not provided in the form
            };

            if (!isNaN(rowData.Weight)) {
                ropeIronCalculates.push(rowData);
            }
        });

        var ropeIronTop = parseFloat($("#halatTop").val());
        var ropeIronTopTotal = parseFloat($("#halatTopTotal").val());
        var postData = {
            RopeIrons: ropeIronCalculates,
            RopeIronTop: ropeIronTop,
            RopeIronTopTotal: ropeIronTopTotal
        };
        debugger;

        // Send the data to the server using a POST request
        Swal.fire({
            title: 'Kaydetme Ýþlemi',
            text: 'Kaydetmek istediðinizden emin misiniz?',
            icon: 'question',
            showCancelButton: true,
            confirmButtonText: 'Evet, kaydet',
            cancelButtonText: 'Vazgeç',
        }).then((result) => {
            if (result.isConfirmed) {
                // Kullanýcý kaydetmeyi onayladý, Ajax isteðini gönder
                $.ajax({
                    type: "POST",
                    url: "/Offer/SaveRopeIronJson", // Gerçek sunucu adresi ile deðiþtirin
                    data: JSON.stringify(postData),
                    contentType: "application/json; charset=utf-8",
                    success: function (response) {
                        // Sunucunun cevabýný iþleyin (gerekiyorsa)
                        Swal.fire(
                            'Baþarýlý!',
                            'Veri baþarýyla kaydedildi.',
                            'success'
                        );
                        // Baþarýyla kaydedildikten sonra sayfayý yenileyin
                        location.reload();
                    },
                    error: function (error) {
                        Swal.fire(
                            'Hata!',
                            'Veri kaydetme sýrasýnda hata.',
                            'error'
                        );
                    }
                });
            }
        });

    });
    $('#adetInput').focus();

    $(".btn.ankrajKaydet").click(function () {
        var ropeIronCalculates = [];

        $("table.ankraj tbody tr").each(function () {
            var row = $(this);
            var adet = row.find(".adetAnkraj").val();
            var enAnkraj = row.find(".enAnkraj").val();
            var boyAnkraj = row.find(".boyAnkraj").val();
            var kalinlikAnkraj = row.find(".kalinlikAnkraj").val();
            var agirlikAnkraj = row.find(".agirlikAnkraj").val();
            var id = row.find(".id").val();
            if (id == "") {
                id = 0;
            }
            // Create an object with the row data
            var rowData = {
                Id: id,
                Price: parseFloat(adet),
                Length: parseFloat(boyAnkraj),
                Weight: parseFloat(agirlikAnkraj),
                OfferCalculateId: parseInt(modelId), // Set the appropriate OfferCalculateId
                Width: parseFloat(enAnkraj),
                Thick: parseFloat(kalinlikAnkraj),
            };

            if (!isNaN(rowData.Weight)) {
                ropeIronCalculates.push(rowData);
            }
        });
        var ankrajPlakasiTop = $("#ankrajPlakasiTop").val();
        var ankrajPlakasiTopTotal = $("#ankrajPlakasiTopTotal").val();
        var postData = {
            AnkrajIrons: ropeIronCalculates,
            AnkrajIronTop: ankrajPlakasiTop,
            AnkrajIronTopTotal: ankrajPlakasiTopTotal
        };
        $.ajax({
            type: "POST",
            url: "/Offer/SaveAnkrajIronJson", // Gerçek sunucu adresi ile deðiþtirin
            data: JSON.stringify(postData),
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                // Sunucunun cevabýný iþleyin (gerekiyorsa)
                Swal.fire(
                    'Baþarýlý!',
                    'Veri baþarýyla kaydedildi.',
                    'success'
                ).then((result) => {
                    // Kullanýcýya baþarý bildirimi gösterildikten sonra sayfayý yenileyin
                    if (result.isConfirmed) {
                        location.reload();
                    }
                });
            },
            error: function (error) {
                // Ýstek baþarýsýz olursa hatalarý iþleyin
                console.error("Veri kaydedilirken hata oluþtu: " + error);
                Swal.fire(
                    'Hata!',
                    'Veri kaydedilirken bir hata oluþtu.',
                    'error'
                );
            }
        });

    });
    $("#confirm").on("click", function () {
        // Kullanýcýya onay kutusu göster
        Swal.fire({
            title: 'Onay',
            text: 'Hesabýnýz onaylanacak ve geri alýnamayacaktýr. Devam etmek istiyor musunuz?',
            icon: 'question',
            showCancelButton: true,
            confirmButtonText: 'Evet, devam et',
            cancelButtonText: 'Ýptal',
        }).then((result) => {
            if (result.isConfirmed) {
                // Kullanýcý onaylarsa
                var offerId = "@Model.OfferPart.OfferCalculates.FirstOrDefault().Id"; // Modelden gelen OfferId'yi JavaScript deðiþkenine al
                var url = "/Offer/ConfirmCalculate/" + offerId; // Hedef URL'yi oluþtur
                window.location.href = url; // Hedef URL'ye yönlendirme yap
            } else {
                // Kullanýcý onaylamazsa, iþlemi iptal et
                Swal.fire('Ýptal Edildi', 'Ýþlem iptal edildi.', 'error');
            }
        });
        // Kullanýcý onaylamazsa, iþlemi iptal et
    });
    $('.SteelMeshType').each(function () {
        var select = $(this);
        var degerAttr = select.attr("deger");
        console.log(degerAttr);
        // AJAX isteði
        $.ajax({
            url: '/Unit/GetIronDiameterWeight', // Ýsteði doðru URL ile deðiþtirin
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                // Verileri alýndýðýnda seçenekleri doldur
                select.empty();
                select.append($('<option>').text('Seciniz')); // Varsayýlan seçeneði ekle

                // JSON verilerini döngüyle iþle
                $.each(data, function (index, item) {
                    // Her bir veri öðesi için yeni bir seçenek oluþtur

                    var option = $('<option>')
                        .attr('value', item.Id)
                        .text(item.DiameterMM)
                        .attr('weightKg', item.WeightKg);

                    // Eðer option'ýn value deðeri degerAttr ile ayný ise, seçili yap
                    if (item.Id == degerAttr) {
                        option.prop('selected', true);
                    }

                    select.append(option);

                });
            }
        });
    });
    $(".select-checkbox").change(function () {
        if ($(this).prop("checked")) {
            Swal.fire({
                title: 'Emin misiniz?',
                text: "Devam etmek istediðinizden emin misiniz?",
                icon: 'question',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Evet',
                cancelButtonText: 'Ýptal'
            }).then((result) => {
                // Kullanýcý evet derse
                if (result.isConfirmed) {
                    // Seçili satýr bulunuyor
                    var selectedRow = $(this).closest("tr");

                    // Seçili satýrdan deðerler alýnýyor
                    var transferId = selectedRow.find("#transferId").val();
                    var calculateId = selectedRow.find("#calculateId").val();

                    $.ajax({
                        url: '/Offer/TransferCalculate', // Kendi controller ve action yönlendirmenizi güncelleyin
                        type: 'GET',
                        data: {
                            transferId: transferId,
                            calculateId: calculateId,
                        },
                        success: function (data) {
                            // Baþarýlý durumu iþleniyor, örneðin sayfayý yenileyebilirsiniz
                            location.reload();
                        },
                        error: function (error) {
                            // Hata durumu iþleniyor
                            console.error(error);
                        }
                    });
                }
            });
        }
    });

    $(".aktar-button").click(function () {
        // Find the selected row
        var selectedRow = $(this).closest("tr");

        // Retrieve values from the selected row
        var transferId = selectedRow.find("#transferId").val();
        var calculateId = selectedRow.find("#calculateId").val();
        var isChecked = selectedRow.find("input[type='checkbox']").prop("checked");

        // Make an AJAX request to the server
        $.ajax({
            url: '/Offer/TransferCalculate', // Update with your controller and action method
            type: 'GET',
            data: {
                transferId: transferId,
                calculateId: calculateId,
            },
            success: function (data) {
                // Handle success, e.g., refresh the page
                location.reload();
            },
            error: function (error) {
                // Handle error
                console.error(error);
            }
        });
    });
    $(document).on("change", '.ah', function () {
        var $row = $(this).closest('tr');
        var $adetInput = $row.find('#adetInput');
        var $benzerInput = $row.find('#benzerInput');
        var $boyInput = $row.find('#boyInput');
        var $selectedOption = $row.find('#IronDiameterWeight option:selected');
        var $resultInput = $row.find('input[wg="' + $selectedOption.text() + '"]');
        var weightKg = parseFloat($selectedOption.attr('weightkg')) || 0;
        var adet = parseFloat($adetInput.val()) || 0;
        var cap = parseFloat($benzerInput.val()) || 0;
        var boy = parseFloat($boyInput.val()) || 0;
        $row.find('.bm').val('');
        var sonuc = adet * cap * boy * weightKg;
        console.log('Seçilen optionun weightkg deðeri: ' + sonuc);
        $resultInput.val(sonuc);
        updateTotalInceKalin();
        updateTotalPriceTop();
        updateKalinAdetTotal();
        updateToplamDemirBeton();
    });

    $(document).on("click", ".add-row", function () {
        var $table = $("#myTable");
        var $lastRow = $table.find("tr:last");
        var $newRow = $lastRow.clone();
        $newRow.find('input').val(''); // Mevcut satýrýn inputlarýný temizle
        $table.append($newRow);

        // "+" düðmesini ve olaylarý yeniden ata
        $newRow.find(".add-row").on("click", function () {
            $newRow.find(".add-row").trigger("click");
        });

        $(".onlyNumber").inputmask("decimal", {
            radixPoint: ".",
            groupSeparator: "",
            digits: 3,
            autoGroup: true,
            prefix: '',
            rightAlign: false,
            allowMinus: false,
            allowPlus: false,
            placeholder: "0",
        });
        $newRow.find('.ah').on('change', function () {
            var $row = $(this).closest('tr');
            var $adetInput = $row.find('#adetInput');
            var $benzerInput = $row.find('#benzerInput');
            var $boyInput = $row.find('#boyInput');
            var $selectedOption = $row.find('#IronDiameterWeight option:selected');
            var $resultInput = $row.find('input[wg="' + $selectedOption.text() + '"]');
            var weightKg = parseFloat($selectedOption.attr('weightkg')) || 0;
            var adet = parseFloat($adetInput.val()) || 0;
            var cap = parseFloat($benzerInput.val()) || 0;
            var boy = parseFloat($boyInput.val()) || 0;

            var sonuc = adet * cap * boy * weightKg;
            console.log('Seçilen optionun weightkg deðeri: ' + sonuc);
            $resultInput.val(sonuc);
            updateTotalInceKalin();
            updateTotalPriceTop();
            updateKalinAdetTotal();
            updateToplamDemirBeton();
            UstuGuncelleIstegi();
        });
    });
    function updateTotalInceKalin() {
        var totalInce = 0;
        var totalKalin = 0;

        // Tüm satýrlarý dönerek Ince ve Kalýn toplamlarýný hesapla
        $('.ah').each(function () {
            var $row = $(this).closest('tr');
            var $selectedOption = $row.find('#IronDiameterWeight option:selected');
            var weightKg = parseFloat($selectedOption.attr('weightkg')) || 0;
            var cap2 = parseFloat($selectedOption.text()) || 0;
            var adet = parseFloat($row.find('#adetInput').val()) || 0;
            var cap = parseFloat($row.find('#benzerInput').val()) || 0;
            var boy = parseFloat($row.find('#boyInput').val()) || 0;

            var sonuc = adet * cap * boy * weightKg / 5;
            if (cap2 < 14) {
                totalInce += sonuc;
            } else {
                totalKalin += sonuc;
            }
        });

        // Toplam Ince ve Kalýn deðerlerini güncelle
        $('#inceAdet').val(totalInce.toFixed(3));
        $('#kalinAdet').val(totalKalin.toFixed(3));
        UstuGuncelleIstegi();
    }
    function updateTotalPriceTop() {
        var totalInce = parseFloat($('#inceAdet').val()) || 0;
        var totalKalin = parseFloat($('#kalinAdet').val()) || 0;
        var totalPriceTop = parseFloat($('#totalPriceTop').val()) || 0;

        var totalInceAdet = totalInce * totalPriceTop;
        var totalKalinAdet = totalKalin * totalPriceTop;

        $('#inceAdetTotal').val(totalInceAdet.toFixed(3));
        $('#kalinAdetTotal').val(totalKalinAdet.toFixed(3));
        UstuGuncelleIstegi();
    }
    function updateKalinAdetTotal() {
        var birimInce = parseFloat($('#inceAdet').val()) || 0;
        var birimKalin = parseFloat($('#kalinAdet').val()) || 0;

        var birimdekiTotal = birimInce + birimKalin;

        $('#birimDemir').val(birimdekiTotal.toFixed(3));
        UstuGuncelleIstegi();
    }
    function updateToplamDemirBeton() {
        var totalPriceTop = parseFloat($('#totalPriceTop').val()) || 0;
        var birimDemir = $('#birimDemir').val();
        $('#demir').val(birimDemir);
        $('#toplamDemirUst').val((birimDemir * totalPriceTop).toFixed(3));

        var brutBeton = parseFloat($('#brutBeton').val()) || 0;

        var netBetonCalculate = brutBeton - (birimDemir / 7800);
        $('#netBeton').val(netBetonCalculate.toFixed(3));
        $('#toplamNetBeton').val((netBetonCalculate * totalPriceTop).toFixed(3));
        UstuGuncelleIstegi();
    }
    $.get('/Unit/GetToronDiameter', function (data) {
        // Her bir .smt sýnýfýna sahip <select> öðesini iþle

    });
    var rows = $('.hasir tbody tr');

    function calculateRowValues(row) {
        var en = parseFloat(row.find('.en').val()) || 0;
        var boy = parseFloat(row.find('.boy').val()) || 0;
        var benzer = parseFloat(row.find('.benzer').val()) || 0;
        var smt = row.find('.smt').val();
        var ag = en * boy * benzer * smt;
        var formattedResult = ag.toFixed(2); // Son iki basamak hassasiyeti
        row.find('.ag').val(formattedResult);
    }

    function calculateTotal() {
        var totalAg = 0;
        rows.each(function () {
            totalAg += parseFloat($(this).find('.ag').val()) || 0;
        });
        $('.toplam').val(totalAg);
        $('#celikHasirTop').val(totalAg);
        var toplamcarpiAdet = parseFloat(totalAg * $('#totalPriceTop').val()) || 0;
        var formattedResult = toplamcarpiAdet.toFixed(2); // Son iki basamak hassasiyeti
        $('#celikHasirTopTotal2').val(formattedResult);
    }

    rows.find('.en, .boy, .benzer, .smt').on('input', function () {
        var row = $(this).closest('tr');
        calculateRowValues(row);
        calculateTotal();
    });
    var rowsHalat = $('.halat tbody tr');
    function calculateRowValuesHalat(row) {
        var adet = parseFloat(row.find('.adetHalat').val()) || 0;
        var boy = parseFloat(row.find('.boyHalat').val()) || 0;

        var capValue = parseFloat(row.find('.cap option:selected').attr('agirlik')) || 0;
        var agirlik = adet * boy * capValue;
        var formattedResult = agirlik.toFixed(2); // Son iki basamak hassasiyeti
        row.find('.agHalat').val(formattedResult);
    }
    rowsHalat.find('.adetHalat, .boyHalat, .cap').on('input', function () {
        var row = $(this).closest('tr');
        calculateRowValuesHalat(row);
        calculateTotalHalat();
    });
    function calculateTotalHalat() {
        var totalAg = 0;

        rowsHalat.each(function () {
            totalAg += parseFloat($(this).find('.agHalat').val()) || 0;
        });
        $('.toplamHalatTablo').val(totalAg.toFixed(3));
        $('#halatTop').val(totalAg.toFixed(3));
        $('#halatTopTotal').val(totalAg.toFixed(3) * parseInt(modalPrice));
    }
    var rowsAnkraj = $('.ankraj tbody tr');
    function calculateRowValuesAnkraj(row) {
        var adet = parseFloat(row.find('.adetAnkraj').val()) || 0;
        var boy = parseFloat(row.find('.boyAnkraj').val()) || 0;
        var en = parseFloat(row.find('.enAnkraj').val()) || 0;
        var kalinlik = parseFloat(row.find('.kalinlikAnkraj').val()) || 0;
        var agirlik = (adet * boy * kalinlik * en * 7.85) / 10000;
        var formattedResult = agirlik.toFixed(2); // Son iki basamak hassasiyeti
        row.find('.agirlikAnkraj').val(formattedResult);
    }
    rowsAnkraj.find('.adetAnkraj, .boyAnkraj,.enAnkraj,.kalinlikAnkraj').on('input', function () {
        var row = $(this).closest('tr');
        calculateRowValuesAnkraj(row);
        calculateTotalAnkraj();
    });
    function calculateTotalAnkraj() {
        var totalAg = 0;
        rowsAnkraj.each(function () {
            totalAg += parseFloat($(this).find('.agirlikAnkraj').val()) || 0;
        });
        $('.toplamAnkraj').val(totalAg.toFixed(3));
        $('#ankrajPlakasiTop').val(totalAg.toFixed(3));
        $('#ankrajPlakasiTopTotal').val((totalAg.toFixed(3) * parseInt(modalPrice)).toFixed(3));
    }

    $(".ah").keypress(function (event) {
        // Eðer basýlan tuþ enter ise (keyCode 13), "Kaydet" iþlevini tetikle
        if (event.which === 13) {
            // "Kaydet" iþlevini çaðýr
            $(this).closest("tr").find(".topTable").click();
        }
    });
    $(".onlyNumber").inputmask("decimal", {
        radixPoint: ".",
        groupSeparator: "",
        digits: 3,
        autoGroup: true,
        prefix: '',
        rightAlign: false,
        allowMinus: false,
        allowPlus: false,
        placeholder: "0",
    });
    $(".topTable").on("click", function () {

        var $tr = $(this).closest("tr");
        var projectElementId = parseInt(modelId); // Make sure you get the value of Model.Id from C# properly

        var totalWeightFields = $tr.find('.bm'); // Select all input fields with the "bm" class
        var isDataValid = false; // Initialize as false

        totalWeightFields.each(function () {
            var fieldValue = $(this).val();
            if (fieldValue !== "" && parseFloat(fieldValue) !== 0) {
                isDataValid = true; // Set to true if at least one field is not empty or not equal to 0
                return false; // Exit the loop early if a valid field is found
            }
        });

        if (!isDataValid) {
            Swal.fire({
                title: "Lütfen Tüm Alanlarý Doldurunuz!",
                icon: "error", // "danger" yerine "error" kullanýlýr
                confirmButtonText: 'Tamam'
            });

            // Display an error message or take appropriate action
            return;
        }

        // Calculate the total weight based on the values in the "bm" fields
        var totalWeight = 0;
        totalWeightFields.each(function () {
            var fieldValue = $(this).val();
            if (fieldValue !== "" && parseFloat(fieldValue) !== 0) {
                totalWeight += parseFloat(fieldValue);
            }
        });

        var projectElementDetails = {
            Id: $tr.find(".itemid").val(),
            OfferCalculateId: projectElementId,
            PozNumber: $tr.find(".pozNumber").val(),
            Price: $tr.find(".Price").val(),
            Similar: $tr.find(".similar").val(),
            Size: parseFloat($tr.find(".Size").val()),
            TotalWeight: parseFloat(totalWeight), // Use the calculated total weight
            IronDiameterWeightId: $tr.find(".SteelMeshType").val()
        };
        var demir = $("#demir").val();
        var toplamDemirUst = $("#toplamDemirUst").val();
        var netBeton = $("#netBeton").val();
        var toplamNetBeton = $("#toplamNetBeton").val();

        var requestData = {
            ProjectElementDetails: projectElementDetails,
            NetIron: parseFloat(demir),
            NetIronTotal: parseFloat(toplamDemirUst),
            Concrete: parseFloat(netBeton),
            NetConcreteTotal: parseFloat(toplamNetBeton)
        };
        $.ajax({
            type: "POST",
            url: "/Offer/SaveProjectDetailJson", // Replace with the correct controller endpoint
            data: JSON.stringify(requestData),
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                // Handle success
                window.location.href = "/Offer/DetailCalculate/" + modelId; // Redirect to another page if needed
            },
            error: function (error) {
                // Handle error
                console.error("Error occurred: " + error);
            }
        });
    });

});

