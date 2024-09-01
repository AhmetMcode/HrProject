$(document).ready(function () {
    $('.btn-delete').click(function () {
        var row = $(this).closest('tr');
        var questionId = row.data('question-id');

        Swal.fire({
            title: 'Emin misiniz?',
            text: "Bu işlemi geri alamazsınız!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Evet, sil!',
            cancelButtonText: 'Hayır, iptal et!'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: '/ProductionStep/DeleteQuestion',
                    type: 'POST',
                    data: { questionId: questionId },
                    success: function (response) {
                        if (response.success) {
                            row.remove();
                            Swal.fire(
                                'Silindi!',
                                'Soru başarıyla silindi.',
                                'success'
                            );
                        } else {
                            Swal.fire(
                                'Hata!',
                                'Soru silinirken bir hata oluştu.',
                                'error'
                            );
                        }
                    },
                    error: function () {
                        Swal.fire(
                            'Hata!',
                            'Soru silinirken bir hata oluştu.',
                            'error'
                        );
                    }
                });
            }
        });
    });
});
$('.btn-duzenle').click(function () {
    var row = $(this).closest('tr');
    var questionId = row.data('question-id');
    var questionDesc = row.find('input:first').val();
    var questionType = row.find('select').val();
    var orderNumber = row.find('input:last').val();
    debugger;
    $.ajax({
        url: '/KaliteBirimAtama/UpdateQuestion',
        type: 'POST',
        data: {
            id: questionId,
            questionDesc: questionDesc,
            questionType: questionType,
            orderNumber: orderNumber
        },
        success: function (response) {
            if (response.success) {
                Swal.fire({
                    title: 'Başarılı!',
                    text: 'Soru başarıyla güncellendi.',
                    icon: 'success',
                    confirmButtonText: 'Tamam'
                });
            } else {
                Swal.fire({
                    title: 'Hata!',
                    text: 'Soru güncellenirken bir hata oluştu.',
                    icon: 'error',
                    confirmButtonText: 'Tamam'
                });
            }
        },
        error: function () {
            Swal.fire({
                title: 'Hata!',
                text: 'Bir hata oluştu.',
                icon: 'error',
                confirmButtonText: 'Tamam'
            });
        }
    });
});
