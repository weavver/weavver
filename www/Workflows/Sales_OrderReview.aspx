<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sales_OrderReview.aspx.cs" Inherits="Company_Sales_Order" Title="Weavver Shopping Cart" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="~/Controls/BillingMethod.ascx" tagname="BillingMethod" tagprefix="wvvr" %>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">
     <asp:UpdatePanel ID="Update1" runat="server" ChildrenAsTriggers="true">
     <ContentTemplate>
          <div style="float:right; padding: 3px 10px 3px 10px;">
               <asp:TextBox ID="CouponCode" runat="server" Width="250px"></asp:TextBox>
               <asp:Button id="AddCode" runat="server" Text="Add Code" OnClick="CodeAdd_Click" />
               <cc1:TextBoxWatermarkExtender ID="Watermark1" runat="server" TargetControlID="CouponCode" WatermarkCssClass="watermark" WatermarkText="Discount or gift card code"></cc1:TextBoxWatermarkExtender>
          </div>
          <asp:DataGrid ID="List" runat="server" Width="100%" AutoGenerateColumns="false" HeaderStyle-BackColor="BurlyWood" BorderColor="LightGray" CellPadding="4" BackColor="#FFFFFF">
          <Columns>
               <asp:BoundColumn HeaderText="Id" DataField="Id" Visible="false"></asp:BoundColumn>
               <asp:TemplateColumn HeaderText="Quantity" HeaderStyle-Width="60px" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate><asp:TextBox ID="Quantity" runat="server" Width="35px" Text=""></asp:TextBox></ItemTemplate>
               </asp:TemplateColumn>
               <asp:TemplateColumn HeaderText="Item">
                    <ItemTemplate>
                         <asp:Literal ID="ItemNameNotes" runat="server"></asp:Literal>
                    </ItemTemplate>
               </asp:TemplateColumn>
               <asp:BoundColumn HeaderText="Set-Up" DataField="SetUp" DataFormatString="${0:n}" ReadOnly="true" HeaderStyle-Width="120px" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
               <asp:BoundColumn HeaderText="Item Price" DataField="UnitCost" DataFormatString="${0:n}" ReadOnly="true" HeaderStyle-Width="120px" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
               <asp:BoundColumn HeaderText="Monthly" DataField="Monthly" DataFormatString="${0:n}" ReadOnly="true" HeaderStyle-Width="120px" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
               <asp:BoundColumn HeaderText="Sub-Total" DataField="Total" DataFormatString="${0:n}" ReadOnly="true" HeaderStyle-Width="120px" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
               <asp:ButtonColumn Text="Remove" CommandName="Remove" ItemStyle-Width="95px" ItemStyle-HorizontalAlign="Center"></asp:ButtonColumn>
          </Columns>
          </asp:DataGrid>
          <table width="100%" style="margin-top: 10px;">
          <tr>
               <td valign="top" style="padding-left: 10px;">
                    <asp:LinkButton id="TotalUpdate" runat="server" Text="Update Totals" OnClick="UpdateQuantity_Click"></asp:LinkButton><br />
               </td>
               <td style="text-align: right;">
               </td>
               <td style="width: 377px;">
                    <div style="text-align:right; width: 100%; margin-bottom: 10px;">
                         <table width="0px" style="float:right;clear: both;">
                         <tr id="SetUp" runat="server">
                              <td style="width: 100px;">Set-Up:</td>
                              <td><asp:Label ID="SetUpTotal" runat="server"></asp:Label></td>
                         </tr>
                         <tr id="Deposits" runat="server">
                              <td style="width: 100px;">Deposit(s):</td>
                              <td><asp:Label ID="DepositTotal" runat="server"></asp:Label></td>
                         </tr>
                         <tr id="Monthly" runat="server">
                              <td style="width: 100px;">Monthly:</td>
                              <td><asp:Label ID="CartMonthly" runat="server"></asp:Label></td>
                         </tr>
                         <tr>
                              <td style="width: 100px;">Due:</td>
                              <td><asp:Label ID="CartTotal" runat="server"></asp:Label></td>
                         </tr>
                         </table>
                    </div>
               </td>
          </tr>
          </table>
     </ContentTemplate>
     </asp:UpdatePanel>
     <hr />
     <div style="clear:both; margin-bottom: 10px;margin-right: 10px; float: right;">
          <asp:ImageButton ID="btnOrder" runat="server" ImageUrl="~/images/sales/checkout.png" OnClick="Next_Click" ValidationGroup="OrderForm" />
     </div>
     <div style="width: 700px; padding: 10px;">
     <%--<a href="#">sp:CustomValidator ID="Priv" runat="server" Text="*" ValidationGroup="OrderForm" ErrorMessage="*" ToolTip="Agreement is required." ClientValidationFunction="ValidateChecked" OnServerValidate="Privacy_Validate"></asp:CustomValidator>--%>
          <asp:Literal ID="StorePolicy" runat="server"></asp:Literal>
     </div>
</asp:Content>