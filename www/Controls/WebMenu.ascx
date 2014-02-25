<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebMenu.ascx.cs" Inherits="WeavverWebMenu" %>
<style type="text/css">
    .navigationMenu
    {
        background-color: #414141;
    }

     .menuContainer
     {
     }
     .menuOption
     {
          background-color: #FFFFFF;
          color: #000000;
          clear: both;
          min-width: 120px;
          z-index: 1000000000;
     }
     .menuLink
     {
          padding: 8px;
          display: inline-block;
          text-decoration: none;
     }
     li
     {
          padding: 0px;
          margin: 5px;
     }
     ul
     {
          padding: 0px;
          margin: 0px;
          list-style-type: none;
     }
     .menuChild
     {
     }
     .no-close .ui-dialog-titlebar-close
     {
          display: none;
     }
</style>
<script type="text/javascript">
     var expandedMode = true;
     var hoverBackCover = "";
     var normalBackCover = "";
     var offsetX = 0;
     var offsetY = 0;

     $(document).ready(function () {
          jQuery.expr[':'].focus = function (elem) {
               return elem === document.activeElement && (elem.type || elem.href);
          };

          $.ctrl = function (key, callback, args) {
               $(document).keydown(function (e) {
                    if (!args) args = []; // IE barks when args is null 
                    if (e.keyCode == key.charCodeAt(0) && e.ctrlKey) {
                         callback.apply(this, args);
                         return false;
                    }
               });
          };

          //initialization
          $('.menu').menu({
               focus: function (event, ui) {
                    var menu = $(this);
                    var timeout = menu.data('timer');
                    if (timeout) {
                         clearTimeout(timeout);
                         menu.data('timer', null);
                    }
               },
               blur: function (event, ui) {
                    var menu = $(this);
                    timer = setTimeout(function () {
                         menu.menu().hide();
                         menu.data('state', 'hidden');
                         menu.data('timer', null);
                    }, 300);
                    menu.data('timer', timer);
               }
          }).removeClass('ui-corner-all').hide();

          $('.menuLink').hover
          (
               function () {
                    $(this).css("background-Color", "#FFFFFF");
                    $(this).css("color", "black");
                    //$('.addMenu', $(this)).css('visibility', '');
               },
               function () {
                    $(this).css("background-Color", "");
                    $(this).css("color", "white");
                    //                    if (expandedMode == false) {
                    //                         $('.addMenu', $(this)).css('visibility', 'hidden');
                    //                    }
               }
          );

          $('.menuLink').bind({
               click: function () {
                    var menu = $(this).next('.menu');

                    var state = menu.data('state');
                    if (state == "shown") {
                         $(this).css('background-color', 'white');
                         menu.menu().hide();
                         menu.data('state', 'hidden');
                    }
                    else {
                         var left = $(this).offset().left;
                         menu.menu().css('left', left);
                         var top = $('#topbar').offset().top + $('#topbar').height();
                         menu.menu().css('top', top);
                         menu.menu().show();
                         menu.data('state', 'shown');
                         $(this).css('background-color', '');
                    }
               }
          });

          //                         menu.css('position', 'absolute');
          //                         menu.slideDown("fast");

          $(document).keyup(function (e) {
               //alert(e.keyCode);

               if (e.keyCode == 27) // escape // clear any fields from focus
               {
                    $("input").blur();
               }

               if (e.keyCode == 77) { // m Key
                    if (!$("input").is(":focus")) {
                         toggleMenu();
                         e.stopPropagation();
                    }
               }
          });

          //          $.ctrl('M', function (event) {
          //               //alert('box has focus');
          //               if (!$("input").is(":focus")) {
          //                    toggleMenu();
          //                    event.stopPropagation();
          //               }
          //          });
     });

     function preventIFrameMouseEvents() {
          $('iframe').css('pointer-events', 'none');
     }

     function allowIFrameMouseEvents() {
          $('iframe').css('pointer-events', 'auto');
     }

     function closeIFrame(windowId, parentId) {
          refreshParent(parentId);
          $('#' + windowId).remove();
     }

     function refreshParent(parentId) {
          var obj = $('iframe', '#' + parentId);
          obj.attr('src', obj.attr('src'));

          //$(obj)[0].contentWindow.document.forms[0].submit()
          //$('input[type=submit]').click();
          //$(obj)[0].WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions("ctl00$Content$DList$searchButton", "", true, "", "", false, false));
     }

     function createPopup(url, width, height, myId) {
          isDialogLoaded = true;
          if (width == 0) {
               width = $(document).width() - 10;
               if (width > 800)
                    width = 800;
          }
          if (height == 0)
               height = 500;

          $('#ContentTable').remove();

          var windowId = getPseudoGuid();

          frameDialogs.push(windowId);

          var newPopup = $('#TheIFrame').clone();
          newPopup.attr("id", windowId);
          newPopup.attr("style", newPopup.attr("style") + "; ");
          newPopup.attr("isdialog", 'yes');

          // navigate to the frame
          if (url.match(/\?/))
               url = url + '&IFrame=true&WindowId=' + windowId;
          else
               url = url + '?IFrame=true&WindowId=' + windowId;
          if (myId)
               url = url + '&ParentId=' + myId;

          $('iframe', newPopup).attr('src', url);

          newPopup.dialog({
               open: function (event, ui) {
                    //$(this).parent().find('.ui-dialog-titlebar').append($('#ItemTitle'));
                    $(".ui-dialog-content").css("padding", 0);
                    $(this).css('overflow', 'hidden');
                    isDialogLoaded = true;
               },
               close: function (event, ui) {
                    frameDialogs.pop(myId);
               },
               title: "Loading..",
               dragStart: preventIFrameMouseEvents,
               dragStop: allowIFrameMouseEvents,
               resizeStart: preventIFrameMouseEvents,
               resizeStop: allowIFrameMouseEvents,
               position: [offsetX + 5, offsetY + 120],
               width: width,
               height: height
          });    //.attr('id', 'dialogId').attr('name', 'dialogId');

          //newPopup.draggable("option", "containment", [50, 50, 300, 300]);

          newPopup.resize(function () {
               clearTimeout(doit);
               doit = setTimeout(resizedw, 100);
          });

//          $('div', 'iframe').ready(function () {
//               $(this).dialog('option', 'title', $(this).attr('title'));
//          });

          //$('#ContentDIV').append(newPopup);

          offsetX = (offsetX > 100) ? 0 : offsetX + 20;
          offsetY = (offsetY > 100) ? 0 : offsetY + 20;
     }
     var frameDialogs = [];
</script>

<div id='TheIFrame' style='display:none;'>
     <iframe style='height: 95%; width: 100%;' src=""></iframe>
</div>

<%--
     Menu Example:
          
     <div>Nav</div>
          <div id="children">
               <div>Accounting</div>
               <div id="children">
                    asdf
               </div>
          </div>
     <div>New</div>
     <div id="children">
          <div>Accounting</div>
          <div id="children">
               asdf
          </div>
     </div

--%>
<asp:Literal ID="MenuItems" runat="server"></asp:Literal>
<div style='clear: both;'></div>