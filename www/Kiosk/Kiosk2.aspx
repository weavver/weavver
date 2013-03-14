<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Kiosk2.aspx.cs" Inherits="Company_Human_Resources_Kiosk2" Title="Weavver :: Kiosk" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<form id="Form1" runat="server">
<html>
<head>
     <title>Weavver :: Company Kiosk</title>
     <link href="/Style.css" rel="stylesheet" type="text/css" />
     <asp:ScriptManager ID="ScriptManager1" runat="server">
     </asp:ScriptManager>
</head>
<body style="background-color: #FFFFFF; padding: 20px;">
     <div style="font-size: 14pt;">
          Hello <asp:Label ID="LoginName" runat="server" />, please choose an option below:
     </div>
     <br />
     <br />
     <img src="/images/about/{id}.jpg" style="width: 250px; height: 200px; float:left; padding: 10px;" />
     You punched in today at <asp:Label ID="PunchedIn" runat="server" Text="7:40AM"></asp:Label>. You can <asp:Button ID="Punch" runat="server" Text="Punch Out" style="height: 30px;" OnClick="Punch_Click" />.<br />
     <br />
     You can check your time card here.<br />
     <asp:LinkButton ID="HiddenButton" runat="server" Text="Properties" style="visibility:hidden; position: absolute; top: 0px; left: 0px;"></asp:LinkButton>
     <cc1:ModalPopupExtender ID="Mod" BackgroundCssClass="modalPopup" runat="server" TargetControlID="TimeCardShow" PopupControlID="TimeCard" CancelControlID="Cancel" Drag="true"></cc1:ModalPopupExtender>
     <asp:Panel id="TimeCard" runat="server" style="border: solid 1px black; height: 350px; width: 400px;" BackColor="White">
          <asp:DataGrid ID="List" runat="server" AutoGenerateColumns="false" Width="100%" style="max-height: 150px; width: 100%; overflow-y: scroll; font-family: Cambria; font-size: 12pt">
          <Columns>
               <asp:BoundColumn HeaderText="Id" DataField="Id" Visible="false"></asp:BoundColumn>
               <asp:BoundColumn HeaderText="Rev" DataField="Rev" Visible="false"></asp:BoundColumn>
               <asp:BoundColumn HeaderText="In" DataField="DateTimeIn" ItemStyle-Font-Size="10pt" ItemStyle-Font-Names="Verdana"></asp:BoundColumn>
               <asp:BoundColumn HeaderText="Out" DataField="DateTimeOut" ItemStyle-Font-Size="10pt" ItemStyle-Font-Names="Verdana"></asp:BoundColumn>
          </Columns>
          </asp:DataGrid>
          <div style="float:right;position:absolute; bottom:0px; width: 380; height: 80px; text-align: center;">
               Total: <asp:Label ID="TotalTime" runat="server"></asp:Label><br />
               <br />
               <asp:Button ID="Cancel" runat="server" Text="Close Time Card" Width="140px" Height="40px" />
          </div>
     </asp:Panel>
     <asp:Button ID="TimeCardShow" runat="server" Text="Time Card" OnClick="TimeCardShow_Click" style="height: 30px;" /><br />
     <div style="float:right;">
          <asp:Button ID="Finished" runat="server" Text="Log Out" style="color: Red; font-size: 12pt; font-weight: bold;" OnClick="LogOut_Click" />
     </div>
</body>
</html>
</form>