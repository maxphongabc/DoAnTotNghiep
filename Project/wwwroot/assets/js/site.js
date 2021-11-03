$(document).ready(function () {
	$(window).scroll(function () {
		if ($(this).scrollTop() > 50) {
			$('#back-to-top').fadeIn();
		} else {
			$('#back-to-top').fadeOut();
		}
	});
	// scroll body to 0px on click
	$('#back-to-top').click(function () {
		$('body,html').animate({
			scrollTop: 0
		}, 400);
		return false;
	});
});
            $(document).ready(function () {
            $(".ajax-add-to-cart").click(function () {
                $.ajax({
                    url: "/Cart/AddCart",
                    data: {
                        id: $(this).data("id")
                    },
                    success: function (data) {
                        Swal.fire({
                            icon: 'success',
                            title: 'Thêm giỏ hàng thành công',
                            showConfirmButton: false,
                            timer: 2500
                        });
                    },
                    error: function () {
                        Swal.fire({
                            icon: 'error',
                            title: 'Thêm giỏ hàng thất bại',
                            text: 'Vui lòng thử lại',
                            showConfirmButton: false,
                            timer: 2500
                        });
                    }
                });
            });
        });
//$(document).ready(function () {
//    $(".ajax-add-to-wishlist").click(function () {
//        $.ajax({
//            url: "/WishList/AddWishList",
//            data: {
//                id: $(this).data("id")
//            },
//            success: function (data) {
//                Swal.fire({
//                    icon: 'success',
//                    title: 'Đã thêm vào danh sách yêu thích ',
//                    showConfirmButton: false,
//                    timer: 2500
//                });
//            },
//            error: function () {
//                Swal.fire({
//                    icon: 'error',
//                    title: 'Thêm sản phẩm yêu thích thất bại',
//                    text: 'Vui lòng thử lại',
//                    showConfirmButton: false,
//                    timer: 2500
//                });
//            }
//        });
//    });
//});
