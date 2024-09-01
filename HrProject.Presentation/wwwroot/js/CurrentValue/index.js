$(document).ready(function () {
    $.get("/Unit/getUnitJson", function (data) {
        // Birimleri doldur
        var unitSelect = $("#unitId");
        unitSelect.empty();
        unitSelect.append('<option value="">Birim Seçiniz</option>');

        $.each(data, function (index, unit) {
            unitSelect.append('<option value="' + unit.Id + '">' + unit.UnitName + '</option>');
        });
    });
});

// "Ekle" butonuna tıklama işlemi
$("#addUnit").click(function () {
    var name = $("#name").val();
    var unitId = $("#unitId").val();
    var price = $("#unitPrice").val();

    // AddcurrentValue işlemine istek gönder
    $.get("/CurrentValue/AddcurrentValue", { name: name, unitId: unitId, price: price }, function () {
        location.reload();
    });
});

function updateCurrentValue(currentValueId) {
    // You can get the other input values using JavaScript
    debugger;
    var price = $('#' + currentValueId).val();
    // Perform an AJAX GET request
    $.get("/CurrentValue/UpdateCurrentValue?currentValueId=" + currentValueId + "&price=" + price, function (data) {
        // İstek başarıyla tamamlandı
    })
        .done(function () {
            // İstek başarılı olduğunda yapılacak işlemler buraya yazılır
            Swal.fire({
                title: 'Başarılı!',
                text: 'Değer başarıyla güncellendi.',
                icon: 'success',
                confirmButtonText: 'Tamam'
            }).then((result) => {
                // SweetAlert kapatıldıktan sonra sayfayı yeniden yükle
                location.reload();
            });
        })
        .fail(function () {
            // İstek başarısız olduğunda yapılacak işlemler buraya yazılır
            Swal.fire({
                title: 'Hata!',
                text: 'İstek sırasında bir hata oluştu.',
                icon: 'error',
                confirmButtonText: 'Tamam'
            });
        });

}
$(".price").inputmask("decimal", {
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
function getchanges(currentValueId) {
    // You can get the other input values using JavaScript
    debugger;
    var price = $('#' + currentValueId).val();
    // Perform an AJAX GET request
    $.ajax({
        url: '/CurrentValue/GetCurrentValueChange', // İsteğin gönderileceği adresi buraya ekleyin
        method: 'GET',
        data: { currentValueId: currentValueId },
        success: function (data) {
            // Başarılı yanıtı işleme alabilirsiniz (isteğin sonucuna göre)
            // Örneğin, sayfayı yeniden yükleyebilirsiniz.
            console.log(data);
            var tableBody = $("#changeTable tbody");
            tableBody.empty(); // Clear previous data
            debugger;
            $.each(data, function (index, change) {
                // Tarihleri gün, ay ve yıl olarak ayrıştırın
                var startDate = new Date(change.StartDate);
                var endDate = new Date(change.EndDate);

                var formattedStartDate = startDate.getDate() + '/' + (startDate.getMonth() + 1) + '/' + startDate.getFullYear();
                var formattedEndDate = endDate.getDate() + '/' + (endDate.getMonth() + 1) + '/' + endDate.getFullYear();
                debugger;
                debugger;
                var row = "<tr>" +
                    "<td>" + change.Price + "</td>" +
                    "<td>" + formattedStartDate + "</td>" +
                    "<td>" + formattedEndDate + "</td>" +
                    "</tr>";

                if (change.isActive) {
                    row = "<tr style='background-color: green;'>" +
                        "<td class=bg-success >" + change.Price + "</td>" +
                        "<td class=bg-success >" + formattedStartDate + "</td>" +
                        "<td class=bg-success >" + formattedEndDate + "</td>" +
                        "</tr>";
                }
                tableBody.append(row);
            });
            $("#changeModal").modal("show");
        },
        error: function (error) {
            // Hata durumunda gerekli işlemleri yapabilirsiniz.
            console.log(error);
        }
    });

}
$(document).ready(function () {
    // Attach click event listener to delete buttons
    $(".btn-danger").click(function (event) {
        event.preventDefault(); // Prevent default action of anchor tag

        var itemId = $(this).attr("itemid");

        // Show SweetAlert confirmation dialog
        Swal.fire({
            title: 'Are you sure?',
            text: 'You won\'t be able to revert this!',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                // If user confirms, make an AJAX request to delete the item
                $.ajax({
                    url: 'CurrentValue/Delete/' + itemId,
                    method: 'GET',
                    success: function (data) {
                        if (data === 'ok') {
                            Swal.fire(
                                'Deleted!',
                                'Your item has been deleted.',
                                'success'
                            );
                            // You can update the UI as needed here
                        } else {
                            Swal.fire(
                                'Error!',
                                'Bu Rayiç Silinemez.',
                                'error'
                            );
                        }
                    },
                    error: function (xhr, status, error) {
                        console.error('Error:', error);
                        Swal.fire(
                            'Error!',
                            'An error occurred while deleting the item.',
                            'error'
                        );
                    }
                });
            }
        });
    });
});
