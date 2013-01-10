<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CMS_Pages.ascx.cs" Inherits="DynamicData_EntityTemplates_CMS_Pages" %>

<div style="padding: 3px; padding-bottom: 5px;">
     <asp:Panel ID="TitlePanel" runat="server">
          <h2><asp:DynamicControl ID="TitleControl" runat="server" DataField="Title" OnInit="DynamicControl_Init" /></h2>
     </asp:Panel>
     <div style="clear:both;">
          <asp:DynamicControl ID="DynamicControl1" runat="server" DataField="Page" OnInit="DynamicControl_Init" />
     </div>
     <div style="clear:both;">
          <asp:DynamicControl ID="DynamicControl2" runat="server" DataField="MasterPage" OnInit="DynamicControl_Init" />
     </div>
     <div style="float:right; clear: both;padding-left: 25px; padding-top: 5px;" title="<%# Eval("UpdatedAt") %>">
          Last Updated @
          <asp:DynamicControl ID="DynamicControl3" runat="server" DataField="CreatedAt" OnInit="DynamicControl_Init" />
     </div>
</div>