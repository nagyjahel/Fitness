'use strict';
(function ($, Fitness) {

    $(document).ready(function () {
        $('#editFirstName').on('click', function (event) {
            if ($('#firstName').prop('disabled')) {
                $('#firstName').prop('disabled', false);
            }
            else {
                $('#firstName').prop('disabled', true);
            }
            
        });

        $('#editLastName').on('click', function (event) {
            if ($('#lastName').prop('disabled')) {
                $('#lastName').prop('disabled', false);
            }
            else {
                $('#lastName').prop('disabled', true);
            }

        });

        $('#editEmail').on('click', function (event) {
            if ($('#email').prop('disabled')) {
                $('#email').prop('disabled', false);
            }
            else {
                $('#email').prop('disabled', true);
            }

        });

        $('#editPhone').on('click', function (event) {
            if ($('#phone').prop('disabled')) {
                $('#phone').prop('disabled', false);
            }
            else {
                $('#phone').prop('disabled', true);
            }

        });

        $('#addNewCard').on('click', function () {
            $('#newCard').prop('hidden', false);
        });
    });

    function addCardToUset() {
        var cardId = $('#cardId').text();
        var cardDateFrom = $('#cardDateFrom').text();
        var cardDateTo = $('#cardDateTo').text();
        var userId = $('#userId').val();

        sendAjax("Cards", cardId, cardDateFrom, cardDateTo, userId);
    }

    function sendAjax(type, cardId, dateFrom, dateTo, userId) {
        var url = null;
        if (type == "Clients") {
            url = "/" + type + "/Cards/" + cardId + "/" + dateFrom + "/" + dateTo + "/" + userId;           
        }
        $.ajax({
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            url: url,
            data: "{'" + type + "':'" + cardId + "','dateFrom':'" + dateFrom + "','" + "','dateTo':'" + dateTo + "','" + "','userId':'" + userId + "'}",
            async: true,
            success: function (response) {
                console.log(type + ": new card saved in database with id number " + cardId);
            },
            error: function () {
                console.log("Error saving " + type + "in database");
            }
        });
    }

})(jQuery, window.Fitness);