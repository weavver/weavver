<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AsteriskConsulting_ExistingPhoneSystem.aspx.cs" Inherits="Company_Services_Phone_Systems_Modify" Title="Weavver :: Phone System :: Modify" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" Runat="Server">
     Hello, this page will be helpful for you if you have an existing Asterisk-based phone
     system and need help supporting and adding on to it.<br />
     <br />
     Please fill out the following form so that we can understand your needs and find someone that can help you.<br />
     <br />
     <div class="formline">
          <div class="formvalue">
               <asp:ListBox ID="SystemList" runat="server">
                    <asp:ListItem Selected=True>I don't know</asp:ListItem>
                    <asp:ListItem>Asterisk on CentOS</asp:ListItem>
                    <asp:ListItem>Trixbox</asp:ListItem>
                    <asp:ListItem>PBX in a Flash</asp:ListItem>
               </asp:ListBox>
          </div>
          Do you know what type of system you have?
     </div>
     <div class="formline">
          <div class="formvalue"><asp:TextBox id="Installer" runat="server"></asp:TextBox><br />
          </div>
          Do you know who set up your phone system?
     </div>
     <div class="formline">
          <div class="formvalue"><asp:Textbox ID="Changes" runat="server" Width="300" Height="150"></asp:Textbox></div>
          What changes would you like?
     </div>
     <div class="formline">
          <div class="formvalue"><asp:Textbox ID="EmailAddress" runat="server"></asp:Textbox></div>
          E-mail Address
     </div>
     <div class="formline">
          <div class="formvalue"><asp:Textbox ID="PhoneNumber" runat="server"></asp:Textbox></div>
          Phone Number
     </div>
     <div class="formline">
          <div class="formvalue"><asp:Button ID="Contact" runat="server" Text="Request Contact" Height="30px" /></div>
     </div>
</asp:Content>
