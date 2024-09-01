$(document).ready(function () {
    var formulas = [];
    tumSatirlariGuncelle();
    formulleriUygula1();
    calculateAdetTirDolly();
    var nakliyeRayic = 0;
    $('.formuls').each(function () {
        var formula = $(this).val();
        formulas.push(formula);
    });
    $('.savetd').each(function () {
        var currentValue = parseFloat($(this).find('.currentValue').val());
        var suanFiyatRayic = parseFloat($(this).find('.suanFiyatRayic').val());
        var inputElement = $(this).find('.currentValue');
       
        if (currentValue > suanFiyatRayic) {
            inputElement.after('<span class="mouseover-span">' + suanFiyatRayic +'</span>');

            inputElement.css('background-color', 'lightcoral');
        } else if (currentValue < suanFiyatRayic) {
            inputElement.css('background-color', 'lightgreen');
            inputElement.after('<span class="mouseover-span">' + suanFiyatRayic + '</span>');
            
        } else {
            inputElement.css('background-color', 'lightblue');
        }
    });

    function calculateTotalConcrete() {
        var totalConcrete = 0;
        $('tbody tr').each(function () {
            if ($(this).text().includes('BETON')) {
                var inputString = $(this).find('.quantity.used').val();
                var modifiedString = inputString.replace(/,/g, ''); // Tüm virgülleri boþluklarla deðiþtir
                
                var quantity = parseFloat(modifiedString);
                if (!isNaN(quantity)) {
                    totalConcrete += quantity;
                }
            }
        });
        return totalConcrete;
    }

    function calculateAdetTirDolly() {
        
        var standardTIR = parseFloat($('#standardTIR').inputmask('unmaskedvalue'));
        var standardTIRAdet = Math.ceil((standardTIR * 2.5) / 25);
        var dollyDorse = parseFloat($('#dollyDorse').inputmask('unmaskedvalue'));
        var dollyDorseAdet = Math.ceil((dollyDorse * 2.5) / 50);

        $('#standartTirAdet').val(standardTIRAdet);
        $('#dollyDorseAdet').val(dollyDorseAdet);
        debugger;
        var akaryakitBedeli = parseFloat($('#AkaryakitFiyati').val());
        var km = parseFloat($('#km').val());
        var mesafeK = parseFloat($('#egimKatsayisi').val());
        var egimK = parseFloat($('#MesafeKatsayisi').val());
        var sonuc = (km * 2 * 0.799 * akaryakitBedeli * mesafeK * 1.5 * egimK);
        var sonucDoly = (km * 2 * 1.105 * mesafeK * akaryakitBedeli * 1.5 * egimK);
        var tirBedel = sonuc * standardTIRAdet;
        var dolyBedel = sonucDoly * dollyDorseAdet;
        var bx20 = tirBedel;
        var bx21 = standardTIRAdet;
        var bz20 = dolyBedel;
        var bz21 = dollyDorseAdet;
        var result = 0;
        debugger;
        if (bx20 === 0) {
            result += 0;
        } else {
            if (sonuc < (1438 * 1.5) || sonucDoly < (1990 * 1.5) && bx20 != 0 && bz20 != 0) {
                result += ((1438 * 1.5) * standardTIRAdet);
            }
            else {
                result += bx20;
            }
        }

        if (bz20 === 0) {
            result += 0;
        } else {
            if (sonucDoly < (1990 * 1.5)) {

                result += ((1990 * 1.5) * dollyDorseAdet);
            }
            else {
                result += bz20;
            }
        }

        $('tbody tr').each(function () {
            if ($(this).text().includes('Nakliye Bedeli')) {
                $(this).find('.amount').val(result);
                $(this).find('.quantity').val(result);
            }
        });
    }
    $('#standardTIR').on('input', function () {
        var standardTIR = parseFloat($('#standardTIR').val());
        calculateAdetTirDolly();
    });
    $('#dollyDorse').on('input', function () {

        var dollyDorse = parseFloat($('#dollyDorse').val());
        calculateAdetTirDolly();

    });
    $(".quantity, .currentValue, .wastage, .change, .enflasyon").on("change", function () {
        var row = $(this).closest('tr');
        var detId = row.find(".detailId").val();
        tumSatirlariGuncelle();
        formulleriUygula1();
    });
    function formulleriUygula1() {
        $('tr.savetd').each(function () {
            var isFormula = $(this).find('.isFormula').val() === 'true';

            if (isFormula) {
                var detailId = $(this).find('.detailId').val();
                var formul = $(this).find('.formuls').val();
                var parantezIcerik = formul.match(/\(([^)]+)\)/);
                var carpimSonrasiFloat = formul.match(/\*\s*([0-9]*\.?[0-9]+)/);
                var floatDeger = 0;
                if (carpimSonrasiFloat) {

                    floatDeger = parseFloat(carpimSonrasiFloat[1]);
                    // Þimdi 'floatDeger' ile istediðiniz iþlemleri yapabilirsiniz
                }
                if (parantezIcerik) {
                    var icIcerik = parantezIcerik[1];
                    var parcalanmisIslem = icIcerik.split('+');
                    // Ýþlemi yapmak için gerekli adýmlarý uygulayalým
                    if (parcalanmisIslem.length === 2) {
                        var birinci = parseFloat(parcalanmisIslem[0]);
                        var ikinci = parseFloat(parcalanmisIslem[1]);
                        var birinciQuantity = $(".currentValueId[value='" + birinci + "']").closest('tr').find('.quantity').val();
                        var ikinciQuantity = $(".currentValueId[value='" + ikinci + "']").closest('tr').find('.quantity').val();
                        var quant = parseFloat(birinciQuantity) + parseFloat(ikinciQuantity);
                        quant = parseFloat(quant * floatDeger);
                        $(this).find(".quantity").val(quant);
                    }
                }
            }
        });
        tumSatirlariGuncelle();
    }



    function tumSatirlariGuncelle() {
        $('.table .savetd').each(function () {
            var $row = $(this);
            var adet = parseFloat($row.find(".quantity").inputmask('unmaskedvalue'));
            var birimFiyat = parseFloat($row.find(".currentValue").inputmask('unmaskedvalue'));
            var fire = parseFloat($row.find(".wastage").inputmask('unmaskedvalue'));

            var enflasyon = parseFloat($row.find(".enflasyon").inputmask('unmaskedvalue') / 100);
            var tutar = (adet * birimFiyat) * (1 + (fire / 100));
            tutar = tutar + (tutar * enflasyon);
            $row.find(".amount").val(tutar);
            var currentValueInput = $row.find(".currentValue");
            var percentInput = $row.find(".percent");
            var currentValue = currentValueInput.inputmask('unmaskedvalue');
            var currentfloatValue = parseFloat(currentValue);
            var quantInput = $row.find(".quantity");
            var quantValue = quantInput.inputmask('unmaskedvalue');
            var quantfloatValue = parseFloat(quantValue);
            var genelToplamInput = $(".subTotalAmaount");
            var genelToplamValue = genelToplamInput.inputmask('unmaskedvalue');
            var genelToplam = parseFloat(genelToplamValue);
            var yuzde = 0;
            yuzde = (tutar / genelToplam) * 100;
            percentInput.val(yuzde);
        });
        $('.deger').each(function () {
            var table = $(this);
            tabloyuGuncelle(table);
        });

    }
    function tabloyuGuncelle(table) {
        var totalAmount = 0;
        table.find('tr').each(function () {
            var $row = $(this);
            var tutar = parseFloat($row.find(".amount").inputmask('unmaskedvalue')) || 0;
            totalAmount += tutar;
        });
        table.find(".totalAmount").val(totalAmount);
        var genelToplam = 0;
        genelToplamGuncelle();

    }
    function genelToplamGuncelle() {
        var genelToplam = 0;
        $('.table tr').each(function () {
            var $row = $(this);
            var currentValueInput = $row.find(".totalAmount");
            if (currentValueInput == undefined) {
                return;
            }
            var currentValue = currentValueInput.inputmask('unmaskedvalue');
            if (currentValue == undefined) {
                return;
            }
            if (currentValue == "") {
                return;
            }
            var currentfloatValue = parseFloat(currentValue);
            genelToplam += currentfloatValue;
        });
        $(".subTotalAmaount").val(genelToplam);
    }

    $('.onlyNumber').inputmask('numeric', {
        radixPoint: '.',
        groupSeparator: ',',
        autoGroup: true,
        digits: 2,
        digitsOptional: false,
        placeholder: '0',
    });



    $("#saveButton").on("click", function () {
        var data = [];
        $(".deger tr ").each(function () {
            var row = $(this);
            var detailId = row.find(".detailId").val();
            if (detailId == null || detailId == "") {
                return true;
            }
            var currentValueInput = row.find(".currentValue");
            var currentValue = currentValueInput.inputmask('unmaskedvalue');
            var currentFloatValue = parseFloat(currentValue) || 0;

            var quantityInput = row.find(".quantity");
            var quantity = quantityInput.inputmask('unmaskedvalue');
            var quantityFloat = parseFloat(quantity) || 0;
            var enflasyonInput = row.find(".enflasyon");
            var enflasyon = enflasyonInput.inputmask('unmaskedvalue');
            var enflasyonFloat = parseFloat(enflasyon) || 0;
            var amount = (quantityFloat * currentFloatValue).toFixed(2);
            var percent = parseFloat(row.find(".percent").val());
            var wastage = parseFloat(row.find(".wastage").val());

            data.push({
                Id: detailId,
                Quantity: quantity,
                CurrentValueC: currentValue,
                Amount: amount,
                Enflasyon: enflasyon,
                Percent: percent,
                Wastage: wastage
            });
        });
        var offerPart = {
            Id: parseInt($("input[name='Id']").val()) || 0,
            PartName: $("#partName").val(),
            StandartTir: parseFloat($("#standardTIR").inputmask('unmaskedvalue')) || 0,
            StandartTirAdet: parseFloat($("#standartTirAdet").inputmask('unmaskedvalue')) || 0,
            DollyDorse: parseFloat($("#dollyDorse").inputmask('unmaskedvalue')) || 0,
            DollyDorseAdet: parseFloat($("#dollyDorseAdet").inputmask('unmaskedvalue')) || 0,
            Miktar: parseFloat($("#Miktar").inputmask('unmaskedvalue')) || 0,
            VkAdet: parseFloat($("#VkAdet").inputmask('unmaskedvalue')) || 0,
            CpMetreKare: parseFloat($("#CpMetreKare").inputmask('unmaskedvalue')) || 0
        };
        var OfferCostCalculateDetailJson = {
            OfferPart: offerPart,
            OfferCostCalculateDetailJson: data
        };
        var jsonData = JSON.stringify(OfferCostCalculateDetailJson); // Convert data to JSON string

        console.log(data);
        console.log(jsonData);
        // Ajax isteði gönderme
        Swal.fire({
            title: "Kaydet",
            text: "Kaydetmek istediðinizden emin misiniz?",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Evet, Kaydet",
            cancelButtonText: "Vazgeç",
            dangerMode: true
        }).then((result) => {
            if (result.isConfirmed) {
                // JSON verisi 'jsonData' deðiþkeninde saklanmalý. Örneðin:
                // var jsonData = JSON.stringify({ anahtar: "deðer" });

                $.ajax({
                    type: "POST",
                    url: "/Offer/SaveJsonOfferCostDetail", // Controller ve action ismini buraya ekleyin
                    contentType: "application/json; charset=utf-8",
                    data: jsonData, // Bu 'jsonData' deðiþkeni AJAX isteðinde gönderilecek veridir.
                    success: function (response) {
                        if (response === "ok") {
                            // Ýþlem baþarýlý mesajý
                            Swal.fire({
                                title: "Baþarýlý!",
                                text: "Ýþlem baþarýyla tamamlandý.",
                                icon: "success"
                            }).then((value) => {
                                location.reload(); // Kullanýcý 'OK' tuþuna bastýðýnda sayfayý yenile
                            });
                        } else {
                            // Baþarýsýz iþlem mesajý
                            Swal.fire("Hata!", "Bir hata oluþtu.", "error");
                        }
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        // AJAX isteði sýrasýnda bir hata oluþtu
                        Swal.fire("Hata!", "Ýþlem sýrasýnda bir hata oluþtu: " + xhr.responseText, "error");
                    }
                });
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire("Ýptal Edildi", "Ýþlem iptal edildi.", "info");
            }
        });

    });
});

