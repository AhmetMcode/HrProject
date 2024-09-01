function OpenModalM(id,asd) {
    debugger;
    if (asd != null) {
        $('#kaliteFormuModal tbody tr').css('background-color', '');

        var row = $('#row-' + asd);
        if (row.length) {
            row.find('td').css('background-color', 'lightgreen');
            row.find('td').css('color', 'white');
        }
    }
    $("#kaliteFormuModal").modal("show");
    $("#stepId").val(id);
}
$(document).ready(function () {

    $(".ata").click(function () {
        var stepId = $("#stepId").val(); // stepId değerini al
        var formId = $(this).attr("id"); // tıklanan düğmenin id'sini al (formId olarak kullanacağız)

        $.ajax({
            url: '/ProductionStep/UpdateProductionStepQualityForm', // İsteğin gönderileceği URL
            type: 'POST', // İstek tipi (POST)
            data: { stepId: stepId, formId: formId }, // Gönderilecek veri (stepId ve formId)
            success: function (response) { // İstek başarılıysa
                alert(response); // Cevabı alert ile göster
                location.reload();
            },
            error: function (xhr, status, error) { // İstek başarısızsa
                console.error(xhr.responseText); // Hata mesajını konsola yaz
            }
        });
    });
    $('#updateer').change(function () {
        // checkbox'un mevcut değerini alın
        var currentValue = $(this).prop('checked');
        debugger;
        // checkbox'un değerini tersine çevirin
        $(this).prop('checked', !currentValue);
        debugger;
        // checkbox'un value özelliğini güncelleyin
        if (!currentValue) {
            $(this).val('true');
        } else {
            $(this).val('false');
        }
    });
    $('#updateer').click(function () {
        if (!$(this).is(':checked')) {
            return confirm("Are you sure?");
        }
    });
});
