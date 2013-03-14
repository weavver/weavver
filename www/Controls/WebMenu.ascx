<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebMenu.ascx.cs" Inherits="WeavverWebMenu" %>

<script type="text/javascript">
     function styleMenu() {
          $('.menuChildren', '.MenuOptions').hide();

          $('.menuOption,.menuRoot', '.MenuOptions').hover
          (
               function () {
                    $(this).css("background-Color", "white");
                    $(this).css("color", "black");
               },
               function () {
                    $(this).css("background-Color", "");
                    $(this).css("color", "white");
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
          $(".MenuOptions").slideUp("fast");
          $(".MenuRoot").hover(function () {
               $(".MenuOptionContainer").css('display', '');
               $(".MenuOptions").slideDown("fast");
          }, function () {
               $(".MenuOptions").slideUp("fast");
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


     });

     function toggleMenu() {
          if (!$('.MenuOptions').is(':visible')) {
               $(".MenuOptions").slideDown("fast");
          }
          else {
               $(".MenuOptions").slideUp("fast");
          }
     }

</script>

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
