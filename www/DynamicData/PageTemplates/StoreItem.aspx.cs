using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Expressions;
using System.Collections.Generic;
using System.Web.Security;

using System.Linq;
using System.Data.Linq;

using Weavver.Data;
using Weavver.Data.Interfaces;
using System.IO;
using System.Web.UI.HtmlControls;

namespace DynamicData
{
     public partial class StoreItem : SkeletonPage
     {
          Logistics_Products item;
          IList<Logistics_FeatureOptions> FeatureOptions;
          protected MetaTable table;
//-------------------------------------------------------------------------------------------
          protected void Page_Init(object sender, EventArgs e)
          {
               IsPublic = true;
               table = DynamicDataRouteHandler.GetRequestMetaTable(Context);
               FormView1.SetMetaTable(table);
          }
//-------------------------------------------------------------------------------------------
          protected void Page_Load(object sender, EventArgs e)
          {

               //HtmlControl wc = (HtmlControl)Master.FindControl("ContentDIV");
               //wc.Attributes.CssStyle["padding"] = "0px";
               //wc.Attributes.CssStyle["padding-left"] = "0px";
               //wc.Attributes.CssStyle["background-color"] = "transparent";
               //wc.Attributes.CssStyle["border"] = "none";

               if (Roles.IsUserInRole("Administrators"))
                    AdminLinks.Visible = true;

               string pathBase = Request.Url.PathAndQuery;
               pathBase = pathBase.Substring(0, pathBase.LastIndexOf("/"));
               string url = pathBase + "/Edit.aspx?Id=" + Request["Id"];

               DetailsDataSource.EntityTypeFilter = table.EntityType.Name;

               WeavverMaster.SetChatVisibility(true);
               WeavverMaster.FormTitle = "Entry from table " + table.DisplayName;
               WeavverMaster.FixedWidth = true;
               WeavverMaster.FormDescription = "";

               ActivationRequired = false;
               string id = Request["id"];
               if (id != null)
               {
                    Guid idGuid = new Guid(id);

                    using (WeavverEntityContainer data = new WeavverEntityContainer())
                    {
                         item = (from x in data.Logistics_Products
                                 where x.Id == idGuid
                                 select x).First();

                         if (item != null)
                         {
                              //Master.FormDescription = description;
                              url = item.Name + " Inquiry";
                              if (Request["IFrame"] == "true")
                                   url += "&IFrame=true";

                              using (WeavverEntityContainer data2 = new WeavverEntityContainer())
                              {
                                   var formDescription  = (from x in data2.CMS_Pages
                                                           where x.Title == "Sales/Header" &&
                                                         x.OrganizationId == SelectedOrganization.Id
                                                         select x).FirstOrDefault();

                                   if (formDescription != null)
                                   {
                                        WeavverMaster.FormDescription = formDescription.Page.Replace("{ITEM_NAME}", url);
                                   }
                              }

                              InitializeDesign();
                         }
                    }
               }
               //Title = table.DisplayName;
               DetailsDataSource.Include = table.ForeignKeyColumnsNames;

               if (!IsPostBack)
               {
                    if (item != null)
                    {
                         UpdatePage();
                    }
               }
               //Master.DiscussionEnabled = false;
          }
//-------------------------------------------------------------------------------------------
          private void InitializeDesign()
          {
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    string controlPath = "~/Products/" + item.Name + "/OrderForm.ascx";
                    
                    if (File.Exists(Server.MapPath(controlPath)))
                    {
                         Control customOrderForm = LoadControl(controlPath);
                         customOrderForm.ID = "CustomOrderForm";
                         OrderFormCell.Controls.AddAt(0, customOrderForm);

                         //Control OrderForm = UpdatePanel1.ContentTemplateContainer.FindControl("OrderForm");
                         //OrderForm.Visible = false;
                         //return;
                    }

                    var features = from x in data.Logistics_Features
                                   where x.OrganizationId == SelectedOrganization.Id &&
                                         x.ParentId == item.Id
                                   orderby x.Name
                                   select x;
    
                    int idPos = 0;
                    
                    foreach (Logistics_Features feature in features)
                    {
                         Literal row = new Literal();
                         row.Text = feature.Name + "<br />";
                         DropDownList ddl = new DropDownList();
                         ddl.ID = "feature-" + idPos.ToString();
                         idPos++;
                         ddl.AutoPostBack = true;
                         ddl.Style["width"] = "100%";
                         ddl.SelectedIndexChanged += new EventHandler(ddl_SelectedIndexChanged);
                         var FeatureOptions = from x in data.Logistics_FeatureOptions
                                                 where x.OrganizationId == SelectedOrganization.Id &&
                                                 x.ParentId == feature.Id
                                                 orderby x.Cost
                                                 select x;

                         foreach (Logistics_FeatureOptions option in FeatureOptions)
                         {
                              ListItem optionItem = new ListItem(option.Name + " - (" + Math.Round(option.Cost, 2).ToString("C") + ")", option.Id.ToString());
                              ddl.Items.Add(optionItem);
                         }

                         if (ddl.Items.Count > 0)
                         {
                              OrderFormControls.Controls.Add(row);
                              OrderFormControls.Controls.Add(ddl);
                              OrderFormControls.Controls.Add(HTMLBreak());
                              OrderFormControls.Controls.Add(HTMLBreak());
                         }
                    }

                    Literal bNotes = new Literal();
                    bNotes.ID = "Notes";
                    bNotes.Text = HTMLPurifierLib.Sanitize(item.BillingNotes);
                    if (!String.IsNullOrEmpty(item.BillingNotes))
                    {
                         BillingNotes.Style.Add("padding-top", "10px");
                    }
                    BillingNotes.Controls.Add(bNotes);

                    Literal SetUp = new Literal();
                    SetUp.ID = "SetUp";
                    Totals.Controls.Add(SetUp);

                    Literal Deposit = new Literal();
                    Deposit.ID = "Deposit";
                    Totals.Controls.Add(Deposit);

                    Literal Price = new Literal();
                    Price.ID = "Price";
                    Totals.Controls.Add(Price);

                    Literal Monthly = new Literal();
                    Monthly.ID = "Monthly";
                    Totals.Controls.Add(Monthly);

                    Literal Total = new Literal();
                    Total.ID = "Total";
                    Totals.Controls.Add(Total);
               }
          }
//-------------------------------------------------------------------------------------------
          private Control HTMLBreak()
          {
               Literal lit = new Literal();
               lit.Text = "<br />";
               return lit;
          }
//-------------------------------------------------------------------------------------------
          private string FormatRow(string id, string name, string val)
          {
               return "<table width='100%' style='width:100%;text-align:left;' cellpadding='0' cellspacing='0' border=0><tr><td>" + name + ":</td><td id='" + id + "' style='text-align:right;'>" + val + "&nbsp;</td></tr></table>";
          }
//-------------------------------------------------------------------------------------------
          public void UpdatePage()
          {
               ////Master.FormTitle = item.Name;
               ////Description.Text = item.Description;

               Literal SetUp = (Literal)UpdatePanel1.ContentTemplateContainer.FindControl("Totals").FindControl("SetUp");
               Literal Monthly = (Literal)UpdatePanel1.ContentTemplateContainer.FindControl("Totals").FindControl("Monthly");
               Literal Deposit = (Literal)UpdatePanel1.ContentTemplateContainer.FindControl("Totals").FindControl("Deposit");
               Literal Price = (Literal)UpdatePanel1.ContentTemplateContainer.FindControl("Totals").FindControl("Price");
               Literal CheckOutTotal = (Literal)UpdatePanel1.ContentTemplateContainer.FindControl("Totals").FindControl("Total");

               decimal total = 0;
               if (item.SetUp > 0)
               {
                    total += item.SetUp;
                    SetUp.Text = FormatRow("SetUp", "Set-Up", Math.Round(item.SetUp, 2).ToString("C"));
               }

               if (item.Deposit > 0)
               {
                    total += item.Deposit;
                    Deposit.Text = FormatRow("Deposit", "Deposit", Math.Round(item.Deposit, 2).ToString("C"));
               }

               if (item.UnitRetailPrice > 0)
               {
                    total += item.UnitRetailPrice;
                    Price.Text = FormatRow("Price", "Price", Math.Round(item.UnitRetailPrice, 2).ToString("C"));
               }

               decimal monthly = CalculateMonthlyTotal();
               if (CalculateMonthlyTotal() > 0)
               {
                    total += monthly;
                    Monthly.Text = FormatRow("Monthly", "Monthly", Math.Round(monthly, 2).ToString("C"));
               }

               decimal checkOutTotal = CalculateOneTimeCosts() + CalculateMonthlyTotal() + item.SetUp;
               CheckOutTotal.Text = FormatRow("Due", "Due at checkout", Math.Round(checkOutTotal * Int32.Parse(Quantity.Text), 2).ToString("C"));
          }
//-------------------------------------------------------------------------------------------
          public decimal CalculateMonthlyTotal()
          {
               decimal cost = 0;
               foreach (Control ctrl in UpdatePanel1.ContentTemplateContainer.FindControl("OrderFormControls").Controls)
               {
                    if (ctrl.GetType() == typeof(DropDownList))
                    {
                         DropDownList ddl = (DropDownList)ctrl;
                         //DropDownList ddl = (DropDownList) UpdatePanel1.ContentTemplateContainer.FindControl("OrderForm").FindControl("feature-" + i.ToString());
                         if (ddl != null)
                         {
                              Guid featureOptionId;
                              Guid.TryParse(ddl.SelectedValue, out featureOptionId);
                              using (WeavverEntityContainer data = new WeavverEntityContainer())
                              {
                                   Logistics_FeatureOptions option = (from x in data.Logistics_FeatureOptions
                                                                     where x.Id == featureOptionId
                                                                     select x).First();
                                   if (option != null && option.BillingType == FeatureBillingType.Monthly.ToString())
                                   {
                                        cost += option.Cost;
                                   }
                              }
                         }
                    }
               }
               return cost + item.UnitMonthly;
          }
//-------------------------------------------------------------------------------------------
          public decimal CalculateOneTimeCosts()
          {
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    decimal total = 0;
                    for (int i = 0; i < 5; i++)
                    {
                         DropDownList ddl = (DropDownList)UpdatePanel1.ContentTemplateContainer.FindControl("OrderFormControls").FindControl("feature-" + i.ToString());
                         if (ddl != null)
                         {
                              Guid featureOptionId;
                              Weavver.Utilities.Common.GuidTryParse(ddl.SelectedValue, out featureOptionId);
                              Logistics_FeatureOptions option = (from x in data.Logistics_FeatureOptions
                                                                 where x.Id == featureOptionId
                                                                 select x).First();
                              if (option != null && option.BillingType == FeatureBillingType.OneTime.ToString())
                              {
                                   total += option.Cost;
                              }
                         }
                    }
                    return total + item.UnitRetailPrice;
               }
          }
