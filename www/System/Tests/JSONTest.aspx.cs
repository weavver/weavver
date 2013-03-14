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
using System.IO;
using Newtonsoft.Json;

public partial class System_Tests_JSONTest : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          IsPublic = true;
     }
//-------------------------------------------------------------------------------------------
     protected void Test_Click(object sender, EventArgs e)
     {
          try
          {
               string jsontest = JSONText.Text;
               StringReader stringReader = new StringReader(jsontest);
               JsonTextReader jsonReader = new JsonTextReader(stringReader);
               if (jsonReader.Read())
               {
                    TestResult.Text = "True";
                    TestResult.ForeColor = System.Drawing.Color.Green;
               }
               else
               {
                    TestResult.Text = "False";
                    TestResult.ForeColor = System.Drawing.Color.Red;
               }
          }
          catch (Exception ex)
          {
               TestResult.Text = "<span style='color: red;'>False:</span> " + ex.Message;
          }
     }
//-------------------------------------------------------------------------------------------
}
