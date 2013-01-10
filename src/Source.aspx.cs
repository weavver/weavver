using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Source : SkeletonPage
{
     protected void Page_Load(object sender, EventArgs e)
     {
          Master.FormTitle = "Source";
          Master.FixedWidth = false;
          Master.FormDescription = "For more information please visit our <a href=\"~/source/source\">open source</a> page.<br />";
          IsPublic = true;
          string file = Request["File"];
          if (file == null || file == "")
               return;
          while (file.Contains(".."))
               file = file.Replace("..", ".");
          file = file.Replace(":", "");

          if (file.ToLower().Contains("web.config") ||
              file.ToLower().Contains("settings.settings") ||
              file.ToLower().Contains("app.config"))
          {
               SourceCode.Text = "MYOB 'n bugger off! :)";
               return;
          }

          if (file.ToLower().StartsWith("/company/products"))
          {
               SourceCode.Text = "// The source code to this page is private.";
               return;
          }
          PageSource.Text = file;

          if (File.Exists(file))
          {
               StreamReader reader = System.IO.File.OpenText(Server.MapPath(file));
               string text = reader.ReadToEnd();
               //SourceCode.Text = "<pre>";
               int linecount = 1;
               foreach (string line in System.Text.RegularExpressions.Regex.Split(text, "\r\n"))
               {
                    string spaces = (linecount < 10) ? "   " : "  "; // sloppy but works for now
                    // SourceCode.Text += linecount + "." + spaces + line.Replace("<", "&lt;") + "\r\n";
                    SourceCode.Text += line + "\r\n";
                    linecount++;
               }
               //SourceCode.Text += "</pre>";
               reader.Close();
          }
          else
          {
               SourceCode.Text = "Not available.";
          }
     }
}
