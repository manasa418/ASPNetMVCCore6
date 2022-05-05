////var dataTable;

////$(document).ready(function () {

////    $.ajax({
////        "url": "/Admin/Category/GetAll",
////        success: function (data) {
////            $('#tab').dataTable({
////                data: data,
////                columns: [

////                    { "data": "id", "width": "15%" },
////                    { "data": "Name", "width": "15%" },
////                    { "data": "DisplayOrder", "width": "15%" },
////                    { "data": "CreatedDateTime", "width": "15%" },
////                    //{ "data": "Age", "width": "15%" },
////                    //{ "data": "Start date", "width": "15%" },
////                    //{ "data": "Salary", "width": "15%" },
////                ]

////            });
////        }

////    });

////});

$(document).ready(function () {
    var table = $('#tab').DataTable();

    $("#btnExport").click(function (e) {
        table.page.len(-1).draw();
        window.open('data:application/vnd.ms-excel,' +
            encodeURIComponent($('#tab').parent().html()));
        setTimeout(function () {
            table.page.len(10).draw();
        }, 1000)
        
    });
});


$(document).ready(function () {
    $('#tab').DataTable({
        "initComplete": function () {
            var api = this.api();
            api.$('td').click(function () {
                api.search(this.innerHTML).draw();
                
            });
        }
    });
});

//$(document).ready(function () {
//    var table = $('#tab').DataTable({
//        scrollY: "400px",
//        scrollX: true,
//        scrollCollapse: false,
//        paging: false,
//        fixedColumns: {
//            leftColumns: 1,
//        }
//    });
//});


//function loadDataTable() {
//    dataTable = $('#tab').dataTable(
//        {
//            "ajax": {
//                "url":"/Admin/Category/GetAll"            
//            },

//            "columns": [
//                { "data": "First name", "width": "15%" },
//                { "data": "Last name", "width": "15%" },
//                { "data": "Position", "width": "15%" },
//                { "data": "Office", "width": "15%" },
//                { "data": "Age", "width": "15%" },
//                { "data": "Start date", "width": "15%" },
//                { "data": "Salary", "width": "15%" },
//{
//    'data': 'Salary',
//        'render': function(salary) {
//            return '$' + salary;
//        }
//},
                
               
//            ]
//        }    
//});