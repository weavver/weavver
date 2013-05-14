<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebMenu.ascx.cs" Inherits="WeavverWebMenu" %>
<style type="text/css">
    .navigationMenu
    {
        background-color: #414141;
    }
</style>
<script type="text/javascript">
     var expandedMode = true;
     var hoverBackCover = "";
     var normalBackCover = "";




     function preventIFrameMouseEvents() {
          $('iframe').css('pointer-events', 'none');
     }

     function allowIFrameMouseEvents() {
          $('iframe').css('pointer-events', 'auto');
     }

     function styleMenu() {
          $('.menuChildren', '.MenuOptions').hide();

          $('.menuOption,.menuRoot', '.MenuOptions').css('cursor', 'pointer');
          $('.menuOption,.menuRoot', '.MenuOptions').hover
          (
               function () {
                    $(this).css("background-Color", "#FFFFFF");
                    $(this).css("color", "black");
                    $('.addMenu', $(this)).css('visibility', '');
               },
               function () {
                    $(this).css("background-Color", "");
                    $(this).css("color", "white");
                    if (expandedMode == false) {
                         $('.addMenu', $(this)).css('visibility', 'hidden');
                    }
               }
          );

          $('.menuRoot', '.MenuOptions').bind({
               click: function () {
                    var html = $(this).html();

                    var state = $(this).attr('state');
                    if (state == "shown") {
                         $(this).next('.menuChildren').slideUp("fast");
                         $(this).attr('state', 'hidden');
                    }
                    else {
                         $(this).next('.menuChildren').slideDown("fast");
                         $(this).next('.menuChildren').children().css("padding-left", "10px");
                         $(this).attr('state', 'shown');
                    }
               }
          });
     }

     $(document).ready(function () {
          //$(".MenuOptions").slideUp("fast");
          $(".MenuRoot").hover(function () {
               $(".MenuOptionContainer").css('display', '');
               $(".MenuOptions").slideDown("fast");
          }, function () {
               if (expandedMode == false) {
                    $(".MenuOptions").slideUp("fast");
               }
          });

          styleMenu();

          $.ctrl = function (key, callback, args) {
               $(document).keydown(function (e) {
                    if (!args) args = []; // IE barks when args is null 
                    if (e.keyCode == key.charCodeAt(0) && e.ctrlKey) {
                         callback.apply(this, args);
                         return false;
                    }
               });
          };

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

          jQuery.expr[':'].focus = function (elem) {
               return elem === document.activeElement && (elem.type || elem.href);
          };

          //          $.ctrl('M', function (event) {
          //               //alert('box has focus');

          //               if (!$("input").is(":focus")) {
          //                    toggleMenu();
          //                    event.stopPropagation();
          //               }
          //          });

          //$('.MenuOptions').css('position', 'absolute');
          $('.MenuOptions').css('border-right', '2px solid gray');
          $('.MenuOptions').css('border-top', '1px solid gray');
          //          $('.MenuOptions').position({
          //               my: 'left top',
          //               at: 'left top',
          //               of: '#ContentTable'
          //          });

          $('.MenuOptions').css('left', 0);
          toggleMenu();

          var x = $('<div id="menucontainer" style="background-color: #414141" />');
          $(document.body).append(x);

          $("#menucontainer").append($('.MenuOptions'));

          //$('.MenuOptions').resizable();
          //$('.MenuOptions').draggable();

          $('#menucontainer').dialog({
               open: function (event, ui) {
                    //$(this).parent().find('.ui-dialog-titlebar').append($('#ItemTitle'));
                    $(".ui-dialog-content").css("padding", 0);
                    $(this).css('overflow', 'hidden');
               },
               height: 700, width: 200, position: [10, 82], title: "Navigation"
          });
          
          $('.MenuRoot').remove();

     });

     function toggleMenu() {
          if (!$('.MenuOptions').is(':visible')) {
               $(".MenuOptions").slideDown("fast");
          }
          else if (expandedMode == false) {
               $(".MenuOptions").slideUp("fast");
          }
     }

     function createPopup(url, height, width) {
          $('#ContentDIV').remove();

          var windowId = getPseudoGuid();

          var newPopup = $('#TheIFrame').clone();
          newPopup.attr("id", windowId);
          newPopup.attr("style", newPopup.attr("style") + "; ");
          newPopup.attr("isdialog", 'yes');

          // navigate to the frame
          if (url.match(/\?/))
               url = url + '&IFrame=true&WindowId=' + windowId;
          else
               url = url + '?IFrame=true&WindowId=' + windowId;
          $('iframe', newPopup).attr('src', url);

          newPopup.dialog({
               open: function (event, ui) {
                    //$(this).parent().find('.ui-dialog-titlebar').append($('#ItemTitle'));
                    $(".ui-dialog-content").css("padding", 0);
                    $(this).css('overflow', 'hidden');
               },
               title: "Loading..",
               dragStart: preventIFrameMouseEvents,
               dragStop: allowIFrameMouseEvents,
               resizeStart: preventIFrameMouseEvents,
               resizeStop: allowIFrameMouseEvents,
               position: [240 + offsetX, 82 + offsetY],
               width: width,
               height: height
           });

          newPopup.resize(function () {
               clearTimeout(doit);
               doit = setTimeout(resizedw, 100);
          });

          $('div', 'iframe').ready(function () {
               $(this).dialog('option', 'title', $(this).attr('title'));
          });

          //$('#ContentDIV').append(newPopup);

          offsetX = (offsetX > 100) ? 0 : offsetX + 20;
          offsetY = (offsetY > 100) ? 0 : offsetY + 20;
     }
     var offsetX = 0;
     var offsetY = 0;
</script>

<div id='TheIFrame' style='display:none;'>
     <iframe id='detailsframe' style='height: 95%; width: 100%;' src=""></iframe>
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


<div class="MenuRoot" style="float:left;z-index: 1000; min-width: 65px; cursor: pointer; min-height: 28px;max-width: 100px; background-color: #414141; color: #FFFFFF; margin-top: 4px; padding-top: 7px; border: 1px solid black; text-align: center;">
     <div style="display: inline-block; vertical-align: middle;">
          MENU
     </div>
     <div class="MenuOptionContainer">
          <div class='MenuOptions'>
               <asp:Literal ID="MenuItems" runat="server"></asp:Literal>
          </div>
     </div>
</div>

