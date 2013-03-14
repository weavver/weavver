using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DynamicData_PageTemplates_Accounting_OFXSettings : WeavverUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
         // Load templates:
         //ICriteria OFXBanks = DatabaseHelper.Session.CreateCriteria(typeof(OFXBank))
         //         .Add(NHibernate.Criterion.Restrictions.Eq("OrganizationId", Guid.Empty))
         //         .AddOrder(NHibernate.Criterion.Order.Asc("Name"));

         //OFXBankList.DataValueField = "Id";
         //OFXBankList.DataTextField = "Name";
         //OFXBankList.DataSource = OFXBanks.List<OFXBank>();
         //OFXBankList.DataBind();
    }
}


// Implement this later to help users configure their OFX data

//     DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
//     ret.Status = "OFX Check";

//Guid ofxBankid = DatabaseHelper.FindAttachment(accountId, "Weavver.Company.Accounting.OFXBank");
//if (ofxBankid != Guid.Empty)
//{
//     OFXBank bank = DatabaseHelper.Session.Get<OFXBank>(ofxBankid);
//     for (int i = 0; i < OFXBankList.Items.Count; i++)
//     {
//          if (OFXBankList.Items[i].Text == bank.Name)
//          {
//               OFXBankList.SelectedIndex = i;
//               break;
//          }
//     }
//     OFXUrl.Text = bank.Url;
//     OFXFinancialInstituationId.Text = bank.FinancialInstitutionId.ToString();
//     OFXFinancialInstituationName.Text = bank.FinancialInstitutionName;
//     OFXBankId.Text = bank.BankId;
//     OFXUsername.Text = bank.Username;
//     OFXPassword.Text = bank.Password;
//}