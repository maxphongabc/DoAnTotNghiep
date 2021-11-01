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