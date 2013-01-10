using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Weavver.Data;

public partial class Company_Products_Snap_Forum_Thread : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          //Label pagename = (Label)FindControlRecursive(Master, "PageName");
          
          //IsPublic = true;
          //if (Request["id"] != null)
          //{
          //     Post item = DatabaseHelper.Session.Get<Post>(new Guid(Request["id"].ToString()));
          //     pagename.Text = item.Subject;
          //     Body.Text = Server.HtmlDecode(item.Body);
          //     PostedBy.Text = DatabaseHelper.GetName(item.Author);
          //     Created.Text = item.Created.ToLocalTime().ToString();


          //     ICriteria criteria = DatabaseHelper.Session.CreateCriteria(typeof(Post))
          //                    .Add(NHibernate.Criterion.Restrictions.Eq("OrganizationId", SelectedOrganization.Id))
          //                    .Add(NHibernate.Criterion.Restrictions.Eq("Id", item.ThreadId));

          //     var docs = criteria.List();

          //     //object[] endkey = {item.ThreadId + 1};
          //     //foreach (var doc in docs)
          //     //{
          //     //     if (doc.Id == item.Id)
          //     //     {
          //     //          // parentdoc = doc;
          //     //     }
          //     //}
          //     List.DataSource = docs;
          //     List.DataBind();
          //}

          //if (LoggedInUser.Id == Guid.Empty)
          //{
          //     ReplyBody.Enabled = false;
          //     ReplyBody.Text = "Please log in to reply.";
          //     ReplyBody.ForeColor = System.Drawing.Color.SaddleBrown;
          //     NotifyMe.Enabled = false;
          //     Reply.Enabled = false;
          //}
     }
//-------------------------------------------------------------------------------------------
     protected string FormatBody(string body)
     {
          return Server.HtmlDecode(body);
     }
//-------------------------------------------------------------------------------------------
     public void Reply_Click(object sender, EventArgs e)
     {
     }
//-------------------------------------------------------------------------------------------
}
