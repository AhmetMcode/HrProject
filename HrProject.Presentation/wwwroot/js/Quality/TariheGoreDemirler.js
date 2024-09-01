function populateModal(gunlukId) {
    debugger;
    var filteredProducts = urunler.filter(function (urun) {
        return urun.ProductPlanDailyPlannedId == gunlukId;
    });

    var $modalBody = $('#productModal .modal-body');
    $modalBody.empty();

    if (filteredProducts.length > 0) {
        var $form = $('<form id="productSelectionForm"></form>');

        filteredProducts.forEach(function (urun) {
            var $formCheck = $('<div class="form-check"></div>');
            var $checkbox = $('<input class="form-check-input" type="checkbox">').val(urun.Id).attr('id', 'productCheck_' + urun.Id);
            var $label = $('<label class="form-check-label"></label>').attr('for', 'productCheck_' + urun.Id).text(urun.Name);

            $formCheck.append($checkbox).append($label);
            $form.append($formCheck);
        });

        $modalBody.append($form);
    } else {
        $modalBody.html('<div>Seçilecek ürün bulunmuyor.</div>');
    }
}

$('#productModal').on('show.bs.modal', function (event) {
    var $button = $(event.relatedTarget);
    var gunlukId = $button.data('gunluk-id');
    populateModal(gunlukId);
});

$('#saveSelectionButton').click(function () {
    var selectedProductIds = [];
    $('#productSelectionForm input[type="checkbox"]:checked').each(function () {
        selectedProductIds.push($(this).val());
    });

    $.ajax({
        url: '/Quality/TopluDemirFormu',
        type: 'POST',
        data: { urunIdler: selectedProductIds },
        success: function (response) {
            window.location.href = response.redirectUrl;
        },
        error: function () {
            alert('An error occurred while processing your request.');
        }
    });
});
