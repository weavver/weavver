<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Accounting_LedgerItems.aspx.cs" Inherits="Company_Accounting_Import_Default" Title="Weavver Accounting :: Import Data" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">
     <script type="text/javascript">
          function CheckAll() {
               $("#Content_LedgerItems input:checkbox").attr("checked", true);
          }

          function CheckNone() {
               $("#Content_LedgerItems input:checkbox").attr("checked", false);
          }
     </script>
     <div style="padding-left: 10px; padding-right: 10px;">
          <table border="0" cellpadding="0" cellspacing="0" style="margin: 10px; margin-left:auto; margin-right:auto;">
          <tr>
               <td style="background-color: #b8e1f4; padding-top: 5px; padding-bottom: 5px; padding: 5px;"><h3>Download direct from your bank/credit card company:</h3></td>
               <td></td>
               <td style="background-color: #b8e1f4; padding-top: 5px; padding-bottom: 5px; padding: 5px;"><h3>From a File:</h3></td>
          </tr>
          <tr>
               <td>
                    <table style="border: 1px solid #cfcece; background-color: #f2f2f2; width: 100%; height: 100px;">
                    <tr>
                         <td style="width: 150px;">Financial Account:</td>
                         <td colspan="3">
                              <asp:DropDownList ID="OFXAccounts" runat="server" Width="300px" EnableViewState="true"></asp:DropDownList>
                         </td>
                    </tr>
                    <tr>
                         <td>Start Date:</td>
                         <td>
                              <asp:TextBox ID="OFXStartDate" runat="server" Width="100px"></asp:TextBox>
                              <cc1:CalendarExtender ID="StartDateExtender" runat="server" TargetControlID="OFXStartDate"></cc1:CalendarExtender>
                         </td>
                         <td>End Date:</td>
                         <td>
                              <asp:TextBox ID="OFXEndDate" runat="server" Width="100px"></asp:TextBox>
                              <cc1:CalendarExtender ID="EndDateExtender" runat="server" TargetControlID="OFXEndDate"></cc1:CalendarExtender>     
                         </td>
                    </tr>
                    <tr>
                         <td colspan="4" style="text-align: right; padding-right: 15px;"><asp:Button ID="OFXPreview" runat="server" Text="Preview" Height="30px" Width="75px" OnClick="OFXPreview_Click" /></td>
                    </tr>
                    </table>
               </td>
               <td style="padding: 15px;">Or</td>
               <td valign="top">
                    <table style="border: 1px solid #cfcece; background-color: #f2f2f2; width: 100%; height: 100px;">
                    <tr>
                         <td style="width: 200px;">Choose your file:</td>
                         <td><asp:FileUpload ID="FileUpload1" runat="server" /></td>
                    </tr>
                    <tr>
                         <td></td>
                         <td>
                              <asp:Button ID="Load" runat="server" Text="Preview" Height="30px" Width="75px" OnClick="Load_Click" /><br />
                         </td>
                    </tr>
                    <tr>
                         <td colspan="2" style="text-align: right; font-size: 9pt;">
                              (Currently only the QIF format from CitiCards.com is supported)
                         </td>
                    </tr>
                    </table>
               </td>
          </tr>
          </table>
     </div>
     <div style="margin-left: 10px; margin-right: 10px;">
          <asp:Panel ID="LedgerItems" runat="server" Visible="false">
               <hr />
               <div style="float:right; padding-bottom: 0px;">
                    Select: <a href="javascript:CheckAll();">All</a>, <a href="javascript:CheckNone();">None</a>
               </div>
               Ledger items detected:<br />
               <br />
               <asp:DataGrid ID="TransactionsDetected" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="BurlyWood" Width="100%">
               <Columns>
                    <asp:BoundColumn HeaderText="Id" DataField="Id" Visible="false"></asp:BoundColumn>
                    <asp:TemplateColumn ItemStyle-HorizontalAlign="Center">
                         <ItemTemplate>
                              <asp:CheckBox ID="ImportRow" runat="server" Checked="false" />
                         </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn HeaderText="Date" DataField="PostAt" DataFormatString="{0:MM/dd/yy}" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="90px"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="TXNID" DataField="ExternalId" Visible="false"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Code" DataField="Code" DataFormatString="{0}"></asp:BoundColumn>
                    <asp:TemplateColumn HeaderText="Memo">
                         <ItemTemplate>
                              <asp:TextBox ID="Memo" runat="server" Text=<%# DataBinder.Eval(Container.DataItem, "Memo") %> Width="350px"></asp:TextBox>
                         </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn HeaderText="Amount" DataField="Amount" ItemStyle-HorizontalAlign="right" DataFormatString="{0,10:C}&nbsp;"></asp:BoundColumn>
               </Columns>
               </asp:DataGrid><br />
               <asp:DataGrid ID="TestGrid" runat="server"></asp:DataGrid>
                    *Light blue transaction rows were detected as already being in the database.
               <div style="float:right; clear: both;">
                    <table>
                    <tr>
                         <td>
                              <table>
                              <tr>
                                   <td>Total Rows:</td>
                                   <td style="text-align:right;"><asp:Label ID="DetectedTotal" runat="server" Text="0"></asp:Label></td> 
                              </tr>
                              <tr>
                                   <td>Total Credits:</td>
                                   <td style="text-align:right;"><asp:Label ID="TotalCredits" runat="server" Text="$0.00"></asp:Label></td>
                              </td>
                              <tr>
                                   <td>Total Debits:</td>
                                   <td style="text-align:right;"><asp:Label ID="TotalDebits" runat="server" Text="$0.00"></asp:Label></td>
                              </tr>
                              </table>
                         </td>
                    </tr>
                    <tr>
                         <td style="text-align: center;">
                              <asp:Button ID="OFXImport" runat="server" Text="Import" Height="30px" Width="180px" OnClick="OFXImport_Click" />
                         </td>
                    </tr>
                    </table>
               </div>
               <br />
          </asp:Panel>
     </div>
</asp:Content>