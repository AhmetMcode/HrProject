updateNameAttributes();
$('#summernote').summernote({
    placeholder: 'Müşteri İstekleri',
    tabsize: 2,
    height: 250
});

$("#myTable").on("click", ".delete-row", function () {
    debugger;
    var id = $(this).closest("tr").find('.detId').val();
    var row =$(this).closest("tr");

    if (id == 0) {
        $(this).closest("tr").remove();
        updateNameAttributes();
    }
    else {
        Swal.fire({
            title: 'Emin misiniz?',
            text: "Bu kaydı silmek istediğinizden emin misiniz?",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Evet, sil',
            cancelButtonText: 'İptal'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: '/Offer/terminDetaySilTeklif',
                    type: 'GET',
                    data: { id: id },
                    success: function (response) {
                        row.remove();
                        updateNameAttributes();
                    },
                    error: function (xhr, status, error) {
                    }
                });
            }
        });
    }
});
$("#myTable").on("click", ".add-row", function () {
    var lastRow = $("#myTable tbody tr:last");
    var newRow = lastRow.clone();
    newRow.find('.length').val('');
    newRow.find('.quant').val('');
    $("#myTable tbody").append(newRow);
    updateNameAttributes();

});
$('#myTable').on('change', '.projectElement', function () {
    debugger;
    var selectedId = $(this).val();  // Seçilen değerin ID'sini alıyoruz
    var row = $(this).closest('tr');
    if (selectedId) {
        $.ajax({
            url: '/Unit/GetProjectElementTypeJson',  // Controller ve Action güncelleyin
            type: 'GET',
            dataType: 'json',
            data: { id: selectedId },
            success: function (data) {
                var elementTypesSelect = row.find('.elementTypes'); // Seçilen satır içindeki elementTypes select'ini buluyoruz
                elementTypesSelect.empty(); // Önceden eklenmiş optionları temizle
                elementTypesSelect.append($('<option>', {
                    value: '',
                    text: 'Seçiniz...',
                    disabled: true,
                    selected: true
                }));

                $.each(data, function (i, item) {
                    elementTypesSelect.append($('<option>', {
                        value: item.Id, // Bu alan JSON'daki gerçek alan adlarına göre güncellenmelidir
                        text: item.Name  // Bu alan JSON'daki gerçek alan adlarına göre güncellenmelidir
                    }));
                });
            },
            error: function () {
                alert('Error loading data');
            }
        });
    }
});
function updateNameAttributes() {
    $('#myTable tbody tr').each(function (index) {
        var row = $(this);
        // Sayacı güncelle
        row.find('[name^="OfferTerminDetails"]').each(function () {
            var nameAttr = $(this).attr('name');
            // Sayacın içindeki değeri artır
            var updatedNameAttr = nameAttr.replace(/\d+/, index);
            $(this).attr('name', updatedNameAttr);
        });
    });
}

// Fonksiyonu çağır
