<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Accounting_FinancialOverview.aspx.cs" Inherits="Company_Accounting_Reports_FinancialOverview" Title="Weavver :: Reports" %>
<%@ Register src="~/DynamicData/Projections/Accounting_Accounts.ascx" tagname="Accounting_Accounts_Projection" tagprefix="wvvr" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">
     <div style="padding-bottom: 10px; float:right;">
          <asp:DropDownList ID="YearFilter" runat="server" Width="100px" AutoPostBack="true">
               <asp:ListItem>2012</asp:ListItem>
               <asp:ListItem>2011</asp:ListItem>
               <asp:ListItem>2010</asp:ListItem>
               <asp:ListItem>2009</asp:ListItem>
               <asp:ListItem>2008</asp:ListItem>
          </asp:DropDownList>
     </div>
     <h2>Accounts Receivable</h2><br />
     Credits and debits from clients and customers broken down by code.<br />
     <br />
     <asp:DataGrid ID="ARList" runat="server" Width="100%" HeaderStyle-BackColor="BurlyWood" AutoGenerateColumns="false">
     <Columns>
          <asp:BoundColumn HeaderText="Code" DataField="Code"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="January" DataField="Jan" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="February" DataField="Feb" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="March" DataField="Mar" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="April" DataField="Apr" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="May" DataField="May" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="June" DataField="Jun" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="July" DataField="Jul" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="August" DataField="Aug" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="September" DataField="Sep" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="October" DataField="Oct" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="November" DataField="Nov" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="December" DataField="Dec" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="Total for Year" DataField="Tot" DataFormatString="{0,10:C}" ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="Total to Date" DataField="TD" DataFormatString="{0,10:C}" ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
     </Columns>
     </asp:DataGrid><br />
     <br />
     <h2>Accounts Payable</h2><br />
     Credits and debits to staff and vendors broken down by code.<br />
     <br />
     <asp:DataGrid ID="APList" runat="server" Width="100%" HeaderStyle-BackColor="BurlyWood" AutoGenerateColumns="false" ShowFooter="false">
     <Columns>
          <asp:BoundColumn HeaderText="Code" DataField="Code"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="January" DataField="Jan" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right" ItemStyle-ForeColor="DarkRed"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="February" DataField="Feb" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right" ItemStyle-ForeColor="DarkRed"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="March" DataField="Mar" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right" ItemStyle-ForeColor="DarkRed"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="April" DataField="Apr" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right" ItemStyle-ForeColor="DarkRed"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="May" DataField="May" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right" ItemStyle-ForeColor="DarkRed"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="June" DataField="Jun" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right" ItemStyle-ForeColor="DarkRed"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="July" DataField="Jul" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right" ItemStyle-ForeColor="DarkRed"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="August" DataField="Aug" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right" ItemStyle-ForeColor="DarkRed"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="September" DataField="Sep" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right" ItemStyle-ForeColor="DarkRed"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="October" DataField="Oct" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right" ItemStyle-ForeColor="DarkRed"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="November" DataField="Nov" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right" ItemStyle-ForeColor="DarkRed"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="December" DataField="Dec" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right" ItemStyle-ForeColor="DarkRed"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="Total for Year" DataField="Tot" ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Right" DataFormatString="{0,10:C}" ItemStyle-ForeColor="DarkRed"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="Total to Date" DataField="TD" ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Right" DataFormatString="{0,10:C}" ItemStyle-ForeColor="DarkRed"></asp:BoundColumn>
     </Columns>
     </asp:DataGrid><br />
     <br />
     <h2>Profit and Loss</h2>
     <br />
     <asp:DataGrid ID="Net" runat="server" Width="100%" HeaderStyle-BackColor="BurlyWood" AutoGenerateColumns="false" ShowFooter="false">
     <Columns>
          <asp:TemplateColumn>
               <ItemTemplate>AR.Credits - AP.Debits</ItemTemplate>
          </asp:TemplateColumn>
          <asp:BoundColumn HeaderText="January" DataField="1" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="February" DataField="2" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="March" DataField="3" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="April" DataField="4" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="May" DataField="5" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="June" DataField="6" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="July" DataField="7" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="August" DataField="8" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="September" DataField="9" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="October" DataField="10" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="November" DataField="11" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="December" DataField="12" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="Total for Year" DataField="YearTotal" ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Right" DataFormatString="{0,10:C}"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="Total to Date" DataField="TD" ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Right" DataFormatString="{0,10:C}"></asp:BoundColumn>
     </Columns>
     </asp:DataGrid>
     <br/>
     <br/>
     <h2>Cash Flow</h2><br />
     Total credits and debits per month on bank accounts.<br />
     <br />
     <asp:DataGrid ID="CashFlow" runat="server" Width="100%" HeaderStyle-BackColor="BurlyWood" AutoGenerateColumns="false" ShowFooter="false">
     <Columns>
          <asp:BoundColumn HeaderText="Code" DataField="Code"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="January" DataField="Jan" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="February" DataField="Feb" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="March" DataField="Mar" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="April" DataField="Apr" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="May" DataField="May" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="June" DataField="Jun" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="July" DataField="Jul" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="August" DataField="Aug" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="September" DataField="Sep" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="October" DataField="Oct" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="November" DataField="Nov" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="December" DataField="Dec" DataFormatString="{0,10:C}" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="Total for Year" DataField="Tot" ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Right" DataFormatString="{0,10:C}"></asp:BoundColumn>
          <asp:BoundColumn HeaderText="Total to Date" DataField="TD" ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Right" DataFormatString="{0,10:C}"></asp:BoundColumn>
     </Columns>
     </asp:DataGrid><br/>
     <div style="float:right; margin-bottom: 15px;">
          <wvvr:Accounting_Accounts_Projection ID="AccountsSummary" runat="server" />
     </div>
</asp:Content>