//$("#saveButton").on("click", function () {
//    var details = [];
//    $(".deger tr").each(function () {
//        var row = $(this);
//        var detailId = parseInt(row.find(".detailId").val()) || 0;
//        if (!detailId) {
//            return true; // Skip rows without a detail ID
//        }

//        var currentValueInput = row.find(".currentValue");
//        var currentValue = parseFloat(currentValueInput.inputmask('unmaskedvalue')) || 0;

//        var quantityInput = row.find(".quantity");
//        var quantity = parseFloat(quantityInput.inputmask('unmaskedvalue')) || 0;

//        var enflasyonInput = row.find(".enflasyon");
//        var enflasyon = parseFloat(enflasyonInput.inputmask('unmaskedvalue')) || 0;

//        var amount = parseFloat((quantity * currentValue).toFixed(2));
//        var percent = parseFloat(row.find(".percent").val()) || 0;
//        var wastage = parseFloat(row.find(".wastage").val()) || 0;

//        details.push({
//            Id: detailId,
//            Quantity: quantity,
//            CurrentValueC: currentValue,
//            Amount: amount,
//            Enflasyon: enflasyon,
//            Percent: percent,
//            Wastage: wastage
//        });
//    });
//    var offerPart = {
//        Id: parseInt($("input[name='Id']").val()) || 0,
//        PartName: $("#partName").val(),
//        StandartTir: parseFloat($("#standardTIR").val()) || 0,
//        StandartTirAdet: parseFloat($("#standartTirAdet").val()) || 0,
//        DollyDorse: parseFloat($("#dollyDorse").val()) || 0,
//        DollyDorseAdet: parseFloat($("#dollyDorseAdet").val()) || 0,
//        Miktar: parseFloat($("#Miktar").val()) || 0,
//        VkAdet: parseFloat($("#VkAdet").val()) || 0,
//        CpMetreKare: parseFloat($("#CpMetreKare").val()) || 0
//    };

