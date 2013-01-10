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

public partial class Company_Wall : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          Master.FormTitle = "Wall";
          Master.FixedWidth = true;

          if (!IsPostBack)
          {
               UpdatePage();
          }
     }
//-------------------------------------------------------------------------------------------
     private void UpdatePage()
     {
          //ICriteria criteria = DatabaseHelper.Session.CreateCriteria(typeof(Message))
          //                    .Add(NHibernate.Criterion.Restrictions.Eq("OrganizationId", SelectedOrganization.Id))
          //                    .AddOrder(NHibernate.Criterion.Order.Desc("CreatedAt"))
          //                    .SetMaxResults(30);

          //List.DataKeyField = "Id";
          //List.DataSource = criteria.List<Message>();
          //List.DataBind();
     }
//-------------------------------------------------------------------------------------------
     protected void Share_Click(object sender, EventArgs e)
     {
          //Message item = new Message();
          //item.OrganizationId = SelectedOrganization.Id;
          //item.Account = SelectedOrganization.Id;
          //item.Body = Body.Text;
          //item.CreatedAt = DateTime.UtcNow;
          //item.CreatedBy = LoggedInUser.Id;
          //item.UpdatedAt = DateTime.UtcNow;
          //item.UpdatedBy = LoggedInUser.Id;
          //item.Commit();

          //Body.Text = "";

          //UpdatePage();
     }
//-------------------------------------------------------------------------------------------
}
