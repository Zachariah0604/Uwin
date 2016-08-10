
function SetCookie(name, value, expires, path, domain, secure) {
    var today = new Date();
    today.setTime(today.getTime());
    if(expires) { expires *= 2592000; }
    var expires_date = new Date(today.getTime() + (expires));
    document.cookie = name + "=" + escape(value)
      + (expires ? ";expires=" + expires_date.toGMTString() : "")
      + (path ? ";path=" + path : "")
      + (domain ? ";domain=" + domain : "")
      + (secure ? ";secure" : "");
}

function GetCookie(name) {
    var cookies = document.cookie.split( ';' );
    var cookie = '';

    for(var i=0; i<cookies.length; i++) {
        cookie = cookies[i].split('=');
        if(cookie[0].replace(/^\s+|\s+$/g, '') == name) {
            return (cookie.length <= 1) ? "" : unescape(cookie[1].replace(/^\s+|\s+$/g, ''));
        }
    }
    return null;
}

function Delcookie(name, path, domain) {
    document.cookie = name + "="
      + (path ? ";path=" + path : "")
      + (domain ? ";domain=" + domain : "")
      + ";expires=Thu, 01-Jan-1970 00:00:01 GMT";
}
