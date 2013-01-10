<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Accounting_TransactionsReport.aspx.cs" Inherits="Company_Accounting_Transactions" Title="Weavver Accounting :: Transaction Breakdown" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">
     <div style="float:right;">
          Start Date: <asp:TextBox ID="StartDate" runat="server"></asp:TextBox>
          End Date: <asp:TextBox ID="EndDate" runat="server"></asp:TextBox>
          <asp:Button ID="Apply" runat="server" Text="Apply" OnClick="Apply_Click" />
     </div>
     <h2>Transactions</h2>
     <style type="text/css">
          #tabs
          {
               font-size: 10pt;
          }
          #calendar {
               width: 900px;
               margin: 0 auto;
          }
     </style>
     <link rel='stylesheet' type='text/css' href='~/Vendors/Adam Shaw/fullcalendar/fullcalendar.css' />
     <br />
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
               <li><a href="#general"><span>General</span></a></li>
               <li><a href="#rules"><span>Rules</span></a></li>
               <li><a href="#reports"><span>Reports</span></a></li>
          </ul>
          <div id="general">
               <table>
               <tr>
                    <td valign="top">
                        
                         <br />
                         Totals by Payee:<br />
                         <br />
                         <asp:DataGrid ID="ByPayee" runat="server" HeaderStyle-BackColor="BurlyWood"></asp:DataGrid><br />
                         <br />
                    </td>
                    <td valign="top">
                         Debits By Day:<br />
                         <br />
                         <asp:DataGrid ID="ExpensesByDay" runat="server" Width="300px" HeaderStyle-BackColor="BurlyWood"></asp:DataGrid>
                         <br />
                         Debits By Month:<br />
                         <br />
                         <asp:DataGrid ID="ExpensesByMonth" runat="server" Width="300px" HeaderStyle-BackColor="BurlyWood"></asp:DataGrid><br />
                    </td>
               </tr>
               </table>
          </div>
          <div id="rules">
               <asp:DataGrid ID="TagRulesList" runat="server" HeaderStyle-BackColor="BurlyWood" AutoGenerateColumns="false">
               <Columns>
                    <asp:BoundColumn HeaderText="Tag" DataField="Tag" DataFormatString="{0}&nbsp;"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="StartsWith" DataField="Rule"></asp:BoundColumn>
               </Columns>
               </asp:DataGrid>
          </div>
          <div id="reports">
               <div style="float:right;">
                    <asp:DropDownList ID="Year" runat="server">
                         <asp:ListItem>2010</asp:ListItem>
                    </asp:DropDownList>     
               </div>
               Tags By Month by Year<br />
               <asp:DataGrid ID="TagsByMonthHorizontal" runat="server" Width="100%" HeaderStyle-BackColor="BurlyWood"></asp:DataGrid><br />
          </div>
     </div>
     <br />
</asp:Content>

