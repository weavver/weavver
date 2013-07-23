using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Expressions;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using Weavver.Data;

// implement later: http://www.scip.be/index.php?Page=ArticlesNET18

namespace DynamicData
{
     public partial class KnowledgeBase : SkeletonPage
     {
          protected MetaTable table;
//-------------------------------------------------------------------------------------------
          protected void Page_Init(object sender, EventArgs e)
          {
               Navigation.SelectedNodeChanged += new EventHandler(Navigation_SelectedNodeChanged);
               FormView1.ItemCommand += new FormViewCommandEventHandler(FormView1_ItemCommand);

               Master.FixedWidth = false;
               Master.Width = "100%";
               table = DynamicDataRouteHandler.GetRequestMetaTable(Context);

               if (!IsPostBack)
               {
                    DoDataBind();
               }
               
               FormView1.SetMetaTable(table);
               //GridDataSource.EntityTypeFilter = table.EntityType.Name;
               TreeDataSource.EntityTypeFilter = table.EntityType.Name;


               TreeDataSource.WhereParameters.Add(new Parameter("OrganizationId", DbType.Guid, SelectedOrganization.OrganizationId.ToString()));
               
               //TreeDataSource.WhereParameters.Add(new Parameter("Parent", DbType.Guid, SelectedOrganization.OrganizationId.ToString()));

               //Master.FormTitle = table.DisplayName;
               //Master.FixedWidth = false;

               IsPublic = true;

               //GridView1.RowCreated += new GridViewRowEventHandler(GridView1_RowCreated);
          }
//-------------------------------------------------------------------------------------------
          void FormView1_ItemCommand(object sender, FormViewCommandEventArgs e)
          {
               if (e.CommandName == "Edit")
               {
                    FormView1.ChangeMode(FormViewMode.Edit);
               }
          }
//-------------------------------------------------------------------------------------------
          void DoDataBind()
          {
               Navigation.Nodes.Clear();
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    var rootItems = from article in data.KnowledgeBase
                                    where article.ParentId.HasValue == false
                                    select article;

                    if (Request["ParentId"] != null)
                    {
                         Guid parentId = new Guid(Request["ParentId"]);
                         rootItems =  rootItems.Where(x => x.Id == parentId);

                         //rootItems = from x in rootItems
                         //            where x.ParentId == parentId
                         //            select x;
                    }

                    var rootItems2 = (from article in rootItems
                                 orderby article.Position, article.Title
                                 select article);

                    PopulateTree(data, null, rootItems2);

                    //List.DataSource = res.Take(1);
                    //List.DataBind();
                    //Navigation.ExpandAll();
                    
                    string selectedNodeId = Request["SelectedNode"];
                    if (selectedNodeId != null)
                    {
                         SelectNode(Navigation.Nodes, selectedNodeId);
                    }
                    else if (Navigation.Nodes.Count > 0)
                    {
                         Navigation.Nodes[0].Select();
                    }
               }
          }
//-------------------------------------------------------------------------------------------
          private void SelectNode(TreeNodeCollection nodes, string nodeId)
          {
               if (nodes.Count > 0)
               {
                    foreach (TreeNode node in nodes)
                    {
                         if (node.Value == nodeId)
                         {
                              node.Expanded = true;
                              node.Select();
                              return;
                         }
                         else
                         {
                              SelectNode(node.ChildNodes, nodeId);
                         }
                    }
               }
          }
//-------------------------------------------------------------------------------------------
          private void PopulateTree(WeavverEntityContainer data, TreeNode parentNode, IOrderedQueryable<Weavver.Data.KnowledgeBase> items)
          {
               foreach (var article in items.ToList())
               {
                    TreeNode node = new TreeNode(article.Title, article.Id.ToString());
                    if (parentNode == null)
                         Navigation.Nodes.Add(node);
                    else
                         parentNode.ChildNodes.Add(node);

                    //if (article.KnowledgeBase2Reference.HasValue)
                    //{
                         var childItems = from childArticles in data.KnowledgeBase
                                          where childArticles.ParentId == article.Id
                                          orderby childArticles.Position, childArticles.Title
                                          select childArticles;

                         PopulateTree(data, node, childItems);
                    //}
               }
          }
//-------------------------------------------------------------------------------------------
          void Navigation_SelectedNodeChanged(object sender, EventArgs e)
          {
               Master.FormTitle = Navigation.SelectedNode.Text;
          }
//-------------------------------------------------------------------------------------------
          protected void Page_Load(object sender, EventArgs e)
          {
               Title = table.DisplayName;
               //GridDataSource.Include = table.ForeignKeyColumnsNames;
               TreeDataSource.Include = table.ForeignKeyColumnsNames;

               // Selection from url
               //if (!Page.IsPostBack && table.HasPrimaryKey)
               {
                    //GridView1.SelectedPersistedDataKey = table.GetDataKeyFromRoute();
                    //if (GridView1.SelectedPersistedDataKey == null)
                    //{
                    //     GridView1.SelectedIndex = 0;
                    //}
               }

               // Disable various options if the table is readonly
               //if (table.IsReadOnly)
               {
                    //DetailsPanel.Visible = false;
                    //GridView1.AutoGenerateSelectButton = false;
                    //GridView1.AutoGenerateEditButton = false;
                    //GridView1.AutoGenerateDeleteButton = false;
                    //GridView1.EnablePersistedSelection = false;
               }
          }
//-------------------------------------------------------------------------------------------
          //protected void GridView1_DataBound(object sender, EventArgs e)
          //{
          //     //if (GridView1.Rows.Count == 0)
          //     //{
          //     //     FormView1.ChangeMode(FormViewMode.Insert);
          //     //}
          //}
//-------------------------------------------------------------------------------------------
          //protected void Label_PreRender(object sender, EventArgs e)
          //{
          //     Label label = (Label)sender;
          //     DynamicFilter dynamicFilter = (DynamicFilter)label.FindControl("DynamicFilter");
          //     QueryableFilterUserControl fuc = dynamicFilter.FilterTemplate as QueryableFilterUserControl;
          //     if (fuc != null && fuc.FilterControl != null)
          //     {
          //          label.AssociatedControlID = fuc.FilterControl.GetUniqueIDRelativeTo(label);
          //     }
          //}
//-------------------------------------------------------------------------------------------
          //protected void DynamicFilter_FilterChanged(object sender, EventArgs e)
          //{
          //     //GridView1.EditIndex = -1;
          //     //GridView1.PageIndex = 0;
          //     //FormView1.ChangeMode(FormViewMode.ReadOnly);
          //}
//-------------------------------------------------------------------------------------------
          protected void Edit_Click(object sender, EventArgs e)
          {
               FormView1.ChangeMode(FormViewMode.ReadOnly);
          }
//-------------------------------------------------------------------------------------------
          //protected void GridView1_SelectedIndexChanging(object sender, EventArgs e)
          //{
          //     //GridView1.EditIndex = -1;
          //     //FormView1.ChangeMode(FormViewMode.ReadOnly);
          //}
//-------------------------------------------------------------------------------------------
          //protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
          //{
          //     SetDeleteConfirmation(e.Row);

