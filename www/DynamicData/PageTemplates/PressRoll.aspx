<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" CodeFile="PressRoll.aspx.cs" Inherits="DynamicData.PressRoll" validateRequest="False" %>
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
     <asp:Panel ID="AdminLinks" runat="server" Visible="false">
          <div style="float:right; padding-bottom: 10px;">
               <a href="List.aspx">Admin List</a>
          </div>
     </asp:Panel>
     <br />
     <br />
     <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true">
          <DataControls>
               <asp:DataControlReference ControlID="GridView1" />
          </DataControls>
     </asp:DynamicDataManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
               <asp:DataList ID="List" runat="server" DataSourceID="GridDataSource" RepeatLayout="Flow" RepeatColumns="1" RepeatDirection="Horizontal" HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
               <ItemTemplate>
                     <div style="border: solid 0px black;">
                         <div title="<%# Eval("UpdatedAt") %>" style="padding: 3px; padding-bottom: 15px;">
                              <h4><%# HTMLPurifierLib.Sanitize((string) DataBinder.Eval(Container.DataItem, "Title")) %></h4>
                              Published on <%# Eval("PublishAt") %><br />
                              <br />
                              <%# HTMLPurifierLib.Sanitize(Eval("HTMLBody").ToString().Replace("\r\n", "\r\n<br />")) %>
                         </div>
                         <div style="margin-left: 60px; margin-right: 20px; padding: 10px; padding-bottom: 0px;"></div>
                    </div>
               </ItemTemplate>
               </asp:DataList>
               <asp:GridView ID="GridView1" runat="server" DataSourceID="GridDataSource" EnablePersistedSelection="true"
                    AllowPaging="True" AllowSorting="True" CssClass="DDGridView"
                    RowStyle-CssClass="td" HeaderStyle-CssClass="th" CellPadding="3" PageSize="50" Visible="false">
               </asp:GridView>
               <ef:EntityDataSource ID="GridDataSource" runat="server" />
          </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>