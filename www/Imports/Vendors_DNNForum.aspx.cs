using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Weavver.Data;

public partial class Company_Products_Snap_Forum_Import : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     string connString = null;
     SqlConnection connection = null;
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          //Company_Products_Snap_MasterPage mp = (Company_Products_Snap_MasterPage) Master;
          //Label pagename = (Label)FindControlRecursive(Master, "PageName");
          //pagename.Text = "Forum :: Import";
          ////WriteNames(Controls[0].Controls[0].Controls[3].Controls[15].Controls[1].Controls[1].Controls, "");
          //IsPublic = true;
          //List.ItemDataBound += new DataGridItemEventHandler(List_ItemDataBound);
          //Import.Click += new EventHandler(Import_Click);
          //Delete.Click += new EventHandler(Delete_Click);
          //Convert.Click += new EventHandler(Convert_Click);
     }
//-------------------------------------------------------------------------------------------
     private void WriteNames(ControlCollection controls, string ownerid)
     {
          for (int i = 0; i < controls.Count; i++)
          {
               Response.Write(ownerid + ": " + controls[i].ID  + " <br />");

               if (controls[i].HasControls())
                    WriteNames(controls[i].Controls, controls[i].ID);
          }
     }
//-------------------------------------------------------------------------------------------
     void List_ItemDataBound(object sender, DataGridItemEventArgs e)
     {
          if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
          {
               if (e.Item.Cells[6].Text.Length > 15)
                    e.Item.Cells[6].Text = e.Item.Cells[6].Text.Substring(0, 15) + "...";
          }
     }
//-------------------------------------------------------------------------------------------
     void Import_Click(object sender, EventArgs e)
     {
          connString = String.Format("server={0};user id={1};password={2};initial catalog={3};", Host.Text, Username.Text, Password.Text, DBName.Text);
          connection = new SqlConnection(connString);
          connection.Open();
          ImportForums();
          ImportPosts();
          connection.Close();
     }
//-------------------------------------------------------------------------------------------
     void Convert_Click(object sender, EventArgs e)
     {
          //ICriteria criteria = DatabaseHelper.Session.CreateCriteria(typeof(Post))
          //               .Add(NHibernate.Criterion.Restrictions.Eq("OrganizationId", SelectedOrganization.Id));

          //List<Post> posts = (List<Post>)criteria.SetMaxResults(30).SetFirstResult(page * 30).List<Post>();
          //int count = 0;
          //foreach (Weavver.Communication.Post item in posts)
          //{
          //     string forumguid = "";
          //     ICriteria criteria = DatabaseHelper.Session.CreateCriteria(typeof(Post))
          //               .Add(NHibernate.Criterion.Restrictions.Eq("OrganizationId", SelectedOrganization.Id))
          //     foreach (Weavver.Communication.Forum forum in forums)
          //     {
          //          forumguid = forum.Id.ToString();
          //     }
          //     item.ForumId = forumguid;
          //     count++;
          //     item.Commit();
          //}
          Status.Text = "Converted " + 0 + " items.";
     }
//-------------------------------------------------------------------------------------------
     void Delete_Click(object sender, EventArgs e)
     {
          // delete from forum_posts where orgid=@orgid;
          // delete from forum_forums where orgid=@orgid;
          int count = 0;
          Status.Text = "Deleted " + count + " items.";
     }
//-------------------------------------------------------------------------------------------
     private void ImportForums()
     {
          //string sql = "Select * from Forum_Forums";
          //SqlCommand command = new SqlCommand(sql, connection);
          //SqlDataReader reader = command.ExecuteReader();
          //List<Forum> forums = new List<Forum>();
          //while (reader.Read())
          //{
          //     Forum item = new Forum();
          //     item.Id = Guid.NewGuid();
          //     item.ForumId = reader.GetInt32(0);
          //     item.Name = reader.GetString(4);
          //     item.Description = reader.GetString(5);
          //     item.Commit();
          //     forums.Add(item);
          //}
          //ForumList.DataSource = forums;
          //ForumList.DataBind();
          //reader.Close();
     }
//-------------------------------------------------------------------------------------------
     private void ImportPosts()
     {
          //string sql = "Select alias = (select username from users u where u.UserID=p.UserID), * from Forum_Posts p, Forum_Forums f, Forum_Threads t Where t.ForumID=f.ForumID and p.ThreadID=t.ThreadID";
          //SqlCommand commandPosts = new SqlCommand(sql, connection);
          //SqlDataReader reader = commandPosts.ExecuteReader();
          //List<Weavver.Communication.Post> posts = new List<Weavver.Communication.Post>();
          //while (reader.Read())
          //{
          //     Weavver.Communication.Post post = new Weavver.Communication.Post();
          //     post.Alias = (reader.IsDBNull(0)) ? "unknown" : reader.GetString(0);
          //     post.Id = Guid.NewGuid();
          //     post.PostId = reader.GetInt32(1);
          //     post.ParentPostId = reader.GetInt32(2);
          //     post.UserId = reader.GetInt32(3);
          //     post.IPAddress = reader.GetString(4);
          //     post.Notify = reader.GetBoolean(5);
          //     post.Subject = reader.GetString(6);
          //     post.Body = reader.GetString(7);
          //     post.Created = reader.GetDateTime(8);
          //     post.ThreadId = reader.GetInt32(9);
          //     post.ForumId = reader.GetInt32(23).ToString();
          //     post.Commit();
          //     posts.Add(post);
          //}
          //List.DataSource = posts;
          //List.DataBind();
          //reader.Close();
     }
//-------------------------------------------------------------------------------------------
}
