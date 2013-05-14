<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" CodeFile="Details.aspx.cs" Inherits="DynamicData.Details" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
     <script type="text/javascript">
          function showAttachments(e) {

               $("#attachmentsDiv").mouseenter(function () {

                    $("#attachmentsDiv").mouseleave(function () { $(this).hide() });

               });

               $('#attachmentsDiv').css({ 'top': document.pageY - 10, 'left': document.pageX - 10 });
               $("#attachmentsDiv").show();
          }

//          $(document).ready(function () {
//               $("#ItemLayer").resizable({
//                    minHeight: $("#ItemLayer").height(),
//                    minWidth: 510
//               });
//               $('#ItemLayer').draggable({
//                    containment: $("body"),
//                    start: function () { $(this).css('position', 'absolute') },
//                    stop: function (event, ui) { }
//               });
//          });

     </script>
               <asp:Panel ID="AvailableActions" runat="server"></asp:Panel>
     <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true">
          <DataControls>
               <asp:DataControlReference ControlID="FormView1" />
          </DataControls>
     </asp:DynamicDataManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Always">
     <ContentTemplate>
          <asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableClientScript="true" HeaderText="Please correct the following problems:" CssClass="DDValidator" ShowMessageBox=true ShowSummary="false" />
          <asp:DynamicValidator runat="server" ID="DetailsViewValidator" ControlToValidate="FormView1" Display="None" CssClass="DDValidator" />
               <div style='background-color: #e8fbff; padding: 5px; vertical-align: middle;'>
                    <div style="float:right;clear:both;margin-bottom: 2px;">
                         <asp:Panel ID="AttachmentsList" runat="server" style="display:inline;">
                              <a href='javascript:showAttachments();'>Attachments<img src="/images/paperclip.png" height="15px" alt="Paperclip image" /></a> |
                         </asp:Panel>
                         <asp:Panel ID="EditOptions" runat="server" style="display:inline;">
                              <asp:LinkButton ID="SaveEdit" runat="server" Text="Save" OnClick="Save_Link" Visible="false"></asp:LinkButton>
                              <asp:LinkButton ID="BeginEdit" runat="server" Text="Edit" OnClick="Edit_Link"></asp:LinkButton>
                              <asp:LinkButton ID="CancelEdit" runat="server" Text="Cancel" OnClick="Cancel_Link" Visible="false"></asp:LinkButton> |
                              <asp:LinkButton ID="DeleteItem" runat="server" CommandName="Delete" Text="Delete" OnClientClick='return confirm("Are you sure you want to delete this item?");' />
                              <asp:DynamicHyperLink ID="BackToTheList" runat="server" Action="List" Text="Back to the List" />
                         </asp:Panel>
                    </div>
                    <%--<h2><asp:Literal ID="ItemTitle" runat="server"></asp:Literal></h2>--%>
                    <div style="clear:both;"></div>
               </div>
               <asp:FormView runat="server" ID="FormView1" DataSourceID="DetailsDataSource" OnItemCommand="FormView1_ItemCommand" OnItemDeleting="FormView1_ItemDeleting" OnItemDeleted="FormView1_ItemDeleted" RenderOuterTable="false">
                <InsertItemTemplate>
                    <asp:DynamicEntity ID="DynamicEntity2" runat="server" Mode="Insert" /><br />
                    <div style="float:right; clear:right; margin-right: 30px;">
                         <asp:Button ID="Button1" runat="server" CommandName="Insert" Text="Save" Height="30px" Width="100px" />
                    </div>
                </InsertItemTemplate>
               <ItemTemplate>
                         <div style='visibility: hidden;'><%# SetTitle(Container.DataItem) %></div>
                         <asp:DynamicEntity ID="DynamicEntity1" runat="server" />
               </ItemTemplate>
               <EditItemTemplate>
                    <asp:DynamicEntity ID="DynamicEntity1" runat="server" Mode="Edit" />
                    <br />
                    <div id="dialog" style="font-size: 12pt;">
                    </div>
               </EditItemTemplate>
               <EmptyDataTemplate>
                    <div class="DDNoItem">No such item.</div>
               </EmptyDataTemplate>
               </asp:FormView>
               <div style="float:right; padding: 10px 10px 10px 0px;">
                    <asp:Panel ID="Projections" runat="server"></asp:Panel>
               </div>
               <div style='clear: both;'></div>
               <div id="attachmentsDiv" style="display: none; position: absolute; left: 0px; top: 0px; min-width: 150px; padding: 5px; background-color: #FFFFFF; border: 1px solid black;">
                    <asp:PlaceHolder ID="Attachments" runat="server">Empty placeholder</asp:PlaceHolder>
               </div>
          <asp:EntityDataSource ID="DetailsDataSource" runat="server" EnableDelete="true" EnableUpdate="true" />
          <asp:QueryExtender TargetControlID="DetailsDataSource" ID="DetailsQueryExtender" runat="server">
               <asp:DynamicRouteExpression />
          </asp:QueryExtender>
     </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>

