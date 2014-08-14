<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Calendar.aspx.cs" Inherits="Calendar" %>
<html>
     <head>
          <title>Company Calendar</title>
          <script type="text/javascript" src="/scripts/jquery-1.6.2.min.js"></script>
          <script type="text/javascript" src="/scripts/jquery-ui-1.8.16.custom.min.js"></script>
          <link rel='stylesheet' type='text/css' href='/vendors/adam shaw/fullcalendar/fullcalendar.css' />
          <link rel='stylesheet' type='text/css' href='/vendors/adam shaw/fullcalendar/fullcalendar.print.css' media='print' />

          <script type="text/javascript" src="/Vendors/Adam Shaw/fullcalendar/fullcalendar.min.js"></script>
          <script type="text/javascript">
          window.onresize = function(event) {
               $('#calendar').fullCalendar('option', 'height', document.body.offsetHeight - 122);
          }
          $('#calendar').width = "200px";
               $(document).ready(function() {

                    var date = new Date();
                    var d = date.getDate();
                    var m = date.getMonth();
                    var y = date.getFullYear();

                    $('#calendar').fullCalendar({
                         header: {
                              left: 'prev,next today',
                              center: 'title',
                              right: 'month,agendaWeek,agendaDay'
                         },
                         editable: false,
                         height: document.body.offsetHeight - 122,
                         windowresize: function(view) {
                         },
                         defaultView: 'month',
//			          events: [
//				          {
//				               title: 'All Day Event',
//				               start: new Date(y, m, 1)
//				          },
//				          {
//				               title: 'Long Event',
//				               start: new Date(y, m, d - 5),
//				               end: new Date(y, m, d - 2)
//				          },
//				          {
//				               id: 999,
//				               title: 'Repeating Event',
//				               start: new Date(y, m, d - 3, 16, 0),
//				               allDay: false
//				          },
//				          {
//				               id: 999,
//				               title: 'Repeating Event',
//				               start: new Date(y, m, d + 4, 16, 0),
//				               allDay: false
//				          },
//				          {
//				               title: 'Meeting',
//				               start: new Date(y, m, d, 10, 30),
//				               allDay: false
//				          },
//				          {
//				               title: 'Lunch',
//				               start: new Date(y, m, d, 12, 0),
//				               end: new Date(y, m, d, 14, 0),
//				               allDay: false
//				          },
//				          {
//				               title: 'Birthday Party',
//				               start: new Date(y, m, d + 1, 19, 0),
//				               end: new Date(y, m, d + 1, 22, 30),
//				               allDay: false
//				          },
//				          {
//				               title: 'Click for Google',
//				               start: new Date(y, m, 28),
//				               end: new Date(y, m, 29),
//				               url: 'http://google.com/'
//				          }
//			          ]
		          });
               });
          </script>
          <style type="text/css">
	          body 
	          {
	               overflow: hidden;
		          text-align: center;
		          font-size: 14px;
		          font-family: "Arial,Verdana,sans-serif";
		          margin: 0px;
		          padding: 0px;
               }
               #calendar {
		          margin: 0 auto;
		     }
          </style>
     </head>
     <body>
          <div id="top" style="text-align: left;background-color: #3b3b3b;background-image: url('<%= Page.ResolveUrl("~/images/header-background.png") %>');margin-bottom: 10">
               <table><tr>
                    <td>
                         <img src="/images/logo.png" style="height: 55px" />
                    </td>
                    <td style="font-size: 25px; padding-top: 10px; font-weight: bold;">Calendar</td>
               </tr></table>
          </div>
          <div id='calendar'></div>
     </body>
</html>