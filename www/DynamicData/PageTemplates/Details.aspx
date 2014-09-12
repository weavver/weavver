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
     <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true">
          <DataControls>
               <asp:DataControlReference ControlID="FormView1" />
          </DataControls>
     </asp:DynamicDataManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Always">
     <ContentTemplate>
          <asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableClientScript="true" HeaderText="Please correct the following problems:" CssClass="DDValidator" ShowMessageBox="true" ShowSummary="false" />
          <asp:DynamicValidator runat="server" ID="DetailsViewValidator" Enabled="false" ControlToValidate="FormView1" Display="None" CssClass="DDValidator" />
          <div style='background-color: #59b8ee; padding: 0px; vertical-align: middle; color: #FFFFFF;padding-left: 5px;'>
               <asp:Panel ID="AvailableActions" runat="server" style="float:left;"></asp:Panel>
               <div ID="EditOptions" runat="server" Visible="true" style="float:right;margin-bottom: 0px; margin-right: 5px;">
                    <asp:PlaceHolder ID="AttachmentsList" runat="server" Visible="false"> <a href='javascript:showAttachments();' class='menuLink'>
                         <span style='vertical-align: middle'>Attachments</span><img src="/images/paperclip.png" height="15px" alt="Paperclip image" style='vertical-align: middle' border="0" /></a>
                    </asp:PlaceHolder>
                    <asp:LinkButton ID="SaveEdit" runat="server" Text="Save" OnClick="Save_Link" ForeColor="White" CssClass="menuLink" Visible="false"></asp:LinkButton>
                    <asp:LinkButton ID="BeginEdit" runat="server" Text="Edit" OnClick="Edit_Link" ForeColor="White" CssClass="menuLink"></asp:LinkButton>
                    <asp:LinkButton ID="CancelEdit" runat="server" Text="Cancel" OnClick="Cancel_Link" CausesValidation="false" Visible="false" CssClass="menuLink"></asp:LinkButton>
                    <asp:LinkButton ID="DeleteItem" runat="server" OnClick="Delete_Link" Text="Delete" OnClientClick='return confirm("Are you sure you want to delete this item?");' CssClass="menuLink" CausesValidation="false" Visible="false" />
                    <a href="#" ID="BackToTheList" runat="server" class="menuLink" Visible="false">Back to the List</a>
               </div>
               <%--<h2><asp:Literal ID="ItemTitle" runat="server"></asp:Literal></h2>--%>
               <div style="clear:both;"></div>
          </div>
          <asp:FormView runat="server" ID="FormView1" DataSourceID="DetailsDataSource" OnItemDeleting="FormView1_ItemDeleting" OnItemDeleted="FormView1_ItemDeleted" 
RenderOuterTable="false" OnModeChanged="FormView1_ModeChanged" OnDataBound="FormView1_DataBound">
          <InsertItemTemplate>
               <asp:DynamicEntity ID="DynamicEntity2" runat="server" Mode="Insert" /><br />
               <div style="float:right; clear:right; margin-right: 20px;">
                    <asp:Button ID="Button1" runat="server" CommandName="Insert" Text="Save" Height="30px" Width="100px" />
               </div>
          </InsertItemTemplate>
          <ItemTemplate>
               <div style='visibility: hidden;'><%# SetTitle(Container.DataItem) %></div>
               <asp:DynamicEntity ID="DynamicEntity1" runat="server" />
               <span style='padding: 10px;'><asp:Literal ID="Permissions" runat="server">Accessible to: Public</asp:Literal></span>
          </ItemTemplate>
          <EditItemTemplate>
               <asp:DynamicEntity ID="DynamicEntity1" runat="server" Mode="Edit" />
               <br />
               <span style='padding: 10px;'><asp:Literal ID="Permissions" runat="server">Accessible to: Public</asp:Literal></span>
               <div id="dialog" style="font-size: 12pt;">
               </div>
          </EditItemTemplate>
          <EmptyDataTemplate>
               <div class="DDNoItem">No such item.</div>
          </EmptyDataTemplate>
          </asp:FormView>
          <div style='clear: both'></div>
          <div style="float:right; padding: 5px 10px 10px 0px;">
               <asp:Panel ID="Projections" runat="server"></asp:Panel>
          </div>
          <div style='clear: both;'></div>
          <div id="attachmentsDiv" style="display: none; position: absolute; left: 0px; top: 0px; min-width: 150px; padding: 5px; background-color: #FFFFFF; border: 1px solid black;">
               <asp:PlaceHolder ID="Attachments" runat="server">Empty placeholder</asp:PlaceHolder>
          </div>
          <ef:EntityDataSource ID="DetailsDataSource" runat="server" EnableInsert="true" EnableDelete="true" EnableUpdate="true" />
          <asp:QueryExtender TargetControlID="DetailsDataSource" ID="DetailsQueryExtender" runat="server">
               <asp:DynamicRouteExpression />
          </asp:QueryExtender>
     </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>

