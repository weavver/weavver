using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Weavver.Data;

using MySql.Data;
using MySql.Data.MySqlClient;

public partial class Account_Default : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     string SelectedDepartment = null;
//-------------------------------------------------------------------------------------------
     protected void Page_Init(object sender, EventArgs e)
     {
          //VoicemailList.ItemDataBound += new DataGridItemEventHandler(List_ItemDataBound);

          Master.FormTitle = "Weavver Account :: Welcome Home!";
          Master.FormDescription = "This is your dashboard, it contains links to the services you have access to.";
          Master.FixedWidth = false;
          Master.Width = "100%";
          RequiresSelectedOrg = false;
     }
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          IsPublic = false;
     }
//-------------------------------------------------------------------------------------------
}
