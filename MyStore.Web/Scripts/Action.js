﻿(function (action, $) {
    action.InitForm = function ($form) {

        $(":submit", $form).click(function (e) {
            e.preventDefault();
            var form = $(this).closest("form");
            var actionUrl = $(this).data("form-action");
            if (actionUrl)
                form.attr("action", actionUrl);

            form.submit();
        });

        $(":not(:submit)[data-form-action]", $form).click(function (e) {
            e.preventDefault();
            var actionUrl = $(this).data("form-action");
            if (actionUrl)
                window.location.href = actionUrl;
        });

    }

}(window.action = window.action || {}, jQuery));