$(document).ready(function () {
    $('#inpPN').keyup(function () {
        if ($('#inpPN').val() != '') {
            $('#divSVC').show();
        } else {
            $('#divSVC').hide();
        }
    })
});




