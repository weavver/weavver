using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_Convert : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
     }
//-------------------------------------------------------------------------------------------
     protected void Change_Click(object sender, EventArgs e)
     {
          ////Divan.CouchJsonDocument doc = DatabaseHelper.Session.Get(OldId.Text);
          //Weavver.Company.HumanResources.Application app = DatabaseHelper.Session.Get<Weavver.Company.HumanResources.Application>(OldId.Text);
          //app.Id_asString = NewId.Text;
          //app.Commit();
          ////db.SaveDocument(doc);
          ////db.DeleteDocument(OldId.Text, doc.Rev);
     }
//-------------------------------------------------------------------------------------------
     protected void ChangeType_Click(object sender, EventArgs e)
     {
          //string oldType = "Weavver.Company.Employee";
          //string newType = "Weavver.Company.HumanResources.Employee";
          //int pos = (Session["pos"] == null) ? 0 : Int32.Parse(Session["pos"].ToString());
          //Session["pos"] = pos + 20;
          //pos = 0;
          ////var docs = db.Query("weavver.company.informationtechnology", "all_servers").Descending().IncludeDocuments().GetResult().Documents<Weavver.Company.InformationTechnology.NetworkAlert>();
          //var docs = db.Query("weavver.company.humanresources.employee", "all").Skip(pos).Limit(20).StartKey(oldType).EndKey(oldType + "Z").IncludeDocuments().GetResult().Documents<Weavver.Company.HumanResources.Employee>();
          //// http://192.168.10.111:5984/_utils/database.html?weavverdb/_design/weavver.system.types/_view/all
          //Response.Write("POS: " + pos.ToString() + "<br />");
          //foreach (var doc in docs)
          //{
          //     //if (doc.BaseObject["Cost"] != null)
          //     {
          //          Response.Write(doc.Id + "<br />");
          //          doc.Type = newType;
          //          //doc.Commit();
          //     }
          //}
     }
//-------------------------------------------------------------------------------------------
}