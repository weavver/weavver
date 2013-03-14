<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" CodeFile="Page.aspx.cs" Inherits="DynamicData.Page" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%--<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true">
        <DataControls>
            <asp:DataControlReference ControlID="FormView1" />
        </DataControls>
    </asp:DynamicDataManager>
     <asp:FormView runat="server" ID="FormView1" DataSourceID="DetailsDataSource" RenderOuterTable="false">
          <ItemTemplate>
               <%# DataBinder.Eval(Container.DataItem, "Page")%>
          </ItemTemplate>
          <EmptyDataTemplate>
          <div class="DDNoItem">No such item.</div>
          </EmptyDataTemplate>
     </asp:FormView>
     <asp:EntityDataSource ID="DetailsDataSource" runat="server" EnableDelete="true" />
     <asp:QueryExtender TargetControlID="DetailsDataSource" ID="DetailsQueryExtender" runat="server">
          <asp:DynamicRouteExpression />
     </asp:QueryExtender>
</asp:Content>