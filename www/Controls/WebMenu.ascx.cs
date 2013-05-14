using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Weavver.Web;
using Weavver.Sys;
using System.Web.DynamicData;
using Weavver.Data;

public partial class WeavverWebMenu : WeavverUserControl
{
//-------------------------------------------------------------------------------------------
     public WeavverMenuItem menuReports = new WeavverMenuItem();
     public WeavverMenuItem menuApplications = new WeavverMenuItem();
     public WeavverMenuItem menuTools = new WeavverMenuItem();
     public WeavverMenuItem menuDepartments = new WeavverMenuItem();

     public WeavverMenuItem menuMy = new WeavverMenuItem();
     public WeavverMenuItem menuNew = new WeavverMenuItem();
     public WeavverMenuItem menuActions = new WeavverMenuItem();
     public WeavverMenuItem menuViews = new WeavverMenuItem();
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          if (Request.Url.PathAndQuery.StartsWith("/system/error") ||
              (BasePage == null))
          {
               //BasePage.WeavverMaster.SetToolbarVisibility(false);
               Visible = false;
               return;
          }

          //Guid adminGuid = BasePage.LoggedInUser.OrganizationId;
          menuDepartments.Name = "Departments";
          menuDepartments.Link = "#";

          menuReports.Name = "Reports";
          menuReports.Link = "#";

          menuTools.Name = "Tools";
          menuTools.Link = "#";

          menuMy.Name = "My";
          menuMy.Link = "#";

          menuNew.Name = "New";
          menuNew.Link = "#";

          menuActions.Name = "Actions";
          menuActions.Link = "#";

          menuViews.Name = "Views";
          menuViews.Link = "#";

          if (HttpContext.Current.User.Identity.IsAuthenticated)
          {
               AddMenuItem(menuMy, "Receivables", String.Format("/Accounting_LedgerItems/List.aspx?AccountId={0}&LedgerType={1}", BasePage.LoggedInUser.OrganizationId.ToString(), LedgerType.Receivable.ToString()));
               AddMenuItem(menuMy, "Payables", String.Format("/Accounting_LedgerItems/List.aspx?AccountId={0}&LedgerType={1}", BasePage.LoggedInUser.OrganizationId.ToString(), LedgerType.Payable.ToString()));
               AddMenuItem(menuMy, "Tasks", String.Format("/HR_Tasks/List.aspx?AssignedTo={0}", BasePage.LoggedInUser.Id.ToString(), (int)LedgerType.Payable));
          }

          if (Roles.IsUserInRole("Accountants"))
          {
               WeavverMenuItem accountingReports = AddMenuItem(menuReports, "Accounting", "#");

               AddMenuItem(accountingReports, "Financial Overview", "/Reports/Accounting_FinancialOverview");
               //AddMenuItem(accountingReports, "Expenses", "/reports/accounting_expenses");
               AddMenuItem(accountingReports, "Account Balances", "~/Accounting_AccountBalances/List.aspx");

               //WeavverMenuItem humanresourcesReports = AddMenuItem(menuReports, "Human Resources", null);
               //AddMenuItem(humanresourcesReports, "Labor Overview", "/Reports/HR_LaborOverview");

               AddLinkToTable(menuTools, "Accounting", "Enter Payment", "/workflows/accounting_enterpayment");
               AddLinkToTable(menuTools, "Accounting", "Import Data", "/Imports/Accounting_LedgerItems");
          }

          if (Global.DefaultModel == null || Global.DefaultModel.Tables.Count <= 0)
               return;

          var tables = Global.DefaultModel.Tables.OrderBy(x => x.Name).ToList();
          foreach (MetaTable table in tables)
          {
               var tableViews = table.Attributes.OfType<DataAccess>();
               var tableCSS = table.Attributes.OfType<CSSAttribute>();

                // if no permission exist then do not add to navigation
               if (tableViews.Count() == 0)
                    continue;

               foreach (var view in tableViews)
                {
                    string[] roles = Roles.GetRolesForUser();
                    if (roles.Length == 0)
                         roles = new string[] { "Guest" };

                    if (view.HasAnyRole(roles))
                    {
                         string tableNameFQN = table.Name;
                         string dept = (tableNameFQN.IndexOf("_") > 1) ? tableNameFQN.Substring(0, tableNameFQN.IndexOf("_")) : tableNameFQN;
                         string tableName = table.DisplayName; // tableNameFQN.Substring(tableNameFQN.IndexOf("_") + 1);

                         if (view.Views.ToString().Contains("Showcase"))
                         {
                              AddLinkToTable(menuDepartments, dept, tableName, "~/" + tableNameFQN + "/Showcase.aspx");
                         }
                         else
                         {
                              if (view.Views.ToString().Contains("List"))
                              {
                                   WeavverMenuItem wmi = AddLinkToTable(menuDepartments, dept, tableName, "~/" + tableNameFQN + "/List.aspx");
                                   if (view.Actions.ToString().Contains("Insert"))
                                   {
                                        //string newname = (tableName.EndsWith("s")) ? tableName.Substring(0, tableName.Length - 1) : tableName;
                                        //AddLinkToTable(menuNew, dept, newname, "~/" + tableNameFQN + "/" + tp.Actions.ToString() + ".aspx");
                                   
                                   }
                              }
                         }
                    }
               }
          }

