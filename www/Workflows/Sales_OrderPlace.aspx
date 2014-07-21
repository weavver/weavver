<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sales_OrderPlace.aspx.cs" Inherits="Sales_Order_Place" Title="Weavver: Web Store Order Form" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register src="~/Controls/PaymentMethod.ascx" tagname="PaymentMethod" tagprefix="wvvr" %>
<%@ Register src="~/Controls/Contact.ascx" tagname="Contact" tagprefix="wvvr" %>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">
     <div style="width:100%; background-color: #414141; color: White;">
          <div style="border: 1px solid white; padding: 10px;">
               <div style="vertical-align: middle;">
                    <div style="float:right; color: White; padding-top: 4px;">
                         <a href="~/workflows/sales_orderreview" style="color: White;">Back to your Shopping Cart</a>
                    </div>
                    <div style="float:left; color: White;">
                         <h2><asp:Literal ID="OrderFormTitle" runat="server" Text="Order Form"></asp:Literal></h2>
                    </div>
                    <div style='clear: both;'></div>
               </div>
          </div>
     </div>
     <asp:Panel ID="Message" runat="server" style="padding: 30px;">
          You don't have any items in your cart.
     </asp:Panel>
     <div id='CustomerInfo' runat="server" style="padding-bottom: 10px; text-align: center;">
          <div class="orderplace_box">
               <wvvr:Contact ID="PrimaryContact" runat="server" />
          </div>
          <div class="orderplace_box">
               <wvvr:Contact ID="BillingContact" runat="server" />
          </div>            
          <div class="orderplace_box">
               <table style="border-left: solid 1px #CCCCCC; margin-top: 0px; height: 280px; width: 100%;" cellpadding="0" cellspacing="0">
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
          </div>
          <div class="orderplace_box">
               <table style="border-left: solid 1px #CCCCCC; margin-top: 0px; width: 100%;" cellpadding="0" cellspacing="0">
               <tr style="background-color: #d4e2e2; text-align: left; padding: 5px; margin-bottom: 5px; color: #000000; height: 25px;">
                    <td style="padding-left: 8px;">
                         <h3>Order Summary</h3>
                    </td>
               </tr>
               <tr>
                    <td valign="top" colspan="2" style="background-color: #FFFFFF; border: none 1px; padding: 8px;">
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
                         <table style="padding: 10px;" cellpadding="0" cellspacing="0">
                         <tr>
                              <td style="padding: 0px; margin-bottom: 5px; border: none 1px #CCCCCC; color: #000000;">
                                   Special Notes:
                              </td>
                         </tr>
                         <tr>
                              <td style="text-align: center; padding: 0px; height: 81px; padding-top:5px;">
                                   <asp:TextBox ID="SpecialInstructions" runat="server" BorderStyle="Solid" TextMode="MultiLine" Width="235" Height="100%"></asp:TextBox>
                              </td>
                         </tr>
                         </table>
                    </td>
               </tr>
               </table>
          </div>
     </div>
     <div style="float: right;">
          <asp:ImageButton ID="btnOrder" runat="server" ImageUrl="~/images/sales/OrderPlace.png" OnClick="Order_Click" ValidationGroup="OrderForm" style="padding: 10px;" />
     </div>
     <div style="clear: both; margin-bottom: 10px;"></div>
          <%--<asp:Button ID="btnOrder" runat="server" Text="Place Order" Width="120" Height="35" Enabled="true" OnClick="Order_Click" style="text-align:center;" ValidationGroup="OrderForm2" />--%>
</asp:Content>