$(document).ready(function () {
    $("#hesapGonderBtn").on("click", function () {
        Swal.fire({
            title: 'Emin misiniz?',
            text: "Hesabý gönderirseniz deðiþiklikler geri alýnamayacak þekilde yöneticinize bildirilecektir. Devam etmek istiyor musunuz?",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Evet, gönder!',
            cancelButtonText: 'Ýptal'
        }).then((result) => {
            if (result.isConfirmed) {
                var offerId = $("#offerId").val();

                var url = "/Offer/SendCalculates/" + offerId;
                debugger;
                $.ajax({
                    url: url,
                    type: "GET",
                    success: function (response) {
                        location.reload();
                    },
                    error: function (xhr, status, error) {
                        console.error("Ýstek baþarýsýz: " + status + " - " + error);
                    }
                });
            }
        });
    });


    function calculateAll() {
        debugger;

        $('tbody tr').each(function () {
            var karTutari = 0;
            var maaliyetDuz = 0;
            var maaliyetArtiKarTurar = 0;
            var genelToplam = 0;
            debugger;
            var row = $(this);
            var karOrani = row.find('.karOrani').val();
            var maaliyetDuz = row.find('.maaliyet').val();
            if (isNaN(karOrani)) {
                return;
            }
            karOrani = parseFloat((karOrani.replace(/,/g, "")) / 100);
            maaliyetDuz = parseFloat(maaliyetDuz.replace(/,/g, ""));
            karTutari = karOrani * (maaliyetDuz);
            maaliyetArtiKarTurar = parseFloat(maaliyetDuz + karTutari);
            row.find(".karToplamSatir").val(karTutari);
            row.find(".toplamFiyatSatir").val(parseFloat(karTutari + maaliyetDuz));

        });
    }
    function calculateMaaliyet() {
        debugger;

        $('tbody tr').each(function () {

        });
    }
    $(".mask").inputmask("decimal", {
        radixPoint: ".",
        groupSeparator: ",",
        digits: 2,
        autoGroup: true,
        prefix: '',
        rightAlign: false,
        allowMinus: false,
        allowPlus: false,
        placeholder: "0.00",
        groupSize: 3,
    });
    $(document).on("change", ".karOrani", function () {
        calculateAll();
    });
    $(document).on("change", "#Inflation,#Overheads,#ExchangeRate", function () {
        calculateMaaliyet();
    });
});
