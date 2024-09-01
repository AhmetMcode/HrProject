$(document).ready(function () {
    $('#fetchDataButton').click(function () {
        var projectId = $('#projectSelect').val(); // Assuming you have a select element with id 'projectSelect'
        $.ajax({
            url: '/Planing/UretimRaporTable/' + projectId,
            type: 'GET',
            success: function (data) {
                $('.tablo').html(data); // Assuming your partial view contains the HTML you want to place in the '.tablo' div
                $('#example').DataTable({
                    language: {
                        url: 'https://cdn.datatables.net/plug-ins/1.13.6/i18n/tr.json',
                    },
                    fixedColumns: {
                        leftColumns: 5
                    }
                });
            },
            error: function () {
                alert('Error fetching data');
            }
        });
    });
});
    