          //     GridViewRow row = e.Row;
          //     // Intitialize TableCell list
          //     List<TableCell> columns = new List<TableCell>();
          //     //foreach (DataControlField column in GridView1.Columns)
          //     //{
          //     //     TableCell cell = row.Cells[0];
          //     //     row.Cells.Remove(cell);
          //     //     columns.Add(cell);
          //     //     break;
          //     //}

          //     // Add cells
          //     //row.Cells.AddRange(columns.ToArray());
          //}
//-------------------------------------------------------------------------------------------
          //protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
          //{
          //     FormView1.DataBind();
          //}
//-------------------------------------------------------------------------------------------
          //protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
          //{
          //     FormView1.DataBind();
          //}
//-------------------------------------------------------------------------------------------
          protected void FormView1_ItemDeleted(object sender, FormViewDeletedEventArgs e)
          {
               DoDataBind();
          }
//-------------------------------------------------------------------------------------------
          protected void FormView1_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
          {
               DoDataBind();
          }
//-------------------------------------------------------------------------------------------
          protected void FormView1_ItemInserted(object sender, FormViewInsertedEventArgs e)
          {
               DoDataBind();
          }
//-------------------------------------------------------------------------------------------
          protected void FormView1_ModeChanging(object sender, FormViewModeEventArgs e)
          {
               if (e.NewMode != FormViewMode.ReadOnly)
               {
                    //GridView1.EditIndex = -1;
               }
          }
//-------------------------------------------------------------------------------------------
          protected void FormView1_PreRender(object sender, EventArgs e)
          {
               if (FormView1.Row != null)
               {
                    SetDeleteConfirmation(FormView1.Row);
               }
          }
//-------------------------------------------------------------------------------------------
          private void SetDeleteConfirmation(TableRow row)
          {
               foreach (Control c in row.Cells[0].Controls)
               {
                    LinkButton button = c as LinkButton;
                    if (button != null && button.CommandName == DataControlCommands.DeleteCommandName)
                    {
                         button.OnClientClick = "return confirm('Are you sure you want to delete this item?');";
                    }
               }
          }
//-------------------------------------------------------------------------------------------
     }
}
