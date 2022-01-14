$(document).ready(function () {
    $("#navLinks li a").click(function (e) {
        $(e.target).closest("a").addClass("border-wb3-tomato");
        $(e.target).closest("span").addClass("font-weight-bold");
        $(e.target).closest(".dropdown-menu").addClass("show");
    });
    //Add navlink formatting when dropdown menu is shown
    $("#navLinks li").on("show.bs.dropdown", function (e) {
        $(e.target).find("a").first().addClass("border-wb3-tomato");
        $(e.target).find("a span").first().addClass("font-weight-bold");
    });
    //Remove navlink formatting when dropdown menu is closed
    $("#navLinks").on("hidden.bs.dropdown", function () {
        $("#navLinks li a").each(function () {
            $(this).removeClass("border-wb3-tomato");
            $(this).children("span").removeClass("font-weight-bold");
        });
    });

    function positionNavbarsAndPageSections() {

        //Set main content position at the end of second navbar
        $("#main_container").offset({
            top: $("header").offset().top +
                document.querySelector("header").getBoundingClientRect().height
        });

        //Set footer at the end of main content
        $("footer").offset({
            top: $("#main_container").offset().top + document.getElementById("main_container").getBoundingClientRect().height
        });
    }

    $(window).on('load resize', function () {
        //positionNavbarsAndPageSections();

        //Remove w-100 from navlinks ul -> li for default behaviour
        $("#navLinks li").removeClass("w-100 p-2");
    });

    //Fix main content position after navbar2 toggler button show/hide
    $('header').on('shown.bs.collapse hidden.bs.collapse', function () {
        //Set main content position at the end of second navbar
        $("#main_container").offset({
            top: $("#navbar2").offset().top +
                document.getElementById("navbar2").getBoundingClientRect().height
        });
        //Set footer at the end of main content
        $("footer").offset({
            top: $("#main_container").offset().top + document.getElementById("main_container").getBoundingClientRect().height
        });
    });
    //Align navlinks to left in vertical state
    $('header').on('show.bs.collapse', function () {
        //Set navlinks ul -> li to w-100 to make them align left
        $("#navLinks li").addClass("w-100 p-2");
    });
    //Default navlinks behaviour in horizontal state
    $('header').on('hide.bs.collapse', function () {
        //Remove navlinks ul -> li to w-100 p-2
        $("#navLinks li").removeClass("w-100 p-2");
    });

    //Search bar submit button disable/enable based on term length
    $("#searchInput").change(function () {
        let term = $(this).val().trim();
        if (term.length < 3) {
            $("#searchSubmit").attr("disabled", true);
        }
        else {
            $("#searchSubmit").attr("disabled", false);
        }
    });

    //Lose focus of search field when hover on submit button, so the event above triggers.
    $("#searchInput").mouseout(function () {
        $("#searchInput").blur();
    });
});