$(document).ready(function () {
    $("#categoryDatatable").DataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "orderMulti": false,
        "ajax": {
            "url": "/api/category",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs": [{
            "targets": [0],
            "visible": false,
            "searchable": false
        }],
        "columns": [
            { "data": "name", "name": "Name", "autoWidth": true },
            { "data": "slug", "name": "Slug", "autoWidth": true },
            {
                "render": function (data, row) {
                    return "<a href='' class='btn btn-danger' onclick=DeleteCategory('" + row.id + "');>Delete</a>";
                }
            }
        ]
    });
});
//var dataTable;

//$(document).ready(function () {
//    loadDataTable();
//});

//function loadDataTable() {
//    dataTable = $('#categoryDatatable').DataTable({
//        "ajax": {
//            "url": "/api/category",
//            "type": "GET",
//            "datatype": "json"
//        },
//        "columns": [
//           { "data": "id", "name": "Id", "20%": true },
//            { "data": "name", "name": "Name", "20%": true },
//            { "data": "slug", "name": "Slug", "20%": true },
//            {
//                "data": "id",
//                "render": function (data) {
//                    return `<div class="text-center">
//                        <a href="/Books/Upsert?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
//                            Edit
//                        </a>
//                        &nbsp;
//                        <a class='btn btn-danger text-white' style='cursor:pointer; width:70px;'
//                            onclick=Delete('/books/Delete?id='+${data})>
//                            Delete
//                        </a>
//                        </div>`;
//                }, "width": "40%"
//            }
//        ],
//        "language": {
//            "emptyTable": "no data found"
//        },
//        "width": "100%"
//    });
//}