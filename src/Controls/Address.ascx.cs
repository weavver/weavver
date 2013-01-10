using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Weavver.Data;
using Weavver.Sys;

public partial class Controls_Address : WeavverUserControl
{
     public Guid ParentId = Guid.Empty;
//-------------------------------------------------------------------------------------------
     [Bindable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("Appearance")]
     public bool Header
     {
          set
          {
               AddressHeader.Visible = value;
          }
     }
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
     }
//-------------------------------------------------------------------------------------------
     protected void Submit_Click(object sender, EventArgs e)
     {
     }
//-------------------------------------------------------------------------------------------
     public Logistics_Addresses AddressData
     {
          get
          {
               Logistics_Addresses item = new Logistics_Addresses();
               item.Id = Guid.NewGuid();
               item.OrganizationId = BasePage.SelectedOrganization.Id;
               item.Name = DisplayName.Text;
               item.Line1 = AddressLine1.Text;
               item.Line2 = AddressLine2.Text;
               item.City = City.Text;
               item.State = State.Text;
               item.ZipCode = ZipCode.Text;
               item.CreatedAt = DateTime.UtcNow;
               item.CreatedBy = BasePage.LoggedInUser.Id;
               item.UpdatedAt = DateTime.UtcNow;
               item.UpdatedBy = BasePage.LoggedInUser.Id;

               return item;
          }

          //Data_Links dl = new Data_Links();
          //dl.OrganizationId = BasePage.SelectedOrganization.Id;
          //dl.Object1 = object1;
          //dl.Object2 = item.Id;
          //dl.CreatedAt = DateTime.UtcNow;
          //dl.CreatedBy = BasePage.LoggedInUser.Id;
          //dl.UpdatedAt = DateTime.UtcNow;
          //dl.UpdatedBy = BasePage.LoggedInUser.Id;
          //dl.Commit();
     }
//-------------------------------------------------------------------------------------------
}