if (!('console' in window)) {
    window.console = {
      log: function() {},
      debug : function(){},
      warn  : function(){},
      error : function(){}
    };
}

(function ($, window, document, undefined) {
  'use strict';

  window.UTme = window.UTme || {};
  UTme.run = UTme.run || {};
  UTme.setting = UTme.setting || {};
  
  
  UTme.userAgent = (function() {
    var name = window.navigator.userAgent.toLowerCase(),
    nameFunc = function(){ return name;},
    isIE = function(){ return ( name.indexOf('msie') >= 0 || name.indexOf('trident') >= 0 );},
    isiPhone = function(){ return name.indexOf('iphone') >= 0;},
    isiPod = function(){ return name.indexOf('ipod') >= 0;},
    isiPad = function(){ return name.indexOf('ipad') >= 0;},
    isiOS = function(){ return ( isiPhone() || isiPod() || isiPad() );},
    isAndroid = function(){ return name.indexOf('android') >= 0;},
    isAndroidDefault = function(){ return ( isAndroid() && name.indexOf('chrome') < 0 && name.indexOf('firefox') < 0 );},
    isAndroidTablet = function(){ return ( isAndroid() && name.indexOf('mobile') < 0 );},
    isAndroidPhone = function(){ return ( isAndroid() && name.indexOf('mobile') >= 0 );},
    isWindowsPhone = function(){ return (isIE() && name.indexOf('iemobile') >= 0);},
    isTablet = function(){ return ( isiPad() || isAndroidTablet() );},
    isSmartPhone = function(){ return ( isiPhone() || isAndroidPhone() || isWindowsPhone() );},
    isMobileDevice = function(){ return ( isSmartPhone() || isTablet() );},
    isMac = function(){ return ( name.indexOf('mac') >= 0 || name.indexOf('ppc') >= 0);},
    verArray = function(){ return _getVerArray();};

    function _getVerArray() {
      var array = (function() {
        if (isIE()) {
          return /(msie|rv:?)\s?([0-9]{1,})([\.0-9]{1,})/.exec(name);
        } else if (isiOS()) {
          return /(os)\s([0-9]{1,})([\_0-9]{1,})/.exec(name);
        } else if (isAndroid()) {
          return /(android)\s([0-9]{1,})([\.0-9]{1,})/.exec(name);
        }/* else if (isWindowsPhone()) {
          return /.../.exec(name);
        }*/
      })();

      return (array) ? [parseInt(array[2], 10), array[2] + array[3]] : false;
    }

    
    var isIEVer = function(targetVer) {
        return (isIE() && verArray()[0] == targetVer);
    },
    isIEVerLt = function(targetVer) {
        return (isIE() && verArray()[0] < targetVer);
    },
    isIEVerLte = function(targetVer) {
        return (isIE() && verArray()[0] <= targetVer);
    },
    isIEVerGt = function(targetVer) {
        return (isIE() && verArray()[0] > targetVer);
    },
    isIEVerGte = function(targetVer) {
        return (isIE() && verArray()[0] >= targetVer);
    };

    return {
      name: nameFunc,
      isIE: isIE,
      isiPhone: isiPhone,
      isiPod: isiPod,
      isiPad: isiPad,
      isiOS: isiOS,
      isAndroid: isAndroid,
      isAndroidDefault: isAndroidDefault,
      isAndroidTablet: isAndroidTablet,
      isAndroidPhone: isAndroidPhone,
      isTablet: isTablet,
      isSmartPhone: isSmartPhone,
      isMobileDevice: isMobileDevice,
      isWindowsPhone: isWindowsPhone,
      isIEVer: isIEVer,
      isIEVerLt: isIEVerLt,
      isIEVerLte: isIEVerLte,
      isIEVerGt: isIEVerGt,
      isIEVerGte: isIEVerGte,
      getVer: verArray[0],
      getVerFull: verArray[1],
      verArray: verArray
    };
  })();




  UTme.addClassUA = function() {

      var uaList = [];
      var ua = UTme.userAgent;

      // IE
      if (ua.isIE()) {
          uaList.push("isIE");
          if (ua.isIEVer(11)) { uaList.push("isIE11"); }
          if (ua.isIEVer(10)) { uaList.push("isIE10"); }
          if (ua.isIEVer(9)) { uaList.push("isIE9"); }
          if (ua.isIEVer(8)) { uaList.push("isIE8"); }
          if (ua.isIEVer(7)) { uaList.push("isIE7"); }
          if (ua.isIEVer(6)) { uaList.push("isIE6"); }
          if (ua.isIEVerLte(8)) { uaList.push("isLegacy"); }
          if (ua.isWindowsPhone()) { uaList.push("isWinPhone"); }
      }

      // iOS
      if (ua.isiOS()) {
          uaList.push("isiOS");
          if (ua.isiPad()) { uaList.push("isiPad"); }
          if (ua.isiPhone()) { uaList.push("isiPhone"); }
          if (ua.isiPod()) { uaList.push("isiPod"); }
      }

      // android
      if (ua.isAndroid()) {
          uaList.push("isAndroid");
         
          if(ua.isAndroidDefault()){  uaList.push("isAndroidDefault"); }
         
          if (ua.isTablet()) {  uaList.push("isAndroidTablet"); }
      }

      // device
      if (ua.isTablet()) { uaList.push("isTablet"); }
      if (ua.isSmartPhone()) { uaList.push("isSmartPhone"); }
      if (ua.isMobileDevice()) { uaList.push("isMobileDevice"); }
      if (!ua.isMobileDevice()) { uaList.push("isOtherDevice"); }

      // Modernizr
      if (Modernizr.touch) { uaList.push("isTouchDevice"); }
      if (!Modernizr.flexbox) { uaList.push("no-flexbox"); }
      
      Modernizr.addTest('cubicbezierrange', function() {
        var el = document.createElement('div');
        el.style.cssText = Modernizr._prefixes.join('transition-timing-function' + ':cubic-bezier(1,0,0,1.1); ');
        return !!el.style.length;
      });
      if (!Modernizr.cubicbezierrange) { uaList.push("no-cubicbezierrange"); }

      //Mac
      //if (ua.isMac()) { uaList.push("isMac"); }

      return uaList.join(" ");
  };
  
  
  
  
  
  (function init() {
    $('html')
      .addClass('js')
      .addClass(UTme.addClassUA());
      
    $(function() {
      $.each(UTme.run, function() {
          this.init();
      });
    });
  })();


})(jQuery, window, document);



