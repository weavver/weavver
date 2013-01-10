<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Kiosk.aspx.cs" Inherits="Company_Human_Resources_Kiosk" Title="Untitled Page" %>
<html>
<head>
     <title>Weavver :: Company Kiosk</title>
     <link href="/Style.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color: #FFFFFF; padding: 20px;">
<form runat="server">
     <script type="text/javascript">
          function typeKey(e)
          {
               if (e.value == "<")
               {
                    Entry.value = Entry.value.substring(0, Entry.value.length - 1);
               }
               else if (e.value != "<")
               {
                    Entry.value += e.value;
               }
          }

          function Next()
          {
               Entry.value = "";
          }
     </script>
     <div style="margin:auto; text-align: center">
          <br />
          <img id="Logo" runat="server" src="/images/logo.jpg" alt="Sankofa" Height="150" /><br />
          <h1><asp:Literal ID="OrgName" runat="server"></asp:Literal> Kiosk</h1>
     </div>
     <div style="width:824px; margin: auto;">
          <br />
          <div style="text-align: center; padding-top: 5px; padding-bottom: 15px;">
               <asp:Label ID="PhoneNumber" Text="<br />" runat="server"></asp:Label><br />
               <asp:Label ID="Directions" Text="" runat="server"></asp:Label>
          </div>
          <div style="text-align: center; padding: 10px;">
               &nbsp;&nbsp;&nbsp;&nbsp;<asp:Textbox ID="Entry" runat="server" Height="30px" Width="200px"></asp:Textbox>
               <input type="button" class="keyboardbutton" value="<" style="WIDTH:50px; height: 32px;" onclick="typeKey(this)" />
          </div>
          <div style="text-align: center; padding-top: 5px; padding-bottom: 5px;">
               <input type="button" class="keyboardbutton" value="1" onclick="typeKey(this)" />
               <input type="button" class="keyboardbutton" value="2" onclick="typeKey(this)" />
               <input type="button" class="keyboardbutton" value="3" onclick="typeKey(this)" /><br />
               <input type="button" class="keyboardbutton" value="4" onclick="typeKey(this)" />
               <input type="button" class="keyboardbutton" value="5" onclick="typeKey(this)" />
               <input type="button" class="keyboardbutton" value="6" onclick="typeKey(this)" /><br />
               <input type="button" class="keyboardbutton" value="7" onclick="typeKey(this)" />
               <input type="button" class="keyboardbutton" value="8" onclick="typeKey(this)" />
               <input type="button" class="keyboardbutton" value="9" onclick="typeKey(this)" /><br />
               <input type="button" class="keyboardbutton" value="0" onclick="typeKey(this)" /><br />
               <br />
               <div style="margin:auto;">
                    <asp:Button id="Reset" runat="server" Text="Reset" class="keyboardbutton" style="background-color: coral; height: 30px; border: outset;" Width="100px" OnClick="Reset_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button id="Next" runat="server" Text="Next" class="keyboardbutton" style="background-color: lightblue; height: 30px; border: outset;" Width="150px" OnClick="Next_Click" />
               </div>
               <img alt="" src="/images/powered-by-weavver.png" height="50px" vspace="10" style="padding-right: 25px; padding-top:10px;" />
          </div>
     </div>
     <div style="text-align: center; clear: both; vertical-align: middle;">
     </div>
     <br />
</form>
</body>
</html>