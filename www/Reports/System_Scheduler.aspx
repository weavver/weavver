<%@ Page Title="Weavver :: Accounting :: Bill" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="System_Scheduler.aspx.cs" Inherits="Company_Accounting_Bill" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" Runat="Server">
     <style type="text/css">
          #tabs
          {
               font-size: 9pt;
          }
     </style>
     <script type="text/javascript">
       $(document).ready(function() {
         $("#tabs").tabs( {
               show: function() {
                var sel = $('#tabs').tabs('option', 'selected');
                $("#<%= hidLastTab.ClientID %>").val(sel);
            },
            selected: <%= hidLastTab.Value %>
            });
       });
      </script>
     <asp:HiddenField runat="server" ID="hidLastTab" Value="0" />
     <div id="tabs">
          <ul>
               <li><a href="#fragment-1"><span>General Information</span></a></li>
               <li><a href="#fragment-2"><span>Schedule</span></a></li>
          </ul>
          <div id="fragment-1">
               <table style="width:500px; padding-left: 20px;">
               <tr>
                    <td style="width: 60px;">From:</td>
                    <td style="text-align: right;">
                         <asp:TextBox ID="Payee" runat="server"></asp:TextBox>
                    </td>
               </tr>
               <tr>
                    <td>Amount:</td>
                    <td style="text-align: right;">
                         <asp:TextBox ID="Amount" runat="server"></asp:TextBox>
                    </td>
               </tr>
               <tr>
                    <td>Due By:</td>
                    <td style="text-align: right;">
                         <asp:TextBox ID="Due" runat="server"></asp:TextBox>
                    </td>
               </tr>
               </table>
          </div>
          <div id="fragment-2">
               <table>
               <tr>
                    <td style="width: 200px;">Repeats</td>
                    <td>
                         <asp:DropDownList ID="Repeats" runat="server" Width="125px">
                         <asp:ListItem>Never</asp:ListItem>
                         <asp:ListItem>Daily</asp:ListItem>
                         <asp:ListItem>Weekly</asp:ListItem>
                         <asp:ListItem>Every Weekday (Mon-Fri)</asp:ListItem>
                         </asp:DropDownList>
                    </td>
               </tr>
               <tr>
                    <td>Repeat every</td>
                    <td>
                         <asp:DropDownList ID="RepeatsEvery" runat="server">
                              <asp:ListItem>1</asp:ListItem>
                              <asp:ListItem>2</asp:ListItem>
                              <asp:ListItem>3</asp:ListItem>
                         </asp:DropDownList> weeks
                    </td>
               </tr>
               <tr>
                    <td valign="top">Repeat on these days:</td>
                    <td>
                         <asp:CheckBoxList ID="RepeatOn" runat="server" RepeatDirection="Vertical" Width="500px">
                              <asp:ListItem>Saturday</asp:ListItem>
                              <asp:ListItem>Monday</asp:ListItem>
                              <asp:ListItem>Tuesday</asp:ListItem>
                              <asp:ListItem>Wednesday</asp:ListItem>
                              <asp:ListItem>Thursday</asp:ListItem>
                              <asp:ListItem>Friday</asp:ListItem>
                              <asp:ListItem>Sunday</asp:ListItem>
                         </asp:CheckBoxList>
                    </td>
               </tr>
               <tr>
                    <td>Starts On:</td>
                    <td>
                         <asp:TextBox ID="StartsOn" runat="server" ReadOnly="true" BackColor="LightGray"></asp:TextBox>
                    </td>
               </tr>
               <tr>
                    <td>Ends on:</td>
                    <td>
                         <asp:TextBox ID="UntilDate" runat="server" Width="75px"></asp:TextBox>
                    </td>
               </tr>
               </table>
          </div>
     </div>
     <br />
     <div style="float:right; padding: 10px;"><asp:Button ID="Save" runat="server" Text="Save" Width="95px" Height="30px" OnClick="Save_Click" /></div>
     <asp:Button ID="Delete" runat="server" Text="Delete" OnClick="Delete_Click" Width="130" Height="25" />
     <br />
</asp:Content>

