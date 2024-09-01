$('input[type="radio"]').change(function () {
    var itemId = $(this).attr('itemId');
    var selectedValue = $(this).val();
    console.log("itemId: " + itemId + ", selected value: " + selectedValue);
    // Buraya baþka iþlemler ekleyebilirsiniz
});
$("#mySteps").sortable({
        // Sürükle býrak iþlemi bittikten sonra yapýlacak iþlemler buraya gelebilir
        update: function (event, ui) {
            // Tüm li elemanlarýnýn sýra numaralarýný güncelle
            updateSequenceNumbers();
            saveNewOrder();
        }
    });
    $('input[type="radio"]').change(function () {
        var selectedStepId = $(this).closest('li').data('id');

        $.ajax({
            url: '/ProductionStep/UpdateLastStep?id=' + selectedStepId,
            type: 'GET',
            success: function (response) {
                if (response === "ok") {
                    swal({
                        title: "Güncelleme!",
                        text: "Güncelleme Tamamlandý!",
                        icon: "success",
                        dangerMode: false,
                    }).then(() => {
                        location.reload();
                    });
                } else if (response === "hata") {
                    swal({
                        title: "Güncelleme!",
                        text: "Güncelleme Tamamlanmadý!",
                        icon: "error", // Hata durumunda "error" ikonunu göster
                        dangerMode: true,
                    }).then(() => {
                    });
                }
            },
            error: function (xhr, status, error) {
                console.error(error); // Hata durumunda konsola hatayý yazdýr
            }
        });
    });

function saveNewOrder() {
    var updatedSteps = [];
    // Tüm li elemanlarýný dolaþarak sýra numaralarýný güncelle
    $('#mySteps li').each(function (index) {
        var stepId = $(this).data('id');
        var stepValue = $(this).find('.badge').text();
        updatedSteps.push({ Id: stepId, Value: stepValue });
    });
    debugger;
    // Ajax isteði ile sýralama deðiþikliklerini sunucuya gönder
    var keyValues = JSON.stringify(updatedSteps);
    $.ajax({
        url: '/ProductionStep/StepUpdateSequence',
        type: 'POST',
        contentType: 'application/json',
        data: keyValues,
        success: function (response) {
            if (response === "ok") {
                swal({
                    title: "Güncelleme!",
                    text: "Güncelleme Tamamlandý!",
                    icon: "success",
                    dangerMode: false,
                }).then(() => {
                    location.reload();
                });
            } else if (response === "hata") {
                swal({
                    title: "Güncelleme!",
                    text: "Güncelleme Tamamlanmadý!",
                    icon: "error", // Hata durumunda "error" ikonunu göster
                    dangerMode: true,
                }).then(() => {
                });
            }
        },
        error: function (xhr, status, error) {
            // Hata durumu
            console.error(error);
        }
    });
}
function updateSequenceNumbers() {
    // Tüm li elemanlarýný dolaþarak sýra numaralarýný güncelle
    $('#mySteps li').each(function (index) {
        // index deðeri 0'dan baþlayarak artýyor, bunu 1'e ekleyerek insan dostu sýralama yapabiliriz
        var newSequenceNumber = index + 1;
        // li elemanýnýn içindeki sýra numarasýný güncelle
        $(this).find('.badge').text(newSequenceNumber);
        // Veritabanýnda güncelleme yapmak için uygun bir veri yapýsýna sýra numarasýný atayabilirsiniz
        // Örneðin:
        // $(this).data('sequence', newSequenceNumber);
    });
}
    $('.delete-button').click(function () {
        var id = $(this).attr('id');
        var confirmDelete = confirm("Silmek istediðinize emin misiniz?");
        if (confirmDelete) {
            $.ajax({
                url: '/ProductionStep/DeleteStep/' + id,
                type: 'GET',
                success: function (response) {
                    location.reload();
                },
                error: function (xhr, status, error) {
                    console.error('Silme iþlemi sýrasýnda bir hata oluþtu:', error);
                }
            });
        }
    });
