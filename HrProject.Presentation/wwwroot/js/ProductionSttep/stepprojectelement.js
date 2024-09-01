$('input[type="radio"]').change(function () {
    var itemId = $(this).attr('itemId');
    var selectedValue = $(this).val();
    console.log("itemId: " + itemId + ", selected value: " + selectedValue);
    // Buraya ba�ka i�lemler ekleyebilirsiniz
});
$("#mySteps").sortable({
        // S�r�kle b�rak i�lemi bittikten sonra yap�lacak i�lemler buraya gelebilir
        update: function (event, ui) {
            // T�m li elemanlar�n�n s�ra numaralar�n� g�ncelle
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
                        title: "G�ncelleme!",
                        text: "G�ncelleme Tamamland�!",
                        icon: "success",
                        dangerMode: false,
                    }).then(() => {
                        location.reload();
                    });
                } else if (response === "hata") {
                    swal({
                        title: "G�ncelleme!",
                        text: "G�ncelleme Tamamlanmad�!",
                        icon: "error", // Hata durumunda "error" ikonunu g�ster
                        dangerMode: true,
                    }).then(() => {
                    });
                }
            },
            error: function (xhr, status, error) {
                console.error(error); // Hata durumunda konsola hatay� yazd�r
            }
        });
    });

function saveNewOrder() {
    var updatedSteps = [];
    // T�m li elemanlar�n� dola�arak s�ra numaralar�n� g�ncelle
    $('#mySteps li').each(function (index) {
        var stepId = $(this).data('id');
        var stepValue = $(this).find('.badge').text();
        updatedSteps.push({ Id: stepId, Value: stepValue });
    });
    debugger;
    // Ajax iste�i ile s�ralama de�i�ikliklerini sunucuya g�nder
    var keyValues = JSON.stringify(updatedSteps);
    $.ajax({
        url: '/ProductionStep/StepUpdateSequence',
        type: 'POST',
        contentType: 'application/json',
        data: keyValues,
        success: function (response) {
            if (response === "ok") {
                swal({
                    title: "G�ncelleme!",
                    text: "G�ncelleme Tamamland�!",
                    icon: "success",
                    dangerMode: false,
                }).then(() => {
                    location.reload();
                });
            } else if (response === "hata") {
                swal({
                    title: "G�ncelleme!",
                    text: "G�ncelleme Tamamlanmad�!",
                    icon: "error", // Hata durumunda "error" ikonunu g�ster
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
    // T�m li elemanlar�n� dola�arak s�ra numaralar�n� g�ncelle
    $('#mySteps li').each(function (index) {
        // index de�eri 0'dan ba�layarak art�yor, bunu 1'e ekleyerek insan dostu s�ralama yapabiliriz
        var newSequenceNumber = index + 1;
        // li eleman�n�n i�indeki s�ra numaras�n� g�ncelle
        $(this).find('.badge').text(newSequenceNumber);
        // Veritaban�nda g�ncelleme yapmak i�in uygun bir veri yap�s�na s�ra numaras�n� atayabilirsiniz
        // �rne�in:
        // $(this).data('sequence', newSequenceNumber);
    });
}
    $('.delete-button').click(function () {
        var id = $(this).attr('id');
        var confirmDelete = confirm("Silmek istedi�inize emin misiniz?");
        if (confirmDelete) {
            $.ajax({
                url: '/ProductionStep/DeleteStep/' + id,
                type: 'GET',
                success: function (response) {
                    location.reload();
                },
                error: function (xhr, status, error) {
                    console.error('Silme i�lemi s�ras�nda bir hata olu�tu:', error);
                }
            });
        }
    });
