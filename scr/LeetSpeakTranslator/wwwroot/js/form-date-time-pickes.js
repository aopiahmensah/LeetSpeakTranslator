$(function() {
	"use strict";

    $('.datepicker').pickadate({
        selectMonths: true,
        selectYears: true
    }),
    $('.timepicker').pickatime()


   
        // $('#date-time').bootstrapMaterialDatePicker({
        //     format: 'YYYY-MM-DD HH:mm'
        // });


        $('#dob').bootstrapMaterialDatePicker({
            time: false
        });
        $('#dateEmployed').bootstrapMaterialDatePicker({
            time: false
        });
        $('#dateEnrolled').bootstrapMaterialDatePicker({
            time: false
        });
        $('#dateCompleted').bootstrapMaterialDatePicker({
            time: false
        });



        // $('#time').bootstrapMaterialDatePicker({
        //     date: false,
        //     format: 'HH:mm'
        // });
   
 

});