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
              (BasePage == null) || BasePage.SelectedOrganization == null)
          {
               //BasePage.WeavverMaster.SetToolbarVisibility(false);
               Visible = false;
               return;
          }

          menuDepartments.Name = "Departments";
          menuDepartments.Link = "#";

          //Guid adminGuid = BasePage.LoggedInUser.OrganizationId;

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

          if (Roles.IsUserInRole("Accountants"))
          {
               //AddMenuItem(accountingReports, "Financial Overview", "/Reports/Accounting_FinancialOverview");
               //AddMenuItem(accountingReports, "Expenses", "/reports/accounting_expenses");

               //WeavverMenuItem humanresourcesReports = AddMenuItem(menuReports, "Human Resources", null);
               //AddMenuItem(humanresourcesReports, "Labor Overview", "/Reports/HR_LaborOverview");

               // AddLinkToTable(menuTools, "Accounting", "Enter Payment", "/workflows/accounting_enterpayment");
          }

          if (Global.DefaultModel == null || Global.DefaultModel.Tables.Count <= 0)
               return;

          string[] roles = Roles.GetRolesForUser();
          if (roles.Length == 0)
               roles = new string[] { "Guest" };

          var tables = Global.DefaultModel.Tables.OrderBy(x => x.Name).ToList().Where(x => x.Scaffold == true);
          foreach (MetaTable table in tables)
          {
               var tableViews = table.Attributes.OfType<DataAccess>()
                    .Where(x => x.TableViews == TableView.List &&
                                x.HasAnyRole(roles));

               var tableCSS = table.Attributes.OfType<CSSAttribute>();

                // if no permission exist then do not add to navigation
               if (tableViews.Count() == 0)
                    continue;

               foreach (var view in tableViews)
               {
                    string tableNameFQN = table.Name;
                    string dept = (tableNameFQN.IndexOf("_") > 1) ? tableNameFQN.Substring(0, tableNameFQN.IndexOf("_")) : tableNameFQN;
                    string tableName = table.DisplayName; // tableNameFQN.Substring(tableNameFQN.IndexOf("_") + 1);

                    WeavverMenuItem wmi;
                    if (view.TableViews.ToString().Contains("Showcase"))
                    {
                         wmi = AddLinkToTable(menuDepartments, dept, tableName, "~/" + tableNameFQN + "/Showcase.aspx");
                    }
                    else if (view.TableViews.ToString().Contains("List"))
                    {
                         wmi = AddLinkToTable(menuDepartments,
                                                       dept,
                                                       tableName, "~/" + tableNameFQN + "/List.aspx",
                                                       Width: view.Width,
                                                       Height: view.Height);


                         var insertPermissions = table.Attributes.OfType<DataAccess>()
                              .Where(x => x.Actions == RowAction.Insert
                                          && x.HasAnyRole(roles));
                         if (insertPermissions.Count() > 0)
                         {
                              //string newname = (tableName.EndsWith("s")) ? tableName.Substring(0, tableName.Length - 1) : tableName;
                              //AddLinkToTable(menuNew, dept, newname, "~/" + tableNameFQN + "/" + tp.Actions.ToString() + ".aspx");
                                   
                         }


                         wmi.Title = "Accessible by: " + String.Join(", ", view.AllowedRoles);
                    }


               }
          }

          if (Roles.IsUserInRole("Administrators"))
          {
               AddLinkToTable(menuDepartments, "System", "Roles", "/System/Roles", 650, 500);
               AddLinkToTable(menuDepartments, "System", "Settings", "/Logistics_Organizations/Details.aspx?id=" + BasePage.LoggedInUser.OrganizationId.ToString(), 500, 500, false);
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
          if (menuMy.Items.Count > 0)
               MenuItems.Text += RenderMenuLink(menuMy);
          foreach (WeavverMenuItem menu in menuDepartments.Items)
          {
               MenuItems.Text += RenderMenuLink(menu);
          }
          if (menuActions.Items.Count > 0)
               MenuItems.Text += RenderMenuLink(menuActions);
          if (menuViews.Items.Count > 0)
               MenuItems.Text += RenderMenuLink(menuViews);
          if (menuTools.Items.Count > 0)
               MenuItems.Text += RenderMenuLink(menuTools);
          if (menuReports.Items.Count > 0)
               MenuItems.Text += RenderMenuLink(menuReports);
          MenuItems.Text += "";
     }
//-------------------------------------------------------------------------------------------
     private string RenderMenuLink(WeavverMenuItem menuItem)
     {
          string output = "<a class='menuLink' href='#'>" + menuItem.Name;
          output += "</a>&nbsp;";
          if (menuItem.Items.Count > 0)
          {
               output += "<ul class='menu'>";
               foreach (WeavverMenuItem subItem in menuItem.Items)
               {
                    output += RenderMenu(subItem);
               }
               output += "</ul>";
          }
          return output;
     }
//-------------------------------------------------------------------------------------------
     private string RenderMenu(WeavverMenuItem menuItem)
     {
          string output = "";
          output += "<li class='menuOption'>";
          if (menuItem.CanAdd)
          {
               output += "<div style='float:right;margin-right: 5px;'><a href='#' style=''>Add</a>"; //<img src='/images/new.png' />
               output += "</div>";
          }
          output += String.Format("<a href=\"javascript:{0}\" title='{1}'>", menuItem.Link, menuItem.Title) + menuItem.Name + "</a><div style='clear: both;'></div>";
          if (menuItem.Items.Count > 0)
          {
               output += "<ul class='menu'>";
               foreach (WeavverMenuItem subItem in menuItem.Items)
               {
                    output += RenderMenu(subItem);
               }
               output += "</ul>";
          }
          output += "</li>";
          return output;
     }
//-------------------------------------------------------------------------------------------
     public WeavverMenuItem AddLinkToTable(WeavverMenuItem rootMenu, string DepartmentMenu, string ItemName, string ItemLink, int Width = 940, int Height = 500, bool canadd = false)
     {
          string formattedName = "";
          // add space at new Upper case letter
          for (int i = 0; i < DepartmentMenu.Length; i++)
          {
               if (DepartmentMenu[i].ToString() == DepartmentMenu[i].ToString().ToUpper()
                    && DepartmentMenu.Length > i + 1 && // ignore acronyms
                    DepartmentMenu[i + 1].ToString() != DepartmentMenu[i + 1].ToString().ToUpper()
                    && i != 0)
                    formattedName += " ";
               formattedName += DepartmentMenu[i];
          }
          DepartmentMenu = formattedName;

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
               newDept.Title = "test";
               parentMenu = newDept;
               rootMenu.Items.Add(newDept);
          }

          ItemLink = BasePage.WeavverMaster.FormatURLs(ItemLink);

          WeavverMenuItem item = new WeavverMenuItem();
          item.Name = ItemName;
          item.Link = "createPopup('" + BasePage.WeavverMaster.FormatURLs(ItemLink) + "', '" + Width + "', '" + Height + "')";
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