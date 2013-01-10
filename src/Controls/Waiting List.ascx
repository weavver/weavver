<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Waiting List.ascx.cs" Inherits="Controls_Waiting_List" %>
<asp:Panel ID="WaitingList" runat="server">
     <style type="text/css">
          .formline
          {
               width: 300px;
               clear: both;
          }
          .formvalue
          {
               width: 150px;
          }
     </style>
     <div class="formline">
          <h4>Sign Up</h4><br />
     </div>
     <div class="formline">
          <div class="formvalue"><asp:TextBox ID="Domain" runat="server"></asp:TextBox></div>
          Domain:
     </div>
     <div class="formline">
          <div class="formvalue"><asp:TextBox ID="Name" runat="server"></asp:TextBox></div>
          Name:
     </div>
     <div class="formline">
          <div class="formvalue"><asp:TextBox ID="Phone" runat="server"></asp:TextBox></div>
          Phone Number:
     </div>
     <div class="formline">
          <div class="formvalue"><asp:TextBox ID="Email" runat="server"></asp:TextBox></div>
          E-mail:
     </div>
     <div class="formline">
          <div class="formvalue"><asp:Button ID="Join" runat="server" Text="Join" OnClick="Join_Click"></asp:Button>     </div>
     </div>
</asp:Panel>
<asp:Panel ID="WaitingListJoined" runat="server" Visible="false">
     <b>Thank you for completing the first step. We will get in touch with you shortly.</b>
</asp:Panel>