(function ($, window, document, undefined) {
  'use strict';


  window.UTme = window.UTme || {};
  UTme.run = UTme.run || {};
  UTme.setting = UTme.setting || {};


  // スムーズスクロール
  UTme.run.smoothScroll = (function(){
    function init() {
      onSmoothScroll();
    }
    
    function onSmoothScroll() {
      $(document).on('click', 'a[href^="#"]:not(.js-noaclink)', function(e) {
        e.preventDefault();
        smoothScroll(this);
      });
    }
    function smoothScroll(el) {
      var target = $(el).attr('href');
      target = (target == '#') ? 'body' : target;
      if($(target)[0]) {
        $(target).velocity('scroll', {
          duration: 800,
          easing: 'easeInOutQuart'
        });
      }
    }
    return {
      init: init
    };
  })();



  // box高さ揃え
  UTme.run.macthHeight = (function(){
    function init() {
      $('.js-mh').matchHeight();
    }
    function change() {

    }
    function update() {
      $('.js-mh').matchHeight();
    }
    
    return {
      init: init,
      update: update
    };
  })();


  // トグル
  UTme.run.slideToggle = (function(){
    
    function init() {
      onClick();
    }
    
    function onClick() {
      var toggleBox = '.js-toggleBox'; //親box
      var toggleBtn = '.js-toggleSwitch'; //ボタン（複数可）
      var toggleContents = '.js-toggleContents'; //スライドするコンテンツ
      //data-slidetype 'none'でスライドなし？

      $(document).on('click', toggleBtn, function(e) {
        e.preventDefault();
        var $toggleBox = $(this).closest(toggleBox);
        //if(UTme.winNameCheck.hasName('w-l') && $toggleBox.attr('data-toggle-pc') == 'false') return;
        
        if($toggleBox.hasClass('is-open')) {
          $toggleBox.removeClass('is-open');
          $toggleBox.find(toggleContents).velocity('slideUp', { duration: 300, easing: UTme.setting.easing });
        } else {
          $toggleBox.addClass('is-open');
          $toggleBox.find(toggleContents).velocity('slideDown', { duration: 300, easing: UTme.setting.easing });
        }
      });
    }
    
    return {
      init: init
    };
  })();



  //tab
  UTme.run.tabBox = (function(){
    function init() {
      onClick();
    }
    
    function change() {
  
    }
    
    function onClick() {
      var tabBox = '.js-tabBox';
      var tabBtn = '.js-tabMenu a';
      var tabContents = '.js-tabContents';
      var isActive = 'is-active';
      
      $(document).on('click', tabBtn, function(e){
        e.preventDefault();
        var index = $(tabBtn).index(this);
        var $target = $(this).closest(tabBox).find(tabContents).eq(index);
        
        if($target[0]) {
          if(!$target.hasClass(isActive)) {
            // contents
            $(tabContents).removeClass(isActive);
            $target.addClass(isActive);
            
            // btn
            $(tabBtn).removeClass(isActive);
            $(this).addClass(isActive);
          }
        }
      });
    }
    
    return {
      init: init
    };
  })();
  
})(jQuery, window, document);




