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

using PDFjet.NET;

using Divan;
using Weavver.Company.Accounting;
using Weavver.Data;
using System.Text.RegularExpressions;

public partial class Company_Accounting_CheckPrint : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          //string id = (string) Request["id"];
          //if (id != null)
          //{
          //     Guid itemId = new Guid(id);
          //     Check item = DatabaseHelper.Session.Get<Check>(itemId);
          //     if (item != null)
          //     {
          //          item.DatabaseHelper = DatabaseHelper;
          //          string filepath = Generate(item);
          //          Response.ContentType = "application/octet-stream";
          //          Response.AddHeader("Content-Disposition", "attachment;filename=\"Check " + item.CheckNumber.ToString() + ".pdf\"");
          //          Response.WriteFile(filepath);
          //          Response.Flush();
          //          System.IO.File.Delete(filepath);
          //     }
          //}
     }
//-------------------------------------------------------------------------------------------
}
