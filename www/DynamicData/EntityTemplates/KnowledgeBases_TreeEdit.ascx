<%@ Control Language="C#" AutoEventWireup="true" CodeFile="KnowledgeBases_TreeEdit.ascx.cs" Inherits="DynamicData_EntityTemplates_KnowledgeBases_TreeEdit" %>

<table cellpadding="3" cellspacing="0">
<tr>
     <td style="width: 125px;">Article Id:</td>
     <td><asp:DynamicControl ID="DynamicControl5" runat="server" DataField="Id" /></td>
</tr>
<tr>
     <td style="width: 125px;">Parent Node:</td>
     <td><asp:DynamicControl ID="DynamicControl4" runat="server" DataField="KnowledgeBase2" OnInit="DynamicControl_Init" /></td>
</tr>
<tr>
     <td>Title:</td>
     <td><asp:DynamicControl ID="DynamicControl1" runat="server" DataField="Title" OnInit="DynamicControl_Init" /></td>
</tr>
<tr>
     <td>Position:</td>
     <td><asp:DynamicControl ID="DynamicControl3" runat="server" DataField="Position" OnInit="DynamicControl_Init" /></td>
</tr>
</table>
<hr />
<div style="min-width: 200px; height: 400px;">
     <asp:DynamicControl ID="DynamicControl2" runat="server" DataField="HtmlBody" HtmlEncode="false" OnInit="DynamicControl_Init" />
</div>