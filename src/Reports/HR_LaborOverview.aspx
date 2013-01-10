<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HR_LaborOverview.aspx.cs" Inherits="Company_HumanResources_Reports_TimeLogs" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">
     <div style="float:right;">
          Filter:<br />
          <asp:DropDownList ID="Staff" runat="server" AutoPostBack="true" Width="250px"></asp:DropDownList><br />
     </div>
     <table>
     <tr>
          <td valign="top">
               Time By Day:<br />
               <br />
               <asp:DataGrid ID="ReportByDay" runat="server" HeaderStyle-BackColor="BurlyWood" Width="200px" AutoGenerateColumns="false">
               <Columns>
                    <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Date" DataField="Date" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px"></asp:BoundColumn>
                    <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Total Time" DataField="Total" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px"></asp:BoundColumn>
               </Columns>
               </asp:DataGrid>
          </td>
          <td valign="top">
               Time By Month:<br />
               <br />
               <asp:DataGrid ID="ReportByMonth" runat="server" HeaderStyle-BackColor="BurlyWood" Width="200px" AutoGenerateColumns="false">
               <Columns>
                    <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Month" DataField="Month" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px"></asp:BoundColumn>
                    <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Total Time" DataField="Total" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px"></asp:BoundColumn>
               </Columns>
               </asp:DataGrid>
          </td>
     </tr>
     </table>
     <table>
     <tr>     
          <td valign="top">
               Earned By Day:<br />
               <br />
               <asp:DataGrid ID="EarnedByDay" runat="server" HeaderStyle-BackColor="BurlyWood" Width="200px" AutoGenerateColumns="false">
               <Columns>
                    <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Date" DataField="Date" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px"></asp:BoundColumn>
                    <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Earned" DataField="Earned" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px"></asp:BoundColumn>
               </Columns>
               </asp:DataGrid>
          </td>
          <td valign="top">
               Earned By Month:<br />
               <br />
               <asp:DataGrid ID="EarnedByMonth" runat="server" HeaderStyle-BackColor="BurlyWood" Width="200px" AutoGenerateColumns="false">
               <Columns>
                    <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Month" DataField="Month" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px"></asp:BoundColumn>
                    <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Earned" DataField="Earned" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px"></asp:BoundColumn>
               </Columns>
               </asp:DataGrid>
          </td>
     </tr>
     </table>
     <br />
     Reports do not factor in taxes or withholdings.
</asp:Content>