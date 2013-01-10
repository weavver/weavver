<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" CodeFile="Details.aspx.cs" Inherits="DynamicData.Details" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
     <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true">
          <DataControls>
               <asp:DataControlReference ControlID="FormView1" />
          </DataControls>
     </asp:DynamicDataManager>
     <div class="DDBottomHyperLink" style="float:right;">
          <%--<asp:DynamicHyperLink ID="ListHyperLink" runat="server" Action="List">Show all items</asp:DynamicHyperLink>--%>
     </div>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
          <asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableClientScript="true" HeaderText="List of validation errors" CssClass="DDValidator" />
          <asp:DynamicValidator runat="server" ID="DetailsViewValidator" ControlToValidate="FormView1" Display="None" CssClass="DDValidator" />
          <asp:FormView runat="server" ID="FormView1" DataSourceID="DetailsDataSource" OnItemCommand="FormView1_ItemCommand" OnItemDeleting="FormView1_ItemDeleting" OnItemDeleted="FormView1_ItemDeleted" RenderOuterTable="false">
               <ItemTemplate>
                    <%# SetTitle(Container.DataItem) %>
                    <asp:LoginView ID="LoginView1" runat="server">
                    <RoleGroups>
                         <asp:RoleGroup Roles="Administrators">
                         <ContentTemplate>
                              <div style="float:right;clear:both;margin-bottom: 2px;">
                                   Actions: <asp:DynamicHyperLink ID="DynamicHyperLink1" runat="server" Action="Edit" Text="Edit" /> |
                                   <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" Text="Delete"
                                             OnClientClick='return confirm("Are you sure you want to delete this item?");' /> |
                                   <asp:DynamicHyperLink ID="DynamicHyperLink2" runat="server" Action="List" Text="Back to the List" />
                              </div>
                         </ContentTemplate>
                         </asp:RoleGroup>
                    </RoleGroups>
                    </asp:LoginView>
                    <asp:DynamicEntity runat="server" />
               </ItemTemplate>
               <EmptyDataTemplate>
                    <div class="DDNoItem">No such item.</div>
               </EmptyDataTemplate>
          </asp:FormView>
          <div style="float:right; padding-top:15px;">
               <asp:Panel ID="Projections" runat="server"></asp:Panel>
          </div>
          <asp:EntityDataSource ID="DetailsDataSource" runat="server" EnableDelete="true" />
          <asp:QueryExtender TargetControlID="DetailsDataSource" ID="DetailsQueryExtender" runat="server">
               <asp:DynamicRouteExpression />
          </asp:QueryExtender>
     </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>

