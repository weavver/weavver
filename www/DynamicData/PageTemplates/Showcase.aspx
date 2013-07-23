<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" CodeFile="Showcase.aspx.cs" Inherits="DynamicData.Showcase" validateRequest="False" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register src="~/DynamicData/Content/GridViewPager.ascx" tagname="GridViewPager" tagprefix="asp" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
<%--<script type="text/javascript">
          function row_click(o)
          {
               alert(window.event.button);
               if (window.event.button == 3)
               {
                    alert('row clicked');
               }
          }
          function right_click(o)
          {
               alert('xasdfasfd');
               return false;
          }
          $(document).ready(function() {
               $("#tabs").tabs( {
                    show: function() {
                     var sel = $('#tabs').tabs('option', 'selected');
                     $("#<%= hidLastTab.ClientID %>").val(sel);
                 },
                 selected: <%= hidLastTab.Value %>
               });
          });
     </script>
     <style type="text/css">
          #tabs
          {
               font-size: 10pt;
          }
          #calendar {
               width: 900px;
               margin: 0 auto;
          }
     </style>--%>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true">
        <DataControls>
            <asp:DataControlReference ControlID="GridView1" />
        </DataControls>
    </asp:DynamicDataManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
               <div style="text-align: center; width: 100%;">
               <asp:Repeater ID="List" runat="server" DataSourceID="GridDataSource">
               <ItemTemplate>
                    <div style="display: inline-block; margin-right: 5px; padding: 5px; width: 210px; text-decoration: none; height:270px; overflow: auto; vertical-align: top; margin-bottom: 10px; background-color: #FAFAFA; border: solid 2px #e4e4e4;-moz-border-radius: 6px;-webkit-border-radius:6px;border-radius: 6px;">
                         <a id="<%# DataBinder.Eval(Container.DataItem, "Id") %>" style="text-decoration: none; font-size: 14pt; margin-bottom: 10px; color: blue;" href="<%# GetURL(Container.DataItem) %>">
                              <%# DataBinder.Eval(Container.DataItem, "Name") %>
                              <div style="padding-top: 10px;padding-right: 5px; text-align: center;"><%# GetLogo(new Guid(DataBinder.Eval(Container.DataItem, "Id").ToString())) %></div>
                         </a>
                         <div style="text-align: left;"><%# DataBinder.Eval(Container.DataItem, "Brief") %></div>
                    </div>
               </ItemTemplate>
               </asp:Repeater>
            </div>
            <asp:GridView ID="GridView1" runat="server" DataSourceID="GridDataSource" EnablePersistedSelection="true"
                AllowPaging="True" AllowSorting="True" CssClass="DDGridView"
                RowStyle-CssClass="td" HeaderStyle-CssClass="th" CellPadding="3" PageSize="50" Visible="false">
            </asp:GridView>
            <asp:EntityDataSource ID="GridDataSource" runat="server" />
        </ContentTemplate>
     </asp:UpdatePanel>
     <div id="specials" style="clear:both; margin: 10px;">
          <asp:Literal ID="StoreSpecials" runat="server"></asp:Literal>
          <a href="~/Sales_ResellerProgram">Reseller Program</a>
     </div>
</asp:Content>