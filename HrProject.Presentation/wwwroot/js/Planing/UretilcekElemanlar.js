$(document).ready(function () {
    $('#filterButton').click(function () {
        var projectId = $('#projectSelect').val();
        document.getElementById('grid').innerHTML = '';

        if ($('#grid').data("ej2_grid")) {
            $('#grid').ej2_instances[0].destroy(); // Destroy grid instance
        }
        if (projectId) {
            $.ajax({
                url: '/Planing/GetUretilcekElemanlarJson',
                type: 'GET',
                dataType: 'json',
                data: { projectModuleSubId: projectId },
                success: function (data) {
                    debugger;
                    if ($('#grid').data("ej2_instances")) {
                        $('#grid').ej2_instances[0].destroy(); // Destroy previous instance if exists
                    }

                    var grid = new ej.grids.Grid({
                        dataSource: data,
                        columns: [
                            { field: 'ProductPlanDailyPlannedId', headerText: 'Plan ID', textAlign: 'Right', width: 120 },
                            { field: 'OrderName', headerText: 'Order Name', textAlign: 'Right', width: 120 },
                            { field: 'ProductPlanDailyPlanned.Name', headerText: 'Plan Name', textAlign: 'Right', width: 150 },
                            { field: 'ProductPlanDailyPlanned.StartTime', headerText: 'Start Time', textAlign: 'Right', width: 150, type: 'datetime', format: 'yMd' },
                            { field: 'ProductPlanDailyPlanned.EndTime', headerText: 'End Time', textAlign: 'Right', width: 150, type: 'datetime', format: 'yMd' },
                            { field: 'Name', headerText: 'Name', textAlign: 'Right', width: 150 },
                            { field: 'StartTime', headerText: 'Start Time', textAlign: 'Right', width: 150, type: 'datetime', format: 'yMd' },
                            { field: 'EndTime', headerText: 'End Time', textAlign: 'Right', width: 150, type: 'datetime', format: 'yMd' }
                            // Add more columns based on your data structure
                        ],
                        height: 400,
                        toolbar: ['Search'],
                        filterSettings: { type: 'Excel' }, // Excel filtreleme türü
                        allowFiltering: true, // Filtrelemeye izin ver
                    });

                    grid.appendTo('#grid');
                }
            });
        }
    });

    $('#clearButton').click(function () {
        $('#projectSelect').val('');
        if ($('#grid').data("ej2_grid")) {
            $('#grid').ej2_instances[0].destroy(); // Destroy grid instance
        }
    });
});