//-------------------------------------------------------------------------------------------
          void ddl_SelectedIndexChanged(object sender, EventArgs e)
          {
               UpdatePage();
          }
//-------------------------------------------------------------------------------------------
          protected void FormView1_ItemDeleted(object sender, FormViewDeletedEventArgs e)
          {
               //if (e.Exception == null || e.ExceptionHandled)
               //{
               //     Response.Redirect(table.ListActionPath);
               //}
          }
//-------------------------------------------------------------------------------------------
          protected void QuantityUp_Clicked(object sender, EventArgs e)
          {
               int newVal = Int32.Parse(Quantity.Text) + 1;
               Quantity.Text = newVal.ToString();
               UpdatePage();
          }
//-------------------------------------------------------------------------------------------
          protected void QuantityDown_Clicked(object sender, EventArgs e)
          {
               int newVal = Int32.Parse(Quantity.Text) - 1;
               newVal = (newVal < 1) ? 1 : newVal;
               Quantity.Text = newVal.ToString();
               UpdatePage();
          }
//-------------------------------------------------------------------------------------------
          protected void Quantity_TextChanged(object sender, EventArgs e)
          {
               if (Page.IsValid)
               {
                    UpdatePage();
               }
          }
//-------------------------------------------------------------------------------------------
          protected void Next_Click(object sender, EventArgs e)
          {
               string notes = item.BillingNotes;
               if (!String.IsNullOrEmpty(notes))
               {
                    notes += "\r\n";
               }
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    var features = from x in data.Logistics_Features
                                   where x.OrganizationId == SelectedOrganization.Id &&
                                   x.ParentId == item.Id
                                   orderby x.Name
                                   select x;

                    int idPos = 0;
                    Sales_ShoppingCartItems shoppingCartItem = Sales_ShoppingCartItems.GetInstance(Server.MapPath("~/bin"), item.PluginURL);
                    int i = 0;
                    foreach (Logistics_Features feature in features)
                    {
                         DropDownList ddl = (DropDownList)UpdatePanel1.ContentTemplateContainer.FindControl("OrderFormControls").FindControl("feature-" + i.ToString());
                         Guid featureOptionId = new Guid(ddl.SelectedValue);

                         Logistics_FeatureOptions option = (from x in data.Logistics_FeatureOptions
                                                            where x.Id == featureOptionId
                                                            select x).First();
                         notes += "- " + data.GetName(option.ParentId) + ": " + option.Name;
                         if (i < features.Count() - 1)
                         {
                              notes += "\r\n";
                         }
                         i++;
                    }

                    shoppingCartItem.SessionId = Session.SessionID;
                    shoppingCartItem.OrganizationId = SelectedOrganization.Id;
                    shoppingCartItem.ProductId = item.Id;
                    if (LoggedInUser != null)
                    {
                         shoppingCartItem.UserId = LoggedInUser.Id;
                    }
                    shoppingCartItem.Name = item.Name;
                    shoppingCartItem.Notes = notes;
                    shoppingCartItem.Deposit = item.Deposit;
                    shoppingCartItem.SetUp = item.SetUp; // TODO: add set-up summing for sub features - add provisioning time tracking to sub-features
                    shoppingCartItem.UnitCost = CalculateOneTimeCosts();
                    shoppingCartItem.Monthly = CalculateMonthlyTotal();
                    shoppingCartItem.Quantity = Int32.Parse(Quantity.Text);
                    shoppingCartItem.RequiresOrganizationId = true;
                    shoppingCartItem.BackLink = Request.Url.ToString();

                    var customForm = (ISales_OrderForm) OrderFormCell.FindControlR<Control>("CustomOrderForm"); 
                    if (customForm != null)
                    {
                         customForm.BeforeAddingToCart(shoppingCartItem);
                    }
                    data.Sales_ShoppingCartItems.Add(shoppingCartItem);
                    data.SaveChanges();

                    string reviewurl = "~/workflows/sales_orderreview.aspx";
                    if (Request["IFrame"] == "true")
                         reviewurl += "?IFrame=true";
                    Response.Redirect(WeavverMaster.FormatURLs(reviewurl));
               }
          }
//-------------------------------------------------------------------------------------------
     }
}
