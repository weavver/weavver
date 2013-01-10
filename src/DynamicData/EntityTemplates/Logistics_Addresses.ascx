<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Logistics_Addresses.ascx.cs"
     Inherits="DynamicData_EntityTemplates_Logistics_Addresses" %>

<table>
<tr>
     <td class="DDLightHeader">
          <asp:Label ID="Label6" runat="server" Text="Name" />
     </td>
     <td colspan="3">
          <asp:DynamicControl ID="DynamicControl5" runat="server" DataField="Name" OnInit="DynamicControl_Init" />
     </td>
</tr>
<tr>
     <td class="DDLightHeader">
          <asp:Label ID="Label1" runat="server" Text="Line 1" />
     </td>
     <td colspan="3">
          <asp:DynamicControl ID="DynamicControl1" runat="server" DataField="Line1" OnInit="DynamicControl_Init" />
     </td>
</tr>
<tr>
     <td class="DDLightHeader">
          <asp:Label ID="Label7" runat="server" Text="Line 2" />
     </td>
     <td colspan="3">
          <asp:DynamicControl ID="DynamicControl2" runat="server" DataField="Line2" OnInit="DynamicControl_Init" />
     </td>
</tr>
<tr>
     <td class="DDLightHeader">
          <asp:Label ID="Label2" runat="server" Text="City" />
     </td>
     <td>
          <asp:DynamicControl ID="DynamicControl3" runat="server" DataField="City" OnInit="DynamicControl_Init" />
     </td>
     <td class="DDLightHeader">
          <asp:Label ID="Label3" runat="server" Text="State/Province" />
     </td>
     <td>
          <asp:DynamicControl ID="DynamicControl4" runat="server" DataField="State" OnInit="DynamicControl_Init" />
     </td>
</tr>
<tr>
     <td class="DDLightHeader">
          <asp:Label ID="Label4" runat="server" Text="Country/Region" />
     </td>
     <td>
          <%--<asp:DynamicControl ID="DynamicControl5" runat="server" DataField="Country" />--%>
     </td>
     <td class="DDLightHeader">
          <asp:Label ID="Label5" runat="server" Text="Postal Code" />
     </td>
     <td>
          <asp:DynamicControl ID="DynamicControl6" runat="server" DataField="ZipCode" OnInit="DynamicControl_Init" />
     </td>
</tr>
</table>