using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using Weavver.Data;
using Weavver.Sys;

public partial class Controls_PhoneNumber : WeavverUserControl
{
     public Guid ParentId = Guid.Empty;
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {

     }
//-------------------------------------------------------------------------------------------
     protected void Save_Click(object sender, EventArgs e)
     {
          if (ParentId != Guid.Empty)
          {
               //Save(ParentId);
          }
     }
//-------------------------------------------------------------------------------------------
     //public Logistics_PhoneNumber
     //{
     //     get
     //     {
     //     PhoneNumber item = new PhoneNumber();
     //     item.Id = Guid.NewGuid();
     //     item.OrganizationId = BasePage.SelectedOrganization.Id;
     //     item.PhoneType = PhoneNumberType.Text;
     //     item.Number = PhoneNumberNumber.Text;
     //     item.Notes = PhoneNumberNotes.Text;
     //     item.CreatedAt = DateTime.UtcNow;
     //     item.CreatedBy = BasePage.LoggedInUser.Id;
     //     item.UpdatedAt = DateTime.UtcNow;
     //     item.UpdatedBy = BasePage.LoggedInUser.Id;
     //     item.Commit();

     //     //DataLink dl = new DataLink();
     //     //dl.OrganizationId = BasePage.SelectedOrganization.Id;
     //     //dl.Object1 = object1;
     //     //dl.Object2 = item.Id;
     //     //dl.CreatedAt = DateTime.UtcNow;
     //     //dl.CreatedBy = BasePage.LoggedInUser.Id;
     //     //dl.UpdatedAt = DateTime.UtcNow;
     //     //dl.UpdatedBy = BasePage.LoggedInUser.Id;
     //     //dl.Commit();

     //     //OnDataSaved(this, EventArgs.Empty);
     //}
//-------------------------------------------------------------------------------------------
}
