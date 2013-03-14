<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CustomerService_FeedbackForm.aspx.cs" Inherits="Company_CustomerService_FeedbackForm" Title="Weavver :: Feedback" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">
     <asp:Panel ID="FeedbackPan" runat="server">
          <table>
          <tr>
               <td style="width: 150px;">Name:</td>
               <td><asp:TextBox ID="Name" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
               <td>Your e-mail address:</td>
               <td><asp:TextBox ID="EmailAddress" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
               <td>Feedback type:</td>
               <td>
                    <asp:DropDownList ID="FeedbackType" runat="server">
                         <asp:ListItem Text="Suggestion"></asp:ListItem>
                         <asp:ListItem Text="Product feedback"></asp:ListItem>
                         <asp:ListItem Text="Service feedback"></asp:ListItem>
                         <asp:ListItem Text="Website - Bug"></asp:ListItem>
                         <asp:ListItem Text="Website - Suggestion"></asp:ListItem>
                    </asp:DropDownList>
               </td>
          </tr>
          <tr>
               <td valign="top">Message:</td>
               <td>
                    <asp:TextBox ID="Message" runat="server" TextMode="MultiLine" Height="250px" Width="300px"></asp:TextBox>
               </td>
          </tr>
          <tr>
               <td></td>
               <td><asp:Button ID="Send" runat="server" Text="Send" Width="150px" Height="25px" OnClick="Send_Click" /></td>
          </tr>
          </table>
     </asp:Panel>
     <asp:Panel ID="ThankYou" runat="server" Visible="false">
          Thank you for your time and comments.
     </asp:Panel>
</asp:Content>