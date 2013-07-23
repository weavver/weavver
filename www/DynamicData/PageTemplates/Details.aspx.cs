using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Expressions;
using System.IO;

using Weavver.Data;

using System.Data.Objects.DataClasses;
using System.Data;
using System.Linq;
using System.Configuration;
using Weavver.Web;
using System.Reflection;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

namespace DynamicData
{
     public partial class Details : SkeletonPage
     {
//-------------------------------------------------------------------------------------------
          protected MetaTable table;
          private string RedirectURL;
//-------------------------------------------------------------------------------------------
          protected void Page_Init(object sender, EventArgs e)
          {
               DetailsDataSource.Inserted += new EventHandler<EntityDataSourceChangedEventArgs>(DetailsDataSource_Inserted);

               WeavverMaster.FixedWidth = true;
               WeavverMaster.Width = "100%";
               ScriptManager.RegisterStartupScript(UpdatePanel1, typeof(string), "RunScripts", "run();", true);

               FormView1.ModeChanged += new EventHandler(FormView1_ModeChanged);
               FormView1.DataBound += new EventHandler(FormView1_DataBound);

               table = DynamicDataRouteHandler.GetRequestMetaTable(Context);
               FormView1.SetMetaTable(table);

               IsPublic = true;

               if (Request["IFrame"] == "true")
               {
                    DynamicHyperLink control = this.FindControlR<DynamicHyperLink>("BackToTheList");
                    if (control != null)
                         control.Visible = false;

                    if (SelectedOrganization != null &&
                         LoggedInUser != null &&
                         SelectedOrganization.OrganizationId == LoggedInUser.OrganizationId)
                    {
                         EditOptions.Visible = true;
                    }
                    else
                    {
                         EditOptions.Visible = false;
                    }

                    if (Request["id"] == null)
                    {
                         SetTitle(null);
                         FormView1.ChangeMode(FormViewMode.Insert);
                         BeginEdit.Visible = false;
                         DeleteItem.Visible = false;
                    }
                    else
                    {
                         FormView1.ChangeMode(FormViewMode.ReadOnly);
                    }
               }
               DetailsDataSource.EntityTypeFilter = table.EntityType.Name;

               if (LoggedInUser != null &&
                    LoggedInUser.OrganizationId != new Guid(ConfigurationManager.AppSettings["default_organizationid"]))
                    DetailsDataSource.WhereParameters.Add(new Parameter("OrganizationId", DbType.Guid, SelectedOrganization.Id.ToString()));

               //TODO: Add logic to let the model generate the title
               // -- for example to show: "Account item" vs "Bank of America Account"
               //Master.FormTitle = table.DisplayName + " entry";

               if (FormView1.CurrentMode != FormViewMode.Insert)
               {
                    GenerateMenu(RowAction.Insert, table.Provider.EntityType);
                    AttachmentsList.Visible = true;

                    string projectionPath = "~/DynamicData/Projections/" + table.EntityType.ToString().Replace("Weavver.Data.", "") + ".ascx";
                    if (File.Exists(Server.MapPath(projectionPath)))
                    {
                         Control projection = LoadControl(projectionPath);
                         Projections.Controls.Add(projection);
                    }
               }
          }
//-------------------------------------------------------------------------------------------
          void DetailsDataSource_Inserted(object sender, EntityDataSourceChangedEventArgs e)
          {
               if (!String.IsNullOrEmpty(Request["ParentId"]))
               {
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "refreshParent", "<script type='text/javascript'>parent.refreshParent('" + Request["ParentId"] + "');</script>", false);
               }

               IAuditable auditData = e.Entity as IAuditable;
               string url = "Details.aspx?Id={0}&WindowId={1}&ParentId={2}&IFrame={3}";
               url = String.Format(url, auditData.Id, Request["WindowId"], Request["ParentId"], Request["IFrame"]);

               ScriptManager.RegisterStartupScript(Page, this.GetType(), "refreshParent2", "<script type='text/javascript'>document.location.href = '" + url + "';</script>", false);
               
