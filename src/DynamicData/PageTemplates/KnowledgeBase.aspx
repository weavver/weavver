<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" CodeFile="KnowledgeBase.aspx.cs" Inherits="DynamicData.KnowledgeBase" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register src="~/DynamicData/Content/GridViewPager.ascx" tagname="GridViewPager" tagprefix="asp" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
     <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true">
     <DataControls>
            <asp:DataControlReference ControlID="FormView1" />
            <%--<asp:DataControlReference ControlID="GridView1" />--%>
     </DataControls>
     </asp:DynamicDataManager>

     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
          <table cellpadding="0" cellspacing="0" width="100%" style="width: 100%">
          <tr>
               <td valign="top" style="width: 280px; border-right: 2px solid #CCCCCC; padding-right: 10px; background-color:#fbfcfc; padding-top: 0px; min-width: 150px">
                    <h2>Knowledge Base</h2>
                    <hr />
                    <asp:TreeView ID="Navigation" runat="server" CssClass="tree" ShowExpandCollapse="true" RootNodeStyle-HorizontalPadding="0" NodeIndent="15" ExpandDepth="5" ShowLines="True" BackColor=""></asp:TreeView>
               </td>
               <td style="padding-left:5px; padding-top: 0px; border-left: 2px solid #f4f5f5;" valign="top">
                    <asp:FormView ID="FormView1" runat="server" DataSourceID="TreeDataSource" RenderOuterTable="false"
                         OnPreRender="FormView1_PreRender" OnModeChanging="FormView1_ModeChanging" OnItemUpdated="FormView1_ItemUpdated"
                         OnItemInserted="FormView1_ItemInserted" OnItemDeleted="FormView1_ItemDeleted">
                    <HeaderTemplate>
                         <table id="detailsTable" cellpadding="6" width="100%">
                    </HeaderTemplate>
                    <ItemTemplate>
                         <tr>
                              <td>
                                   <asp:LoginView id="LoginView1" runat="server">
                                   <RoleGroups>
                                        <asp:RoleGroup Roles="Administrators">
                                        <ContentTemplate>
                                             <div style="float:right;">
                                                  <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit" Text="Edit" />
                                                  <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" Text="Delete"
                                                       OnClientClick='return confirm("Are you sure you want to delete this item?");' />
                                                  <asp:LinkButton ID="LinkButton3" runat="server" CommandName="New" Text="New" />
                                             </div>
                                        </ContentTemplate>
                                        </asp:RoleGroup>
                                   </RoleGroups>
                                   </asp:LoginView>
                                   <asp:DynamicEntity ID="DynamicEntity1" runat="server" UIHint="KnowledgeBases" />
                              </td>
                         </tr>
                    </ItemTemplate>
                    <EditItemTemplate>
                         <tr class="td">
                              <td colspan="2" style="text-align:right;">
                                   <asp:LoginView id="LoginView1" runat="server">
                                   <RoleGroups>
                                        <asp:RoleGroup Roles="Administrators">
                                        <ContentTemplate>
                                             <div style="float:right;">
                                                  <asp:LinkButton runat="server" CommandName="Update" Text="Update" />
                                                  <asp:LinkButton runat="server" CommandName="Cancel" Text="Cancel" CausesValidation="false" />
                                             </div>
                                        </ContentTemplate>
                                        </asp:RoleGroup>
                                   </RoleGroups>
                                   </asp:LoginView>
                              </td>
                         </tr>
                         <asp:DynamicEntity ID="DynamicEntity2" runat="server" UIHint="KnowledgeBases_TreeEdit" Mode="Edit" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                         <tr class="td">
                              <td colspan="2" style="text-align:right;">
                                   <asp:LoginView id="LoginView1" runat="server">
                                   <RoleGroups>
                                        <asp:RoleGroup Roles="Administrators">
                                        <ContentTemplate>
                                             <asp:LinkButton runat="server" CommandName="Insert" Text="Insert" />
                                             <asp:LinkButton runat="server" CommandName="Cancel" Text="Cancel" CausesValidation="false" />
                                        </ContentTemplate>
                                        </asp:RoleGroup>
                                   </RoleGroups>
                                   </asp:LoginView>
                              </td>
                         </tr>
                         <asp:DynamicEntity ID="DynamicEntity3" UIHint="KnowledgeBases_TreeEdit" runat="server" Mode="Insert" />
                    </InsertItemTemplate>
                    <FooterTemplate>
                         </table>
                    </FooterTemplate>
                    </asp:FormView>
               </td>
          </tr>
          </table>
          <asp:EntityDataSource ID="TreeDataSource" runat="server" EnableDelete="true" EnableInsert="true" EnableUpdate="true" />
          <asp:QueryExtender TargetControlID="TreeDataSource" runat="server">
               <asp:ControlFilterExpression ControlID="Navigation" />
          </asp:QueryExtender>
     </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>
