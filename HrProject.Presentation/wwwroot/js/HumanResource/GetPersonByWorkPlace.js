function showFileInput(tarih) {
    
    document.getElementById('excelFileInput').setAttribute('data-tarih', tarih);
    document.getElementById('excelFileInput').click();
}

function handleFileUpload(event) {
    const file = event.target.files[0];
    const targetDate = event.target.getAttribute('data-tarih'); // Get the specific date

    if (file && targetDate) {
        const reader = new FileReader();
        reader.onload = function (e) {
            const data = new Uint8Array(e.target.result);
            const workbook = XLSX.read(data, { type: 'array' });
            const worksheet = workbook.Sheets[workbook.SheetNames[0]];

            const excelData = XLSX.utils.sheet_to_json(worksheet, { header: 1 });

            // İsim 2. sütun (index 1), soyisim 3. sütun (index 2), ve toplam çalışma süresi 11. sütun (index 10)
            excelData.forEach(row => {
                const name = row[1];
                const surname = row[2];
                const totalWorkTime = row[10];

                if (name && surname && totalWorkTime) {
                    // .cshtml tablonuzdaki satırları iterasyon yaparak data-ad ve data-soyad ile eşleştirme yapın
                    $('tr').each(function () {
                        const tableName = $(this).find('td:first-child');
                        const tableNameAd = tableName.data('ad') ? tableName.data('ad').toString().toLowerCase() : '';
                        const tableNameSoyad = tableName.data('soyad') ? tableName.data('soyad').toString().toLowerCase() : '';

                        if (tableNameAd === name.toLowerCase() && tableNameSoyad === surname.toLowerCase()) {
                            const inputField = $(this).find(`input[tarihjs="${targetDate}"]`);
                            if (inputField.length > 0) {
                                inputField.val(parseFloat(totalWorkTime).toFixed(2));
                            }
                        }
                    });
                }
            });
        };
        reader.readAsArrayBuffer(file);
    }
}




    $(document).ready(function () {
            $('input').keydown(function (e) {
                if (e.which === 9) {
                    e.preventDefault();
                    var $input = $(this);
                    var index = $input.closest('td').index();
                    var $row = $input.closest('tr');
                    var $nextRow = $row.next('tr');
                    if ($nextRow.length > 0) {
                        var $nextInput = $nextRow.children('td').eq(index).find('input');
                        $nextInput.focus();
                    }
                }
            });
            var table = $('#example').DataTable({
                language: {
                    url: 'https://cdn.datatables.net/plug-ins/1.13.6/i18n/tr.json',
                },
                dom: 'Bfrtip',
                buttons: [
                    'copyHtml5',
                    'excelHtml5',
                    'csvHtml5',
                    'pdfHtml5'
                ],
                paging: false // Sayfalama özelliğini devre dışı bırakır

            });

            new $.fn.dataTable.FixedColumns(table, {
                leftColumns: 1, // İlk sütunu sabitle
            });
        });    function saveColumn(button) {
            // Veriyi depolamak için bir dizi oluştur
            var dataArray = [];

            // Butonun ID'sinden tarihi çıkar
            var dateTimeString = button.id;

            // Eğer dateTime bir dize ise, onu bir tarih nesnesine çevir
            if (typeof dateTimeString === 'string') {
                // DateTime formatına uygun bir tarih nesnesi oluşturun
                var dateParts = dateTimeString.split('-');
                var day = parseInt(dateParts[0], 10);
                var month = parseInt(dateParts[1], 10);
                var year = parseInt(dateParts[2], 10);
                var dateTime = new Date(Date.UTC(year, month - 1, day)); // UTC kullan

                // Tıklanan butonun içinde bulunduğu sütunu bul
                var columnIndex = $(button).closest('th').index();

                // Her bir satır için döngü
                $('tr').each(function () {
                    // Belirli sütundaki .form-control öğesini bul
                    var formControlElement = $(this).find('td:eq(' + columnIndex + ') .form-control');
                    var id = $(this).find('td:eq(' + columnIndex + ') .tDId').val() || 0;

                    // Eğer bu sütunda .form-control öğesi varsa, ID'sini al
                    if (formControlElement.length > 0) {
                        var personId = formControlElement.attr('id').split('_')[1];

                        // Belirli tarih için mevcut satırdaki giriş alanındaki değeri çıkar
                        var inputValue = formControlElement.val();
                        inputValue = inputValue || 0;

                        // JavaScript'te ISO 8601 biçimine çevir
                        var isoDateString = dateTime.toISOString();

                        // Veriyi diziye ekle
                        dataArray.push({
                            Id: id,
                            personId: personId,
                            DayOfWork: isoDateString,
                            WorkTime: inputValue
                        });
                    }
                });


                // Kontrol amaçlı, console'a yazdır
                console.log("Oluşturulan dataArray: ", dataArray);
                $.ajax({
                    type: "POST", // Veriyi gönderirken kullanılacak HTTP yöntemi
                    url: "/HumanResource/SaveTallyDetail", // Backend'inizin endpoint'i
                    contentType: "application/json", // Gönderilen verinin türü
                    data: JSON.stringify(dataArray), // JSON formatına çevrilen veri
                    success: function (response) {
                        console.log("Backend'den gelen cevap: ", response);
                        location.reload();
                        // Başarılı bir şekilde gönderildiğinde yapılacak işlemler
                    },
                    error: function (error) {
                        console.error("Hata oluştu: ", error);
                        // Hata durumunda yapılacak işlemler
                    }
                });
            }
        }
    $(document).ready(function () {
            function doldur(button) {
                alert("merhba");
            }
    });

// Sadece 'Ad Soyad' sütununa tıklanıldığında sayfaya git
$('#personTable tbody').on('click', 'td.first-column', function () {
    var personId = $(this).closest('tr').data('person-id');
    if (personId) {
        window.location.href = '/HumanResource/PersonelDetail/' + personId;
    }
});
