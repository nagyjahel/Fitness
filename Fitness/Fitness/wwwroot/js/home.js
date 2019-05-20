'use strict';
(function ($, Fitness) {

    Fitness = Fitness || {};
    Fitness.userId = null;
    function sendAjax(type,url,userId, abonamentId) {
        $.ajax({

            type: type,

            contentType: "application/json; charset=utf-8",

            url: url,

            data: { 'userId': userId, 'abonamentId': abonamentId},

            async: true,

            success: function (response) {

                prompt("Sikeresen be lett léptetve!");
                console.log("Ok");

            },

            error: function () {

                console.log("Error");

            }

        });
    }
    
    Fitness.saveUserId = function (userId) {
        this.userId = userId;
    };
    $(document).ready(function () {
        $("#cardSearch").click(function () {
           //sendAjax('GET', 'Home/Card/',$("#cardId").val());
        });

        $(".entrance").click(function () {
            $(".entrance").attr("enabled", "false");
            sendAjax('POST', 'Home/Entrance/', Fitness.userId, $(this).attr('id'));
        });
    });

    return Fitness;

})(jQuery, window.Fitness);