               //Response.Redirect(url);
          }
//-------------------------------------------------------------------------------------------
          void FormView1_DataBound(object sender, EventArgs e)
          {
               ICustomTypeDescriptor descriptor = FormView1.DataItem as ICustomTypeDescriptor;
               if (descriptor != null)
               {
                    EntityObject owner = (EntityObject)descriptor.GetPropertyOwner(null);
                //    object x = owner.
               }
          }
//-------------------------------------------------------------------------------------------
          void FormView1_ModeChanged(object sender, EventArgs e)
          {
               if (FormView1.CurrentMode == FormViewMode.Insert)
               {
                    SaveEdit.Visible = true;
                    BeginEdit.Visible = false;
                    DeleteItem.Visible = false;
                    DetailsDataSource.EnableInsert = true;
               }

               if (FormView1.CurrentMode == FormViewMode.ReadOnly)
               {
                    BeginEdit.Visible = true;
                    CancelEdit.Visible = false;
               }

               if (FormView1.CurrentMode == FormViewMode.Edit)
               {
                    SaveEdit.Visible = true;
                    CancelEdit.Visible = true;
               }
          }
//-------------------------------------------------------------------------------------------
          protected void Page_Load(object sender, EventArgs e)
          {
               ///DetailsDataSource.Include = table.ForeignKeyColumnsNames;
          }
//-------------------------------------------------------------------------------------------
          protected string SetTitle(object dataItem)
          {
               string title = "";
               try
               {
                    title = DataBinder.Eval(dataItem, "Title").ToString();
               }
               catch { title = table.DisplayName + " entry"; }

               //ItemTitle.Text = title;
               WeavverMaster.FormTitle = title;
               //ItemTitle.Text = title;

               Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "titlescript", "<script type='text/javascript'>parent.document.title = '" + title + "';</script>");
               return "";
          }
//-------------------------------------------------------------------------------------------
          public void GenerateMenu(RowAction currentPage, Type type)
          {
               MethodInfo[] methods = type.GetMethods();
               foreach (MethodInfo method in methods)
               {
                    foreach (object attrib in method.GetCustomAttributes(typeof(DynamicDataWebMethod), true))
                    {
                         DynamicDataWebMethod ddMethod = (DynamicDataWebMethod)attrib;
                         foreach (string role in ddMethod.Roles)
                         {
                              if (User.IsInRole(role))
                              {
                                   LinkButton webMethod = new LinkButton();
                                   webMethod.ID = "DynamicWebMethod_" + method.Name;
                                   webMethod.Text = ((DynamicDataWebMethod)attrib).MethodName;
                                   webMethod.CommandName = method.Name;
                                   webMethod.Click += new EventHandler(DynamicWebMethod_Click);
                                   webMethod.CssClass = "attachmentLink";
                                   webMethod.ToolTip = "Accessible to: " + String.Join(", ", ddMethod.Roles);

                                   AvailableActions.Controls.Add(webMethod);

                                   if (ddMethod.RequiresPostback)
                                   {
                                        PostBackTrigger trig1 = new PostBackTrigger();
                                        trig1.ControlID = "DynamicWebMethod_" + method.Name;
                                        UpdatePanel1.Triggers.Add(trig1);
                                   }
                                   break;
                              }
                         }

                         //if (attrib.GetType() == typeof(CSSAttribute))
                         //{
                         //     ShowError(((CSSAttribute)attrib)._CSS);
                         //}
                    }
               }

               
               ICustomTypeDescriptor descriptor = FormView1.DataItem as ICustomTypeDescriptor;
               if (descriptor != null)
               {
                    EntityObject owner = (EntityObject)descriptor.GetPropertyOwner(null);
                    if (typeof(INavigationActions).IsAssignableFrom(owner.GetType()))
                    {
                         var NavActions = owner as INavigationActions;
                         List<WeavverMenuItem> items = (List<WeavverMenuItem>)NavActions.GetItemMenu();
                         if (items != null)
                         {
                              foreach (WeavverMenuItem item in items)
                              {
                                   if (item.Link.StartsWith("control://"))
                                   {
                                        string controlPath = item.Link.Substring(10);
                                        if (File.Exists(Server.MapPath(controlPath)))
                                        {
                                             WeavverUserControl customControl = (WeavverUserControl)LoadControl(controlPath);
                                             //quickAdd.DataSaved += new DataSavedHandler(QuickAdd_DataSaved);
                                             AvailableActions.Controls.Add(customControl);
                                        }
                                   }
                                   else
                                   {
                                        LinkButton webMethod = new LinkButton();
                                        webMethod.ID = "DynamicMethod_" + item.Name;
                                        webMethod.Text = item.Name;
                                        webMethod.CommandName = item.Name;
                                        webMethod.CssClass = "attachmentLink";
                                        AvailableActions.Controls.Add(webMethod);
                                   }
                              }
                         }
                    }
               }
          }
