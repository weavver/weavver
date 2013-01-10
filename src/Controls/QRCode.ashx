<%@ WebHandler Language="C#" Class="QRCode" %>

using System;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

using Weavver.Utilities;

public class QRCode : IHttpHandler
{
//-------------------------------------------------------------------------------------------
     public void ProcessRequest(HttpContext context)
     {
          context.Response.ContentType = "image/png";
          
          Bitmap img = QRUtility.GenerateCode(context.Request["URL"]);
          using (MemoryStream ms = new MemoryStream())
          {
               img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
               ms.WriteTo(context.Response.OutputStream);
          }
     }
//-------------------------------------------------------------------------------------------
     public bool IsReusable
     {
          get
          {
               return true;
          }
     }
//-------------------------------------------------------------------------------------------
}