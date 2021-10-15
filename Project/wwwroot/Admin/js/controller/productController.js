
//var common = {
//    init: function () {
//        common.registerEvent();
//    },
//    registerEvent: function () {
//        $("#txtKeyword").autocomplete({
//            minLength: 0,
//            source: function (request, response) {
//                $.ajax({
//                    url: "/Admin/Product/ListName",
//                    dataType: "json",
//                    data: {
//                        q: request.term
//                    },
//                    success: function (res) {
//                        response(res.data);
//                    }
//                });
//            },
//            focus: function (event, ui) {
//                $("#txtKeyword").val(ui.item.label);
//                return false;
//            },
//            select: function (event, ui) {
//                $("#txtKeyword").val(ui.item.label);
//                return false;
//            }
//        })
//            .autocomplete("instance")._renderItem = function (ul, item) {
//                return $("<li>")
//                    .append("<a>" + item.label + "</a>")
//                    .appendTo(ul);
//            };
//    }
//}
//common.init();
//var product = {
//    init: function () {
//        product.registerEvents();
//    },
//    registerEvents: function () {
//        $('.btn-images').off('click').on('click', function (e) {
//            e.preventDefault();
//            $('#imagesManange').modal('show');
//            $('#hidProductID').val($(this).data('id'));
//            product.loadImages();
//        });

//        $('#btnChooImages').off('click').on('click', function (e) {
//            e.preventDefault();
//            var finder = new CKFinder();
//            finder.selectActionFunction = function (url) {
//                $('#imageList').append('<div style="float:left"><img src="' + url + '" width="100" /><a href="#" class="btn-delImage"><i class="fa fa-times"></i></a></div>');

//                $('.btn-delImage').off('click').on('click', function (e) {
//                    e.preventDefault();
//                    $(this).parent().remove();
//                });

//            };
//            finder.popup();
//        });

//        $('#btnSaveImages').off('click').on('click', function () {
//            var images = [];
//            var id = $('#hidProductID').val();
//            $.each($('#imageList img'), function (i, item) {
//                images.push($(item).prop('src'));
//            })
//            console.log(id);
//            $.ajax({
//                url: '/Admin/Product/SaveImages',
//                type: 'POST',
//                data: {
//                    id: id,
//                    images: JSON.stringify(images)
//                },
//                dataType: 'json',
//                success: function (response) {
//                    if (response.status) {
//                        $('#imagesManange').modal('hide');
//                        $('#imageList').html('');
//                        alert('Save thành công');
//                    }

//                    //thong bao thanh cong
//                }
//            });
//        });
//    },
//    loadImages: function () {
//        $.ajax({
//            url: '/Admin/Product/LoadImages',
//            type: 'GET',
//            data: {
//                id: $('#hidProductID').val()
//            },
//            dataType: 'json',
//            success: function (response) {
//                var data = response.data;
//                var html = '';
//                $.each(data, function (i, item) {
//                    html += '<div style="float:left"><img src="' + item + '" width="100" /><a href="#" class="btn-delImage"><i class="fa fa-times"></i></a></div>'
//                });
//                $('#imageList').html(html);

//                $('.btn-delImage').off('click').on('click', function (e) {
//                    e.preventDefault();
//                    $(this).parent().remove();
//                });

//                //thong bao thanh cong
//            }
//        });
//    }
//}
//product.init();
function readURL(input) {
    if (input.files && input.files[0]) {
        let reader = new FileReader();

        reader.onload = function (e) {
            $("img#imgpreview").attr("src", e.target.result).width(200).height(200);
        };

        reader.readAsDataURL(input.files[0]);
    }
}

//$(document).ready(function () {
//    $("customerDatatable").DataTable({
//        "processing": true,
//        "serverSide": true,
//        "filter": true,
//        "ajax": {
//            "url": "/admin/controllers/category",
//            "type": "POST",
//            "datatype": "json"
//        },
//        "columnDefs": [{
//            "targets": [0],
//            "visible": false,
//            "searchable": false
//        }],
//        "columns": [
//            { "data": "id", "name": "Id", "autoWidth": true },
//            { "data": "name", "name": "Name", "autoWidth": true },
//            { "data": "slug", "name": "Slug", "autoWidth": true },
//            { "data": "status", "name": "Status", "autoWidth": true },
//            {
//                "render": function (data, row) {
//                    return "<a href='#' class='btn btn-danger' onclick=DeleteCategory('" + row.id + "');>Delete</a>";
//                }
//            }
//        ]
//    });
//});