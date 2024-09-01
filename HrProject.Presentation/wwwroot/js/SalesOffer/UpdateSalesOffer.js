
$(document).ready(function () {
    $('tbody tr').each(function () {
        var row = $(this);
        calculateAll(row);
    });
    calculateSub();

    /*$(".onlyNumber").inputmask("decimal", { min: 0, max: Infinity, allowMinus: true });*/

    $(".onlyNumber").inputmask("decimal", {
        radixPoint: ".",
        groupSeparator: ",",
        digits: 2,
        autoGroup: true,
        prefix: '',
        rightAlign: false,
        allowMinus: false,
        allowPlus: false,
        placeholder: "0",
        groupSize: 3

    });
    $(document).on("change", ".quantitySelect", function () {
        calculateAll($(this).closest('tr'));
    });
    $(document).on("change", ".dovizKuru", function () {
        calculateAll($(this).closest('tr'));
    });
    $(document).on("change", ".unitprice", function () {
        calculateAll($(this).closest('tr'));
    });
    

    $(document).on("change", ".purchase", function () {
        calculateAll($(this).closest('tr'));
    });


    function calculateAll(row) {
        var quantity = parseFloat(row.find('.quantitySelect').val().replace(/,/g, "")) || 0;
        var currencyTotal = parseFloat(row.find('.dovizKuru').val().replace(/,/g, "")) || 0;
        var unitPrice = parseFloat(row.find('.unitprice').val().replace(/,/g, "")) || 0;
        var selectedOption = row.find(".purchase option:selected");
        var dataDegerString = selectedOption.attr("vatrate");
        var purchaseVat = 0;

        if (dataDegerString) {
            purchaseVat = parseFloat(dataDegerString) || 0;
        }

        var netPrice = quantity * currencyTotal * unitPrice;
        var totalprice = netPrice + (netPrice * purchaseVat);

        row.find('.netprice').val(netPrice.toFixed(2));
        row.find('.totalprice').val(totalprice.toFixed(2)); 
        calculateSub();
    }
    function calculateSub()
    {
        var toplamNet = 0;
        var kdvtoplam = 0;
        var grandTotal = 0;
        $('tbody tr').each(function () {
            
            var row = $(this);
            var netStr = row.find('.netprice').val().replace(/,/g, "");
            var net = parseFloat(netStr); // Noktalý sayýlarý iþlemek için parseFloat kullanýldý.
            if (isNaN(net)) { // net undefined, null veya bir sayý deðilse bu adýmý atla.
                return;
            }
            var selectedOption = row.find(".purchase option:selected");
            var dataDegerString = selectedOption.attr("vatrate");
            var purchaseVat = 0;

            if (dataDegerString) {
                purchaseVat = parseFloat(dataDegerString.replace(/,/g, "")) || 0;
            }

            toplamNet += net;
            kdvtoplam += (net * purchaseVat);
            grandTotal += (toplamNet + kdvtoplam);
        });
        $("#totalPrice").val(toplamNet.toFixed(2));
        $("#vatTotal").val(kdvtoplam.toFixed(2));
        $('#grandTotal').val(grandTotal.toFixed(2));
    }

    updateRowIds();

    $(".add-row").click(function () {
         var lastRow = $("#myTable tbody tr:last");
        var newRow = lastRow.clone();

        newRow.find('input:not(.sofId):not(.sofOfId), select:not(.CLASI)').val('');


        newRow.find('.stockSelect').remove();

        var newStockSelect = $('<select class="stockSelect selectpicker" name="SalesDetailOffers[1].StockId" data-live-search="true"></select>');

        $.ajax({
            url: '/FuelAndMaintenance/GetStockJson', // Sunucudan stok verilerini getiren endpointin URL'si
            method: 'GET',
            success: function (data) {
                // AJAX isteði baþarýlý olduðunda burasý çalýþýr
                // Veriye göre seçenekleri doldur
                $.each(data, function (index, stock) {
                    newStockSelect.append('<option value="' + stock.Id + '">' + stock.Name + " - "+ stock.Code + '</option>');
                });

                // Yeni oluþturulan select elementini tabloya ekle
                newRow.find('td').eq(2).html(newStockSelect);


                // Tabloya yeni satýrý ekle
                $("#myTable tbody").append(newRow);

                // selectpicker'ý yenile
                $('.selectpicker').selectpicker('refresh');

                // Satýr ID'lerini güncelle
                updateRowIds();

                calculateAll(newRow);
            },

            error: function (xhr, status, error) {
                // Hata durumunda burasý çalýþýr
                console.error('AJAX error:', error);
            }
        });


    });

    function updateRowIds() {
        $('#myTable tbody tr').each(function (index) {
            var row = $(this);

            // Satýr içindeki çocuk elementleri bulmak için .find() kullanýn
            row.find('.offertype').attr('name', 'SalesDetailOffers[' + index + '].OfferType');
            row.find('.sofId').attr('name', 'SalesDetailOffers[' + index + '].Id');
            row.find('.sofOfId').attr('name', 'SalesDetailOffers[' + index + '].SalesOfferId');
            row.find('.serviceText').attr('name', 'SalesDetailOffers[' + index + '].ServiceText');
            row.find('.stockSelect').attr('name', 'SalesDetailOffers[' + index + '].StockId');
            row.find('.quantitySelect').attr('name', 'SalesDetailOffers[' + index + '].Quantity');
            row.find('.currencytype').attr('name', 'SalesDetailOffers[' + index + '].CurrencyType');
            row.find('.dovizKuru').attr('name', 'SalesDetailOffers[' + index + '].CurrencyTotal');
            row.find('.unitprice').attr('name', 'SalesDetailOffers[' + index + '].UnitPrice');
            row.find('.netprice').attr('name', 'SalesDetailOffers[' + index + '].NetPrice');
            row.find('.purchase').attr('name', 'SalesDetailOffers[' + index + '].PurchaseVatId');
            row.find('.totalprice').attr('name', 'SalesDetailOffers[' + index + '].TotalPrice');
            row.find('.description').attr('name', 'SalesDetailOffers[' + index + '].Description');
        });
    }
    $('tbody').on('click', '.delete-row', function () {
        var rowCount = $(this).closest('table').find('tbody tr').length;

        if (rowCount > 1) {
            var sofIdValue = $(this).closest('tr').find('.sofId').val();
          
            if (sofIdValue != 0) {
                swal({
                    title: "Sil!",
                    text: "Bu veri tabanýna kayýtlý bir tekliftir silmek istediðinizden emin misiniz!",
                    icon: "warning",
                    buttons: ["Vazgeç", "Evet, Sil"],
                    dangerMode: true,
                }).then((willDelete) => {
                    if (willDelete) {
                        // Silme iþlemi için gerekli kodlar
                        $(this).closest('tr').remove();
                        debugger;
                        $.ajax({
                            type: 'POST',
                            url: '/SalesOffer/DeleteDetail/' + sofIdValue,
                            dataType: 'json',
                            success: function (result) {
                                swal("Baþarýyla Silindi!", {
                                    icon: "success",
                                });
                                location.reload();
                            },
                            error: function (xhr, status, error) {
                                console.error(xhr.responseText);
                                swal("Silme Ýþlemi Baþarýsýz!");
                            }
                        });
                    } else {
                        swal("Ýþlem Ýptal Edildi!");
                    }
                });
            } else {
                $(this).closest('tr').remove();
                updateRowIds($("#myTable tbody tr"), function () {
                    swal("Baþarýyla Silindi!", {
                        icon: "success",
                    });
                    location.reload();
                });
            }
        } else {
            alert("Tabloda en az bir satýr olmalý!");
        }
        updateRowIds();
        calculateAll();
    });
    

    

    function handleStockSelection(row) {
        var productType = row.find('.offertype').val();
        var stockSelect = row.find('.stockSelect');
        var serviceText = row.find('.serviceText'); // Yeni eklenen text input

        // Show stock selection only when productType is not '1'
        if (productType === '1') {
            stockSelect.hide();
            serviceText.show();

            //if (serviceText.length === 0) {
            //    var textInput = '<input type="text" class="form-control serviceText" placeholder="Hizmet Bilgisi Giriniz">';
            //    stockSelect.after(textInput);
            //}
        } else {
            stockSelect.show();
            serviceText.hide();
             
            /*serviceText.remove();*/
        }
    }


    $('tbody').on('change', '.offertype', function () {
        var row = $(this).closest('tr');
        handleStockSelection(row);
    });

    $('tbody .stockSelect').hide();

    $('.offertype').on('change', function () {
        var row = $(this).closest('tr');
        handleStockSelection(row);
    });

    $('tbody').on('change', '.currencytype', function () {
        var row = $(this).closest('tr');
        var currencyType = $(this).val();
        var currencyTotalInput = row.find('.dovizKuru');
        if (currencyType === '1') {
            currencyTotalInput.val('1,00'.replace(',', '.'));
        } else {
            currencyTotalInput.val('');
        }

    });

    
    
});
