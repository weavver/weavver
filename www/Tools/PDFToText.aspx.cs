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

public partial class Tools_PDFToText : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          IsPublic = true;
          Master.FormTitle = "PDF to Text";
          Master.FormDescription = "This is a free tool to convert your PDF documents to text. This is not an OCR tool. It will only extract embedded text.<br />";
     }
//-------------------------------------------------------------------------------------------
     protected void Convert_Click(object sender, EventArgs e)
     {
          if (PDFUpload1.HasFile)
          {
               string filepath = ConfigurationManager.AppSettings["temp_folder"] + Guid.NewGuid() + ".pdf";
               PDFUpload1.SaveAs(filepath);
               org.pdfbox.pdmodel.PDDocument doc = org.pdfbox.pdmodel.PDDocument.load(filepath);
               org.pdfbox.util.PDFTextStripper strip = new org.pdfbox.util.PDFTextStripper();
               string pdfText = strip.getText(doc);

               Output.Text = pdfText;
               System.IO.File.Delete(filepath);
          }
     }
//-------------------------------------------------------------------------------------------
}
