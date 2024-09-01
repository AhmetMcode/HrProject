function editItem(id) {

    $.ajax({
        url: '/ProductPlan/GetDailyPlanJson/' + id,
        type: 'GET',
        success: function (data) {
            debugger;
            // Modal içindeki alanları doldur
            $('#editName').val(data.Name);
            $('#editId').val(id);
            if (data.StartTime) {
                const startTime = new Date(data.StartTime);
                if (!isNaN(startTime.getTime())) {
                    $('#editStartTime').val(startTime.toISOString().substring(0, 16));
                } else {
                    console.error('Invalid date:', data.StartTime);
                    // Handle invalid date case, e.g., set to a default value or show an error message
                }
            } else {
                console.error('Start time is null or undefined');
                // Handle null/undefined date case, e.g., set to a default value or show an error message
            }
            $('#editEndTime').val(new Date(data.EndTime).toISOString().substring(0, 16));

            $('#editModal').modal('show');
        },
        error: function () {
            alert('Bir hata oluştu.');
        }
    });
}
function dosyaIndir(pmCalcId, projeId) {
    // Send an AJAX request to the server
    $.ajax({
        url: '/ProductPlan/ProjeDosyasiIndir', // Adjust the URL to match your controller and action
        type: 'GET',
        data: {
            pmCalcId: pmCalcId,
            projeId: projeId
        },
        success: function (response) {
            // Create a temporary link element to initiate download
            var link = document.createElement('a');
            link.href = window.URL.createObjectURL(new Blob([response], { type: 'application/zip' }));
            link.download = 'ProjeDosyalar.zip'; // Default name for the downloaded file
            document.body.appendChild(link);
            link.click();
            document.body.removeChild(link);
        },
        error: function (xhr, status, error) {
            alert('Dosya indirilemedi. Hata: ' + error);
        }
    });
}
$(".gunlukDuzenleKaydet").click(function () {
    var editId = $("#editId").val();
    var editName = $("#editName").val();
    var editStartTime = $("#editStartTime").val();
    var editEndTime = $("#editEndTime").val();

    var data = {
        Id: editId,
        Name: editName,
        StartTime: editStartTime,
        EndTime: editEndTime
        // Add other form fields here
    };

    $.ajax({
        type: "POST",
        url: "/ProductPlan/GunlukPlanDuzenle",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert("Başarılı: " + response.message);
            $('#editModal').modal('hide');
            // Add additional code to update the page or relevant area
        },
        error: function (error) {
            alert("Hata: " + error.responseText);
            // Add additional code to show error message
        }
    });
});

function uretimEmriOlustur(productPlanId,pmCalc)
{
    debugger;
    $.ajax({
        url: '/ProductPlan/UretimEmriOlustur',
        type: 'POST',
        data: { id: productPlanId, pmCalcId: pmCalc },
        success: function (response) {
            // İşlem başarılı
            Swal.fire({
                title: 'Başarı!',
                text: 'Üretim emri oluşturuldu.',
                icon: 'success',
                confirmButtonText: 'Tamam'
            });
            location.reload();
        },
        error: function (xhr, status, error) {
            // İşlem başarısız
            Swal.fire({
                title: 'Hata!',
                text: 'Bir hata oluştu. Lütfen tekrar deneyin.',
                icon: 'error',
                confirmButtonText: 'Tamam'
            });
        }
    });
}
$(document).ready(function () {
    $('#editForm').on('submit', function (e) {
        e.preventDefault();
        var formData = $(this).serialize();

        $.ajax({
            url: '/ProductPlanSubPlanned/Update',
            type: 'POST',
            data: formData,
            success: function () {
                $('#editModal').modal('hide');
                location.reload(); 
            },
            error: function () {
                alert('Bir hata oluştu.');
            }
        });
    });
});
