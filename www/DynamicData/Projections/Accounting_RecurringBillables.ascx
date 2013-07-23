<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Accounting_RecurringBillables.ascx.cs" Inherits="DynamicData_Projections_Accounting_RecurringBillables" %>

<asp:Panel ID="Totals" runat="server" Visible="false">
     <div style="float:right; padding-top: 0px;">
          <table cellpadding="0" cellspacing="0" width="225px">
          <tr>
               <td>Recurring Revenue:</td>
               <td style="text-align: right;"><asp:Literal ID="RecurringRevenue" runat="server"></asp:Literal></td>
          </tr>
          <tr>
               <td style="border-bottom: solid 1px black;">Recurring Expenses:</td>
               <td style="text-align: right; border-bottom: solid 1px black;">- <asp:Literal ID="RecurringExpenses" runat="server"></asp:Literal></td>
          </tr>
          <tr>
               <td>Net:</td>
               <td style="text-align: right;"><asp:Literal ID="Net" runat="server"></asp:Literal></td>
          </tr>
          </table>
     </div>
</asp:Panel>

<asp:Panel ID="Projection" runat="server" Visible="false">
     <div id="Projection" style='padding: 5px;'>
          <br />
          Projected Billing Schedule:<br />
          <br />
          <asp:DataGrid id="ProjectionList" runat="server" width="100%" headerstyle-backcolor="burlywood" autogeneratecolumns="false">
          <Columns>
               <asp:BoundColumn HeaderText="Post On" DataField="PostAt" DataFormatString="{0:MM/dd/yy}" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="center"></asp:BoundColumn>
               <asp:BoundColumn HeaderText="Code" DataField="Code" ItemStyle-Width="75px" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
               <asp:BoundColumn HeaderText="Memo" DataField="Memo"></asp:BoundColumn>
               <asp:BoundColumn HeaderText="Amount" DataField="Amount" DataFormatString="{0:C}" ItemStyle-HorizontalAlign="right" ItemStyle-Width="100px"></asp:BoundColumn>
          </Columns>
          </asp:DataGrid><br />
          If the End At date is not set the schedule is projected only 24 periods out.
     </div>
     <script type="text/javascript">
          $(document).ready(function () {
               var tabs = $("#tableControl").tabs();
               var ul = tabs.find("ul");
               $("<li><a href='#Projection'>Projection</a></li>").appendTo(ul);
               $('#tableControl').append($('#Projection'));
               tabs.tabs("refresh");
          });
     </script>
</asp:Panel>