$(function() {
	"use strict";

    $(document).ready(function() {
        $.ajax({
            success: function(){
                $('#titleTable').DataTable();
                $('#orgsTable').DataTable();
                $('#orgMembersTable').DataTable();
                $('#bibleTable').DataTable();
                $('#bclassTable').DataTable();
                $('#activitiesTable').DataTable();
                $('#membersBirthdayTable').DataTable();
                $('#churchActivitiesAssignedTable').DataTable();
                $('#attendanceTable').DataTable();
            }
        })
    } );


    // $(document).ready(function() {
    //     var table = $('#example2').DataTable( {
    //         lengthChange: false,
    //         "responsive": true, "lengthChange": false, "autoWidth": false,
    //         buttons: ["copy", "csv", "excel", "pdf", "print", "colvis"]
    //     } );
     
    //     table.buttons().container()
    //         .appendTo( '#example2_wrapper .col-md-6:eq(0)' );
    // } );

        // $('#titleTable').DataTable();
        // $('#orgsTable').DataTable();
        // $('#orgMembersTable').DataTable();
        // $('#bibleTable').DataTable();
        // $('#bclassTable').DataTable();
        // $('#activitiesTable').DataTable();
        // $('#membersBirthdayTable').DataTable();
        // $('#activitiesAssignedTable').DataTable();


});



