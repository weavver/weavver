<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DynamicList.ascx.cs" Inherits="DynamicData_DynamicList" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/DynamicData/Content/GridViewPager.ascx" TagName="GridViewPager" TagPrefix="asp" %>
<%@ Register Src="~/Controls/ColumnPicker.ascx" TagName="ColumnPicker" TagPrefix="wvvr" %>
<script type="text/javascript">
     function confirmDelete() {
          var answer = confirm("Are you sure you want to delete this item?");
          event.stopPropagation();
          return answer;
     }

     // document.oncontextmenu = RightMouseDown;
     document.onmousedown = documentMouseClick;

     function documentMouseClick() {
          //$("#smoothmenu2").css("visibility", "hidden");
     }

     function mouseDown(e, objectId) {
          window.event.preventDefault();

//          $("#smoothmenu2").css("visibility", "visible");
//          $("#smoothmenu2").css("left", document.pageX);
//          $("#smoothmenu2").css("top", document.pageY);

          //window.event.preventDefault();
          return false;
     }

     function RightMouseDown() { return false; }

//     ddsmoothmenu.init({
//          mainmenuid: "smoothmenu2", //menu DIV id
//          orientation: 'v', //Horizontal or vertical menu: Set to "h" or "v"
//          classname: 'ddsmoothmenu-v', //class added to menu's outer DIV
//          //customtheme: ["#1c5a80", "#18374a"],
//          contentsource: "markup" //"markup" or ["container_id", "path_to_menu_file"]
//     });


     // increase the default animation speed to exaggerate the effect
     $.fx.speeds._default = 1000;
     var dlg = $(document).ready(function () {

          $("#filterRepeater").dialog({
               autoOpen: false,
               title: "Filter Options",
               open: function (type, data) {
                    $(this).parent().appendTo("form");
               }
          });
     });


     $(document).ready(function () {


          //          $("#WindowLayer").resizable({
          //               minHeight: 200,
          //               minWidth: 210
          //          });

          //          $('#WindowLayer').draggable({
          //               handle: "#ItemTitle",
          //               containment: $("body"),
          //               start: function () {
          //                    if ($(this).css('position') != 'absolute') {
          //                         //                         $(this).css('left', $(this).left());
          //                         //                         $(this).css('top', $(this).top());
          //                         $(this).css('position', 'absolute');
          //                    }
          //               },
          //               stop: function (event, ui) { }
          //          });

          $("#WindowLayer").dialog({
               position: {
                    my: 'top',
                    at: 'top',
                    of: '#ContentDIV'
               },
               open: function (event, ui) {
                    //$(this).parent().find('.ui-dialog-titlebar').append($('#ItemTitle'));
                    $(".ui-dialog-content").css("padding", 0);
               },
               title: "Title",
               dragStart: preventIFrameMouseEvents,
               dragStop: allowIFrameMouseEvents,
               resizeStart: preventIFrameMouseEvents,
               resizeStop: allowIFrameMouseEvents,
               height: 560,
               width: 780
          });

          $("#WindowLayer").resize(function () {
               var y = $("#WindowLayer").height() - $("#ItemTitle").height() - 5;
               $("#OverflowLayer").height(y);
          });

//          $('#TheIFrame').dialog({
//               open: function (event, ui) {
//                    //$(this).parent().find('.ui-dialog-titlebar').append($('#ItemTitle'));
//                    $(".ui-dialog-content").css("padding", 0);
//                    $(this).css('overflow', 'hidden');
//               },
//               dragStart: preventIFrameMouseEvents,
//               dragStop: allowIFrameMouseEvents,
//               resizeStart: preventIFrameMouseEvents,
//               resizeStop: allowIFrameMouseEvents
//          });

          $('#TheIFrame').resize(function () {
               $('#detailsframe').height($('#TheIFrame').closest('.ui-dialog').height() - 15);
               $('#detailsframe').width($('#TheIFrame').closest('.ui-dialog').width() - 15);
          });

     });

</script>

