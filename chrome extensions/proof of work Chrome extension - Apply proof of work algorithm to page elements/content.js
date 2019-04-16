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
		$('body').prepend("<form id='get-pow-mod-form' class='get-pow-mod-form-class'><div class='pow-form-container'><h2>Proof of Work hashing for html document elements</h2><div class='pow_form_label'><label for='p_modulo'>Enter Modulo</label></div><div class='pow-form-inputs'><input type='number' id='p_modulo' value='10' min='10'/></div><div class='pow-form-label'><label for='p_output'>hashed html output</label></div><div class='pow-form-inputs'><textarea id='p_output' rows='10' cols='100'>hashed html output</textarea></div><div class='pow-form-label'><label for='p_md5sum'>MD5 hash</label></div><div class='pow-form-inputs'><input type='text' id='p_md5sum' value='calculated MD5 hash'/><span class='pow-form-clocks' id='p_hashtime'>elapsed time</span><span id='p_clocks_separator' class='pow-form-clocks'>/</span><span class='pow-form-clocks' id='p_hashcount'>number of hashes</span></div></div></form>");
		
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
	
	var d_last = new Date();
	var d_total = 0;
	
	var hashtext = "";

	disablePowForm(true);
	
	do {
		pow_el.attr("pow-salt", i.toString());
		var htmltext = $(el).html();
		hashtext = hex_md5(htmltext);
		var hash = BigInt('0x' + hashtext);
		i++;
		var d_now = new Date();
		//if (i % 1000n == 0n) {
		if (d_now - d_last > 1000) {
			d_total += d_now - d_last;
			d_last = d_now;
			setPowFormClocks(i, d_total);
			console.log(".");
			await new Promise(resolve => setTimeout(resolve, 1));
		}
	} while (hash % pow_mod != BigInt('0') && bPowIsEnabled);
	
	if (bPowIsEnabled) {
		$('textarea#p_output').val($(el).html());
		$('input#p_md5sum').val(hashtext);
		disablePowForm(false);
		setPowFormClocks(i, d_total);
	}

	$("body").css( 'cursor', 'default' );
}

function disablePowForm(bFormDisabled) {
	if (!bPowIsEnabled) return;
	
	$('textarea#p_output').prop('disabled', bFormDisabled);
	
	if (bFormDisabled) {
		$('span#p_hashtime').html('elapsed time');
		$('span#p_hashcount').html('number of hashes');
		$('textarea#p_output').val('hashed html output');
		$('input#p_md5sum').val('calculated MD5 hash');
	}
}

function setPowFormClocks(hashcount, msec) {
	if (!bPowIsEnabled) return;

	var secondselapsed = parseInt(msec / 1000);
	var hours = parseInt(secondselapsed / 3600);
	var minutes = parseInt((secondselapsed / 60) % 60);
	var seconds = parseInt(secondselapsed % 60);
	
	$('span#p_hashtime').html(pad(hours, 3) + ':' + pad(minutes, 2) + ':' + pad(seconds, 2));
	$('span#p_hashcount').html(hashcount.toString());	
}

function pad(num, size) {
	var s = num.toString();
    while (s.length < size) s = "0" + s;
    return s;
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
	
	var hash_already_running = false;
	
	$(this).on('click', async function(event) {
		if (!bPowIsEnabled || hash_already_running) {
			$(this).off("click");
			return;			
		}
				
		hash_already_running = true;
		
		$(this).removeClass("highlight-pow");
		$(this).addClass('highlight-pow-running');
		$("body").css( 'cursor', 'wait' );
		var pow_mod = 10;
		if ($('input#p_modulo').length) {
			pow_mod = BigInt($('input#p_modulo').val());
		}
		event.stopImmediatePropagation();
		await calculate_pow(this, pow_mod);
		window.dispatchEvent(new CustomEvent("powCalculateRequestMsg", {data: 'validate_pow'}));
		
		$(this).removeClass('highlight-pow-running');
		hash_already_running = false;
	});
		
	event.stopImmediatePropagation();
});
