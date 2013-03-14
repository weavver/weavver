using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DynamicData;
using Weavver.Data;

public partial class DynamicData_EntityTemplates_Accounting_Checks : System.Web.DynamicData.EntityTemplateUserControl
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          using (WeavverEntityContainer data = new WeavverEntityContainer())
          {
               SkeletonPage sPage = (SkeletonPage) Page;

               if (sPage.SelectedOrganization.BillingAddress.HasValue)
               {
                    var orgAddress = (from addy in data.Logistics_Addresses
                                      where addy.OrganizationId == sPage.SelectedOrganization.Id &&
                                      addy.Id == sPage.SelectedOrganization.BillingAddress.Value
                                      select addy).First();

                    OrgAddress.Text = orgAddress.ToString().Replace("\r\n", "<br />");
               }


               if (Request["id"] != null)
               {
                    Guid checkId = new Guid(Request["id"]);

                    var check = (from checks in data.Accounting_Checks
                                 where checks.OrganizationId == sPage.SelectedOrganization.Id &&
                                 checks.Id == checkId
                                 select checks).First();

                    var payeeAccount = (from orgs in data.Logistics_Organizations
                                        where orgs.Id == check.Payee
                                        select orgs).First();

                    if (payeeAccount.BillingAddress.HasValue)
                    {
                         var payeeAddress = (from addy in data.Logistics_Addresses
                                             where addy.OrganizationId == sPage.SelectedOrganization.Id &&
                                             addy.Id == payeeAccount.BillingAddress
                                             select addy).First();

                         PayeeAddress.Text = payeeAddress.ToString().Replace("\r\n", "<br />");
                    }
               }
          }
     }
//-------------------------------------------------------------------------------------------
     protected void DynamicControl_Init(object sender, EventArgs e)
     {
          DynamicControl dynamicControl = (DynamicControl)sender;
          dynamicControl.Mode = this.Mode;

     }
//-------------------------------------------------------------------------------------------
}