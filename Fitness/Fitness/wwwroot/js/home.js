'use strict';
(function ($, Fitness) {

    
    function sendAjax(type,url,userId, abonamentId) {
        $.ajax({

            type: type,

            contentType: "application/json; charset=utf-8",

            url: url + "/" + userId + "/" + abonamentId,

            data: "{'userId':'" + userId + "', 'abonamentId':'" + abonamentId + "'}",

            async: true,

            success: function (response) {

                alert("Sikeresen be lett léptetve!");
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

        $(".entrance").click(function () {
            $(".entrance").attr("enabled", "false");
            sendAjax('POST', 'Home/Entrance', $(".userIdP").attr('id'), $(this).attr('id'));
        });
    });
    
})(jQuery, window.Fitness);