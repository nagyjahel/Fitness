'use strict';
(function ($, Fitness) {

    $(document).ready(function () {
        $('#selectedType').on('change', function (event) {
            var type = $('#selectedType').val();
            console.log(type);
            switch (type) {
                case "0":
                    $('#startDate').attr('hidden', false);
                    $('#endDate').attr('hidden', false);
                    $('#accessLimit').attr('hidden', true);
                    break;
                case "1":
                    $('#startDate').attr('hidden', true);
                    $('#endDate').attr('hidden', true);
                    $('#accessLimit').attr('hidden', false);
                    break;
                case "2":
                    $('#startDate').attr('hidden', false);
                    $('#endDate').attr('hidden', false);
                    $('#accessLimit').attr('hidden', false);
                    break;
                default:
                    $('#startDate').attr('hidden', true);
                    $('#endDate').attr('hidden', true);
                    $('#accessLimit').attr('hidden', true);
                    break;
            }
            
        });
        $("#selectAll").click(function () {
            $('input:checkbox').not(this).prop('checked', this.checked);
        });
    });

})(jQuery, window.Fitness);