//    var OfferCostCalculateDetailJson = {
//        OfferPart: offerPart, // Burasý gerektiði gibi doldurulmalýdýr.
//        OfferCostCalculateDetailJson: details
//    };

//    var vm = JSON.stringify(OfferCostCalculateDetailJson);

//    console.log(vm);
//    // Ajax isteði gönderme
//    Swal.fire({
//        title: "Kaydet",
//        text: "Kaydetmek istediðinizden emin misiniz?",
//        icon: "warning",
//        showCancelButton: true,
//        confirmButtonText: "Evet, Kaydet",
//        cancelButtonText: "Vazgeç",
//        dangerMode: true
//    }).then((result) => {
//        if (result.isConfirmed) {
//            $.ajax({
//                type: "POST",
//                url: "/Offer/SaveJsonOfferCostDetail", // Doðru URL'yi kullanýn
//                contentType: "application/json; charset=utf-8",
//                data: vm,
//                success: function (response) {
//                    Swal.fire({
//                        title: "Baþarýlý!",
//                        text: "Ýþlem baþarýyla tamamlandý.",
//                        icon: "success"
//                    }).then(() => {
//                        location.reload();
//                    });
//                },
//                error: function (xhr, ajaxOptions, thrownError) {
//                    Swal.fire("Hata!", "Ýþlem sýrasýnda bir hata oluþtu: " + xhr.responseText, "error");
//                }
//            });
//        } else if (result.dismiss === Swal.DismissReason.cancel) {
//            Swal.fire("Ýptal Edildi", "Ýþlem iptal edildi.", "info");
//        }
//    });
//});