<asp:UpdatePanel ID="EntityControls" runat="server" UpdateMode="Conditional">
     <ContentTemplate>
          <asp:Panel ID="AddedControls" runat="server"></asp:Panel>
     </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>


     <div id="WindowLayer" style="background-color: #FFFFFF; border: 2px inset;">
          <div style="float:right; display: inline-block; padding: 5px;">
               <asp:Button ID="DownloadCSV" runat="server" OnClick="DownloadCSV_Click" Text="Export Data" Height="30px" Visible="false" />
               <a href="javascript:createPopup('/Accounting_Checks/Details.aspx');">New</a>
               <asp:LoginView ID="SecureContent" runat="server">
                    <RoleGroups>
                         <asp:RoleGroup Roles="Administrators">
                         <ContentTemplate>
                                   | <wvvr:ColumnPicker id="ColumnPicker1" runat="server" Visible="true"></wvvr:ColumnPicker> |
                         </ContentTemplate>
                         </asp:RoleGroup>
                    </RoleGroups>
               </asp:LoginView>
               <%--<asp:DynamicHyperLink <I>D="InsertHyperLink" runat="server" Action="Insert">
                    <img id="Img1" runat="server" src="~/DynamicData/Content/Images/plus.gif" alt="Insert new item" />New
               </asp:DynamicHyperLink>--%>
               <a href="#" onclick="javascript:$('#filterRepeater').dialog('open')">Filter</a>
          </div>
          <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true">
               <DataControls>
                    <asp:DataControlReference ControlID="GridView1" />
               </DataControls>
          </asp:DynamicDataManager>
          <asp:PlaceHolder ID="QuickAdd" runat="server"></asp:PlaceHolder><br />
          <asp:GridView ID="GridView1" runat="server" DataSourceID="GridDataSource" EnablePersistedSelection="true"
               AllowPaging="True" AllowSorting="True" CssClass="DDGridView" BorderColor="#d3d3d3"
               RowStyle-CssClass="td" HeaderStyle-CssClass="th" CellPadding="3" PageSize="50">
               <Columns></Columns>
               <PagerStyle CssClass="DDFooter" />
               <PagerTemplate>
                    <asp:GridViewPager ID="GridViewPager1" runat="server" />
               </PagerTemplate>
               <EmptyDataTemplate>
                    There are currently no items in this table.
               </EmptyDataTemplate>
          </asp:GridView>
          <div style="float: right; padding: 10px 10px 0px 0px;">
               <asp:Label ID="RowSummary" runat="server" Text="Undefined"></asp:Label>
          </div>
          <div style="clear:right; float: right; padding: 10px 10px 0px 0px;">
               <asp:PlaceHolder ID="Projections" runat="server"></asp:PlaceHolder>
          </div>
          <br />
          <asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableClientScript="true" HeaderText="List of validation errors" CssClass="DDValidator" />
          <asp:DynamicValidator runat="server" ID="GridViewValidator" ControlToValidate="GridView1" Display="None" CssClass="DDValidator" />
          <asp:EntityDataSource ID="GridDataSource" runat="server" EnableDelete="true" />
          <asp:QueryExtender ID="GridQueryExtender" runat="server" TargetControlID="GridDataSource">
               <asp:DynamicFilterExpression ControlID="FilterRepeater" />
          </asp:QueryExtender>
          <div id="smoothmenu2" class="ddsmoothmenu-v" style="position: absolute; visibility: hidden;">
               <ul>
                    <asp:PlaceHolder ID="RightClickOptions" runat="server"></asp:PlaceHolder>
               </ul>
          </div>
          <div style='clear: both;'></div>
     </div>
</ContentTemplate>
</asp:UpdatePanel>
<div id="filterRepeater" class="DD" style="background-color: #FFFFFF;">
     <asp:UpdatePanel ID="FilterUpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
     <ContentTemplate>
          <table>
          <asp:QueryableFilterRepeater runat="server" ID="FilterRepeater">
               <ItemTemplate>
                    <tr>
                         <td nowrap="nowrap" style="padding-right: 15px;">
                              <asp:Label ID="Label1" runat="server" Text='<%# Eval("DisplayName") %>' OnPreRender="Label_PreRender" />
                         </td>
                         <td nowrap="nowrap">
                              <asp:DynamicFilter runat="server" ID="DynamicFilter" OnFilterChanged="DynamicFilter_FilterChanged" />
                         </td>
                    </tr>
               </ItemTemplate>
          </asp:QueryableFilterRepeater>
          </table>
          <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="SearchButton_Click" Height="30px" style="width: 100px; float:right; margin: 10px;" />
     </ContentTemplate>
     </asp:UpdatePanel>
</div>