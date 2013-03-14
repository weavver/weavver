using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Weavver.Data;

public partial class Company_Products_Snap_Forum_Default : SkeletonPage
{
     protected void Page_Load(object sender, EventArgs e)
     {
          Label pagename = (Label)FindControlRecursive(Master, "PageName");
          pagename.Text = "Forums";

          IsPublic = true;
          //ICriteria criteria = DatabaseHelper.Session.CreateCriteria(typeof(Forum))
          //                         .Add(NHibernate.Criterion.Restrictions.Eq("OrganizationId", SelectedOrganization.Id));
          //List.DataSource = criteria.List();
          //List.DataBind();

          //var postcounts = db.Query("Weavver.Communication.forums", "postcount_byforum").Group().GetResult().Documents();
          //foreach (var postcount in postcounts)
          //{
          //     Response.Write("RESULT: " + postcount.Obj["value"]);
          //}
          // _view/all

          //Label pagename = (Label) Master.FindControl("Content").FindControl("PageName");
          //pagename.Text = "Forums";
     }
}
