<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HttpStreaming.aspx.cs" Async="true" Inherits="System_CometTest" MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" Runat="Server">
     <h2>HTTP Streaming</h2><br />
     The following page is a test harness for the Weavver.Web.HttpStreaming* classes.<br />
     <br />
     Notes: HttpResponse.Flush() does not flush unless the buffer has more then 256 bytes in it.<br />
     <br />
     <script language="javascript" type="text/javascript">
		function startHttpStream()
		{
			var url = "HttpStreaming.ashx";
			postRequest(url);
		}

		var xmlhttp = null;
		function postRequest(url)
		{
			if (window.XMLHttpRequest)
               {
                    xmlhttp = new XMLHttpRequest(); // code for IE7+, Firefox, Chrome, Opera, Safari
               }
               else if (window.ActiveXObject)
               {
                    xmlhttp = new ActiveXObject("Microsoft.XMLHTTP"); // code for IE6, IE5
               }
			xmlhttp.open("POST", url, true);
               xmlhttp.onreadystatechange = function()
                                            {
                                                 pollLatestResponse();
                                            };
			xmlhttp.send();
		}
		
		var nextReadPos = 0;
          function pollLatestResponse()
          {
               if (xmlhttp.readyState == 3)
			{
			     // alert(xmlhttp.responseText);
                    var allMessages = xmlhttp.responseText;
                    do
                    {
                         var unprocessed = allMessages.substring(nextReadPos);
                         var messageXMLEndIndex = unprocessed.indexOf("</message>");
                         if (messageXMLEndIndex!=-1) {
                              var endOfFirstMessageIndex = messageXMLEndIndex + "</message>".length;
                              var message = unprocessed.substring(0, endOfFirstMessageIndex - 10);
                              if (nextReadPos > 256)
                              {
                                   document.getElementById("divResponse").innerHTML = "<p>" + message + "</p>";
                              }
                              nextReadPos += endOfFirstMessageIndex;
                         }
                    }
                    while (messageXMLEndIndex != -1);
                    xmlhttp.responseText = "";
               }
               else
               {
                    //alert("some random state: " + xmlhttp.readyState);
               }
          }
     </script>
     <input type="button" value="Start Clock" onclick="javascript:startHttpStream();" /><br />
	<div id="divResponse"></div>
</asp:Content>