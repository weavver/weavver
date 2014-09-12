<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" CodeFile="Edit.aspx.cs" Inherits="DynamicData.Edit" ValidateRequest="false" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
          <asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableClientScript="true" HeaderText="List of validation errors" CssClass="DDValidator" />
          <asp:DynamicValidator runat="server" ID="DetailsViewValidator" ControlToValidate="FormView1" Display="None" CssClass="DDValidator" />
          <asp:FormView runat="server" ID="FormView1" DataSourceID="DetailsDataSource" DefaultMode="Edit" OnItemCommand="FormView1_ItemCommand" OnItemUpdated="FormView1_ItemUpdated" RenderOuterTable="false">
               <EditItemTemplate>
                    <div style='background-color: #59b8ee; padding: 5px; vertical-align: middle; margin-bottom: 5px;'>
                         <div style="float:right; color: #FFFFFF">
                              <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" Text="Save" style="color: #FFFFFF" /> | 
                              <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Cancel" Text="Cancel" CausesValidation="false" style="color: #FFFFFF" />
                         </div>
                         <div style="clear: both;"></div>
                    </div>
                    <br />
                    <br />
                    <asp:DynamicEntity ID="DynamicEntity1" runat="server" Mode="Edit" />
                    <br />
                    <div id="dialog" style="font-size: 12pt;">
                    </div>
               </EditItemTemplate>
               <EmptyDataTemplate>
                    <div class="DDNoItem">No such item.</div>
               </EmptyDataTemplate>
          </asp:FormView>
          <ef:EntityDataSource ID="DetailsDataSource" runat="server" EnableUpdate="true" />
          <asp:QueryExtender TargetControlID="DetailsDataSource" ID="DetailsQueryExtender" runat="server">
               <asp:DynamicRouteExpression />
          </asp:QueryExtender>
     </ContentTemplate>
     </asp:UpdatePanel>
     <div style="clear:right; float: right; padding: 15px; clear:both;">
          <asp:Panel ID="Projections" runat="server"></asp:Panel>
     </div>
     <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true">
          <DataControls>
               <asp:DataControlReference ControlID="FormView1" />
          </DataControls>
     </asp:DynamicDataManager>
</asp:Content>