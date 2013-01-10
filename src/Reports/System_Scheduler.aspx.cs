using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Company_Accounting_Bill : SkeletonPage
{
     private Guid id = Guid.Empty;
     //private Weavver.Company.Accounting.Bill item;
//-------------------------------------------------------------------------------------------
     protected void Page_Init(object sender, EventArgs e)
     {
          //Master.FormTitle = "Bill";
          //Master.FormDescription = "Enter bills from a contractor, vendors, friends, family, etc here.";
          //Master.FixedWidth = true;
          //List.ItemDataBound         += new DataGridItemEventHandler(List_ItemDataBound);
          //List.ItemCommand           += new DataGridCommandEventHandler(List_ItemCommand);
     }
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          //IsPublic = true;

          //if (Request["id"] == null)
          //{
          //     Delete.Visible = false;
          //}
          //else
          //{
          //     id = new Guid(Request["id"]);
          //     //item = Weavver.Company.Accounting.Bill.Get(id.ToString());
          //     Delete.Visible = true;
          //     if (!IsPostBack)
          //     {
          //          UpdatePage();
          //     }
          //}
     }
//-------------------------------------------------------------------------------------------
     protected void UpdatePage()
     {
          //Payee.Text = item.Payee;
          //Amount.Text = item.Amount.ToString();
          //Due.Text = item.Due.ToString();
     }
//-------------------------------------------------------------------------------------------
     protected void Bill_Client(object sender, EventArgs e)
     {
     }
//-------------------------------------------------------------------------------------------
     protected void Save_Click(object sender, EventArgs e)
     {
          //if (item == null)
          //{
          //     item = new Weavver.Company.Accounting.Bill(); //.Get(id);
          //     item.Id = Guid.NewGuid();
          //     item.OrganizationId = SelectedOrganization.Id;
          //}
          //item.Payee = Payee.Text;
          //item.Amount = Decimal.Parse(Amount.Text);
          //item.Due = DateTime.Parse(Due.Text);
          //item.Commit();

          //Response.Redirect("Bills.aspx");
     }
//-------------------------------------------------------------------------------------------
     protected void Delete_Click(object sender, EventArgs e)
     {
          //Weavver.Company.Accounting.Bill item = Weavver.Company.Accounting.Bill.Get(id.ToString());
          //item.Deleted = true;
          //item.Commit();

          //Response.Redirect("/Company/Accounting/Bills.aspx");
     }
//-------------------------------------------------------------------------------------------
}
