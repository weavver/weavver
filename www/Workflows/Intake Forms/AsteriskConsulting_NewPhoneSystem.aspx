<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AsteriskConsulting_NewPhoneSystem.aspx.cs" Inherits="Company_Services_Phone_Systems_Project" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" Runat="Server">
     <div style="float:right">
          <a href="Consultant">Sign up as a consultant</a>
     </div>
     <h4>Phone System Consulting</h4>
     <br />
     Sign up for a Weavver account and get started posting your project today. Here you can find consultants to help you design your Telecom related projects.<br />
     <asp:Panel ID="LeadForm" Visible="True" runat="server">
          <div class="formline">
               <div class="formvalue">
                    <asp:TextBox id="PhoneCount" runat="server"></asp:TextBox><br />
               </div>
               How many phones do you need?
          </div>
          <div class="formline">
               <div class="formvalue"><asp:Textbox ID="NetworkAdmin" runat="server"></asp:Textbox></div>
               Do you have a network administrator?
          </div>
          <div class="formline">
               <div class="formvalue">
               <asp:DropDownList ID="NetworkConnections" runat="server">
                    <asp:ListItem>All</asp:ListItem>
                    <asp:ListItem>Most</asp:ListItem>
                    <asp:ListItem>I don't know</asp:ListItem>
               </asp:DropDownList></asp:Textbox></div>
               Is there a network connection next to each location you need a phone?
          </div>
          <div class="formline">
               <div class="formvalue">
                    <asp:DropDownList ID="Provider" runat="server">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList>
               </div>
               Do you already have telephone service from a provider?
          </div>
          <div class="formline">
               <div class="formvalue"><asp:Textbox ID="PhoneService" runat="server"></asp:Textbox></div>
               Do you want new phone service for your business?
          </div>
          <div class="formline">
               <div class="formvalue">
                    <asp:ListBox ID="SystemList" runat="server">
                         <asp:ListItem Selected=True>I don't know</asp:ListItem>
                         <asp:ListItem>Asterisk on CentOS</asp:ListItem>
                         <asp:ListItem>FreeSWITCH</asp:ListItem>
                         <asp:ListItem>Trixbox</asp:ListItem>
                         <asp:ListItem>PBX in a Flash</asp:ListItem>
                    </asp:ListBox>
               </div>
               What type of system are you looking for?
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
               <div class="formvalue"><asp:Textbox ID="Other" runat="server" Width="300px" Height="150px" TextMode="MultiLine"></asp:Textbox></div>
               Other
          </div>
          <div class="formline">
               <div class="formvalue"><asp:Button ID="RequestQuote" runat="server" Text="Request a Quote" OnClick="SendLead_Click" /></div>
          </div>
          <br />
     </asp:Panel>
     <asp:Panel ID="LeadSent" Visible="false" runat="server">
          Thank you for inquiring. Someone will contact you soon.
     </asp:Panel>
</asp:Content>