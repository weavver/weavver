
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using Weavver.Data;
using Weavver.Security;

public partial class RegisterControl : WeavverUserControl
{
     public event EventHandler AccountActivated;
//-------------------------------------------------------------------------------------------
     protected void Page_Init(object sender, EventArgs e)
     {
          Wizard1.ActiveStepChanged += new EventHandler(Wizard1_ActiveStepChanged);
          //recaptcha.PublicKey = ConfigurationManager.AppSettings["recaptcha_publickey"];
          //recaptcha.PrivateKey = ConfigurationManager.AppSettings["recaptcha_privatekey"];

          System.Web.UI.HtmlControls.HtmlGenericControl si = new System.Web.UI.HtmlControls.HtmlGenericControl();
          si.TagName = "script";
          si.Attributes.Add("type", @"text/javascript");
          si.Attributes.Add("src", "http://www.google.com/recaptcha/api/js/recaptcha_ajax.js");

          Page.ClientScript.RegisterClientScriptInclude("recaptcha", "http://www.google.com/recaptcha/api/js/recaptcha_ajax.js");
          //this.Page.Header.Controls.Add(si);

          // <script type="text/javascript" src="http://www.google.com/recaptcha/api/js/recaptcha_ajax.js"></script>
     }
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          if (!IsPostBack && HttpContext.Current.User.Identity.IsAuthenticated)
          {
               MembershipUser user = Membership.GetUser();
               if (!BasePage.LoggedInUser.Activated)
               {
                    Wizard1.ActiveStepIndex = 2;

                    if (Request["activationKey"] != null)
                    {
                         ((TextBox) GetControlFromWizard(ActivateStep, "ActivationCode")).Text = Request["activationKey"];
                         ActivateNext_Click(sender, e);
                    }
               }
               else if (BasePage.LoggedInUser.Activated)
               {
                    Wizard1.ActiveStepIndex = 3;
               }
          }
     }
//-------------------------------------------------------------------------------------------
     void Wizard1_ActiveStepChanged(object sender, EventArgs e)
     {
          switch (Wizard1.ActiveStepIndex)
          {
               case 2:
                    Title.Text = "Please activate your Weavver Account";
                    break;

               case 3:
                    Title.Text = "Your account has been activated.";
                    break;
          }
     }
//-------------------------------------------------------------------------------------------
     private void ReloadCaptcha()
     {
          ScriptManager.RegisterClientScriptBlock(
               this.Page,
               this.Page.GetType(),
               "ReCaptcha",
               "CreateCaptcha();",
               true);
     }
//-------------------------------------------------------------------------------------------
     protected void EmailValidation(object sender, ServerValidateEventArgs args)
     {
          args.IsValid = Weavver.Net.Mail.Common.IsValidAddress(args.Value);
     }
//-------------------------------------------------------------------------------------------
     protected void UserInfoNext_Click(object sender, EventArgs e)
     {
          Page.Validate("RegisterInfo");
          if (Page.IsValid)
          {
               string username = ((TextBox)GetControlFromWizard(UserInfoStep, "UserName")).Text;
               string password = ((TextBox)GetControlFromWizard(UserInfoStep, "Password")).Text;

               WeavverMembershipProvider provider = (WeavverMembershipProvider) System.Web.Security.Membership.Provider;
               System_Users item = provider.GetUser(username);
               if (item != null)
               {
                    UsernameTaken();
               }
               else if (Request.QueryString["checkingout"] == "true")
               {
                    Session["UserPassword"] = password;
                    CaptchaStepNext_Click(null, e);
               }
               else
               {
                    Session["UserPassword"] = password;
                    Title.Text = "Our lord <a href='http://www.reddit.com/r/inglip' target='_blank'>Inglip</a> requires your verification:";
                    Wizard1.ActiveStepIndex++;
               }
               ReloadCaptcha();
          }
     }
