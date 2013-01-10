using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Weavver.Sys;

public partial class System_DeleteObject : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          Master.FormTitle = "Delete the following objects?";

          //if (!IsPostBack)
          {
               UpdatePage();
          }
     }
//-------------------------------------------------------------------------------------------
     public void UpdatePage()
     {
          //Guid id = new Guid(Request["id"]);
          //Master.AddAttachmentLink(DatabaseHelper.GetName(id), "?id=" + Request["id"].ToString(), DatabaseHelper.GetClassType(id));
          //AddCB(id, DatabaseHelper.GetName(id), "");
          //IList<DataLink> Links = DatabaseHelper.FindLinks(id);
          //string str = "";
          //foreach (DataLink link in Links)
          //{
          //     Guid objId = (link.Object1 == id) ? link.Object2 : link.Object1;
          //     string objType = (link.Object1 == id) ? link.Object2Type : link.Object1Type;
          //     CheckBox cbDeletableObject = new CheckBox();
          //     cbDeletableObject.Text = DatabaseHelper.GetName(objId);
          //     cbDeletableObject.Checked = true;
          //     //str += (link.Object1Type + ": " + link.Object1.ToString() + "-" + link.Object2.ToString());

          //     AddCB(objId, objType, "----->");
          //}
     }
//-------------------------------------------------------------------------------------------
     private void AddCB(Guid id, string typename, string indentation)
     {
          //Literal htmlIndentation = new Literal();
          //htmlIndentation.Text = indentation;
          //Objects.Controls.Add(htmlIndentation);

          //CheckBox cbDeletableObject = new CheckBox();
          //cbDeletableObject.Text = typename;
          //cbDeletableObject.Checked = true;
          //cbDeletableObject.Attributes["datakey"] = id.ToString();

          //Objects.Controls.Add(cbDeletableObject);
          //Literal htmlBR = new Literal();
          //htmlBR.Text = " <span style='color: grey'>" + id.ToString() + "</span><br />";
          //Objects.Controls.Add(htmlBR);
     }
//-------------------------------------------------------------------------------------------
     protected void Delete_Click(object sender, EventArgs e)
     {
          //SqlTransaction transaction = wvvrdb.MSSQLDB.BeginTransaction("Deleting object tree");
          //try
          //{
          //     DeleteCheckedItems(transaction, Objects);
          //     transaction.Commit();
          //}
          //catch (Exception ex)
          //{
          //     transaction.Rollback();
          //     ShowError("The object could not be deleted.");
          //     return;
          //}
          //string url = (Request["returnurl"] == null) ? "~/" : Request["returnurl"].ToString();
          //Response.Redirect(url);
     }
//-------------------------------------------------------------------------------------------
     public void DeleteCheckedItems(SqlTransaction transaction, Control parent)
     {
          //foreach (Control control in parent.Controls)
          //{
          //     if (control.GetType() == typeof(CheckBox))
          //     {
          //          CheckBox item = (CheckBox)control;
          //          if (item.Checked)
          //          {
          //               Guid itemId = new Guid(item.Attributes["datakey"]);
          //               DataRowLookup reverseLookup = DatabaseHelper.Session.Get<DataRowLookup>(itemId);
          //               if (reverseLookup != null)
          //               {
          //                    SqlCommand command = new SqlCommand("delete from " + reverseLookup.TableName + " where id=@Id", wvvrdb.MSSQLDB);
          //                    command.Parameters.AddWithValue("Id", reverseLookup.RowId);
          //                    command.Transaction = transaction;
          //                    command.ExecuteNonQuery();
          //               }

          //               string sql = "delete from system_datalinks where (object1=@object1 and object2=@object2) ";
          //               sql += "or (object1=@object2 and object2=@object1)";
          //               SqlCommand dataLinks = new SqlCommand(sql, wvvrdb.MSSQLDB);
          //               dataLinks.Parameters.AddWithValue("Object1", itemId);
          //               dataLinks.Parameters.AddWithValue("Object2", new Guid(Request["id"]));
          //               dataLinks.Transaction = transaction;
          //               dataLinks.ExecuteNonQuery();
          //          }
          //     }
          //     if (control.HasControls())
          //     {
          //          DeleteCheckedItems(transaction, control);
          //     }
          //}
     }
//-------------------------------------------------------------------------------------------
}