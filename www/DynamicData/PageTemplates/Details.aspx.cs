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

namespace DynamicData
{
     public partial class Details : SkeletonPage
     {
//-------------------------------------------------------------------------------------------
          protected MetaTable table;
          private string RedirectURL;
//-------------------------------------------------------------------------------------------
          protected void Page_PreInit(object sender, EventArgs e)
          {
               if (Request["IFrame"] == "true")
               {
                    MasterPageFile = "~/Blank.master";
               }
          }
//-------------------------------------------------------------------------------------------
          protected void Page_Init(object sender, EventArgs e)
          {
               IsPublic = true;
               
               if (Request["IFrame"] == "true")
               {
                    DynamicHyperLink control = this.FindControlR<DynamicHyperLink>("BackToTheList");
                    if (control != null)
                         control.Visible = false;

                    if (Request["id"] == null)
                    {
                         FormView1.ChangeMode(FormViewMode.Insert);

                         UpdatePanel1.FindControlR<LinkButton>("BeginEdit").Visible = false;
                         UpdatePanel1.FindControlR<LinkButton>("CancelEdit").Visible = false;
                         UpdatePanel1.FindControlR<LinkButton>("DeleteItem").Visible = false;
                    }
               }

               //if (!IsPostBack)
               {
                    //FormView1.ChangeMode(FormViewMode.Edit);
                    table = DynamicDataRouteHandler.GetRequestMetaTable(Context);
                    FormView1.SetMetaTable(table);
                    DetailsDataSource.EntityTypeFilter = table.EntityType.Name;

                    if (LoggedInUser != null &&
                        LoggedInUser.OrganizationId != new Guid(ConfigurationManager.AppSettings["default_organizationid"]))
                         DetailsDataSource.WhereParameters.Add(new Parameter("OrganizationId", DbType.Guid, SelectedOrganization.Id.ToString()));

                    //TODO: Add logic to let the model generate the title
                    // -- for example to show: "Account item" vs "Bank of America Account"
                    //Master.FormTitle = table.DisplayName + " entry";

                    GenerateMenu(TableActions.Details, table.Provider.EntityType);

                    string projectionPath = "~/DynamicData/Projections/" + table.EntityType.ToString().Replace("Weavver.Data.", "") + ".ascx";
                    if (File.Exists(Server.MapPath(projectionPath)))
                    {
                         Control projection = LoadControl(projectionPath);
                         Projections.Controls.Add(projection);
                    }
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
               //Master.FormTitle = title;
               //ItemTitle.Text = title;


               Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "titlescript", "<script type='text/javascript'>parent.document.title = '" + title + "';</script>");
               return "";
          }
//-------------------------------------------------------------------------------------------
          public void GenerateMenu(TableActions currentPage, Type type)
          {
               string[] roles = Roles.GetRolesForUser();
               if (roles.Length == 0)
                    roles = new string[] { "Guest" };
               var tablePermissions = table.Attributes.OfType<DataAccess>();
               foreach (var att in tablePermissions)
               {
                    if (att.HasAnyRole(roles))
                    {
                         switch (att.Actions)
                         {
                              case TableActions.List:
                              case TableActions.Showcase:
                              case TableActions.PressRoll:
                                   WeavverMenuItem mi = new WeavverMenuItem();
                                   mi.Name = att.Actions.ToString();
                                   mi.Link = "/" + table.EntityType.Name + "/" + att.Actions.ToString() + ".aspx";
                                   //WeavverMaster.ViewsMenuAdd(mi);
                                   break;

                              case TableActions.Edit:
                              case TableActions.Delete:
                                   if (currentPage == TableActions.Details ||
                                       currentPage == TableActions.Page)
                                   {
                                        WeavverMenuItem actionItem = new WeavverMenuItem();
                                        actionItem.Name = att.Actions.ToString();
                                        actionItem.Link = "/" + table.EntityType.Name + "/" + att.Actions.ToString() + ".aspx?Id=" + Request["Id"];
                                        ///WeavverMaster.ActionsMenuAdd(actionItem);
                                   }
                                   break;
                         }
                    }
               }


               MethodInfo[] methods = type.GetMethods();
               foreach (MethodInfo method in methods)
               {
                    bool isWebAccessible = false;
                    foreach (object attrib in method.GetCustomAttributes(true))
                    {
                         if (attrib.GetType() == typeof(DynamicDataWebMethod))
                         {
                              LinkButton webMethod = new LinkButton();
                              webMethod.ID = "DynamicMethod_" + method.Name;
                              webMethod.Text = ((DynamicDataWebMethod)attrib).MethodName;
                              webMethod.CommandName = method.Name;
                              webMethod.Click += new EventHandler(DynamicWebMethod_Click);
                              webMethod.CssClass = "attachmentLink";

                              //WebMethods.Controls.Add(webMethod);
                              AvailableActions.Controls.Add(webMethod);

                              break;
                         }

                         if (attrib.GetType() == typeof(CSSAttribute))
                         {
                              ShowError(((CSSAttribute)attrib)._CSS);
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
               FormView1.UpdateItem(true);
               //FormView1.ChangeMode(FormViewMode.ReadOnly);
               //FormView1.DataBind();
          }
//-------------------------------------------------------------------------------------------
          protected void Edit_Link(object sender, EventArgs e)
          {
               //Response.Redirect("http://www.yahoo.com");

               FormView1.ChangeMode(FormViewMode.Edit);
               FormView1.DataBind();

               UpdatePanel1.FindControlR<LinkButton>("BeginEdit").Visible = false;
               UpdatePanel1.FindControlR<LinkButton>("CancelEdit").Visible = true;
          }
//-------------------------------------------------------------------------------------------
          protected void Cancel_Link(object sender, EventArgs e)
          {
               FormView1.ChangeMode(FormViewMode.ReadOnly);
               FormView1.DataBind();

               UpdatePanel1.FindControlR<LinkButton>("BeginEdit").Visible = true;
               UpdatePanel1.FindControlR<LinkButton>("CancelEdit").Visible = false;
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
               if (e.Exception == null || e.ExceptionHandled)
               {
                    Response.Redirect(RedirectURL);
               }
          }
//-------------------------------------------------------------------------------------------
     }
}
