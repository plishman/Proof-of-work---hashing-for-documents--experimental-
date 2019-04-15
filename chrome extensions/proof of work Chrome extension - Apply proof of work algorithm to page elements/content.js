var bPowIsEnabled = false;
EnablePow();

function EnablePow(){
	bPowIsEnabled = $('body').hasClass('pow-calculator');

	if (bPowIsEnabled) {
		$('form#get-pow-mod-form').remove();
		$('body').removeClass('pow-calculator');
		bPowIsEnabled = false;
	}
	else {
		$('form#get-pow-mod-form').remove();
		$('body').prepend("<form id='get-pow-mod-form' class='get-pow-mod-form-class'><div class='pow-form-container'><div class='pow_form_label'><label for='p_modulo'>Enter Modulo</label></div><div class='pow-form-inputs'><input type='number' id='p_modulo' value='10' min='10'/></div><div class='pow-form-label'><label for='p_output'>hashed html output</label></div><div class='pow-form-inputs'><textarea id='p_output' rows='10' cols='100'>hashed html output</textarea></div></div></form>");
		
		$('body').addClass('pow-calculator');

		window.dispatchEvent(new CustomEvent("powCalculateRequestMsg", {data: 'validate_pow'}));	  
		bPowIsEnabled = true;
	}
}

async function calculate_pow(el, modulo)
{
	var pow_mod = BigInt(modulo);

	$(el).children().remove('.pow-class');
	pow_el = $("<span pow-salt='0' pow-mod='" + modulo.toString() + "' class='pow-class'></span>").appendTo($(el));
		
	var i = BigInt(0);
	
	do {
		pow_el.attr("pow-salt", i.toString());
		var htmltext = $(el).html();
		var hashtext = hex_md5(htmltext);
		var hash = BigInt('0x' + hashtext);
		i++;
		if (i % 1000n == 0n) {
			console.log(".");
			await new Promise(resolve => setTimeout(resolve, 100));
		}
	} while (hash % pow_mod != BigInt('0'));
	
	$('textarea#p_output').val($(el).html());
	$("body").css( 'cursor', 'default' );
}

$('.pow-article-content').mouseenter(function(event) {
	if (!bPowIsEnabled) {
		$(this).off("mouseenter");
		return;
	}

	$(this).mouseleave(function(event){
		$(this).removeClass("highlight-pow");
		$(this).off("mouseleave");
		event.stopImmediatePropagation();
	});
	
	$(this).addClass("highlight-pow");
	
	$(this).on('click', async function(event) {
		if (!bPowIsEnabled) {
			$(this).off("click");
			return;			
		}

		$(this).removeClass("highlight-pow");
		$("body").css( 'cursor', 'wait' );
		var pow_mod = 10;
		if ($('input#p_modulo').length) {
			pow_mod = BigInt($('input#p_modulo').val());
		}
		event.stopImmediatePropagation();
		await calculate_pow(this, pow_mod);
		window.dispatchEvent(new CustomEvent("powCalculateRequestMsg", {data: 'validate_pow'}));
	});
		
	event.stopImmediatePropagation();
});
