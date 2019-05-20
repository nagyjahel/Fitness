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

        $('#newAbonamentButton').on('click', function () {
            if ($('#abonamentDetails').prop('hidden') == true) {
                $('#newAbonamentButton').removeClass('glyphicon glyphicon-menu-down');
                $('#newAbonamentButton').addClass('glyphicon glyphicon-menu-up');
                $('#abonamentDetails').prop('hidden', false);
            }
            else {
                $('#newAbonamentButton').removeClass('glyphicon glyphicon-menu-up');
                $('#newAbonamentButton').addClass('glyphicon glyphicon-menu-down');
                $('#abonamentDetails').prop('hidden', true);

            }
        });
    });

})(jQuery, window.Fitness);