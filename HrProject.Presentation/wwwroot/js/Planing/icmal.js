$(document).ready(function () {
    // Her bir satırı döngüye al
    $("table.table tbody tr").each(function () {
        // Hesaplamaları yeniden yap fonksiyonu
        function hesaplamalariYenidenYap(satir) {
            var birimMaaliyet = parseFloat(satir.find("td:eq(2) input").val().replace(/,/g, ""));
            var sozlesmeMetraj = parseFloat(satir.find("td:eq(4) input").val().replace(/,/g, ""));
            var projeMetraj = parseFloat(satir.find("td:eq(5) input").val().replace(/,/g, ""));
            var uretilenMetraj = parseFloat(satir.find("td:eq(6) input").val().replace(/,/g, ""));
            var durum = satir.find("td:eq(3)").text().trim();

            if (isNaN(birimMaaliyet)) {
                birimMaaliyet = 0;
            }

            // Üretilmiş maaliyet hesapla
            var uretilmisMaaliyet = 0;
            if (durum === 'Başladı') {
                uretilmisMaaliyet = birimMaaliyet * uretilenMetraj;
            }

            // Kalan metrajı hesapla
            var kalanMetraj = projeMetraj - uretilenMetraj;

            // Diğer maaliyetleri hesapla
            var uretilmisMaliyet = birimMaaliyet * uretilenMetraj;
            var kalanMaliyet = birimMaaliyet * kalanMetraj;
            var toplamMaliyetSozlesme = birimMaaliyet * sozlesmeMetraj;
            var toplamMaliyetProje = birimMaaliyet * projeMetraj;
            debugger;
            // Değerleri tabloya yaz
            satir.find("td:eq(7) input").val(kalanMetraj);
            satir.find("td:eq(8) input").val(uretilmisMaaliyet);
            satir.find("td:eq(9) input").val(kalanMaliyet);
            satir.find("td:eq(10) input").val(toplamMaliyetSozlesme);
            satir.find("td:eq(11) input").val(toplamMaliyetProje);
        }

        // İnput değer değiştiğinde hesaplamaları yeniden yap
        $(this).find("input").on('input', function () {
            hesaplamalariYenidenYap($(this).closest('tr'));
        });

        // İlk hesaplamarı yap
        hesaplamalariYenidenYap($(this));
    });

    $(".onlynumber").inputmask("decimal", {
        radixPoint: ".",
        groupSeparator: ",",
        digits: 3,
        autoGroup: true,
        prefix: '',
        rightAlign: false,
        allowMinus: false,
        allowPlus: false,
        placeholder: "0",
    });
});