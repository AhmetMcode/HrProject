$('.duplicateRowBtn').click(function () {
    var clonedRow = $(this).closest('tr').clone();
    $(this).closest('tr').after(clonedRow);
});
$(".kalipSelect").change(function () {
    var selectedOption = $(this).find(":selected");
    var patternId = selectedOption.val();

    var row = $(this).closest("tr");
  
    $.ajax({
        type: "GET",
        url: "/Planing/GetAviablePattern",
        data: { patternId: patternId },
        success: function (result) {
            row.find(".baslangic").val(result);
        },
        error: function (error) {
            console.error("Error:", error);
        }
    });
    function updateEndDate() {
        debugger;
        $("tbody tr").each(function () {
            var row = $(this);
            var startDateInput = row.find(".baslangic");
            var endDateInput = row.find(".bitis");
            var producibleAmountInput = row.find("input[type=number]");
            var includingMarketsCheckbox = row.find("input[type=checkbox]");
            var adet = row.find(".adet").val();
            var neKadar = row.find(".uretimAdet").val();
            var gunSayisi = Math.ceil(adet / parseInt(neKadar));

            if (producibleAmountInput.val() && startDateInput.val()) {
                var startDate = new Date(startDateInput.val());
                var producibleAmount = parseInt(producibleAmountInput.val());
                var endDate = new Date(startDate.getTime() + ((gunSayisi - 1) * 24 * 60 * 60 * 1000));


                // Set the end date input value
                endDateInput.val(endDate.toISOString().split('T')[0]);
            }
        });
    }

    $("tbody").on("change", ".uretimAdet", function () {
        updateEndDate();
    });
    $(".kaydet").click(function () {
        debugger;
        var dataToSend = [];
        $("tbody tr").each(function () {
            var row = $(this);
            var id = row.find("input[type=hidden]").val();
            var projectId = $("#projectId").val();
            var startDate = row.find(".baslangic").val();
            var patternId = row.find(".kalipSelect").val();
            var uretimAdet = row.find(".uretimAdet").val();
            var terminType = $(".terminType").val();
            var uretilecek = row.find(".adet").val();
            var pmCalcId = row.find(".pmCalcId").val();

            if (uretimAdet != "0" && uretimAdet != "") {
                debugger;

                dataToSend.push({
                    Id: id,
                    ProjectId: projectId,
                    StartDate: startDate,
                    PatternId: patternId,
                    UretimAdet: uretimAdet,
                    UretilcekAdet: uretilecek,
                    TerminType: terminType,
                    PmCalculateId: pmCalcId
                });
            }
        });

        Swal.fire({
            title: "Emin misiniz?",
            text: "Ýsteði göndermek istediðinizden emin misiniz?",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Evet, Gönder",
            cancelButtonText: "Vazgeç",
            dangerMode: true
        }).then((result) => {
            if (result.isConfirmed) {
                debugger;
                $.ajax({
                    url: '/ProductionPlace/DoPlanReelPost',
                    type: 'POST',
                    contentType: 'application/json',
                    data: JSON.stringify(dataToSend),
                    success: function (response) {
                        console.log(response);
                        Swal.fire({
                            title: "Ýþlem Baþarýlý",
                            icon: "success"
                        }).then(() => {
                            location.reload();
                        });
                    },
                    error: function (error) {
                        console.error(error);
                        Swal.fire({
                            title: "Hata!",
                            text: "Ýsteði gönderirken bir hata oluþtu. Lütfen tekrar deneyin.",
                            icon: "error"
                        });
                    }
                });
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire("Ýþlem Ýptal Edildi!");
            }
        });

    });
});
