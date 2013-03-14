<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Forum_Posts.aspx.cs" Inherits="Company_Products_Snap_Forum_Forum" %>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" Runat="Server">
     <asp:Literal ID="Description" runat="server"></asp:Literal><br />
     <br />
     <div style="background-color: #FFE9E8; padding: 5px;">We have imported old posts from the old Snap website. Please be aware that we fixed many of the old issues and that Snap is now being actively developed.<br /></div>
     <br />
     <script type="text/javascript">
          function mouseOver(o) {
               o.style.borderBottom = '';
               o.style.backgroundColor = '#F5FAFA';
               o.style.border = 'solid 1px lightgray';
               o.style.padding = '3px';
          }
          function mouseOut(o)
          {
               o.style.backgroundColor = '';
               o.style.border = 'none';
               o.style.border = 'solid 1px lightgray';
               o.style.padding = '3px';
          }
     </script>
     <asp:DataGrid ID="List" runat="server" Width="100%" Visible="true" AutoGenerateColumns="false" HeaderStyle-BackColor="#CCCCCC" CellPadding="4" BorderColor="lightgray">
     <Columns>
          <asp:BoundColumn DataField="Id" Visible="false"></asp:BoundColumn>
          <asp:BoundColumn DataField="Alias" Visible="true" HeaderText="Posted By" HeaderStyle-Width="125px"></asp:BoundColumn>
          <asp:TemplateColumn HeaderText="Subject">
          <ItemTemplate>
               <div style="overflow:hidden; width: 100%;">
                    <%# DataBinder.Eval(Container.DataItem, "Subject")%>
                    <span style="color: Gray; font-style: italic;">&nbsp;&nbsp;<%# TrimPost(DataBinder.Eval(Container.DataItem, "Body").ToString()) %></span>
               </div>
          </ItemTemplate>
          </asp:TemplateColumn><%--
          <asp:TemplateColumn HeaderText="Replies" ItemStyle-HorizontalAlign="Center">
               <ItemTemplate><%# GetReplyCount((Weavver.Communication.Post) Container.DataItem) %></ItemTemplate>
          </asp:TemplateColumn>--%>
          <asp:BoundColumn DataField="Created" Visible="true" ItemStyle-Width="175px" HeaderText="Last Updated" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
     </Columns>
     </asp:DataGrid>
     <asp:DataList ID="List2" runat="server" Width="100%" Visible="true">
     <ItemTemplate>
          <table width="100%" cellpadding="0" cellspacing="0">
          <tr style="cursor: pointer; text-decoration: none; color: Black; padding: 3px; border: solid 1px white; border: solid 1px lightgray;" >
               <td style="padding: 3px;"><%# DataBinder.Eval(Container.DataItem, "Alias") %></td>
               <td style="padding: 3px; overflow: hidden;"><%# DataBinder.Eval(Container.DataItem, "Subject") %>
                    
               </td>
               <td>
                    <asp:Label ID="Count" runat="server" Text="12"></asp:Label>
               </td>
               <td style="padding: 3px; width: 205px;">
                    <div style="float:right; color: Black; font-style: normal; text-decoration: none;">
                         <asp:Label ID="Created" runat="server"></asp:Label>
                    </div>
               </td>
          </tr>
          </table>
     </ItemTemplate>
     </asp:DataList>
     <div style="height: 30px;">&nbsp;</div>
</asp:Content>