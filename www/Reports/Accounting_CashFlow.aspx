<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Accounting_CashFlow.aspx.cs" Inherits="Accounting_CashFlowReport" Title="Accounting :: Cash Flow" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">
     <div style="padding-bottom: 10px; float:right; border: solid 1px black; background-color: lightgray; padding: 8px; width: 220px;">
          <h3>Filter</h3><br />
          <table width="100%">
          <tr>
               <td valign="top">Ledger Types:</td>
               <td>
                    <asp:CheckBoxList ID="LedgerTypes" runat="server" Width="100px">
                         <asp:ListItem Text="Credit Card" Value="CreditCard" Selected="True"></asp:ListItem>
                         <asp:ListItem Text="Savings" Value="Savings" Selected="True"></asp:ListItem>
                         <asp:ListItem Text="Payables" Value="Payables" Selected="True"></asp:ListItem>
                         <asp:ListItem Text="Checking" Value="Checking" Selected="True"></asp:ListItem>
                    </asp:CheckBoxList>
               </td>
          </tr>
          <tr>
               <td valign="top">Account:</td>
               <td><asp:CheckBoxList ID="Accounts" runat="server" Width="100px"></asp:CheckBoxList></td>
          </tr>
          <tr>
               <td>Year:</td>
               <td>
                    <asp:DropDownList ID="YearFilter" runat="server" Width="100px" AutoPostBack="true">
                         <asp:ListItem>2012</asp:ListItem>
                         <asp:ListItem>2011</asp:ListItem>
                         <asp:ListItem>2010</asp:ListItem>
                         <asp:ListItem>2009</asp:ListItem>
                         <asp:ListItem>2008</asp:ListItem>
                    </asp:DropDownList>
               </td>
          </tr>
          </table>
     </div>
     <table>
     <tr>
          <td valign="top">
               <h3>By Day</h3><br />
               <asp:DataGrid ID="ByDay" runat="server" Width="200px" HeaderStyle-BackColor="BurlyWood" AutoGenerateColumns="false">
               <Columns>
                    <asp:BoundColumn HeaderText="Date" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Total" DataField="Total" DataFormatString="{0,10:C}" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
               </Columns>
               </asp:DataGrid>
          </td>
          <td valign="top">
               <h3>By Week</h3><br />
               <asp:DataGrid ID="ByWeek" runat="server" Width="260px" HeaderStyle-BackColor="BurlyWood" AutoGenerateColumns="false">
               <Columns>
                    <asp:BoundColumn HeaderText="Week" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Total" DataField="Total" DataFormatString="{0,10:C}" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
               </Columns>
               </asp:DataGrid>
          </td>
          <td valign="top">
               <h3>By Month</h3><br />
               <asp:DataGrid ID="ByMonth" runat="server" Width="200px" HeaderStyle-BackColor="BurlyWood" AutoGenerateColumns="false">
               <Columns>
                    <asp:BoundColumn HeaderText="Month" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Total" DataField="Total" DataFormatString="{0,10:C}" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
               </Columns>
               </asp:DataGrid>
          </td>
     </tr>
     </table>     
</asp:Content>