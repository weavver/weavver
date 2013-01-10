<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Accounting_OFXBillPay.aspx.cs" Inherits="Company_Accounting_BillPay" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">
     Scheduled Payments:<br />
     <br />
     <asp:DataGrid ID="ScheduledPayments" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="BurlyWood" Width="100%" BackColor="White">
     <Columns>
          <asp:BoundColumn DataField="Status" HeaderText="Status" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" DataFormatString="{0}"></asp:BoundColumn>
          <asp:BoundColumn DataField="DateDue" HeaderText="Due Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" DataFormatString="{0:mm/dd/YY}"></asp:BoundColumn>
          <asp:BoundColumn DataField="CheckNumber" HeaderText="Check Num" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px" DataFormatString="{0}"></asp:BoundColumn>
          <asp:BoundColumn DataField="PayeeAccount" HeaderText="Payee" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="130px" DataFormatString="{0}"></asp:BoundColumn>
          <asp:BoundColumn DataField="Memo" HeaderText="Memo" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" DataFormatString="{0}"></asp:BoundColumn>
          <asp:BoundColumn DataField="Amount" HeaderText="Amount" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px" DataFormatString="{0:C}"></asp:BoundColumn>
     </Columns>
     </asp:DataGrid><br />
     <br />
     Serverside Payees:<br />
     <br />
     <asp:DataGrid ID="Payees" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="BurlyWood" Width="100%" BackColor="White">
     <Columns>
          <asp:BoundColumn DataField="ListId" Visible="true" ItemStyle-Width="100px"></asp:BoundColumn>
          <asp:BoundColumn DataField="Account" HeaderText="Account" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px" DataFormatString="{0}"></asp:BoundColumn>
          <asp:BoundColumn DataField="Name" HeaderText="Full Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px" DataFormatString="{0}"></asp:BoundColumn>
          <asp:BoundColumn DataField="Addr1" HeaderText="Address" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px" DataFormatString="{0}"></asp:BoundColumn>
          <asp:BoundColumn DataField="City" HeaderText="City" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px" DataFormatString="{0}"></asp:BoundColumn>
          <asp:BoundColumn DataField="PostalCode" HeaderText="Zip Code" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px" DataFormatString="{0}"></asp:BoundColumn>
          <asp:BoundColumn DataField="State" HeaderText="State" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px" DataFormatString="{0}"></asp:BoundColumn>
     </Columns>
     </asp:DataGrid>
</asp:Content>
