var gridObj;
var filterType;

function actionBeginHandler(args) {
    if (args.requestType === 'delete') {
        const data = args.data;
        let recordId;
        debugger;
        // Eğer args.data bir array ise, ilk öğenin Id'sini al
        if (Array.isArray(data)) {
            recordId = data.length > 0 ? data[0].Id : null;
        } else {
            // args.data bir object ise doğrudan Id'sini al
            recordId = data.Id;
        }

        // SweetAlert2 ile onay istemi
        Swal.fire({
            title: 'Emin misiniz?',
            text: "Bu kaydı silmek istediğinize emin misiniz?",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Evet, sil!',
            cancelButtonText: 'Hayır, iptal et'
        }).then((result) => {
            if (result.isConfirmed) {
                debugger;
                // ID ile backend isteği gönder
                $.ajax({
                    url: '/ProjectModule/DeleteCalculate/' + recordId,
                    type: 'GET', // 'GET' yerine 'DELETE' kullanmak genellikle daha doğrudur.
                    success: function (data) {
                        if (data.success) {
                            Swal.fire(
                                'Silindi!',
                                'Kayıt başarıyla silindi.',
                                'success'
                            );
                            gridObj.refresh(); // Grid'i güncelle
                        } else {
                            Swal.fire(
                                'Hata!',
                                data.message || 'Silme işlemi başarısız oldu.',
                                'error'
                            );
                        }
                    },
                    error: function () {
                        Swal.fire(
                            'Hata!',
                            'Silme işlemi sırasında hata oluştu.',
                            'error'
                        );
                    }
                });
            } else {
                // Silme işlemini iptal et
                args.cancel = true;
            }
        });
    }
    if (args.requestType === 'add') {
        args.cancel = true;

        const exampleModal = new bootstrap.Modal(document.getElementById('editModal'), {
            keyboard: false
        });
        exampleModal.show();
      
    }
}

$('#uploadForm').submit(function (e) {
    e.preventDefault(); // Formun normal submit olayını engelle

    var formData = new FormData(this); // Form verilerini al
    startSignalRConnection();
    debugger;
    $.ajax({
        url: '/ProjectModule/UploadPmCalculate', // İsteğin gönderileceği URL'yi belirtin
        type: 'POST',
        data: formData,
        processData: false,  // FormData'nın doğru şekilde gönderilmesini sağlar
        contentType: false,  // İçerik türünü false olarak ayarlayın
        success: function (response) {
            console.log('Dosya başarıyla yüklendi:', response);
            alert('Dosya yüklendi!'); // Kullanıcıya bildirim verin

            // Dosya yüklendikten sonra SignalR bağlantısını başlatın
        },
        error: function (xhr, status, error) {
            console.error('Hata oluştu:', error);
            alert('Dosya yükleme sırasında bir hata oluştu.');
        }
    });
});

let connection = null;
let modalContent = '';

function startSignalRConnection() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("/processingHub")
        .build();

    connection.on("ReceiveStatus", (message) => {
        modalContent += `${message}<br>`; // Mesajı modalContent'e ekle

        // Başarı ve hata durumlarına göre modal başlığını güncelle
        const modalTitle = document.getElementById('exampleModalLabel');
        if (message.toLowerCase().includes('success')) {
            modalTitle.classList.add('success');
            modalTitle.classList.remove('error');
        } else if (message.toLowerCase().includes('error')) {
            modalTitle.classList.add('error');
            modalTitle.classList.remove('success');
        }

        // Modal içeriğini güncelle
        const modalBody = document.getElementById('modalBody');
        if (modalBody) {
            modalBody.innerHTML = modalContent; // Modal içeriği güncelleniyor
        }
    });

    connection.start().then(() => {
        console.log('SignalR bağlantısı kuruldu.');

        // Modal'ı göster
        const exampleModal = new bootstrap.Modal(document.getElementById('exampleModal'), {
            keyboard: false
        });
        exampleModal.show();
    }).catch(err => console.error('SignalR bağlantısı kurulurken bir hata oluştu:', err));
}

