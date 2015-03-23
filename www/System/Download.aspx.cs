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

public partial class System_Download : SkeletonPage
{
     protected void Page_Load(object sender, EventArgs e)
     {
          // add a check to see that the user has access to this object
          //Response.WriteFile("C:\\.rnd");

          if (Request["redir"] != null)
          {
               using (WeavverEntityContainer dataContext = new WeavverEntityContainer())
               {
                    IT_DownloadLogs downloadLog = new IT_DownloadLogs();
                    downloadLog.Id = Guid.NewGuid();
                    downloadLog.OrganizationId = SelectedOrganization.Id;
                    downloadLog.FileName = System.IO.Path.GetFileName(Request["redir"]);
                    downloadLog.DownloadedAt = DateTime.UtcNow;
                    downloadLog.DownloadedByIP = Request.UserHostAddress;
                    downloadLog.DownloadedBy = LoggedInUser.Id;

                    dataContext.IT_DownloadLogs.Add(downloadLog);
                    dataContext.SaveChanges();

                    Response.Redirect(Request["redir"]);
               }
          }
     }
     
          //string id = Request["id"];
          //if (id != null)
          //{
          //     Guid fileId = Guid.Empty;
          //     Weavver.Common.Common.GuidTryParse(id, out fileId);
          //     if (fileId != Guid.Empty)
          //     {
          //          AudioFile file = session.Get<AudioFile>(fileId);
          //          if (file != null && file.OrganizationId == LoggedInUser.OrganizationId)
          //          {
          //               Response.AddHeader("Content-Disposition", "attachment; filename=voicemail.mp3");
          //               Response.AddHeader("Content-Length", file.AudioData.Length.ToString());
          //               Response.ContentType = "audio/mpeg";
          //               Response.BinaryWrite(file.AudioData);
          //               return;
          //          }
          //     }
          //}
          //Response.Write("File not found.");
     // A download example that chunks the response
     //private void DownloadFile(string strFileName, string strFullPath)
     //{
     //     string strFileExt = strFullPath.Substring(strFullPath.LastIndexOf(".") + 1);
     //     if (!(new FileInfo(strFullPath).Exists))
     //     {
     //          this.lblError.Text = "Selected file not found";
     //          return;
     //     }
     //     if (strFileExt == "vb" || strFileExt == "lic" || strFileExt == "asp" || strFileExt == "asa" || strFileExt == "aspx" || strFileExt == "resx" || strFileExt == "asax" || strFileExt == "mdb" || strFileExt == "ascx" || strFileExt == "config" || strFileExt == "fla" || strFileExt == "dll" || strFileExt == "js" || strFileExt == "xml")
     //     {
     //          this.lblError.Text = "You cannot download this file type";
     //          return;
     //     }
     //     else
     //     {
     //          System.IO.Stream iStream = null;
     //          // Buffer to read 10K bytes in chunk:
     //          byte[] buffer = new Byte[10000];
     //          // Length of the file:
     //          int length;
     //          // Total bytes to read:
     //          long dataToRead;


     //          try
     //          {
     //               // Open the file.
     //               iStream = new System.IO.FileStream(strFullPath, System.IO.FileMode.Open,
     //                    System.IO.FileAccess.Read, System.IO.FileShare.Read);

     //               // Total bytes to read:
     //               dataToRead = iStream.Length;

     //               Response.ContentType = "application/octet-stream";
     //               //Response.AddHeader("Content-Disposition", "attachment; filename=" + strFileName);
     //               Response.AddHeader("Content-Disposition", @"attachment; filename=""" + strFileName + @"""");
     //               Response.AddHeader("Content-Length", dataToRead.ToString());

     //               // Read the bytes.
     //               while (dataToRead > 0)
     //               {
     //                    // Verify that the client is connected.
     //                    if (Response.IsClientConnected)
     //                    {
     //                         // Read the data in buffer.
     //                         length = iStream.Read(buffer, 0, 10000);

     //                         // Write the data to the current output stream.
     //                         Response.OutputStream.Write(buffer, 0, length);

     //                         // Flush the data to the HTML output.
     //                         Response.Flush();

     //                         buffer = new Byte[10000];
     //                         dataToRead = dataToRead - length;
     //                    }
     //                    else
     //                    {
     //                         //prevent infinite loop if user disconnects
     //                         dataToRead = -1;
     //                    }
     //               }
     //          }
     //          catch (Exception ex)
     //          {
     //               // Trap the error, if any.
     //               this.lblError.Text = ex.Message;
     //          }
     //          finally
     //          {
     //               if (iStream != null)
     //               {
     //                    //Close the file.
     //                    iStream.Close();
     //               }
     //          }
     //     }
     //}

}