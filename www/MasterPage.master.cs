using System;
using System.Collections;
using System.Collections.Generic;
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

using Weavver.Web;
using Weavver.Sys;
using Weavver.Data;

//namespace Weavver
//{
     public partial class WeavverMasterPage : MasterPage, WeavverMasterPageInterface
     {
          public bool InitializeMap = false;
          public bool IsOnline = true;
//-------------------------------------------------------------------------------------------
          public SkeletonPage BasePage
          {
               get
               {
                    if (Page.GetType().IsSubclassOf(typeof(SkeletonPage)))
                    {
                         return (SkeletonPage) Page;
                    }
                    else
                    {
                         return null;
                    }
               }
          }
//-------------------------------------------------------------------------------------------
          public string FormTitle
          {
               set
               {
                    TitleDiv.Visible = !(value == null || value == "");
                    Title.Text = value;
                    if (BasePage != null) BasePage.Title = value;
               }
          }
//-------------------------------------------------------------------------------------------
          public string FormDescription
          {
               set
               {
                    DescriptionDiv.Visible = !(value == null || value == "");
                    Description.Text = value;
               }
          }
//-------------------------------------------------------------------------------------------
          public void SetToolbarVisibility(bool visible)
          {
               //Toolbar.Visible = visible;
               //MenuFiller.Visible = visible;
          }
          //CustomerChat
//-------------------------------------------------------------------------------------------
          public void SetChatVisibility(bool visible)
          {
               CustomerChat.Visible = visible;
               //MenuFiller.Visible = visible;
          }
//-------------------------------------------------------------------------------------------
          public void ToolBarMenuAdd(WeavverMenuItem item)
          {
               //Toolbar.menuTools.Items.Add(item);
          }
//-------------------------------------------------------------------------------------------
          public void ViewsMenuAdd(WeavverMenuItem item)
          {
               //Toolbar.menuViews.Items.Add(item);
          }
//-------------------------------------------------------------------------------------------
          public void ActionsMenuAdd(WeavverMenuItem item)
          {
               //Toolbar.menuActions.Items.Add(item);
          }
//-------------------------------------------------------------------------------------------
          public void DataViewsMenuAdd(WeavverMenuItem item)
          {
               //Toolbar.menuViews.Items.Add(item);
          }
//-------------------------------------------------------------------------------------------
          public WeavverWebMenu FormToolbar
          {
               get
               {
                    //return Toolbar;
                    return null;
               }
          }
//-------------------------------------------------------------------------------------------
          public string Width
          {
               get
               {
                    return ContentTable.Style["width"];
               }
               set
               {
                    if (value != null)
                    {
                         ContentTable.Style["width"] = value;
                    }
               }
          }
//-------------------------------------------------------------------------------------------
          public string MaxWidth
          {
               get
               {
                    return ContentTable.Style["max-width"];
               }
               set
               {
                    if (value != null)
                    {
                         ContentTable.Style["max-width"] = value;
                    }
                    else
                    {
                         ContentTable.Style.Remove("max-width");
                    }
               }
          }
//-------------------------------------------------------------------------------------------
          public bool FixedWidth
          {
               get
               {
                    return !(MaxWidth == "950px");
               }
               set
               {
                    if (value == false)
                    {
                         ContentTable.Style.Remove("max-width");
                    }
                    else
                    {
                         MaxWidth = "950px";
                    }
               }
          }
//-------------------------------------------------------------------------------------------
          protected void Page_Init(object sender, EventArgs e)
          {
               FixedWidth = true;
               Version.Text = ConfigurationManager.AppSettings["version"];

               //if (!HttpContext.Current.User.Identity.IsAuthenticated)
               //     SetToolbarVisiblity(false);

               //<asp:TextBox ID="Organizations" runat="server" AutoPostBack="false" AutoCompleteType="Disabled"></asp:TextBox>
               //<cc1:AutoCompleteExtender
               //     ID="OrganizationsCompleter"
               //     runat="server"
               //     OnClientItemSelected="Organizations_itemSelected"
               //     TargetControlID="Organizations"
               //     delimitercharacters=";, :"
               //     MinimumPrefixLength="1"
               //     ServicePath="~/System/Data/WebServices.asmx"
               //     ServiceMethod="GetOrganizationsCompletionList">
               //</cc1:AutoCompleteExtender>
               //<asp:LinkButton ID="OrganizationEdit" runat="server" Text="Edit" Font-Size="12" OnClick="OrganizationEdit_Click"></asp:LinkButton>
          }
//-------------------------------------------------------------------------------------------
          protected void Page_Load(object sender, EventArgs e)
          {
               if (InitializeMap)
               {
                    Body.Attributes.Add("onload", "initialize();");
               }

               if (Request["rid"] != null)
               {
                    Session["rid"] = Request["rid"];
               }

               if (Request.UserAgent != null &&
                   !Request.UserAgent.Contains("iPhone") &&
                   !Request.UserAgent.Contains("Android"))
               {
                    footer.Style["position"] = "fixed";
                    footer.Style["bottom"] = "0px";
                    footer.Style["width"] = "100%";
                    // style="position: fixed;bottom: -55px;"
               }
               GoogleAnalytics.Visible = (Request.Url.Host.ToLower().Contains("weavver.com"));
               string srcTxt = "<a href='{0}?File={1}.cs'>Source</a>";
               Source.Text = String.Format(srcTxt, Page.ResolveUrl("~/Source"), Page.ResolveUrl(Request.FilePath));

               Page.Header.DataBind();
          }
//-------------------------------------------------------------------------------------------
          protected void Page_PreRender(object sender, EventArgs e)
          {
               if (Request["id"] != null && BasePage != null && BasePage.LoggedInUser != null)
               {
                    //WeavverMasterPage x;
                    //Guid id = new Guid(Request["id"]);
                    //using (WeavverEntityContainer data = new WeavverEntityContainer())
                    //{
                    //     var user = for x in data.link
                                    
                    //          SelectedDatesCollection x
                    //foreach (DataLink link in Links)
                    //{
                    //     string typeid = (link.Object1 == id) ? link.Object2.ToString() : link.Object1.ToString();
                    //     string typename = (link.Object1 == id) ? link.Object2Type : link.Object1Type;
                    //     string url = "~/" + typename.ToLower().Replace("weavver.", "").Replace(".", "/");
                    //     url = url.Replace("/hr/", "/humanresources/");
                    //     url = url.Replace("/sys/", "/system/");
                    //     url = url.Replace("/staff", "/staffmember");
                    //     url = url.Replace("/employee", "/staffmember");
                    //     url += "?id=" + typeid;
                    //     Guid linkId = (link.Object1 == id) ? link.Object2 : link.Object1;
                    //     AddAttachmentLink(BasePage.DatabaseHelper.GetName(linkId), url, BasePage.DatabaseHelper.GetClassType(linkId));
                    //}
                    //if (BasePage.LoggedInUser.OrganizationId == new Guid("0baae579-dbd8-488d-9e51-dd4dd6079e95"))
                    //{
                    //     AddAttachmentLink("Attach data", "~/system/link?linkto=" + Request["id"].ToString(), null);
                    //}
               }
          }
//-------------------------------------------------------------------------------------------
          public void Attach_Click(object sender, EventArgs e)
          {
               Response.Redirect("/system/link?linkto=" + Request["id"].ToString());
          }
//-------------------------------------------------------------------------------------------
          //protected override void Render(HtmlTextWriter writer)
          //{
          //     MemoryStream ms = new MemoryStream();
          //     StreamWriter sw = new StreamWriter(ms);
          //     HtmlTextWriter htw = new HtmlTextWriter(sw);

          //     base.Render(htw);
          //     htw.Flush();
          //     ms.Position = 0;

          //     TextReader tr = new StreamReader(ms);
          //     string output = tr.ReadToEnd();
          //     string newOutput = FormatURLs(output);
          //     writer.Write(newOutput);

          //     htw.Close();
          //     sw.Close();
          //     ms.Close();
          //}
          //DUPLICATED IN BLANK.MASTER - UPDATE THERE AS WELL 
//-------------------------------------------------------------------------------------------
          public string FormatURLs(string str)
          {
               //string appPath = HttpContext.Current.Request.ApplicationPath;

               //Ensure the app path ends w/ a slash
               //if (!appPath.EndsWith("/"))
                 //   appPath += "/";

               string basepath = (BasePage == null || BasePage.SelectedOrganization == null) ? "~/" : "~/" + BasePage.SelectedOrganization.VanityURL + "/";
               //string orgname = (BasePage == null || BasePage.SelectedOrganization == null) ? BasePage.SelectedOrganization.VanityURL : "";
               return str.Replace("~/", Page.ResolveUrl(basepath)); //.Replace("%orgname%", orgname);
          }
//-------------------------------------------------------------------------------------------
     }
//}