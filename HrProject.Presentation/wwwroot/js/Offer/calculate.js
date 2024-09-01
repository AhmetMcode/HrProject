$(document).ready(function () {
    // Delete button click event
    $(".delete-button").on("click", function (e) {
        e.preventDefault();

        // Confirm dialog
        Swal.fire({
            title: "Sil!",
            text: "Bu veri taban�na kay�tl� bir tekliftir silmek istedi�inizden emin misiniz!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Evet, Sil",
            cancelButtonText: "Vazge�",
            dangerMode: true,
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                // Kullan�c� silmeyi onaylad�ysa
                var itemId = $(this).data("id"); // Bu sat�r, bu fonksiyonun bir olay i�leyicisi olarak nas�l �a�r�ld���na ba�l� olarak �al��mayabilir.

                $.ajax({
                    type: "POST", // veya sunucu yap�land�rmas�na ba�l� olarak "DELETE"
                    url: "/Offer/DeleteCalculate/" + itemId,
                    success: function (data) {
                        Swal.fire(
                            'Silindi!',
                            'Teklif ba�ar�yla silindi.',
                            'success'
                        ).then(() => {
                            location.reload(); // Sayfay� yeniden y�kle
                        });
                    },
                    error: function () {
                        // AJAX iste�i hatas�
                        Swal.fire(
                            'Hata!',
                            'AJAX iste�i s�ras�nda bir hata olu�tu. L�tfen tekrar deneyin.',
                            'error'
                        );
                    }
                });
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire("��lem �ptal Edildi!", '', 'info');
            }
        });

    });
});
$(document).ready(function () {
    $("table tbody").sortable({

    });

    $("button.btn.kaydet").click(function () {
        // Reset borders to default (remove red borders)
        $("td input").css("border", "1px solid #ced4da");
        debugger;
        var sira_no = $("#sira_no").val();
        var eleman_adi = $("#projectElementSelect").val();
        var concrete_select = $("#concreteSelect").val();
        var price = $("#price").val();
        var gross_concrete = $("#GrossConcrete").val();
        var trElements = document.querySelectorAll('tr');
        var emptyFields = []; // Bo� zorunlu alanlar� saklamak i�in dizi olu�turulur

        
        var offerData = [];
        debugger;
        $('.zorunlu').each(function () {
            $('.zorunlu').each(function () {
                if ($(this).val() == "") {
                    emptyFields.push("1");
                }
            });
        });
        trElements.forEach(function (tr) {
            var tdElements = $(tr).find('td');
            if (tdElements.length >= 5) {
                var id = tdElements.eq(0).find('.calculateId');
                var concreteClassId = tdElements.eq(6).find('.cs');
                var pes = tdElements.eq(2).find('select').val();
                debugger;
                var projectElementTypeId = tdElements.eq(4).find('select').val();

                // E�er de�er null ise, 0 olarak ata
                if (projectElementTypeId === "") {
                    projectElementTypeId = 1;
                }
                var dataObject = {
                    Id: id.val(),
                    OfferPartId: $("#ofpId").val(),
                    OrderNumber: tdElements.eq(1).find('input').val(),
                    ConcreteClassId: concreteClassId.val(),
                    Price: tdElements.eq(7).find('input').val(),
                    ProjectElementTypeId: projectElementTypeId,
                    Length: tdElements.eq(5).find('input').val(),
                    ProjectElementId: tdElements.eq(2).find('select').val(),
                    GrossConcrete: (parseFloat(tdElements.eq(8).find('input').val().replace(',', ''))),
                };
                console.log(parseFloat(tdElements.eq(8).find('input').val().replace(',', '')));
                debugger;
                if (dataObject.Id == "") {
                    dataObject.Id = 0;
                }
                if (dataObject.Price != "") {
                    offerData.push(dataObject);
                }
            }
        });

        // Verileri JSON format�na d�n��t�r�n
        var jsonData = JSON.stringify(offerData);
        console.log(jsonData);
        // Sunucu taraf�ndaki API URL'ini belirleyin
        var apiUrl = '/Offer/CalculateJson'; // API'nin ger�ek URL'sini buraya ekleyin
        if (emptyFields.length > 0) {
            // Bo� zorunlu alanlar listesini al ve kullan�c�ya g�ster
            var emptyFieldsMessage = emptyFields.join(", ");
            Swal.fire({
                title: 'Uyar�!',
                text: 'Doldurulmam�� zorunlu alanlar var: . Devam etmek istiyor musunuz?',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Evet',
                cancelButtonText: 'Hay�r'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: 'POST', // Veri g�nderme t�r� (POST)
                        url: apiUrl, // API URL'si
                        data: jsonData, // G�nderilecek JSON veri
                        contentType: 'application/json', // Veri t�r�
                        success: function (response) {
                            Swal.fire({
                                title: 'Ba�ar�l�!',
                                text: 'Veri ba�ar�yla g�nderildi.',
                                icon: 'success',
                                confirmButtonText: 'Tamam'
                            }).then((result) => {
                                if (result.isConfirmed) {
                                    location.reload();
                                }
                            });
                        },
                        error: function (xhr, status, error) {
                            Swal.fire({
                                title: 'Hata!',
                                text: 'Veri g�nderilirken bir hata olu�tu.',
                                icon: 'error',
                                confirmButtonText: 'Tamam'
                            });
                        }
                    });
                }
            });
        } else {
            $.ajax({
                type: 'POST', // Veri g�nderme t�r� (POST)
                url: apiUrl, // API URL'si
                data: jsonData, // G�nderilecek JSON veri
                contentType: 'application/json', // Veri t�r�
                success: function (response) {
                    Swal.fire({
                        title: 'Ba�ar�l�!',
                        text: 'Veri ba�ar�yla g�nderildi.',
                        icon: 'success',
                        confirmButtonText: 'Tamam'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            location.reload();
                        }
                    });
                },
                error: function (xhr, status, error) {
                    Swal.fire({
                        title: 'Hata!',
                        text: 'Veri g�nderilirken bir hata olu�tu.',
                        icon: 'error',
                        confirmButtonText: 'Tamam'
                    });
                }
            });
        }
        

        // Check if any of the four inputs is empty
        if (sira_no === "" || eleman_adi === "" || concrete_select === "" || price === "" || gross_concrete === "") {
            // Uyar� mesaj�n� g�ster
            swal("Error", "Please fill in all required fields.", "error");

            // Bo� giri�lere k�rm�z� kenarl�k uygula
            if (sira_no === "") $("#sira_no").css("border", "1px solid red");
            if (eleman_adi === "") $("#projectElementSelect").css("border", "1px solid red");
            if (concrete_select === "") $("#concreteSelect").css("border", "1px solid red");
            if (gross_concrete === "") $("#GrossConcrete").css("border", "1px solid red");
            if (price === "") $("#price").css("border", "1px solid red");
        } else {
        }

    });
});
$(document).ready(function () {
    $("table").on("click", ".btn-outline-primary", function () {
        var newRow = $(this).closest("tr").clone();
        newRow.find("input").val("");

        var lastSiraNo = parseInt($("table tbody tr:last input[id='sira_no']").val());
        newRow.find("input[id='sira_no']").val(lastSiraNo + 1);
        newRow.find("input[id='offerId']").val($("#ofpId").val());
        $("table tbody").append(newRow);
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
        validateZorunlu();


    });
    function validateZorunlu() {
        $('.zorunlu').each(function () {
            $(this).css('background-color', 'lightblue');
        });
    }
    $("#projectElementSelect").change(function () {
        // Get the selected value
        var selectedValue = $(this).val();
        debugger;
        // Make an AJAX call to the server
        $.ajax({
            url: '/Unit/GetProjectElementTypeJson/' + selectedValue,
            type: 'GET',
            success: function (data) {
                // Clear the options in the second select element
                $("#petSelect").empty();

                // Populate the second select element with the received data
                $.each(data, function (index, item) {
                    $("#petSelect").append('<option value="' + item.Id + '">' + item.Code + '</option>');
                });
            },
            error: function (error) {
                console.log(error);
            }
        });
    });
    $('.pes').each(function () {
        var select = $(this);
        select.empty(); // Clear existing options
        // Make an AJAX request or use the data you need for each select element
        // You can add more logic here to determine which URL to use based on the select element
        $.get('/Unit/GetProjectElementJson', function (data) {
            $.each(data, function (index, element) {
                // Append the options to the select element
                select.append($('<option>', {
                    value: element.Id,
                    text: element.Code
                }));
            });
        });
    });
    $('.cs').each(function () {
        var select = $(this);
        select.empty(); // Mevcut se�enekleri temizle
        $.get('/Unit/GetConcreteClassJson', function (data) {
            $.each(data, function (index, element) {
                select.append($('<option>', {
                    value: element.Id,
                    text: element.Name
                }));
            });
        });
    });

});
function Atama(element) {

    // Get the selected value
    var selectedValue = $(element).val();
    // Make an AJAX call to the server
    $.ajax({
        url: '/Unit/GetProjectElementTypeJson/' + selectedValue,
        type: 'GET',
        success: function (data) {
            // Clear the options in the second select element
            $(element).closest('tr').find("#petSelect").empty();

            // Populate the second select element with the received data
            $.each(data, function (index, item) {
                $(element).closest('tr').find("#petSelect").append('<option value="' + item.Id + '">' + item.Code + '</option>');
            });
        },
        error: function (error) {
            console.log(error);
        }
    });
}
$(document).ready(function () {
    $("#hesapBitir").on("click", function () {
        // Kullan�c�ya emin olup olmad���n� sor
        var confirmFinish = confirm("Hesab� bitirmek istedi�inizden emin misiniz?");

        if (confirmFinish) {
            // Kullan�c� evet derse iste�i g�nder
            var offerId = $(this).attr("value");

            $.ajax({
                type: "POST",
                url: "/Offer/FinishCalculate", // ControllerAdi'yi kendi controller ad�nla de�i�tir
                data: { offerId: offerId },
                success: function (result) {
                    // Ba�ar�yla tamamland�ysa, Index sayfas�na y�nlendir
                    window.location.href = "/Offer/Index"; // ControllerAdi'yi kendi controller ad�nla de�i�tir
                },
                error: function (error) {
                    // Hata durumunda burada i�lemler yapabilirsin
                    console.error("Hata olu�tu: " + error.responseText);
                }
            });
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
    $('.zorunlu').on('input', function () {
        var filled = true;

        $('.zorunlu').each(function () {
            $('.zorunlu').each(function () {
                $(this).css('background-color', 'lightblue');
            });
        });

    });
});