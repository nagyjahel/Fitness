'use strict';
(function ($) {

    function sendAjax(type,url, cardId) {
        $.ajax({

            type: type,

            contentType: "application/json; charset=utf-8",

            url: url,

            data: { 'cardId': cardId},

            async: true,

            success: function (response) {

                console.log("Ok");

            },

            error: function () {

                console.log("Error");

            }

        });
    }

    $(document).ready(function () {
        $("#cardSearch").click(function () {
           //sendAjax('GET', 'Home/Card/',$("#cardId").val());

        });
    });



})(jQuery);