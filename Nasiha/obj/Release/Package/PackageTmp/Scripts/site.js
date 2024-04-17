$(document).ready(function () {

    //$("body").on("click", function () {
    //    var attrValue = $("#searchForm").css("display");
    //    console.log(attrValue);

    //    if (attrValue === "block") {
    //        $("#searchForm").slideUp();
    //    }
    //});

    // show and hide adminMenu
    $(".showMenuBtn").on("click", function () {
        $(".adminMenu").slideToggle();
    });

    // show and hide search form
    $("#searchBtn").on("click", function () {
        $("#searchForm").slideToggle();
    });

    // search validation 
    $("#searchButton").on("click", function () {
        var searchQ = $("#searchQuery").val();

        if (searchQ === "" || searchQ === " ") {
            $('#warningModal').modal('show');
        } else {
            $("#searchButton").parents("form").submit();
        }
    });

    // add simple animation to home page

    setInterval(function () {
        $(".home i").toggleClass("active");
    }, 2000);

    // set default height for pages .. to make it take all screen Hight
    var windowHeight = $(window).innerHeight(),
        footerHeight = $("footer").outerHeight(),
        height = windowHeight - footerHeight;

    $(".content").css("minHeight", height);
    $(".login, .register, .ForgotPassword, .resetPassword, .intro")
        .css("minHeight", height);

    var windowWidth = $(window).outerWidth();
    if (windowWidth >= 768) {
        $(".adminMenu ").css("minHeight", height);
    }

    // remove input-lg and btn-lg bootstrap classes making fields and buttons biger the normal 
    // on xs Screens "Phones and taplets"
    if ($(window).innerWidth() <= 767) {
        $("form input").removeClass("input-lg");
        $("form .btn").removeClass("btn-lg");
    }

    // set background for social media icons 
    $(".social").each(function () {
        var brandColor = $(this).attr("data-color");
        $(this).css("backgroundColor", brandColor);
    });


    // return page Direction if user chossen arabic language
    var siteLanguage = document.cookie.replace(/(?:(?:^|.*;\s*)Language\s*\=\s*([^;]*).*$)|^.*$/, "$1");
    if (siteLanguage === "ar-EG") {
        $("html").attr("dir", "rtl");
    }

    // make change profile picture easier than before
    $(".userImage").on("click", function () {
        $(".profilePictureInput").click();
    });

    $(".profilePictureInput").on("change", function () {
        $(".profilePictureForm").submit();
    });

});