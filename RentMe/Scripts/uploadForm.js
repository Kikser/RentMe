$(document).ready(function () {
    $(".icon-bg").click(function (e) {
        ShowDialog(false);
        e.preventDefault();
    });

    $("#btnClose").click(function (e) {
        HideDialog();
        e.preventDefault();
    });
});


function ShowDialog(modal) {
    $("#overlay").show();
    $("#dialog").fadeIn(700);

    if (modal) {
        $("#overlay").unbind("click");
    }
    else {
        $("#overlay").click(function (e) {
            HideDialog();
        });
    }
}

function HideDialog() {
    $("#overlay").hide();
    $("#dialog").fadeOut(700);
}