          if (Roles.IsUserInRole("Administrators"))
          {
               AddLinkToTable(menuDepartments, "System", "Roles", "/System/Roles", 500, 700);
               AddLinkToTable(menuDepartments, "System", "Settings", "/System_Settings/Edit.aspx?id=" + BasePage.LoggedInUser.OrganizationId.ToString(), 500, 500, false);
          }
     }
//-------------------------------------------------------------------------------------------
     public WeavverMenuItem AddMenuItem(WeavverMenuItem topMenu, string name, string link)
     {
          WeavverMenuItem item = new WeavverMenuItem();
          item.Name = name;
          item.Link = link;
          item.parent = topMenu;
          topMenu.Items.Add(item);
          return item;
     }
//-------------------------------------------------------------------------------------------
     protected void Page_PreRender(object sender, EventArgs e)
     {
          MenuItems.Text = "";
          //if (menuDepartments.Items.Count > 0)
               MenuItems.Text += RenderMenu(menuDepartments);
          if (menuNew.Items.Count > 0)
               MenuItems.Text += RenderMenu(menuNew);
          if (menuMy.Items.Count > 0)
               MenuItems.Text += RenderMenu(menuMy);
          if (menuActions.Items.Count > 0)
               MenuItems.Text += RenderMenu(menuActions);
          if (menuViews.Items.Count > 0)
               MenuItems.Text += RenderMenu(menuViews);
          if (menuTools.Items.Count > 0)
               MenuItems.Text += RenderMenu(menuTools);
          if (menuReports.Items.Count > 0)
               MenuItems.Text += RenderMenu(menuReports);
          MenuItems.Text += "";
     }
//-------------------------------------------------------------------------------------------
     private string RenderMenu(WeavverMenuItem menuItem)
     {
          string output = "";
          if (menuItem.Items.Count == 0)
          {
               //string url = String.Format("createPopup('" + menuItem.Link + "','{0}','{1}');", menuItem.Width.ToString(), menuItem.Height.ToString());
               // output += "<div class='menuOption' onclick=\"window.location='" + menuItem.Link + "'\">";
               output += "<div class='menuOption' onclick=\"" + menuItem.Link + "\">";

               if (menuItem.CanAdd)
               {
                    output += "<div class='addMenu' style='float:right;margin-right: 5px;'><a href='#' style=''>Add</a>"; //<img src='/images/new.png' />
                    output += "</div>";
               }

               output += menuItem.Name + "</div>";
          }
          else
          {
               output += "<div class='menuRoot'>";
               output += menuItem.Name;
               output += "</div>";
               output += "<div class='menuChildren'>";
               foreach (WeavverMenuItem subItem in menuItem.Items)
               {
                    output += RenderMenu(subItem);
               }
               output += "</div>";
          }
          return output;
     }
//-------------------------------------------------------------------------------------------
     public WeavverMenuItem AddLinkToTable(WeavverMenuItem rootMenu, string DepartmentMenu, string ItemName, string ItemLink, int width = 500, int height = 500, bool canadd = false)
     {
          WeavverMenuItem parentMenu = null;
          foreach (WeavverMenuItem deptChild in rootMenu.Items)
          {
               if (deptChild.Name == DepartmentMenu)
               {
                    parentMenu = deptChild;
                    break;
               }
          }
          if (parentMenu == null)
          {
               WeavverMenuItem newDept = new WeavverMenuItem();
               newDept.Name = DepartmentMenu;
               newDept.Link = "#";
               newDept.parent = rootMenu;
               parentMenu = newDept;
               rootMenu.Items.Add(newDept);
          }

          WeavverMenuItem item = new WeavverMenuItem();
          item.Name = ItemName;
          item.Link = "createPopup('" + ItemLink + "', '" + width + "', '" + height + "')";
          item.parent = parentMenu;
          parentMenu.Items.Add(item);
          return item;
     }
//-------------------------------------------------------------------------------------------
     public void AddLink(string department, string pluralname, string singlename, string href, string hrefnew, Guid adminGuid)
     {
          if (BasePage != null && BasePage.LoggedInUser != null)
          {
               if (BasePage.LoggedInUser.OrganizationId == adminGuid || // if this is a weavver staff logged into the weavver org
                  adminGuid == Guid.Empty)
               {
                    AddLink(department, pluralname, singlename, href, hrefnew, Guid.Empty);
               }
          }
     }
//-------------------------------------------------------------------------------------------
}