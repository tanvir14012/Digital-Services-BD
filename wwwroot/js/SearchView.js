$(document).ready(function () {
    //Price submit
    $("#goPrice").click(function () {
        let priceRange = $("#priceRange").slider("option", "values")[0].toString().concat("to").concat($("#priceRange").slider("option", "values")[1].toString());
        $("#priceRangeInput").val(priceRange);
        $("#pageNoInput").val("1");
        $("#searchForm").submit();
    });

    //Pagination
    $(".pagination li").click(function (evt) {
        let page = $(evt.target).closest("a").attr("value");
        if (parseInt(page)) {
            $("#pageNoInput").val(page);
            $("#searchForm").submit();
        }
    });

    //Sort by filter change 
    $("#sortBy").change(function () {
        $("#pageNoInput").val("1");
        $("#searchForm").submit();
    });
});