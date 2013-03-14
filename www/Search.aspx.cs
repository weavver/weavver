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

public partial class Search : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          if (!Roles.IsUserInRole("Administrators"))
               Response.Redirect("/", true);

          if (!IsPostBack)
          {
               SearchBox.Text = Request["q"];
               Submit_Click(null, EventArgs.Empty);
          }

          Master.FormTitle = "Search";
          string focus = "<script language='javascript'>document.getElementById('" + SearchBox.ClientID + "').focus();</script>";
          Page.RegisterStartupScript("focus", focus);
     }
//-------------------------------------------------------------------------------------------
     protected void Submit_Click(object sender, EventArgs e)
     {
          if (SearchBox.Text == "")
          {
               return;
          }

          using (WeavverEntityContainer data = new WeavverEntityContainer())
          {
               var results = data.SearchAllTables(SearchBox.Text);

               var foundTypes = (results.GroupBy(l => l.TableName)
                                       .Select(g => new
                                       {
                                            Type = CleanUp(g.Key),
                                            Count = g.Distinct().Count()
                                       })).OrderByDescending(g => g.Count);

               FoundTypes.DataSource = foundTypes;
               FoundTypes.DataBind();

               var results2 = data.SearchAllTables(SearchBox.Text);
               var searchResults = (results2
                                   .Select(g => new {TableName = CleanUp(g.TableName),
                                        ColumnName = CleanUp(g.ColumnName),
                                        ColumnValue = Trim(g.ColumnValue) }));


               List.DataSource = searchResults;
               List.DataBind();
          }
     }

     private string CleanUp(string column)
     {
          return column.Replace("[dbo].", "").Replace("[", "").Replace("]", "");
     }

     protected string Trim(object x)
     {
          string y = x.ToString();
          if (y.Length > 60)
               y = y.Substring(0, 60);
          return y;
     }
//-------------------------------------------------------------------------------------------
}