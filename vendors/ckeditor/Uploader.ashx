<%@ WebHandler Language="C#" Class="Uploader" %>

using System;
using System.Web;
using System.IO;

public class Uploader : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
   
    public void ProcessRequest (HttpContext context) {
        //context.Response.Write(context.Session["SelectedOrganizationId"].ToString());
         HttpPostedFile uploads = context.Request.Files["upload"];
         string CKEditorFuncNum = context.Request["CKEditorFuncNum"];
         string file = System.IO.Path.GetFileName(uploads.FileName);
         string orgId = context.Session["SelectedOrganizationId"].ToString();
         string filepath = System.Configuration.ConfigurationManager.AppSettings["upload_folder"] + "\\" + orgId + "\\" + file;
         // protect from overwrites
         if (File.Exists(filepath))
              return;
         uploads.SaveAs(filepath);
         string url = "/uploads/" + orgId + "/" + file;
         context.Response.Write("<script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + url + "\");</script>");
         context.Response.End();            
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
 
}