$(document).ready(function () {
    $("input[type='radio']").change(function () {
        btnRadioValidation();
    });
});


function btnRadioValidation() {
    var radioboxValue = $("input[type='radio']:checked").val();
    if (!radioboxValue === true) {
        $("#btnSubmit").attr("disabled", true);
        $("#divErrorMessage").show();
    }
    else {
        $("#divErrorMessage").hide();
        $("#btnSubmit").attr("disabled", false);
    }
}
