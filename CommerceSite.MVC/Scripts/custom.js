$(document).ready(function () {

    $("#pageSize").change(function () {
        var pageSize = $("#pageSize option:selected").text();

        $.post("/Product/Products",
            {
                PageSize : pageSize
            });


    });
});