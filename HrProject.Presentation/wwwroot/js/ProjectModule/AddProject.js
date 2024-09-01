
$(document).ready(function () {
    $('#uploadButton').click(function () {
        var formData = new FormData($('#uploadForm2')[0]);

        $.ajax({
            url: '/ProjectModule/UretimiOnayiVerildi', // Bu URL'yi doğru endpoint ile değiştirin
            type: 'POST', // Dosya yükleme işlemi için POST kullanmak daha uygun
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                Swal.fire({
                    icon: 'success',
                    title: 'Başarılı',
                    text: 'Belge başarıyla yüklendi.'
                }).then((result) => {
                    if (result.isConfirmed) {
                        $('#uploadModal').modal('hide');
                    }
                });
            },
            error: function (xhr, status, error) {
                // Hata olursa yapılacak işlemler
                Swal.fire({
                    icon: 'error',
                    title: 'Hata',
                    text: 'Belge yüklenirken hata oluştu.'
                });
            }
        });
    });
    $('#sendNotification').click(function () {
        var projectId = $('#ProjectId').val();
        var smsContent = $('#smsContentUretim').val();
        var phoneNumber = $('#phoneNumber').val();
        var emailAddress = $('#emailAddress').val();

        $.ajax({
            url: '/ProjectModule/UretimOnayMailSmsGonder', // Uygun URL ile değiştirin
            type: 'GET',
            data: {
                projectId: projectId,
                sms: phoneNumber,
                mail: emailAddress,
                icerik: smsContent
            },
            success: function (response) {
                // Başarılı olursa yapılacak işlemler
                Swal.fire({
                    icon: 'success',
                    title: 'Başarılı',
                    text: 'Mail ve SMS gönderildi.'
                });
            },
            error: function (xhr, status, error) {
                // Hata olursa yapılacak işlemler
                Swal.fire({
                    icon: 'error',
                    title: 'Hata',
                    text: 'Gönderim sırasında hata oluştu.'
                });
            }
        });

    });
    $(".forUretim").each(function () {
        var startDateValue = $(this).find(".startDatePicker").val();
        var completeDateValue = $(this).find(".completeDatePicker").val();
        // StartDate alanı için değeri atama
        if (startDateValue) {
            $(this).find(".startDatePicker").val(startDateValue);
        }

        // CompleteDate alanı için değeri atama
        if (completeDateValue) {
            $(this).find(".completeDatePicker").val(completeDateValue);
        }
    });



    $("#ekle").click(function () {
        addInputRow();
    });
});
$(document).on('click', '.delete-row', function () {
    $(this).closest('.row.mt-1').remove();
});
async function addInputRow() {
    // Clone the template row
    var newRow = $(".row.mt-1:first").clone();

    // Clear input values in the new row
    newRow.find('input').val('');

    // Fetch user data and populate the dropdown in the new row
    var users = await $.getJSON('/User/GetProjectUsersJson');

    var select = newRow.find('.usersUretim');
    select.empty(); // Clear existing options

    $.each(users, function (index, user) {
        select.append('<option value="' + user.Id + '">' + user.Email + '</option>');
    });

    // Append the new row to the form
    $(".row.mt-1:last").after(newRow);
}
$('#summernote').summernote({
    placeholder: 'Müşteri İstekleri',
    tabsize: 2,
    height: 250
});
$(document).ready(function () {
    $("#saveUretims").click(function () {
        // Form verilerini topla
        var formData = [];
        $(".forUretim").each(function () {
            var drawId = $(this).find(".drawid").val() || 0;
            var name = $(this).find(".name").val();
            var responsUserId = $(this).find(".usersUretim").val();
            var start = new Date($(this).find("input[type='date']:first").val()); // Tarihi uygun formatta Date nesnesine dönüştür
            var finish = new Date($(this).find("input[type='date']:last").val()); // Tarihi uygun formatta Date nesnesine dönüştür

            // responsUserId kontrolü
            if (responsUserId === undefined || responsUserId === null) {
                return;
            }
            if (start === undefined || finish === undefined) {
                return;
            }
            if (start == "") {
                return;
            }
            if (finish == "") {
                return;
            }
            if (name == "") {
                return;
            }
            formData.push({
                SubId: projeId,
                Id: drawId, // Bu değeri isteğinize göre güncelleyebilirsiniz
                Name: name,
                ResponsUserId: responsUserId,
                Start: start,
                Finish: finish
            });
        });

        var jsonData = JSON.stringify(formData);

        $.ajax({
            url: '/ProjectModule/AddProductionDrawing', // İsteğinizi alacak controller ve action adını belirtin
            type: 'POST',
            contentType: 'application/json',
            data: jsonData,
            success: function (response) {
                // Başarılı işlemleri burada işleyin
                Swal.fire({
                    title: 'Başarılı!',
                    text: 'İşlemler kaydedildi.',
                    icon: 'success',
                    confirmButtonText: 'Tamam'
                }).then((result) => {
                    if (result.isConfirmed) {
                        location.reload(); // Sayfayı yenile
                    }
                });
            },
            error: function (error) {
                // Hata durumlarını burada işleyin
                console.error(error);
                Swal.fire({
                    title: 'Hata!',
                    text: 'İşlem sırasında bir hata oluştu.',
                    icon: 'error',
                    confirmButtonText: 'Tamam'
                });
            }
        });
    });
});

