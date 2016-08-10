(function ($, window, document, undefined) {
  'use strict';


  window.UTme = window.UTme || {};
  UTme.run = UTme.run || {};
  UTme.setting = UTme.setting || {};

  
  UTme.run.gNav = (function() {
    function init() {
      pcInit();
    }
    
    function pcInit() {
      var $gNavWrap = $('#gnav');
      var $gNavLi = $('#gnav > li');
      var $gNavBtn = $gNavWrap.find('.gnav-button');

      $gNavBtn.on('click', function(e){
       
      });

      $gNavLi.on('mouseenter', function(e){

        var $this = $(this);
        var $parentLi = $this.closest('li');

      
        clearTimeout($this.data('mouseOutTimer'));

        if ($parentLi.hasClass('is-active')) return true;

        var timer = setTimeout(function() {
          $parentLi.removeClass('is-hover').addClass('is-active');
          $this.find('.snav-area').fadeIn(100);
        }, 150);

        $parentLi.addClass('is-hover');
        $this.data('mouseInTimer', timer);
      });

      $gNavLi.on('mouseleave', function(e){

        var $this = $(this);
        var $parentLi = $this.closest('li');
       
        clearTimeout($this.data('mouseInTimer'));
        var timer = setTimeout(function() {
          $this.find('.snav-area').fadeOut(100, function() {
            $parentLi.removeClass('is-active');
          });
        }, 100);

        $parentLi.removeClass('is-hover');
        $this.data('mouseOutTimer', timer);
      });

      $gNavLi.on('focusin', function(e){
        $(this).trigger('mouseenter');
      });

      $gNavLi.on('focusout', function(e){
        $(this).trigger('mouseleave');
      });
    }
    
    return {
      init: init
    };
  })();

  UTme.run.checkUserAgent = (function() {
    var ua = UTme.setting.ua,
        versionLimit = 10,
        message = 'このウェブサイトには、お使いのブラウザでは動作しない部分や表示が崩れる部分があります。\n下記の推奨ブラウザをご利用ください。\n\n推奨ブラウザ：\nChrome最新版、Firefox最新版 Internet Explorer 11以上',
        isTarget = location.pathname === '/' || location.pathname === '/index.html' || location.pathname === '/news/';
    function init(){
      if(UTme.userAgent.isIEVerLte(versionLimit) && isTarget){
        alert(message);
      }
    }
    return {
      init: init
    };
  })();
})(jQuery, window, document);

