<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Communication_Emails.ascx.cs" Inherits="DynamicData_EntityTemplates_Communication_Emails" %>

<div class="blog" style="border: solid 0px black;">
     <div style="padding: 3px; padding-bottom: 15px;">
          <div style="float:right;" title="<%# Eval("UpdatedAt") %>">
               <%--<% SetTitle(Eval("Title").ToString()); %>--%>
               <table style="padding-left: 25px; padding-top: 5px;" cellpadding="0" cellspacing="0">
               <tr>
                    <td>Received/Sent @&nbsp;</td>
                    <td><asp:DynamicControl ID="DynamicControl3" runat="server" DataField="CreatedAt" OnInit="DynamicControl_Init" /></td>
               </tr>
               </table>
          </div>
          <h2>Subject: <asp:DynamicControl ID="DynamicControl2" runat="server" DataField="Subject" OnInit="DynamicControl_Init" /></h2>
          <hr />
          From: <asp:DynamicControl ID="DynamicControl4" runat="server" DataField="From" OnInit="DynamicControl_Init" /><br />
          Send/Sent to: <asp:DynamicControl ID="DynamicControl5" runat="server" DataField="To" OnInit="DynamicControl_Init" />
          <div class="blog-body" style="clear:both;">
               Body:<br />
               <asp:DynamicControl ID="DynamicControl1" runat="server" DataField="HTMLBody" OnInit="DynamicControl_Init" />
          </div>
     </div>
     <div style="margin-left: 60px; margin-right: 20px; padding: 10px; padding-bottom: 0px;"></div>
</div>