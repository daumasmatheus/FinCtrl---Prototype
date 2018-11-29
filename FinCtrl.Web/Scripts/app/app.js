$(document).ready(function () {
    $(".link-details").click(function () {
        var id = $(this).data("value");
        $("#conteudoModal").load("/Finances/Details/" + id, function () {
            $("#financesModal").modal("show");
        });
    });       
});