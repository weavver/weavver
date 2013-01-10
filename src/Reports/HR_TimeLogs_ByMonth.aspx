<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HR_TimeLogs_ByMonth.aspx.cs" Inherits="Company_Human_Resources_Time_Logs_Reports_ByMonth" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">
     <h2>Time Logs, Report By Month</h2>
     <br />
     <asp:Table ID="Report" runat="server" Width="100%" CellPadding="0" CellSpacing="0"></asp:Table>
     Total By Day:<br />
     <br />
     <asp:DataGrid ID="List" runat="server" HeaderStyle-BackColor="BurlyWood" Width="300px" AutoGenerateColumns="false">
     <Columns>
          <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Date" DataField="Date" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px"></asp:BoundColumn>
          <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Total Time" DataField="Total" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px"></asp:BoundColumn>
          <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Earned" DataField="Earned" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px"></asp:BoundColumn>
     </Columns>
     </asp:DataGrid><br />
     Total By Month:<br />
     <br />
     <asp:DataGrid ID="ListM" runat="server" HeaderStyle-BackColor="BurlyWood" Width="300px" AutoGenerateColumns="false">
     <Columns>
          <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Month" DataField="Month" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px"></asp:BoundColumn>
          <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Total Time" DataField="Total" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px"></asp:BoundColumn>
          <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Earned" DataField="Earned" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px"></asp:BoundColumn>
     </Columns>
     </asp:DataGrid>
     <br />
</asp:Content>