$(document).ready(function () {
    // Attach a click event handler to the button
    $("#pozNumberSave").on("click", function () {
        // Get the values from the input fields
        var pozNumber = $("#pozNumber").val();
        var subId = $("#subId").val();

        // Create a data object with the values
        var data = {
            id: subId,
            pozCode: pozNumber
        };

        // Make an AJAX request
        $.ajax({
            type: "POST",
            url: "/ProjectModule/UpdatePoz", // Replace with the actual controller and action names
            data: data,
            success: function (result) {
                location.reload(); // Reload the page
                // You can update the UI or perform other actions here
            },
            error: function (error) {
                // Handle the error response
                console.error(error);
            }
        });
    });
    $.ajax({
        url: '/ProjectModule/CombineUserGetirJson',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            var $select = $('.ilkUsers.usersUretim');
            $.each(data, function (index, user) {
                $select.append($('<option>', {
                    value: user.Id,
                    text: user.DisplayName
                }));
            });
        },
        error: function (xhr, status, error) {
            console.error("Kullanıcı verileri alınamadı: " + error);
        }
    });
});
$(document).ready(function () {
    $("#ertele").on("click", function () {
        var id = projeId;
        var day = $("#gunSayisi").val();

        $.ajax({
            url: "/ProjectModule/PostPone",
            type: "POST",
            data: { id: id, day: day },
            success: function (data) {
                alert(data);
                location.reload();
            },
            error: function () {
                alert("An error occurred");
            }
        });
    });
    $("#sendSms").on("click", function () {
        var emailContent = $("#emailContent").val();
        var postponeDays = $("#gunSayisi").val();
        var smsContent = $("#smsContent").val();

        // Make an AJAX request to the server
        $.ajax({
            url: "/ProjectModule/SenEmailAndSms",
            method: "POST",
            data: {
                id: projeId, // Replace yourId with the actual value
                Email: emailContent,
                sms: smsContent
            },
            success: function (data) {
                // Handle the success response from the server
                location.reload(); // Reload the page
            },
            error: function (error) {
                // Handle the error response from the server
                console.log("Error occurred", error);
            }
        });
    });
    $(".assigment").on("click", function () {
        Swal.fire({
            title: 'Emin misiniz?',
            text: "Bu işlemi gerçekleştirmek istediğinize emin misiniz?",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Evet, devam et!',
            cancelButtonText: 'Hayır'
        }).then((result) => {
            if (result.isConfirmed) {
                // Prepare an array to store form data
                var formDataArray = [];

                // Iterate through each form section and push data to the array
                $(".assd").each(function () {
                    var userSelect = $(this).find("#userSelect").val();
                    var startDate = $(this).find("#startDate").val();
                    var endDate = $(this).find("#endDate").val();
                    var projectProcessStageIndex = $(this).find(".deger").text();
                    var projectProcessStage = projectProcessStages.indexOf(parseInt(projectProcessStageIndex));

                    // Make sure the required fields are filled
                    if (userSelect && startDate && endDate) {
                        var formData = {
                            UserId: userSelect,
                            StartDate: startDate,
                            EndDate: endDate,
                            ProjectId: projeId,
                            ProjectProcessStage: projectProcessStageIndex
                            // Add more data properties as needed
                        };

                        formDataArray.push(formData);
                    }
                });

                // Make an AJAX request to the server with all form data
                $.ajax({
                    url: "/ProjectModule/SaveProjectAssigment", // Replace with your actual endpoint
                    method: "POST",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(formDataArray),
                    success: function (response) {
                        // Handle success if needed
                        Swal.fire({
                            title: 'Başarılı!',
                            text: 'İşlemler kaydedildi.',
                            icon: 'success',
                            confirmButtonText: 'Tamam'
                        }).then((result) => {
                            if (result.isConfirmed) {
                                location.reload(); // Sayfayı yenile
                            }
                        });
                    },
                    error: function (error) {
                        // Handle error if needed
                        console.error(error);
                        Swal.fire({
                            title: 'Hata!',
                            text: 'İşlem sırasında bir hata oluştu.',
                            icon: 'error',
                            confirmButtonText: 'Tamam'
                        });
                    }
                });
            }
        });
    });
});
$(document).ready(function () {
    $('#uploadDocumentModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var sistemPlani = false;
        debugger;
        var projeId = button.data('proje-id');
        var projeElemanId = button.data('proje-eleman-id');
        if (projeElemanId == "sistem-plani") {
            sistemPlani = true; // sistemPlani değişkenini true yap

            $('#uploadForm').data('proje-eleman-id', "sistem-plani");

        }
        else {
            $('#uploadForm').data('proje-eleman-id', projeElemanId);

        }
        // Store IDs in the form for use in the AJAX request
        $('#uploadForm').data('proje-id', projeId);

        // AJAX request to get existing files
        $.ajax({
            url: '/ProjectModule/EskiUretimCizimler',
            type: 'GET',
            data: {
                projeId: projeId,
                projeElemanId: projeElemanId,
                sistemPlani: sistemPlani 

            },
            success: function (dosyalar) {
                // Clear the table
                $('#existingFilesTable tbody').empty();

                debugger;
                dosyalar.forEach(function (dosya) {
                    var row = '<tr>' +
                        '<td>' + dosya.RevizeNo + '</td>' +
                        '<td>' + dosya.Uzanti + '</td>' +
                        '<td>' +
                        '<button class="btn btn-info btn-sm"  >İndir</button>' +
                        '<input type="hidden" class="dosya" value="' + dosya.Dosya + '">' +
                        '<input type="hidden" class="uzanti" value="' + dosya.Uzanti + '">' +
                        '<input type="hidden" class="ad" value="' + dosya.Ad + '">' +
                        '</td>' +
                        '</tr>';
                    $('#existingFilesTable tbody').append(row);
                });
            },
            error: function () {
                alert('Dosyalar yüklenirken bir hata oluştu.');
            },

        });
        $('#existingFilesTable').on('click', '.btn-info', function () {
            var $row = $(this).closest('tr');
            var dosyaBase64 = $row.find('.dosya').val();
            var uzanti = $row.find('.uzanti').val();
            var dosyaAdi = $row.find('.ad').val() + uzanti;
            var link = document.createElement('a');
            link.href = 'data:application/octet-stream;base64,' + dosyaBase64;
            link.download = dosyaAdi;
            document.body.appendChild(link);
            link.click();
            document.body.removeChild(link);
        });

    });

    $('#uploadForm').submit(function (event) {
        event.preventDefault(); // Prevent the default form submission
        var asd = $(this).data('proje-eleman-id');
        var formData = new FormData(this);
        formData.append('projeId', $(this).data('proje-id'));
        debugger;
        if ($(this).data('proje-eleman-id') == "sistem-plani") {
            formData.append('sistemPlani', true);
            formData.append('projeElemanId', 0);
        } else {
            formData.append('projeElemanId', $(this).data('proje-eleman-id'));
        }

        $.ajax({
            url: '/ProjectModule/UploadUretimCizim',
            type: 'POST',
            data: formData,
            processData: false, 
            contentType: false,
            success: function (response) {
                if (response.success) {
                    alert(response.message);
                    $('#uploadDocumentModal').modal('hide');
                    location.reload(); // Reload the page to reflect changes
                } else {
                    alert('Yükleme sırasında bir hata oluştu: ' + response.message);
                }
            },
            error: function (xhr, status, error) {
                // Log error details for debugging
                console.error('Error:', status, error);
                alert('Yükleme sırasında bir hata oluştu.');
            }
        });
    });

});