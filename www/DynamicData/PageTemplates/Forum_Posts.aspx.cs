using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Weavver.Data;

public partial class Company_Products_Snap_Forum_Forum : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Init(object sender, EventArgs e)
     {
          Label pagename = (Label)FindControlRecursive(Master, "PageName");
          pagename.Text = "Forum";

          IsPublic = true;
          // List.ItemDataBound += new DataListItemEventHandler(List_ItemDataBound);
          List.ItemDataBound += new DataGridItemEventHandler(List_ItemDataBound);

          if (Request["id"] != null)
          {
               //Weavver.Communication.Forum item = Weavver.Communication.Forum.Get(Request["id"]);
               //if (item != null)
               //{
               //     Description.Text = item.Description;
               //     pagename.Text = item.Name;
               //}
          }
     }
//-------------------------------------------------------------------------------------------
     void List_ItemDataBound(object sender, DataGridItemEventArgs e)
     {
          if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
          {
               //Weavver.Communication.Post post = (Weavver.Communication.Post)e.Item.DataItem;
               //e.Item.Attributes.Add("onmouseover", "mouseOver(this);");
               //e.Item.Attributes.Add("onmouseout", "mouseOut(this);");
               //e.Item.Style.Add("cursor", "pointer");
               //e.Item.Attributes.Add("onclick", "location.href = 'Thread.aspx?id=" + post.Id + "';");
               //e.Item.Cells[1].Style.Add("overflow", "hidden");

               //// <%# DataBinder.Eval(Container.DataItem, "Created") %>

               ////TextBox created = (TextBox) e.Item.FindControl("Created");
               ////created.Text = "asdfa";
          }
     }
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          string forumid = Request["id"];

          //object[] startkey = {forumid};
          //object[] endkey = {forumid + "Z"};
          //ICriteria criteria = DatabaseHelper.Session.CreateCriteria(typeof(Post))
          //               .Add(NHibernate.Criterion.Restrictions.Eq("OrganizationId", SelectedOrganization.Id))
          //               .Add(NHibernate.Criterion.Restrictions.IsNull("ThreadId"));
          //List.DataSource = criteria.List<Post>();
          //List.DataBind();
     }
//-------------------------------------------------------------------------------------------
     void List_ItemDataBound(object sender, DataListItemEventArgs e)
     {
          if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
          {
               // Weavver.Communication.Post post = (Weavver.Communication.Post) e.Item.DataItem;
          }
     }
//-------------------------------------------------------------------------------------------
     protected string TrimPost(string body)
     {
          body = System.Text.RegularExpressions.Regex.Replace(Server.HtmlDecode(body), @"<(.|\n)*?>", string.Empty);
          body = Server.HtmlEncode(body.Replace("&nbsp;", ""));
          if (body.Length > 100)
               return body.Substring(0, 100) + "...";
          else
               return body;
     }
//-------------------------------------------------------------------------------------------
     protected int GetReplyCount()
     {
          //ICriteria criteria = DatabaseHelper.Session.CreateCriteria(typeof(Weavver.Communication.Post))
          //               .Add(NHibernate.Criterion.Restrictions.Eq("OrganizationId", SelectedOrganization.Id))
          //               .Add(NHibernate.Criterion.Restrictions.Eq("ThreadId", post.ThreadId))
          //               .SetProjection(NHibernate.Criterion.Projections.RowCount());

          //return (int) criteria.UniqueResult();
          return 0;
     }
//-------------------------------------------------------------------------------------------
}
