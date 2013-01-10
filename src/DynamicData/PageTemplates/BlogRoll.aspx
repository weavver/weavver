<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" CodeFile="BlogRoll.aspx.cs" Inherits="DynamicData.PressRoll" validateRequest="False" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register src="~/DynamicData/Content/GridViewPager.ascx" tagname="GridViewPager" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
     <asp:Panel ID="AdminLinks" runat="server" Visible="false" style="clear:both">
          <div style="float:right; padding-bottom: 10px;">
               <a href="List.aspx">Admin List</a>
               <asp:LinkButton ID="LinkButton3" runat="server" CommandName="New" Text="New" />
          </div><br />
          <br />
     </asp:Panel>
     <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true">
     <DataControls>
          <asp:DataControlReference ControlID="List" />
     </DataControls>
     </asp:DynamicDataManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
               <asp:ListView ID="List" runat="server" DataSourceID="GridDataSource">
               <ItemTemplate>
                    <table cellpadding="10px" width="100%" class="RowStyle" onclick="location.href='Details.aspx?Id=<%# Eval("Id") %>'" onmouseover="mouseOver(this, 'HoverRowStyle')" onmouseout="mouseOver(this, 'RowStyle')">
                         <asp:DynamicEntity ID="DynamicEntity1" runat="server" />
                    </table>
               </ItemTemplate>
          </asp:ListView>
          </table>
          <asp:EntityDataSource ID="GridDataSource" runat="server" />
          <div style="background-image: url('/images/blogs/SquareDivider.png'); height:75px; margin-top: 10px; clear:both;"></div>
     </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>