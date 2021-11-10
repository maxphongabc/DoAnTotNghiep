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
                location.reload()
                Swal.fire({
                    icon: 'success',
                    title: 'Thêm giỏ hàng thành công',
                    showConfirmButton: false,
                    timer: 2500
                });
                windown.location.reload();
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
$(function () {

    if ($("a.confirmDeletion").length) {
        $("a.confirmDeletion").click(() => {
            if (!confirm("Confirm deletion")) return false;
        });
    }

    if ($("div.alert.notification").length) {
        setTimeout(() => {
            $("div.alert.notification").fadeOut();
        }, 2000);
    }

});
function readURL(input) {
    if (input.files && input.files[0]) {
        let reader = new FileReader();

        reader.onload = function (e) {
            $("img#imgpreview").attr("src", e.target.result).width(200).height(200);
        };

        reader.readAsDataURL(input.files[0]);
    }
}