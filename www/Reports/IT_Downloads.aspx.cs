using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Company_Logistics_Downloads : SkeletonPage
{
     protected void Page_Load(object sender, EventArgs e)
     {
          IsPublic = false;

          if (LoggedInUser.OrganizationId == new Guid("0baae579-dbd8-488d-9e51-dd4dd6079e95"))
          {
               //Weavver.Data.WeavverDatabase db = new Weavver.Data.WeavverDatabase();
               //string connString = ConfigurationManager.AppSettings["snap_connectionstring"].ToString();
               //db.InitAsMSSQL(connString);

               //SqlCommand command = new SqlCommand("select distinct filename as 'Product', (select count(*) from downloads where filename=d.filename) as 'Download Count' from downloads d order by filename", db.MSSQLDB);
               //List.DataSource = command.ExecuteReader();
               //List.DataBind();
          }
     }
}
