<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" CodeFile="StoreItem.aspx.cs" Inherits="DynamicData.StoreItem" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
     <div id='storeitemcontent'>
          <ul>
               <li><a href="#tabs-1"><asp:Label ID="PageName" runat="server" Text="General Information"></asp:Label></a></li>
          </ul>
          <div id='tabs-1'>
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
                              <td colspan="2" style="background-color: #DEB887; height: 25px; padding-left: 8px;">
                                   <h3>Order Form</h3>
                              </td>
                         </tr>
                         <tr>
                              <td id="BillingNotes" runat="server" colspan="2" style="padding-left: 8px; padding-right: 8px; background-color: #e7f2e7"></td>
                         </tr>
                         <tr>
                              <td id="OrderFormCell" runat="server" colspan="2" style="padding-left: 8px; padding-right: 8px; padding-top: 10px; background-color: #e7f2e7">
                                   <asp:Panel ID="OrderFormControls" runat="server"></asp:Panel>
                              </td>
                         </tr>
                         <tr>
                              <td colspan="2" style="text-align: right; padding-left: 8px; padding-right: 8px; padding-top: 5px; padding-bottom: 5px; background-color: #e7f2e7;">
                                   Qty.&nbsp;<nobr><asp:TextBox ID="Quantity" runat="server" Text="1" width="25px" AutoPostBack="true" CausesValidation="True" OnTextChanged="Quantity_TextChanged"></asp:TextBox>
                                   <asp:LinkButton ID="QuantityUp" runat="server" Text="+" OnClick="QuantityUp_Clicked" />/<asp:LinkButton ID="QuantityDown" runat="server" Text="-" OnClick="QuantityDown_Clicked" /></nobr>
                                   <br />
                                   <br />
                                   <asp:Panel ID="Totals" runat="server"></asp:Panel>
                              </td>
                         </tr>
                         <tr>
                              <td colspan="2" style="padding-left: 5px; padding-right: 5px; padding-top: 5px; padding-bottom: 5px; background-color: #e7f2e7">
                                   <asp:Button id="Next" runat="server" Text="Add to shopping cart" Height="30px" Width="100%" OnClick="Next_Click" style="-webkit-appearance: button;" />
                              </td>
                         </tr>
                         </table>
                    </ContentTemplate>
                    </asp:UpdatePanel>
               </div>
               <asp:FormView runat="server" ID="FormView1" DataSourceID="DetailsDataSource" RenderOuterTable="false">
               <ItemTemplate>
                    <!--<%# WeavverMaster.FormTitle = (string) DataBinder.Eval(Container.DataItem, "Name") %>-->
                    <%# HTMLPurifierLib.Sanitize((string) DataBinder.Eval(Container.DataItem, "Description")) %>
               </ItemTemplate>
               <EmptyDataTemplate>
                    <div class="DDNoItem">No such item.</div>
               </EmptyDataTemplate>
               </asp:FormView>
               <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true">
                    <DataControls>
                         <asp:DataControlReference ControlID="FormView1" />
                    </DataControls>
               </asp:DynamicDataManager>
               <asp:EntityDataSource ID="DetailsDataSource" runat="server" EnableDelete="true" />
               <asp:QueryExtender TargetControlID="DetailsDataSource" ID="DetailsQueryExtender" runat="server">
                    <asp:DynamicRouteExpression />
               </asp:QueryExtender>
               <div style="clear: both;"></div>
          </div>
     </div>
     <script type="text/javascript">
          $(document).ready(function () {
               $('#storeitemcontent').tabs();
          });
     </script>
</asp:Content>