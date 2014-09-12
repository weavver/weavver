<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" CodeFile="PressRelease.aspx.cs" Inherits="DynamicData.Showcase" validateRequest="False" %>
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
     <div style="float:right;">
          <a href="~/company/sales/reseller/">Reseller Program</a>
     </div>
     <br />
     <br />
    <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true">
        <DataControls>
            <asp:DataControlReference ControlID="GridView1" />
        </DataControls>
    </asp:DynamicDataManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <asp:DataList ID="ShowcaseList" runat="server" DataSourceID="GridDataSource" RepeatLayout="Table" RepeatColumns="4" RepeatDirection="Horizontal" HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
               <ItemTemplate>
                    <div style="padding: 5px; width: 210px; text-decoration: none; min-height:235px; vertical-align: top; margin-right: 15px; margin-bottom: 20px; background-color: #FAFAFA; border: solid 2px #e4e4e4;-moz-border-radius: 6px;-webkit-border-radius:6px;border-radius: 6px;">
                         <a id="<%# DataBinder.Eval(Container.DataItem, "Id") %>" style="text-decoration: none; color: Black;" href="StoreItem.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "Id") %>" style="font-size: 14pt;">
                              &nbsp;<span style="font-size: 14pt; margin-bottom: 10px; color: blue;"><%# DataBinder.Eval(Container.DataItem, "Name") %></span>
                              <div style="padding-top: 10px;padding-right: 5px; text-align: center;"><%# GetLogo(new Guid(DataBinder.Eval(Container.DataItem, "Id").ToString())) %></div>
                         </a> 
                         <div style="text-align: left;"><%# HTMLPurifierLib.Sanitize(DataBinder.Eval(Container.DataItem, "Brief").ToString()) %></div>
                    </div>
               </ItemTemplate>
            </asp:DataList>
            <asp:GridView ID="GridView1" runat="server" DataSourceID="GridDataSource" EnablePersistedSelection="true"
                AllowPaging="True" AllowSorting="True" CssClass="DDGridView"
                RowStyle-CssClass="td" HeaderStyle-CssClass="th" CellPadding="3" PageSize="50" Visible="false">
            </asp:GridView>
            <ef:EntityDataSource ID="GridDataSource" runat="server" EnableDelete="true" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>