$(document).ready(function () {
    // Sayfa açılır açılmaz TeklifRaporlari endpoint'ine istek at
    $.ajax({
        url: '/Offer/TeklifRaporlariJson', // Endpoint URL'si
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            if ($('#grid').data("ej2_instances")) {
                $('#grid').ej2_instances[0].destroy(); // Önceki grid varsa yok et
            }

            // Grid oluştur ve veriyi içine koy
            var grid = new ej.grids.Grid({
                dataSource: data,
                columns: [
                    { field: 'Id', headerText: 'ID', textAlign: 'Right', width: 120 },
                    { field: 'Name', headerText: 'Name', textAlign: 'Left', width: 150 },
                    { field: 'Code', headerText: 'Code', textAlign: 'Left', width: 120 },
                    { field: 'ProjeTerminTarihi', headerText: 'Termin Tarihi', textAlign: 'Right', width: 150, type: 'date', format: 'yMd' },
                    { field: 'UretimDurumu', headerText: 'Üretim Durumu', textAlign: 'Left', width: 150 },
                    { field: 'BaslangicZamani', headerText: 'Başlangıç Zamanı', textAlign: 'Right', width: 150, type: 'datetime', format: 'yMd HH:mm:ss' }
                    // Daha fazla sütun ekleyebilirsiniz
                ],
                height: 400,
                toolbar: ['Search'],
                filterSettings: { type: 'Excel' }, // Excel filtreleme türü
                allowFiltering: true, // Filtrelemeye izin ver
            });

            grid.appendTo('#grid');
        },
        error: function (error) {
            console.error("Veri yüklenirken bir hata oluştu:", error);
        }
    });
});