    $(document).ready(function() {
        $('#taskDetayliAciklama').summernote();
        // Silme düğmesine tıklandığında
        $('.delete-task-btn').click(function () {
            var taskId = $(this).data('task-id');
            debugger;
            // SweetAlert ile onay iletişim kutusu görüntüleme
            Swal.fire({
                title: "Emin misiniz?",
                text: "Görevi silmek istediğinizden emin misiniz?",
                icon: "warning",
                showCancelButton: true,
                confirmButtonColor: "#3085d6",
                cancelButtonColor: "#d33",
                confirmButtonText: "Evet, sil!",
                cancelButtonText: "İptal"
            }).then((result) => {
                if (result.isConfirmed) {
                    // Silme işlemini gerçekleştirmek için AJAX isteği
                    $.ajax({
                        type: "GET",
                        url: "/Kanban/DeleteTask?taskId=" + taskId,

                        success: function (response) {
                            // Başarılı silme işlemi
                            if (response === "ok") {
                                Swal.fire("Başarılı!", "Görev başarıyla silindi!", "success");
                            } else {
                                Swal.fire({
                                    icon: "warning",
                                    title: response
                                });
                            }
                            location.reload(); // Bu satır buraya taşındı
                        },

                        error: function (response) {
                            // Hata durumunda
                            Swal.fire("Hata!", "Görev silinirken bir hata oluştu!", "error");
                        }
                    });
                } else {
                    // Silme işlemi iptal edildi
                    Swal.fire("İptal edildi", "Görev silme işlemi iptal edildi!", "info");
                }
            });

        });

    $("#GorevEkle").click(function () {
        var taskData = {
            Title: $("#taskTitle").val(),
            Description: $("#taskDescription").val(),
            DetayliAciklama: $("#taskDetayliAciklama").val(),
            StartTime: $("#taskStartTime").val(),
            EndTime: $("#taskEndTime").val(),
            Urgency: parseInt($("#taskUrgency").val()),
            Status: 1,
            OpenUserId: "asd",
            ResponseUserId:"asd"
        };
        debugger;

        $.ajax({
            type: "POST",
            url: "/Kanban/AddTask",
            contentType: 'application/json', // Veri türü
            data: JSON.stringify(taskData),
            success: function (response) {
                // Başarılı sonuç işlemleri
                alert("Görev başarıyla eklendi!");
                $('#staticBackdrop').modal('hide'); // Modal'ı kapat

            },
            error: function (response) {
                // Hata işlemleri
                alert("Görev eklenirken bir hata oluştu.");
            }
        });
    });
});
$(function () {
    $(".card-body").sortable({
        connectWith: ".card-body",
        items: ".hareketli",
        placeholder: "ui-state-highlight",
        stop: function (event, ui) {
            var item = ui.item; 
            var parent = item.parent(); 
            var itemId = item.data('taskid'); 
            var newIndex = item.index(); 
            var status = parent.data('status');
            debugger;
            // AJAX ile sunucuya gönder
            $.ajax({
                url: '/Kanban/SetStatus', // Bu URL'yi işleyecek olan sunucu tarafı metodu
                method: 'POST',
                data: {
                    id: itemId,
                    Status: status
                },
                success: function (response) {
                    // Başarılı güncelleme sonrası işlemler
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    // Hata yönetimi
                    alert("Bir hata oluştu: " + thrownError);
                }
            });
        }
    }).disableSelection();
});

$(document).ready(function () {
   
    $('.message').click(function () {
        debugger;
        // 'id' attribute'u oku veya gerekiyorsa başka bir yöntemle id değerini al
        var messageId = $(this).data('id');

        $.get('/Kanban/KanbanMessagePartial', { id: messageId }, function (data) {
            // 'data' partial view içeriğidir
            // Modalı burada açıp içeriğini 'data' ile doldurun
            $('#modalContent').html(data);
            $('#myModal').modal('show');
        });
    });
});