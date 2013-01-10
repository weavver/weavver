<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Accounting_Checks.ascx.cs" Inherits="DynamicData_EntityTemplates_Accounting_Checks" %>

<div style="clear:both;">
     Funding Source: <asp:DynamicControl ID="DynamicControl6" runat="server" DataField="Accounting_Accounts" OnInit="DynamicControl_Init" />
</div>
<div style="background-color: #EBFCF6; margin: auto; margin-top: 5px; border: outset 2px; width: 800px; padding: 10px;clear: both;">
     <div style="float:right; clear: right; text-align: right;">
          Check #<asp:DynamicControl ID="DynamicControl3" runat="server" DataField="CheckNumber" OnInit="DynamicControl_Init" />
          <table style="width: 100%; margin-top: 10px;">
          <tr>
               <td>
                    <asp:DynamicControl ID="DynamicControl2" runat="server" DataField="PostAt" OnInit="DynamicControl_Init" />
               </td>
          </tr>
          </table>
     </div>
     <asp:Literal ID="OrgAddress" runat="server"></asp:Literal>
     <br />
     <br />
     <table style="width: 100%;">
     <tr>
          <td style="width: 75px;">Pay to the order of:</td>
          <td style="border-bottom: solid 1px black;">
               <asp:DynamicControl ID="DynamicControl4" runat="server" DataField="PayeeAccount" OnInit="DynamicControl_Init" />
          </td>
          <td style="text-align: right;">
               <span style="height:25px; width: 170px;display: inline-block; text-align:left;">
                    <asp:DynamicControl ID="DynamicControl5" runat="server" DataField="Amount" OnInit="DynamicControl_Init" />
               </span>
          </td>
     </tr>
     </table>
     <br />
     <table>
     <tr>
          <td valign="top" style="width: 75px">Payee<br />address:</td>
          <td>
               <asp:Literal ID="PayeeAddress" runat="server"></asp:Literal>
          </td>
     </tr>
     </table>
     <br />
     <table style="width: 100%; margin-bottom: 10px;">
     <tr>
          <td style="width: 75px;">Memo:</td>
          <td style="border-bottom: solid 1px black; width: 275px;">
               <asp:DynamicControl ID="DynamicControl1" runat="server" DataField="Memo" OnInit="DynamicControl_Init" />
          </td>
          <td style="width: auto; text-align: right;">
               Signature: <span style="border-bottom: solid 1px black;">XXXXXXXXXXXXXXXXXXXXXX</span>
          </td>
     </tr>
     </table>
     :: 1 2 3 4 5 6 7 8 ::
</div>