define(["jquery", "scroll"], function ($) {
    function init() {
        $(".item-name").on("click", function () {
            var obj = $(this), ul = obj.next();
            ul.fadeToggle();
        })
        $(".vp-left-list").mCustomScrollbar();
    }
    return {
        init: init
    }
})