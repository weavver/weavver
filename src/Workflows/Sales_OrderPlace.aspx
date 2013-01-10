<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sales_OrderPlace.aspx.cs" Inherits="Sales_Order_Place" Title="Weavver: Web Store Order Form" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register src="~/Controls/Log In.ascx" tagname="LogIn" tagprefix="wvvr" %>
<%@ Register src="~/Controls/Register.ascx" tagname="Register" tagprefix="wvvr" %>
<%@ Register src="~/Controls/PaymentMethod.ascx" tagname="PaymentMethod" tagprefix="wvvr" %>
<%@ Register src="~/Controls/Contact.ascx" tagname="Contact" tagprefix="wvvr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">
     <div style="width:100%; background-color: #414141; color: White;">
          <div style="padding: 10px;">
               <div style="float:right; color: White;">
                    <a href="~/workflows/sales_orderreview" style="color: White;">Back to your Shopping Cart</a>
               </div>
               <h2><asp:Literal ID="OrderFormTitle" runat="server" Text="Order Form"></asp:Literal></h2>
          </div>
     </div>
     <asp:Panel ID="Message" runat="server" style="padding: 30px;">
          You don't have any items in your cart.
     </asp:Panel>
     <table id="CustomerInfo" runat="server" style="margin-top: 10px;" cellpadding="0" cellspacing="0">
     <tr>
          <td valign="top" style="width:33%;padding-right:2px;">
               <wvvr:Contact ID="PrimaryContact" runat="server" />
          </td>
          <td valign="top" style="width:33%;padding-left: 2px;padding-right:2px;">
               <wvvr:Contact ID="BillingContact" runat="server" />
          </td>
          <td valign="top" style="width:33%;padding-left: 2px;">
               <table style="border: solid 1px #CCCCCC; margin-top: 0px; height: 280px; width: 100%;" cellpadding="0" cellspacing="0">
               <tr style="background-color: #d4e2e2; text-align: left; padding: 5px; margin-bottom: 5px; color: #000000; height: 25px;">
                    <td style="padding-left: 8px;">
                         <h3>Payment Information</h3>
                    </td>
                    <td>
                         <div style="float:right;"><%--
                              <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="PaymentOptions">
                              <ProgressTemplate><span style="font-style: italic;">Refreshing..&nbsp;</span></ProgressTemplate>
                              </asp:UpdateProgress>--%>
                         </div>
                    </td>
               </tr>
               <tr>
                    <td colspan="2" style="background-color: #FFFFFF; border: none 1px; padding: 8px;" valign="top">
                         <wvvr:PaymentMethod id="PaymentMethod1" runat="server"></wvvr:PaymentMethod>
                    </td>
               </tr>
               </table>
          </td>
     </tr>
     <tr>
          <td valign="top" style="width:33%;padding-right: 2px; padding-top: 4px;">
               <table style="border-right: solid 1px #CCCCCC; width: 100%;" cellpadding="0" cellspacing="0">
               <tr>
                    <td style="background-color: #d4e2e2; padding: 5px; margin-bottom: 5px; border: none 1px #CCCCCC; color: #000000;">
                         <h3>Order Summary</h3>
                    </td>
               </tr>
               <tr>
                    <td colspan="2" style="background-color: #FFFFFF; width: 320px; border: none 1px; padding: 8px;">
                         <table style="width: 100%;">
                         <tr>
                              <td style="text-align: left; width: 75px;">Deposit:</td>
                              <td style="text-align:right;"><asp:Label ID="Deposit" runat="server"></asp:Label></td>
                         </tr>
                         <tr>
                              <td style="text-align: left;">Monthly:</td>
                              <td style="text-align:right;"><asp:Label ID="Monthly" runat="server"></asp:Label></td>
                         </tr>
                         <tr>
                              <td style="text-align: left;">Total due:</td>
                              <td style="text-align:right;"><asp:Label ID="CartTotal" runat="server"></asp:Label></td>
                         </tr>
                         </table>
                    </td>
               </tr>
               </table>
          </td>
          <td valign="top" style="width:33%;padding-right: 2px; padding-top: 4px;">
               <table style="border: solid 1px #CCCCCC; width: 100%;" cellpadding="0" cellspacing="0">
               <tr>
                    <td style="background-color: #d4e2e2; padding: 5px; margin-bottom: 5px; border: none 1px #CCCCCC; color: #000000;">
                         <h3>Special Instructions:</h3>
                    </td>
               </tr>
               <tr>
                    <td style="text-align: center; padding: 0px; height: 81px;">
                         <asp:TextBox ID="SpecialInstructions" runat="server" BorderStyle="None" TextMode="MultiLine" Width="98%" Height="100%"></asp:TextBox>
                    </td>
               </tr>
               </table>
          </td>
          <td valign="top" style="padding-top: 8px; padding-left: 2px;">
               <br />
               <div style="float:right;">
                    <asp:ImageButton ID="btnOrder" runat="server" ImageUrl="~/images/sales/OrderPlace.png" OnClick="Order_Click" ValidationGroup="OrderForm" />
               </div>
               <%--<asp:Button ID="btnOrder" runat="server" Text="Place Order" Width="120" Height="35" Enabled="true" OnClick="Order_Click" style="text-align:center;" ValidationGroup="OrderForm2" />--%>
          </td>
     </tr>
     </table>
</asp:Content>