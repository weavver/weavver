using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using Weavver.Data;

// Weavver.. "Improving the way the world works."

public partial class Controls_Comments : WeavverUserControl
{
//-------------------------------------------------------------------------------------------
     protected void Page_Init(object sender, EventArgs e)
     {
          //if (BasePage == null ||
          //    BasePage.LoggedInUser == null ||
          //    BasePage.LoggedInUser.Id == Guid.Empty ||
          //    BasePage.LoggedInUser.OrganizationId != new Guid("0baae579-dbd8-488d-9e51-dd4dd6079e95") ||
          //    Request["id"] == null)
          //{
          //     Visible = false;
          //}
          //else
          //{
          //     Visible = true;
          //}
     }
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          //if (!IsPostBack && Visible)
          //{
          //     UpdatePage();
          //}
     }
//-------------------------------------------------------------------------------------------
}