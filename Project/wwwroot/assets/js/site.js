﻿(function ($) {



	/* ..............................................
	   Scroll
	   ................................................. */
	$(window).on('scroll', function () {
		if ($(window).scrollTop() > 50) {
			$('.main-header').addClass('fixed-menu');
		} else {
			$('.main-header').removeClass('fixed-menu');
		}
	});
	$(document).ready(function () {
		$(window).on('scroll', function () {
			if ($(this).scrollTop() > 100) {
				$('#back-to-top').fadeIn();
			} else {
				$('#back-to-top').fadeOut();
			}
		});
		$('#back-to-top').click(function () {
			$("html, body").animate({
				scrollTop: 0
			}, 600);
			return false;
		});
	});

}(jQuery));