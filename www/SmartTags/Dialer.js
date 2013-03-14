// ©Weavver, Inc.  2010
// All Rights Reserved

var j;

function loadJQuery(window, document, version, callback) {
    var d;
    var loaded = false;
    if (!(j = window.jQuery) || version > j.fn.jquery || callback(j, loaded)) {
        var script = document.createElement("script");
        script.type = "text/javascript";
        script.src = "jquery.js";
        script.onload = script.onreadystatechange = function() {
            if (!loaded && (!(d = this.readyState) || d == "loaded" || d == "complete")) {
                callback((j = window.jQuery).noConflict(1), loaded = true);
                j(script).remove();
            }
        };
        document.documentElement.childNodes[0].appendChild(script)
    }
}

loadJQuery(window, document, "1.3", jquery_loaded);

function jquery_loaded(j, loaded)
{
     j(document).ready(function(){
	     markWords();
     });
}


var originalText = '';

function markWords(){

	if( originalText.length == 0 ){
		originalText = j('body').html();
		_text = originalText;
	}
	else{
		_text = originalText;
	}

	var KEY_REGEX_DEFAULT = "(" +
	    "((1\\s*)?\\d{3}[^\\d<]\\d{3}[^\\d<]\\d{4})" + // 877-947-3537
	    "|" +
	    "(\\(\\d{3}\\)\\s*\\d{3}[^\\d<]\\d{4})" + // (888) 742-4147
	    "|" +
	    "(\\+?\\d\\s*\\(\\d{3}\\)\\s*\\d{3}[^\\d<]\\d{4})" + // +1 (256) 428-6000
	    "|" +
	    "(\\+?\\d[^\\d<]\\d{3}[^\\d<]\\d{3}[^\\d<]\\d{4})" + // +1-256-428-6000
	    "|" +
	    "(\\d\\s*\\(\\d{3}\\)[^\\d(<]*\\(\\d{3}[^\\d<]\\d{4}\\))" + // 1 (877) LINUX-ME (546-8963)
	    "|" +
	    "(\\d-\\d{3}(-[a-z]+)+)" + // 1-800-AA-ZZZZZ
	    "|" +
	    "(1?\\d{10,13})" + // 2223334444, 12223334444
	    "|" +
	    "(0\\d{4}\\s*?\\d{6})" + // 01279 757775
	    "|" +
	    "(\\+\\d{2,3}\\s*[\\-\\.]?\\d{1,3}\\s*[\\-\\.]?\\d{3,4}\\s*[\\-\\.]?\\d{3,4})" +  // +31 20 12334676, +31 20 592 5065
	    "|" +
	    "(\\+44\\s*\\(0\\)\\s*\\d{4}[^\\d<]\\d{6})"  +  // +44(0)1865 332211
	    "|" +
	    "(\\+61\\s*\\(0\\)\\s*3[^\\d<]\\d{4}[^\\d<]\\d{4})"  + //+61 (0)3 9221 0888
	    "|" +
	    "(\\d{2}[\\s\-\\.]{1}(\\d{4}([\\s\\-\\.]{1})){2})" + //08 8228 2999
	     "|" +
	    "(\\(\\d{2}\\)\\s*(\\d{4}([\\s\-\\.]{1})){2})" + //(08) 8228 2999
	     "|" +
	     "(\\d{4}[\\s\\-\\.]{1}\\d{6,7})" + //0123-456789
	    ")";

	reg = new RegExp(KEY_REGEX_DEFAULT);
	textParts = new Array();

	while(true){
		m = reg.exec(_text);
		if( m != null ){
			textParts[textParts.length] = _text.substr(0, m.index + m[0].length);
			_text = _text.substr(m.index + m[0].length);
		}
		else {
			textParts[textParts.length] = _text.substr(0);
			break;
		}
	}

	// changes the mached text parts and join it
	fullText = '';
	for(i=0; i<textParts.length; i++){
		fullText += textParts[i].replace(reg, "<a href=\"javascript:;\" onmouseup=\"showDialog('$1');\">$1</a>");
	}

	// add a iframe to comunicate with server
	fullText = "<iframe id=\"dialerWidget\" style=\"display:visible; border: 1px dotted;\"></iframe>" + fullText;

	// set the div with fulltext
	j('body').html(fullText);

	// set the status ready
	setMyStatus('Ready');
}

function showDialog(num){
     j('#dialerWidget').attr('src', 'about:blank');
	j('#dialerWidget').attr('src', 'DialerWidget.aspx?num=' + num);
	j('#dialerWidget').css('visibility', 'visible');
	j('#dialerWidget').css('height', '150px');
}