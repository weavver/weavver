<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Legal_DigitalSignature.aspx.cs" Inherits="Open_Contributors" Title="Weavver :: Contributors" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" Runat="Server">
     <asp:Panel ID="Patches" runat="server">
          <div style="border: solid 1px lightgrey; padding: 10px; clear: both;">
               <asp:Literal ID="ContributionAgreement" runat="server"></asp:Literal>
               <span style="font-weight: bold;">Digital Signature</span><br />
               <br />
               <table style="width: 300px;">
               <tr>
                    <td>First Name</td>
                    <td><asp:TextBox ID="FirstName" runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                    <td>Last Name</td>
                    <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                    <td>Zip Code</td>
                    <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                    <td>Country</td>
                    <td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                    <td>E-mail Address</td>
                    <td><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                    <td>Telephone</td>
                    <td><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                    <td>
                    </td>
                    <td>
                         <asp:CheckBox ID="Agreed" runat="server" Text="I Agree" /><br />
                         <br />
                         <asp:Button ID="Submit" runat="server" Text="Submit" Enabled="false" Height="30px" Width="100px" />
                    </td>
               </tr>
               </table>
          </div>
     </asp:Panel>
</asp:Content>