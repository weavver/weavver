<%@ Page Language="C#" CodeFile="XML.aspx.cs" ViewStateMode="Disabled" Inherits="DynamicData.XML" validateRequest="False" %>
<html>
<form runat="server">
     <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true">
          <DataControls>
               <asp:DataControlReference ControlID="GridView1" />
          </DataControls>
     </asp:DynamicDataManager>
     <ef:EntityDataSource ID="GridDataSource" runat="server" EnableDelete="true" />

     <asp:ListView ID="GridView1" runat="server" DataSourceID="GridDataSource"
                         EnablePersistedSelection="true"
                         AllowPaging="True" AllowSorting="True" PageSize="50">
     <ItemTemplate>
     asdf
     </ItemTemplate>
     </asp:ListView>
</form>
</html>