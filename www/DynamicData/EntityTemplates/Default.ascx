<%@ Control Language="C#" CodeFile="Default.ascx.cs" Inherits="DynamicData.DefaultEntityTemplate" %>

<script type="text/javascript">
     $(document).ready(function () {
          //$('#EntityWindow').dialog();
     });
</script>
<div id='EntityWindow'>
     <%--
     <%// This is not rendered here, it's added to each tab content area. %>
     <asp:EntityTemplate ID="EntityTemplate1" runat="server">
     <ItemTemplate>
          <tr runat="server">
               <td>
                    <asp:Label ID="Label1" runat="server" OnInit="Label_Init" />:</label>
               </td>
               <td>
                    <div><asp:DynamicControl ID="DynamicControl1" runat="server" OnInit="DynamicControl_Init" /></div><br />
               </td>
          </tr>
     </ItemTemplate>
     </asp:EntityTemplate>--%>

     <div id="tableControl" style="margin: 0px; padding: 0px;clear:both;">
         <ul id="tabheader" runat="server">
             <li class="tabcontroltab"><a href="#<%# GeneralControls.ClientID %>">General Information</a></li>
         </ul>
         <div id="GeneralControls" runat="server" style="padding: 0px;">
         </div>
         <asp:PlaceHolder ID="Tabs" runat="server"></asp:PlaceHolder>
     </div>
</div>