using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;

using Weavver.Data;
using Weavver.Sys;
using System.Web.DynamicData;

public partial class System_Link : SkeletonPage
{
     Guid linkToId;
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          Master.FormTitle = "Attach";
          Master.FormDescription = "Attach two objects together to create meta-objects.";

          //if (Request["linkto"] != null)
          //{
          //     linkToId = new Guid(Request["linkto"]);
          //     LinkTo.Text = linkToId.ToString();
          //     LinkToType.Text = DatabaseHelper.GetClassType(linkToId);
          //     LinkToTable.Text = DatabaseHelper.GetTableName(linkToId);

          //     Link2DataObjects.Visible = false;
          //}
          //else
          //{
          //     Link2DataObjects.Visible = true;
          //}

          //if (!IsPostBack)
          //{
          //     System.Collections.IList visibleTables = Global.DefaultModel.VisibleTables;
          //     DataTypes.DataSource = visibleTables;
          //     DataTypes.DataBind();
          //     if (Request["id"] != null)
          //     {
          //          string documentid = Request["id"];
          //          //Camera doc = DatabaseHelper.Session.Get<Weavver.Company.Security.Camera>(documentid);
          //          //ObjectA.Text = "\"" + doc.Location + "\" of type " + doc.Type;
          //     }
          //}
     }
//-------------------------------------------------------------------------------------------
     protected void GetInfo_Click(object sender, EventArgs e)
     {
          //Guid objectB = new Guid(ObjectB.Text);
          //if (objectB != linkToId)
          //{
          //     ObjectBId.Text = objectB.ToString();
          //     ObjectBClassType.Text = DatabaseHelper.GetClassType(objectB);
          //     ObjectBTableName.Text = DatabaseHelper.GetTableName(objectB);
          //}
          //else
          //{
          //     ErrorMsg.Text = "The IDs are the same.. You shouldn't link an object to itself!";
          //}
     }
//-------------------------------------------------------------------------------------------
     protected void Link_Click(object sender, EventArgs e)
     {
          //var objIdA = new Guid(Request["linkto"]);
          //var objIdB = new Guid(ObjectB.Text);
          //string objectTypeA = DatabaseHelper.GetClassType(objIdA);
          //string objectTypeB = DatabaseHelper.GetClassType(objIdB);
          //var item = new DataLink();
          //item.DatabaseHelper = DatabaseHelper;
          //item.OrganizationId = SelectedOrganization.Id;
          //item.Object1 = objIdA;
          //item.Object1Type = objectTypeA;
          //item.Object2 = objIdB;
          //item.Object2Type = objectTypeB;
          //item.CreatedAt = DateTime.UtcNow;
          //item.CreatedBy = LoggedInUser.Id;
          //item.UpdatedAt = DateTime.UtcNow;
          //item.UpdatedBy = LoggedInUser.Id;
          //item.Commit();

          //ShowError("Objects linked together.");
     }
//-------------------------------------------------------------------------------------------
     protected void DataTypes_SelectedIndexChanged(object sender, EventArgs e)
     {
          //Weavver.Sys.Reflection reflection = new Weavver.Sys.Reflection();
          //Panel x = reflection.GenerateForm(DataTypes.Text);
          //DynamicForm.Controls.Add(x);

          LinkExisting.Visible = false;
     }
//-------------------------------------------------------------------------------------------
}