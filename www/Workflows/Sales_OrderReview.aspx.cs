using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Weavver.Data;

public partial class Company_Sales_Order : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Init(object sender, EventArgs e)
     {
          List.ItemDataBound += new DataGridItemEventHandler(List_ItemDataBound);
          List.ItemCommand += new DataGridCommandEventHandler(List_ItemCommand);

          WeavverMaster.FormTitle = "Your Shopping Cart";
          WeavverMaster.FixedWidth = true;
          ActivationRequired = false;
          RunCustomValidationJs = true;
          IsPublic = true;
     }
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          if (!IsPostBack)
          {
               UpdatePage();
          }
     }
//-------------------------------------------------------------------------------------------
     public void UpdatePage()
     {
          using (WeavverEntityContainer data = new WeavverEntityContainer())
          {

               List.DataKeyField = "Id";
               List.DataSource = ShoppingCart.Items;
               List.DataBind();

               decimal deposit = ShoppingCart.DepositTotal;
               decimal monthly = ShoppingCart.MonthlyTotal;
               decimal setup = ShoppingCart.SetUpTotal;

               SetUp.Visible = (setup > 0);
               SetUpTotal.Text = String.Format("{0,10:C}", setup);
               Monthly.Visible = (monthly > 0);
               CartMonthly.Text = String.Format("{0,10:C}", monthly);
               Deposits.Visible = (deposit > 0);
               DepositTotal.Text = String.Format("{0,10:C}", deposit);
               CartTotal.Text = String.Format("{0,10:C}", ShoppingCart.Total);

               if (ShoppingCart.Items.Count == 0)
               {
                    btnOrder.ImageUrl = "~/images/sales/checkout-disabled.png";
                    btnOrder.Enabled = false;
                    TotalUpdate.Visible = false;
               }
               else
               {
                    TotalUpdate.Visible = true;
                    btnOrder.ImageUrl = "~/images/sales/checkout.png";
                    btnOrder.Enabled = true;
               }

               var policy = (from x in data.CMS_Pages
                             where x.Title == "Sales/Store Policy" &&
                                   x.OrganizationId == SelectedOrganization.Id
                             select x).FirstOrDefault();

               if (policy != null)
               {
                    StorePolicy.Text = policy.Page;
               }
          }
     }
//-------------------------------------------------------------------------------------------
     public void UpdateTotals()
     {
          using (WeavverEntityContainer data = new WeavverEntityContainer())
          {
               foreach (DataGridItem dataitem in List.Items)
               {
                    Guid key = (Guid)List.DataKeys[dataitem.ItemIndex];
                    foreach (Sales_ShoppingCartItems item in ShoppingCart.Items.ToList())
                    {
                         if (item.Id == key)
                         {
                              int quantity = item.Quantity;
                              TextBox tbQuantity = (TextBox) dataitem.Cells[1].Controls[0];
                              Int32.TryParse(tbQuantity.Text, out quantity);
                              bool changed = false;
                              
                              if (quantity == 0)
                              {
                                   data.Sales_ShoppingCartItems.Attach(item);
                                   ShoppingCart.Items.Remove(item);
                                   data.Sales_ShoppingCartItems.Remove(item);
                                   continue;
                              }
                              else if (quantity != item.Quantity)
                              {
                                   data.Sales_ShoppingCartItems.Attach(item);
                                   item.Quantity = quantity;
                              }
                         }
                    }
               }
               data.SaveChanges();
          }
     }
//-------------------------------------------------------------------------------------------
     void List_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
     {
          if (e.Item.ItemType == System.Web.UI.WebControls.ListItemType.Item || e.Item.ItemType == System.Web.UI.WebControls.ListItemType.AlternatingItem)
          {
               Sales_ShoppingCartItems item = (Sales_ShoppingCartItems) e.Item.DataItem;

               LiteralControl ItemNameNotes = (LiteralControl) e.Item.Cells[2].Controls[0];
               ItemNameNotes.Text = "<a href=\"" + item.BackLink + "\">" + item.Name + "</a>";
               if (!String.IsNullOrEmpty(item.Notes))
                    ItemNameNotes.Text += "<div style='padding-left: 10px;'>" + item.Notes.Replace("\r\n", "<br />") + "</div>";

               TextBox Quantity = (TextBox) e.Item.Cells[1].Controls[0];
               Quantity.Text = item.Quantity.ToString();
               //Quantity.Text = "asdfasdf";

               if (e.Item.Cells[3].Text == "$0.00")
                    e.Item.Cells[3].Text = "";
               if (e.Item.Cells[4].Text == "$0.00")
                    e.Item.Cells[4].Text = "";
               if (e.Item.Cells[5].Text == "$0.00")
                    e.Item.Cells[5].Text = "";
          }
     }
//-------------------------------------------------------------------------------------------
     void List_ItemCommand(object source, DataGridCommandEventArgs e)
     {
          Guid key = (Guid) List.DataKeys[e.Item.ItemIndex];
          //ShoppingCart.Items.Remove(item);
          using (WeavverEntityContainer data = new WeavverEntityContainer())
          {
               var cartItem = (from item in data.Sales_ShoppingCartItems
                              where item.Id == key &&
                                   item.OrganizationId == SelectedOrganization.Id &&
                                   item.SessionId == Session.SessionID
                              select item).FirstOrDefault();

               if (cartItem != null)
               {
                    data.Sales_ShoppingCartItems.Remove(cartItem);
                    data.SaveChanges();
               }
          }
          UpdatePage();
     }
//-------------------------------------------------------------------------------------------
     protected void UpdateQuantity_Click(object sender, EventArgs e)
     {
          UpdateTotals();
          UpdatePage();
     }
//-------------------------------------------------------------------------------------------
     //protected void Privacy_Validate(object source, ServerValidateEventArgs args)
     //{
     //     args.IsValid = ChkPrivacy.Checked;
     //}
//-------------------------------------------------------------------------------------------
     protected void CodeAdd_Click(object sender, EventArgs e)
     {
          UpdateTotals();
          UpdatePage();
     }
//-------------------------------------------------------------------------------------------
     protected void Next_Click(object sender, EventArgs e)
     {
          if (LoggedInUser == null && ShoppingCart.RequiresOrganizationId)
          {
               string redirect = "~/account/register?checkingout=true&redirecturl=/" + SelectedOrganization.VanityURL + "/workflows/sales_orderplace.aspx";
               if (Request["IFrame"] == "true")
               {
                    redirect += "&IFrame=true";
               }
               Response.Redirect(redirect);
          }
          else
          {
               UpdateTotals();
               Response.Redirect("sales_orderplace");
          }
     }
//-------------------------------------------------------------------------------------------
}