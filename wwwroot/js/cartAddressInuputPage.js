$(document).ready(function () {
    $("#skip").click(function () {
        $("#isAnonymous").val(true);
        $("form").submit();
    });

    $("[data-toggle='tooltip']").tooltip();

    //Division change
    $("#BillingAddress_State").change(function () {
        let division = $(this).val();
        let division_id = $(this).children(`option[value=${division}]`).attr("data-id");
        $(`#BillingAddress_City option`).hide();
        $(`#BillingAddress_City option[data-division-id=${division_id}]`).show();
        $(`#BillingAddress_City option[data-division-id=${division_id}]`).first().attr("selected", true);
        $(`#BillingAddress_City`).val($(`#BillingAddress_City option[data-division-id=${division_id}]`).first().val());
        let district_id = $(`#BillingAddress_City option[data-division-id=${division_id}]`).first().attr("data-id");
        $(`#BillingAddress_Zip`).val($(`#BillingAddress_Zip option[data-district-id=${district_id}]`).first().val());
    });

    //District change
    $("#BillingAddress_City").change(function () {
        let district = $(this).val();
        let district_id = $(this).children(`option[value=${district}]`).attr("data-id");
        $(`#BillingAddress_Zip option`).hide();
        $(`#BillingAddress_Zip option[data-district-id=${district_id}]`).show();
        $(`#BillingAddress_Zip option[data-district-id=${district_id}]`).first().attr("selected", true);
        $(`#BillingAddress_Zip`).val($(`#BillingAddress_Zip option[data-district-id=${district_id}]`).first().val());
    });

    //Initial placeholder values
    $('#BillingAddress_State').val("Dhaka");

    $('#BillingAddress_City option').hide();
    $('#BillingAddress_City option[data-division-id=3]').show();
    $('#BillingAddress_City option[data-division-id=3]').first().attr("selected", true);

    $('#BillingAddress_Zip option').hide();
    $('#BillingAddress_Zip option[data-district-id=1]').show();
    $('#BillingAddress_Zip option[data-district-id=1]').first().attr("selected", true);
    $('#BillingAddress_Zip').val($('#BillingAddress_Zip option[data-district-id=1]').first().val());

});