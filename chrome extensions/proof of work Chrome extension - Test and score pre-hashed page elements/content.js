
window.addEventListener("powCalculateRequestMsg", function(data) {
  // no data needed at this point, since only one action is possible with this content script - to check and calculate all pow elements
  validate_pow();
}, false);

$('document').ready(function() {validate_pow();});

function validate_pow() {
	const pow_salt_score_notfound = "?";

	$("span.pow-class").each(function(index) {
		$(this).children().remove();

		var pow_salt = $(this).attr('pow-salt');
		var pow_mod = $(this).attr('pow-mod');

		var pow_salt_score = pow_salt_score_notfound;

		if (!isNaN(pow_salt) && !isNaN(pow_mod)) {
			var pow_salt_n = BigInt(pow_salt);
			var pow_mod_n = BigInt(pow_mod);
								
			if (pow_mod_n > 0) {
				var el = $(this).parent();
				var htmltext = $(el).html();
				var hashtext = hex_md5(htmltext);
				var hash = BigInt('0x' + hashtext);
				if (hash % pow_mod_n == BigInt('0')) {
					// hash is exactly divisible by pow_mod_n -> hashed ok
					if (pow_salt_n == 0) {
						pow_salt_score = "0.0";
					}
					else {
						pow_salt_score = (Math.log10(parseInt(pow_salt_n))).toFixed(1).toString();
					}
				}
				else {
					// hash is not divisible by pow_mod_n -> test failed
				}
			}
		}
		
		var score = $('<span>' + pow_salt_score + '</span>');
		
		if (pow_salt_score == pow_salt_score_notfound) {
			score.addClass("pow-calc-test-failed");
		}
		else {
			score.addClass("pow-calc-test-passed");
		}

		score.appendTo($(this));
	});
}