//-------------------------------------------------------------------------------------------
     protected void CaptchaStepNext_Click(object sender, EventArgs e)
     {
          if (Request["checkingout"] == "true" ||
              Request["recaptcha_response_field"] == ConfigurationManager.AppSettings["recaptcha_bypasskey"] ||
              Weavver.Vendors.Google.reCAPTCHA.Verify(ConfigurationManager.AppSettings["recaptcha_privatekey"],
                   Request.UserHostAddress,
                   Request["recaptcha_challenge_field"],
                   Request["recaptcha_response_field"]))
          {
               string emailaddress = ((TextBox)GetControlFromWizard(UserInfoStep, "EmailAddress")).Text;
               string username = ((TextBox)GetControlFromWizard(UserInfoStep, "UserName")).Text;
               string password = ((TextBox)GetControlFromWizard(UserInfoStep, "Password")).Text;
               string firstname = ((TextBox)GetControlFromWizard(UserInfoStep, "FirstName")).Text;
               string lastname = ((TextBox)GetControlFromWizard(UserInfoStep, "LastName")).Text;
               string orgname = ((TextBox)GetControlFromWizard(UserInfoStep, "OrganizationName")).Text;
               string referredby = (Session["ReferredBy"] == null) ? null : Session["referredby"].ToString();
               WeavverMembershipProvider provider = (WeavverMembershipProvider) System.Web.Security.Membership.Provider;
               MembershipCreateStatus status = MembershipCreateStatus.Success;
               MembershipUser user = provider.CreateUser(username, Session["UserPassword"].ToString(), emailaddress, "NONE", "", false, Guid.NewGuid(), Request.UserHostAddress, referredby, out status);
               if (status == MembershipCreateStatus.Success)
               {
                    using (WeavverEntityContainer data = new WeavverEntityContainer())
                    {
                         System_Users newUser = provider.GetUser(username);

                         Logistics_Organizations newOrg = new Logistics_Organizations();
                         newOrg.Id = Guid.NewGuid();
                         newOrg.OrganizationId = new Guid(ConfigurationManager.AppSettings["default_organizationid"]);
                         newOrg.OrganizationType = OrganizationTypes.Personal.ToString();
                         newOrg.Name = (!String.IsNullOrEmpty(orgname)) ? orgname : firstname + " " + lastname;
                         newOrg.EIN = "";
                         newOrg.Founded = DateTime.UtcNow;
                         newOrg.Bio = "My bio";
                         newOrg.CreatedAt = DateTime.UtcNow;
                         newOrg.CreatedBy = newUser.Id;
                         newOrg.UpdatedAt = DateTime.UtcNow;
                         newOrg.UpdatedBy = newUser.Id;
                         data.Logistics_Organizations.Add(newOrg);

                         data.System_Users.Attach(newUser);
                         newUser.OrganizationId = newOrg.Id;
                         newUser.FirstName = firstname;
                         newUser.LastName = lastname;

                         int changedRows = data.SaveChanges();
                         if (changedRows > 0)
                         {
                              // add this user as an administrator to their ORG
                              string oldAppName = Roles.ApplicationName;
                              Roles.ApplicationName = newOrg.Id.ToString();
                              Roles.CreateRole("Administrators");
                              Roles.AddUserToRole(newUser.Username, "Administrators");
                              Roles.ApplicationName = oldAppName;
                         }
                    }
                    //newOrg.Commit();

                    MailMessage mNewUser = new MailMessage("system@weavver.com", System.Configuration.ConfigurationManager.AppSettings["admin_address"]);
                    mNewUser.Subject = "New user";
                    //mm.Body = CreateUserWizard1.Email;
                    mNewUser.Body = "User: " + username + "\r\n"
                            + "Created At: " + DateTime.Now.ToString() + "\r\n"
                            + "By IP: " + Request.UserHostAddress + "\r\n"
                            + "Referred By: " + Session["ReferredBy"];

                    SmtpClient client2 = new SmtpClient(System.Configuration.ConfigurationManager.AppSettings["smtp_server"]);
                    client2.Send(mNewUser);

                    FormsAuthentication.SetAuthCookie(username, true);
                    if (Request.QueryString["checkingout"] == "true")
                    {
                         Response.Redirect("~/workflows/sales_orderplace");
                    }
                    else
                    {
                         provider.SendUserActivationInstructions(user.UserName, Request.Url.Scheme + "://" + Request.Url.Host);
                         Wizard1.ActiveStepIndex++;
                    }
               }
               else
               {
                    throw new Exception("We could not create your account. Please try again later.");
               }
          }
          else
          {
               ReloadCaptcha();
               ((Literal)GetControlFromWizard(CaptchaStep, "CaptchaError")).Text = "Please try again.";
          }
     }
//-------------------------------------------------------------------------------------------
     protected void ActivateNext_Click(object sender, EventArgs e)
     {
          Weavver.Security.WeavverMembershipProvider memProvider = new Weavver.Security.WeavverMembershipProvider();
          MembershipUser user = Membership.GetUser();
          if (user != null)
          {
               bool activated = memProvider.ActivateUser(user.UserName, ((TextBox)GetControlFromWizard(ActivateStep, "ActivationCode")).Text);
               if (activated)
               {
                    if (AccountActivated != null)
                         AccountActivated(this, EventArgs.Empty);
                    else
                         Wizard1.ActiveStepIndex++;
               }
               else
               {
                    ((Literal)GetControlFromWizard(ActivateStep, "ActivationFailed")).Visible = true;
               }
          }
          else
          {
               ((Literal)GetControlFromWizard(ActivateStep, "ActivationFailed")).Visible = true;
          }
     }
//-------------------------------------------------------------------------------------------
     protected void SendActivationEmail_Click(object sender, EventArgs e)
     {
          Weavver.Security.WeavverMembershipProvider memProvider = new Weavver.Security.WeavverMembershipProvider();
          memProvider.SendUserActivationInstructions(Membership.GetUser().UserName, BasePage.BaseURL);
          ((Literal)GetControlFromWizard(ActivateStep, "ActivationSent")).Visible = true;
     }
//-------------------------------------------------------------------------------------------
     public void UsernameTaken()
     {
          Title.Text = "Register your Weavver&reg; ID";
          ((TextBox)GetControlFromWizard(UserInfoStep, "UserName")).Text = "";
          ((TextBox)GetControlFromWizard(UserInfoStep, "UserName")).Visible = true;
          Wizard1.ActiveStepIndex = 0;
          ((Label)GetControlFromWizard(UserInfoStep, "ErrorMessage")).Text = "The username you chose is in use.";
     }
//-------------------------------------------------------------------------------------------
     private Control GetControlFromWizard(TemplatedWizardStep wzdTemplate, string controlName)
     {
          return wzdTemplate.ContentTemplateContainer.FindControl(controlName);
     }
//-------------------------------------------------------------------------------------------
}
