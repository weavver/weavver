<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" CodeFile="StoreItem.aspx.cs" Inherits="DynamicData.StoreItem" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
     <div style="float:right; font-size: 14px; color: #FFFFFF; margin-right: 15px; padding-bottom: 5px;">
          If you need help or would like to discuss your project please call us at +1-714-872-5920 or
          <a id="ItemInquire" runat="server" href="#" style="color: #FFFFFF; text-decoration: underline;">inquire online</a>.
     </div>
     <div style="clear: both; min-height: 63px; background-color: #228ae3; position: relative;background-image: url('~/images/storeitem/barfiller.jpg');">
          <div style="float: left; background-image: url('~/images/storeitem/barleftWeavver.png'); height: 64px; width: 13px; font-weight: bold;">
               &nbsp;
          </div>
               <div style="float:right;">
                    <img src="~/images/storeitem/barright.jpg" />
               </div>
          <div style="float:left; height: 33px; vertical-align: bottom; position: absolute; bottom: 0px; left: 7px;">
               <img style="float:left; height: 34px;" src="~/images/storeitem/pageNameLeft.png" />
               <div style="background-repeat: repeat-x; background-position: bottom; float: left; padding-top: 0px; font: Bold 11pt Verdana;height: 34px; text-align: center;background-image: url('~/images/storeitem/pageNameFiller.png');">
                    <div style="padding-top: 8px; height: 34px;">
                         <asp:Label ID="PageName" runat="server" Text="General Information"></asp:Label>
                    </div>
               </div>
               <div style="display: inline-block;background-position: bottom; vertical-align: bottom; height: 34px;">
                    <img style="float:left; height: 34px;" src="~/images/storeitem/pageNameRight.png" border="0" />
               </div>
          </div>
     </div>
     
     <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #FFFFFF">
     <tr>
          <td width="20" align="left" valign="top">
               <img src="~/images/storeitem/left_corn_up.gif" width="24" height="21">
          </td>
          <td bgcolor="ffffff">
               &nbsp;
          </td>
          <td width="10" align="right" valign="top">
               <img src="~/images/storeitem/right_corn_up.gif" width="24" height="21">
          </td>
     </tr>
     </table>

     <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
     <tr>
          <td style="background-image: url('~/images/storeitem/left_shad.gif'); background-repeat: repeat-y;width: 24px;">
               &nbsp;
          </td>
          <td style="padding-right: 10px; background-color: #FFFFFF;">
               <div style="float:right; margin-left: 15px; max-width: 250px;">
                    <asp:Panel ID="AdminLinks" runat="server" Visible="false">
                         <div style="padding-bottom: 15px;text-align:right;">
                              <a id="EditLink" runat="server" href="#" style="padding-bottom: 10px;">Edit</a>
                         </div>
                    </asp:Panel>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                         <table id="OrderForm" runat="server" style="border: solid 1px lightgrey;" cellpadding="0" cellspacing="0">
                         <tr>
                              <td colspan="2" style="background-color: #DEB887; height: 25px; padding-left: 10px;">
                                   <h3>Order Form</h3>
                              </td>
                         </tr>
                         <tr>
                              <td id="BillingNotes" runat="server" colspan="2" style="padding-left: 10px; padding-right: 10px; background-color: #e7f2e7"></td>
                         </tr>
                         <tr>
                              <td id="OrderFormCell" runat="server" colspan="2" style="padding-left: 10px; padding-right: 10px; padding-top: 10px; background-color: #e7f2e7">
                                   <asp:Panel ID="OrderFormControls" runat="server"></asp:Panel>
                              </td>
                         </tr>
                         <tr>
                              <td colspan="2" style="text-align: right; padding-left: 10px; padding-right: 10px; padding-top: 5px; padding-bottom: 5px; background-color: #e7f2e7;">
                                   Qty.&nbsp;<nobr><asp:TextBox ID="Quantity" runat="server" Text="1" width="25px" AutoPostBack="true" CausesValidation="True" OnTextChanged="Quantity_TextChanged"></asp:TextBox>
                                   <asp:LinkButton ID="QuantityUp" runat="server" Text="+" OnClick="QuantityUp_Clicked" />/<asp:LinkButton ID="QuantityDown" runat="server" Text="-" OnClick="QuantityDown_Clicked" /></nobr>
                                   <br />
                                   <br />
                                   <asp:Panel ID="Totals" runat="server"></asp:Panel>
                              </td>
                         </tr>
                         <tr>
                              <td colspan="2" style="padding-left: 10px; padding-top: 10px; padding-bottom: 10px; background-color: #e7f2e7">
                                   <asp:Button id="Next" runat="server" Text="Add to shopping cart" Height="30px" Width="150px" OnClick="Next_Click" style="-webkit-appearance: button;" />
                              </td>
                         </tr>
                         </table>
                    </ContentTemplate>
                    </asp:UpdatePanel>
               </div>
               <asp:FormView runat="server" ID="FormView1" DataSourceID="DetailsDataSource" RenderOuterTable="false">
                    <ItemTemplate>
                         <!--<%# Master.FormTitle = (string) DataBinder.Eval(Container.DataItem, "Name") %>-->
                         
                         <%# DataBinder.Eval(Container.DataItem, "Description") %>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                    <div class="DDNoItem">No such item.</div>
                    </EmptyDataTemplate>
               </asp:FormView>
          </td>
          <td style="background-image: url('~/images/storeitem/right_shad.gif'); background-repeat: repeat-y;width: 24px;">
               &nbsp;
          </td>
     </tr>
     <tr>
          <td align="right" valign="bottom">
               <img src="~/images/storeitem/left_corn_bot.gif" width="24" height="21">
          </td>
          <td background="~/images/storeitem/bot_bg.gif">
               &nbsp;
          </td>
          <td align="left" valign="bottom">
               <img src="~/images/storeitem/right_corn_bot.gif" width="24" height="21">
          </td>
     </tr>
     </table>
     <br />
     <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true">
          <DataControls>
               <asp:DataControlReference ControlID="FormView1" />
          </DataControls>
     </asp:DynamicDataManager>
     <asp:EntityDataSource ID="DetailsDataSource" runat="server" EnableDelete="true" />
     <asp:QueryExtender TargetControlID="DetailsDataSource" ID="DetailsQueryExtender" runat="server">
          <asp:DynamicRouteExpression />
     </asp:QueryExtender>
</asp:Content>