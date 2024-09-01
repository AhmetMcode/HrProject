
$(document).ready(function () {
    // Quantity input alanlarını seç
    var quantityInputs = $('.quantitySelect');

    // Input değiştiğinde kontrolü yap
    quantityInputs.on('input', function () {
        // Girilen değeri al
        var inputValue = $(this).val();

        // Sayısal bir değer değilse
        if (!/^[0-9]*\.?[0-9]+$/.test(inputValue)) {
            // Sayısal olmayan karakterleri temizle
            $(this).val(inputValue.replace(/[^0-9\.]/g, ''));
        }
    });
});




$('.stockSelect').change(function () {
    var selectedStockId = $(this).val();
    var tr = $(this).closest('tr'); // Seçili select'in bulunduğu satırı al

    $.ajax({
        url: '/Stock/GetStock',
        type: 'GET',
        data: { stockId: selectedStockId },
        success: function (data) {
            // Başarılı olduğunda dönen verileri kullan
            var unitSelect = tr.find('.unitSelect'); // Satırdaki unit select'i al

            // Önce mevcut seçenekleri temizle
            unitSelect.empty();

            // Dönen verilerle select'i doldur
            $.each(data, function (index, unit) {
                debugger;
                unitSelect.append($('<option></option>').attr('value', unit.Id).text(unit.UnitName));
            });
        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('Hata:', error);
        }
    });
});