//-------------------------------------------------------------------------------------------
          public void AddAttachmentLink(string linkname, string href, string typeName)
          {
               HtmlAnchor link = new HtmlAnchor();
               link.InnerText = linkname;
               link.HRef = "javascript:createPopup('" + href + "');";
               link.Title = typeName;
               link.Attributes["class"] = "attachmentLink";
               this.FindControlR<Control>("Attachments").Controls.Add(link);

               //Literal litHR = new Literal();
               //litHR.Text = "&nbsp;&nbsp;";
               //Attachments.Controls.Add(litHR);
          }
//-------------------------------------------------------------------------------------------
          protected void FormView1_ItemCommand(object sender, FormViewCommandEventArgs e)
          {
               if (e.CommandName == DataControlCommands.UpdateCommandName)
               {
               }
               if (e.CommandName == DataControlCommands.CancelCommandName)
               {
               }
          }
//-------------------------------------------------------------------------------------------
          protected void Save_Link(object sender, EventArgs e)
          {
               try
               {
                    FormView1.UpdateItem(true);
                    ReadOnlyMode();
                    if (!String.IsNullOrEmpty(Request["ParentId"]))
                    {
                         ScriptManager.RegisterStartupScript(Page, this.GetType(), "refreshParent", "<script type='text/javascript'>parent.refreshParent('" + Request["ParentId"] + "');</script>", false);
                    }
               }
               catch (Exception ex)
               {
                    ShowError(ex.Message);
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "validationerror", "<script type='text/javascript'>alert('" + ex.Message + "');</script>", false);
               }
          }
//-------------------------------------------------------------------------------------------
          protected void Edit_Link(object sender, EventArgs e)
          {
               //Response.Redirect("http://www.yahoo.com");

               FormView1.ChangeMode(FormViewMode.Edit);
               FormView1.DataBind();

               BeginEdit.Visible = false;
               SaveEdit.Visible = true;
               UpdatePanel1.FindControlR<LinkButton>("BeginEdit").Visible = false;
               UpdatePanel1.FindControlR<LinkButton>("CancelEdit").Visible = true;
               DeleteItem.Visible = false;
          }
//-------------------------------------------------------------------------------------------
          protected void Delete_Link(object sender, EventArgs e)
          {
               FormView1.DeleteItem();
          }
//-------------------------------------------------------------------------------------------
          protected void Cancel_Link(object sender, EventArgs e)
          {
               ReadOnlyMode();
          }
//-------------------------------------------------------------------------------------------
          private void ReadOnlyMode()
          {
               FormView1.ChangeMode(FormViewMode.ReadOnly);
               FormView1.DataBind();

               BeginEdit.Visible = true;
               SaveEdit.Visible = false;
               UpdatePanel1.FindControlR<LinkButton>("BeginEdit").Visible = true;
               UpdatePanel1.FindControlR<LinkButton>("CancelEdit").Visible = false;
               DeleteItem.Visible = true;
          }
//-------------------------------------------------------------------------------------------
          protected void FormView1_ItemDeleting(object sender, FormViewDeleteEventArgs e)
          {
               FormView1.DataBind();
               ICustomTypeDescriptor descriptor = FormView1.DataItem as ICustomTypeDescriptor;
               if (descriptor != null)
               {
                    EntityObject owner = (EntityObject) descriptor.GetPropertyOwner(null);
                    var NavActions = owner as INavigationActions;
                    if (NavActions == null)
                         RedirectURL = table.ListActionPath;
                    else
                         RedirectURL = NavActions.CancelURL;
               }
          }
//-------------------------------------------------------------------------------------------
          protected void FormView1_ItemDeleted(object sender, FormViewDeletedEventArgs e)
          {
               if (Page.MasterPageFile.Contains("Blank.master"))
               {
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "closeIFrame", "<script type='text/javascript'>parent.closeIFrame('" + Request["WindowId"] + "', '" + Request["ParentId"] + "');</script>", false);
               }
               else
               {
                    if (e.Exception == null || e.ExceptionHandled)
                    {
                         Response.Redirect(RedirectURL);
                    }
               }
          }
//-------------------------------------------------------------------------------------------
     }
}