var selectedCariId;
$(document).ready(function () {

    var personelRadio = $('#Personel');
    var tasiyiciRadio = $('#Tasiyici');
    var kargoRadio = $('#Kargo');
    var addDriverBtn = $('#addDriverBtn');
    var personelCars = $('#personelCars');
    var personelNameDetails = $('#personelNameDetails');
    var tasiyiciCars = $('#tasiyiciCars');
    var vehicleInfo = $('#vehicleInfo');
    var addDriverBtn = $('#addDriverBtn');
    var driverDetails = $('#driverDetails');
    var kargoCompany = $('#kargoCompany');
    var cargoCompany = $('#cargoCompany');
    var taxNumber = $('#taxNumber');

    var isFirstClick = true;

    // Şoför ekle butonuna tıklanınca gerekli işlemleri yap
    addDriverBtn.click(function () {
        if (isFirstClick) {
            addDriverBtn.hide();
            isFirstClick = false;
        }
        driverDetails.show(); // Örnek: Şoför detaylarını göster
    });

    personelRadio.change(function () {
        if (personelRadio.is(':checked')) {
            personelCars.show();
            personelNameDetails.show();
            addDriverBtn.hide();
            tasiyiciCars.hide();
            driverDetails.hide();
            kargoCompany.hide();
        }
    });

    tasiyiciRadio.change(function () {
        if (tasiyiciRadio.is(':checked')) {
            tasiyiciCars.show();
            personelCars.hide();
            addDriverBtn.show();
            personelNameDetails.hide();
            driverDetails.hide();
            kargoCompany.hide();
        }
    });

    kargoRadio.change(function () {
        if (kargoRadio.is(':checked')) {
            kargoCompany.show();
            personelCars.hide();
            personelNameDetails.hide();
            addDriverBtn.hide();
            tasiyiciCars.hide();
            driverDetails.hide();
        }
    });

    addDriverBtn.click(function () {
        driverDetails.show();
    });

    // Satır eklemek için
    $(".add-row").click(function () {
        var lastRow = $("#myTable tbody tr:last");
        var newRow = lastRow.clone();

        // Remove selected options from cloned row
        newRow.find('.stockSelect option:selected').removeAttr('selected');

        // Remove stockSelect element from the cloned row
        newRow.find('.stockSelect').remove();

        // Update values for new row
        newRow.find('.unitSelect').val(''); // Set the value to an empty string or whatever default you want
        newRow.find('.quantitySelect').val(''); // Set the value to an empty string or whatever default you want

        var lastUnitId = 0;
        var lastQuantityId = 0;
        var lastUnitName = lastRow.find('.unitSelect').attr('name');
        var lastQuantityName = lastRow.find('.quantitySelect').attr('name');

        if (lastUnitName) {
            lastUnitId = parseInt(lastUnitName.match(/\d+/)[0]);
        }
        if (lastQuantityName) {
            lastQuantityId = parseInt(lastQuantityName.match(/\d+/)[0]);
        }

        var newUnitId = lastUnitId + 1;
        var newQuantityId = lastQuantityId + 1;
        var newSelect = $('<select class="form-control stockSelect" name="OutWaybillChanges[' + newUnitId + '].StockId"></select>');

        // AJAX call to fetch the stock data
        $.ajax({
            url: '/Stock/GetStocksJsonOnlyStock', // Uygun URL'i buraya yazın
            type: 'GET',
            success: function (data) {
                $.each(data, function (index, stock) {
                    newSelect.append('<option value="' + stock.Id + '">' + stock.Code + ' - ' + stock.Name + ' - ' + stock.Barcode + '</option>');
                });

                // Add the new select element to the new row
                newRow.find('td:eq(0)').append(newSelect);

                // Update the new row with the correct names for the selects
                newRow.find('.unitSelect').attr('name', 'OutWaybillChanges[' + newUnitId + '].UnitId');
                newRow.find('.quantitySelect').attr('name', 'OutWaybillChanges[' + newQuantityId + '].Quantity');

                $("#myTable tbody").append(newRow);
            },
            error: function (xhr, status, error) {
                console.log('Stok verileri alınırken hata oluştu: ' + error);
            }
        });
    });





    // Satırı silmek için
    $('tbody').on('click', '.delete-row', function () {
        var rowCount = $(this).closest('table').find('tbody tr').length;

        if (rowCount > 1) {
            $(this).closest('tr').remove();
        } else {
            alert("Tabloda en az bir satır olmalı!");
        }
    });
    var originalBoxShadow = $('.stockNameSelect').css('box-shadow');




    $.ajax({

        type: "GET",
        url: "/Waybill/GetCarikartJson",
        dataType: "json",
        success: function (data) {
            var datalist = document.getElementById("cariName");
            for (var i = 0; i < data.length; i++) {
                var option = document.createElement("option");
                option.value = data[i].Title;
                option.text = data[i].TaxNumber;
                datalist.appendChild(option);
            }

            var originalBoxShadow = $('#cariNameSelect').css('box-shadow');

            // Input değiştiğinde kontrolü yap
            $('#cariNameSelect').on('input', function () {
                var inputVal = $(this).val();
                var isValueInDatabase = data.some(function (item) {
                    return item.Title === inputVal || item.TaxNumber === inputVal;
                });

                if (isValueInDatabase) {
                    // Eğer veri tabanında varsa, selectedCariId'yi set et
                    selectedCariId = data.find(function (item) {
                        return item.Title === inputVal || item.TaxNumber === inputVal;
                    }).Id;

                } else {
                    // Eğer veri tabanında yoksa, selectedCariId'yi sıfırla veya başka bir değer ata
                    selectedCariId = null; // Örneğin sıfırlama
                }
                // Veritabanında olmayan bir değer girildiyse shadow'u kırmızıya çevir
                var isValueNotInDatabase = !data.some(function (item) {
                    return item.Title === inputVal || item.TaxNumber === inputVal;
                });

                if (isValueNotInDatabase) {
                    $(this).css('box-shadow', '0 0 10px red');
                } else {
                    $(this).css('box-shadow', originalBoxShadow);
                }

            });

            // Model'den gelen değeri set et
            var selectedCode = '@(Model != null && Model.CariKart != null ? Model.CariKart.Title : "")';
            $('#cariNameSelect').val(selectedCode);

        },
        error: function (error) {
            console.log("Hata oluştu: " + error);
        }
    });
    $.ajax({
        type: "GET",
        url: "/Waybill/GetStockJson",
        dataType: "json",
        success: function (data) {
            var datalist = document.getElementById("stockName");
            for (var i = 0; i < data.length; i++) {
                var option = document.createElement("option");
                option.value = data[i].Name; // Changed from Title to Name
                datalist.appendChild(option);
            }
            $('.stockNameSelect').on('input', function () {
                var inputVal = $(this).val();
                debugger;
                // Veritabanında olmayan bir değer girildiyse shadow'u kırmızıya çevir
                var isValueNotInDatabase = !data.some(function (item) {
                    return item.Name === inputVal; // Changed from Title to Name
                });

                if (isValueNotInDatabase) {
                    $(this).css('box-shadow', '0 0 10px red');
                } else {
                    $(this).css('box-shadow', originalBoxShadow);
                }
            });

        },
        error: function (error) {
            console.log("Hata oluştu: " + error);
        }
    });

    var citySelect = $("#citySelect");
    var districtSelect = $("#districtSelect");


    // Seçilen şehre göre ilçeleri doldurma
    citySelect.on("change", function () {
        districtSelect.empty(); // Ilçe seçeneklerini temizle

        var selectedCityId = $(this).val();
        if (selectedCityId) {
            $.ajax({
                type: "GET",
                url: "/Offer/GetDistrictsJson", // İsteği doğru URL ile değiştirin
                data: { cityId: selectedCityId },
                dataType: "json",
                success: function (data) {
                    // İlk seçeneği ekleyin
                    districtSelect.append($("<option></option>").val("").text("İlçe Seçiniz"));
                    // Ilçe verilerini ilçe seçim alanına ekleyin
                    for (var i = 0; i < data.length; i++) {
                        districtSelect.append($("<option></option>").val(data[i].Id).text(data[i].Name));
                    }
                },
                error: function (error) {
                    console.log("Hata oluştu: " + error);
                }
            });
        }
    });

    var citySelect2 = $("#citySelect2");
    var districtSelect2 = $("#districtSelect2");


    // Seçilen şehre göre ilçeleri doldurma
    citySelect2.on("change", function () {
        districtSelect2.empty(); // Ilçe seçeneklerini temizle

        var selectedCityId = $(this).val();
        if (selectedCityId) {
            $.ajax({
                type: "GET",
                url: "/Offer/GetDistrictsJson", // İsteği doğru URL ile değiştirin
                data: { cityId: selectedCityId },
                dataType: "json",
                success: function (data) {
                    // İlk seçeneği ekleyin
                    districtSelect2.append($("<option></option>").val("").text("İlçe Seçiniz"));
                    // Ilçe verilerini ilçe seçim alanına ekleyin
                    for (var i = 0; i < data.length; i++) {
                        districtSelect2.append($("<option></option>").val(data[i].Id).text(data[i].Name));
                    }
                },
                error: function (error) {
                    console.log("Hata oluştu: " + error);
                }
            });
        }
    });

    // $('.cariSelect').change(function () {
    //     var selectedOption = $(this).find(':selected');
    //     var selectedCariId = selectedOption.attr('id');
    //     console.log('Selected Cari Id:', selectedCariId);
    // });

    $('#sameAddressCheckbox').change(function () {
        var isChecked = $(this).prop('checked');

        if (isChecked) {
            // Cari Kart ID'sini al
            var cariKartId = $('.cariSelect').selectpicker('val');

            if (cariKartId) {
                // Checkbox seçildiğinde ve CariKartId seçili olduğunda Ajax ile verileri çek
                $.ajax({
                    type: "GET",
                    url: "/Waybill/GetInvoiceAddress",
                    data: { id: cariKartId },
                    dataType: "json",
                    success: function (data) {


                        // DefaultAddress === true olan adresi bul
                        var defaultAddress = null;

                        for (var i = 0; i < data.InvoiceAdresses["$values"].length; i++) {

                            if (data.InvoiceAdresses["$values"][i].DefaultAddress === true) {

                                defaultAddress = data.InvoiceAdresses["$values"][i];
                                break; // DefaultAddress === true bulundu, döngüden çık
                            }
                        }


                        if (defaultAddress) {
                            // DefaultAddress === true olan adres bulundu, devam edebilirsiniz
                            $('#adress1').val(defaultAddress.Adress).prop('disabled', true);
                            $('#entrypostacodeSelect').val(defaultAddress.PostaCode).prop('disabled', true);

                            // var cityName = defaultAddress.City.Name;
                            // $('#citySelect').val(cityName).prop('disabled', true);

                            var citySelect = $('#citySelect');
                            citySelect.empty();
                            var cityName = defaultAddress.City.Name;
                            var cityId = defaultAddress.City.Id;
                            citySelect.append('<option value="' + cityId + '">' + cityName + '</option>').val(cityId);
                            citySelect.prop('disabled', true);

                            // İlçe seçeneklerini doldur
                            var districtSelect = $('#districtSelect');
                            districtSelect.empty();
                            var districtName = defaultAddress.District.Name;
                            var districtId = defaultAddress.District.Id;
                            districtSelect.append('<option value="' + districtId + '">' + districtName + '</option>').val(districtId);
                            districtSelect.prop('disabled', true);

                            // Adres bilgilerini readonly yap
                            $('#adress1').prop('readonly', true);
                        } else {
                            // DefaultAddress === true olan adres bulunamadı, gerekli işlemleri yapabilirsiniz
                        }
                    },
                    error: function (xhr, textStatus, errorThrown) {
                        console.log("Hata oluştu: " + errorThrown);
                        console.log("Detaylı bilgi: " + xhr.responseText);
                    }
                });
            }
        } else {
            // Checkbox seçilmediğinde adres bilgilerini readonly kaldır
            $('#adress1, #entrypostacodeSelect, #districtSelect, #citySelect').val('').prop('disabled', false);
            $('#adress1').prop('readonly', false);
        }
    });




    // Cari kart seçildiğinde ve edit date seçildiğinde updateWaybillNo fonksiyonunu çağır
    $('#cariKartSelect').select2({
        placeholder: "Cari Kart Seçiniz",
        allowClear: true
    });
    $(document).on('change', '.cariNameSelect, #editDate', function () {

        if ($('.cariNameSelect').val() !== '' && $('#editDate').val() !== '') {
            debugger;
            updateWaybillNo();
        }

    });
    function updateWaybillNo() {
        debugger;
        var cariKartId = $('.cariNameSelect:selected').attr('id').split('_')[1];
        // Cari kart ID'sini uygun şekilde al
        var editDate = $('#editDate').val(); // Edit date değerini uygun şekilde al
        $.ajax({
            url: '/Waybill/UpdateWaybillNo',
            type: 'GET',
            data: { cariKartId: cariKartId, editDate: editDate },
            success: function (result) {
                // Başarılı yanıt alındığında waybillNo alanına yaz
                $('#waybillNo').val(result);

                // Diğer işlemleri burada gerçekleştir
            },
            error: function (error) {
                // Hata durumunda işlemleri gerçekleştir
                console.log('Hata oluştu: ' + error.statusText);
            }
        });
    }
    $.ajax({
        url: '/CariKart/IndexJson', // Verileri çekeceğiniz URL'yi belirtin
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            // AJAX başarılı olduğunda verileri <select> içine doldur
            var select = $('#cariKartSelect');
            select.empty(); // Mevcut seçenekleri temizle

            // Boş seçeneği ekleyin
            select.append($('<option>').val('').text('Cari Kart Seçiniz'));

            // Veritabanından gelen verilerle <select> doldur
            $.each(data, function (index, item) {
                select.append($('<option>').val(item.Id).text(item.Title));
            });
        },
        error: function () {
            console.error('Veri alınamadı.');
        }
    });

});

