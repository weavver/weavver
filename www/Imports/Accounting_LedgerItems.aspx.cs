using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using Weavver.Company.Accounting;
using Weavver.Data;

using SoftwareIsHardwork.Tools.QifConvUtil;

public partial class Company_Accounting_Import_Default : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_PreInit(object sender, EventArgs e)
     {
          if (Request["IFrame"] == "true")
          {
               MasterPageFile = "~/Blank.master";
          }
     }
//-------------------------------------------------------------------------------------------
     protected void Page_Init(object sender, EventArgs e)
     {
          TransactionsDetected.ItemDataBound += new DataGridItemEventHandler(TransactionsDetected_ItemDataBound);

          WeavverMaster.FormTitle = "Import Financial Records";
          WeavverMaster.FormDescription = "Use this tool to import your accounting records.";
          WeavverMaster.FixedWidth = true;

          //transactionFolder = Path.Combine(ConfigurationManager.AppSettings["data_folder"], @"Accounting\Transactions\");

          if (!Roles.IsUserInRole("Administrators"))
               Response.Redirect("~/System/HTTP401", true);
     }
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          if (!IsPostBack)
          {
               UpdatePage();
          }
     }
//-------------------------------------------------------------------------------------------
     public void UpdatePage()
     {
          using (WeavverEntityContainer data = new WeavverEntityContainer())
          {
               var financialAccounts = from x in data.Accounting_Accounts
                                       from y in data.Accounting_OFXSettings
                                       where x.OrganizationId == SelectedOrganization.Id
                                           && x.Id == y.AccountId
                                       orderby x.Name ascending
                                       select x;

               OFXAccounts.Items.Clear();
               foreach (Accounting_Accounts account in financialAccounts)
               {
                    OFXAccounts.Items.Add(new ListItem(account.Name, account.Id.ToString()));
               }
          }

          OFXStartDate.Text = DateTime.Now.Subtract(TimeSpan.FromDays(30)).ToString("MM/dd/yy");
          OFXEndDate.Text = DateTime.Now.ToString("MM/dd/yy");
     }
//-------------------------------------------------------------------------------------------
     protected void Load_Click(object sender, EventArgs e)
     {
          //ClearError();
          if (!FileUpload1.HasFile)
          {
               ShowError("Please choose a file to upload.");
               return;
          }

          string uploadedFilePath = Path.Combine(ConfigurationManager.AppSettings["temp_folder"], Guid.NewGuid().ToString() + ".acctimport." + Path.GetExtension(FileUpload1.FileName));
          FileUpload1.SaveAs(uploadedFilePath);

          LoadTransactions(uploadedFilePath);
     }
//-------------------------------------------------------------------------------------------
     public void OFXPreview_Click(object sender, EventArgs e)
     {
          ClearError();

          using (WeavverEntityContainer data = new WeavverEntityContainer())
          {
               Accounting_OFXSettings ofxSettings = (from x in data.Accounting_OFXSettings
                                                     where x.AccountId == new Guid(OFXAccounts.SelectedValue)
                                                     select x).FirstOrDefault();

               if (ofxSettings != null)
               {
                    Accounting_Accounts acct = (from x in data.Accounting_Accounts
                                                where x.Id == new Guid(OFXAccounts.SelectedValue)
                                                select x).FirstOrDefault();

                    List<Accounting_OFXLedgerItem> items = ofxSettings.GetRemoteLedgerItems(DateTime.Parse(OFXStartDate.Text), DateTime.Parse(OFXEndDate.Text));
                    Session["Import_Transactions"] = items;
                    List<Accounting_LedgerItems> LedgerItemsData = new List<Accounting_LedgerItems>();
                    foreach (var item in items)
                    {
                         LedgerItemsData.Add(item.LedgerItem);
                    }
                    var sortedItems = LedgerItemsData.OrderByDescending(x => x.PostAt);
                    TransactionsDetected.DataSource = sortedItems;
                    TransactionsDetected.DataBind();

                    LedgerItems.Visible = true;

                    // totals
                    var credits = items.Where(x => x.LedgerItem.Amount > 0).Sum(x => x.LedgerItem.Amount);
                    var debits = items.Where(x => x.LedgerItem.Amount < 0).Sum(x => x.LedgerItem.Amount);
                    DetectedTotal.Text = items.Count.ToString();
                    if (credits.HasValue)
                         TotalCredits.Text = String.Format("{0,10:C}", credits.Value);
                    if (debits.HasValue)
                         TotalDebits.Text = String.Format("{0,10:C}", debits.Value);
               }
          }
     }
//-------------------------------------------------------------------------------------------
     void TransactionsDetected_ItemDataBound(object sender, DataGridItemEventArgs e)
     {
          if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.EditItem)
          {
               Accounting_LedgerItems item = (Accounting_LedgerItems)e.Item.DataItem;
               if (item.Amount.Value < 0)
                    e.Item.Style["background-color"] = "#FFE9E8";
               else if (item.Amount.Value > 0)
                    e.Item.Style["background-color"] = "#C1FFC1";

               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    var row = (from x in data.Accounting_LedgerItems
                               where x.ExternalId == item.ExternalId
                               select x).FirstOrDefault();

                    if (row != null)
                         e.Item.Style["background-color"] = "#d4eaf1";
                    else
                         ((CheckBox)FindControlRecursive(e.Item.Cells[1], "ImportRow")).Checked = true;

                    e.Item.ToolTip = item.ExternalId;
               }
          }
     }
//-------------------------------------------------------------------------------------------
     public void LoadTransactions(string file)
     {
          if (file.EndsWith("qif"))
          {
               //NonInvestmentAccount account = QifParser.ParseNonInvestmentAccountFile(file);
               //foreach (NonInvestmentAccountTransaction transaction in account.Transactions)
               //{
               //     DataRow row = Accounting.transactions.NewRow();
               //     row[0] = Weavver.Utilities.Common.MD5(transaction.Date + transaction.Payee + transaction.Amount);
               //     row[1] = transaction.Date;
               //     row[2] = transaction.Payee;
               //     row[3] = Convert.ToDecimal(transaction.Amount);
               //     row[4] = Accounting.MatchAndLog((DateTime)row[1], row[2].ToString(), (decimal)row[3]);
               //     Accounting.transactions.Rows.Add(row);
               //}
          }
          else if (file.EndsWith("qbo") || file.EndsWith("ofx") || file.EndsWith("qfx"))
          {
               //XElement doc = FinancerData.ImportOfx.toXElement(file);
               //var imps = (from c in doc.Descendants("STMTTRN")
               //            select new
               //            {
               //                 amount = decimal.Parse(c.Element("TRNAMT").Value.Replace("-", ""), System.Globalization.NumberFormatInfo.InvariantInfo),
               //                 data = DateTime.ParseExact(c.Element("DTPOSTED").Value, "yyyyMMdd", null),
               //                 description = c.Element("MEMO").Value
               //            });
               //TestGrid.DataSource = imps;
               //TestGrid.DataBind();

               //OFXImporter.Importer imp = new OFXImporter.Importer();
               //string ofxdata = System.IO.File.ReadAllText(file);
               //OFXImporter.OFX ofxFile = imp.Import(ofxdata);

               //foreach (OFXImporter.OFXTransaction transaction in ofxFile.Transactions)
               //{
               //     DataRow row = Accounting.transactions.NewRow();
               //     row[0] = transaction.TransactionID;
               //     row[1] = transaction.Date;
               //     row[2] = transaction.Name;
               //     row[3] = transaction.Amount;
               //     row[4] = Accounting.MatchAndLog((DateTime)row[1], row[2].ToString(), (decimal)row[3]);
               //     Accounting.transactions.Rows.Add(row);
               //}
          }
          else if (file.EndsWith("txt"))
          {
               //string stuff = System.IO.File.ReadAllText(file);
               //string[] data = stuff.Split('|');
               //int pos = 0;
               //while (pos < data.Length - 1)
               //{
               //     DataRow row = transactions.NewRow();

               //     //date
               //     if (pos == 0)
               //          row[1] = data[pos];
               //     else
               //          row[1] = data[pos].Substring(2);

               //     //payee
               //     row[2] = data[pos + 2];

               //     //amount
               //     decimal amount = Decimal.Parse(data[pos + 1].Replace("$", ""));
               //     row[3] = amount;

               //     // do not log payments for now
               //     //if (amount > 0)
               //     {
               //          row[0] = Weavver.Common.Common.MD5(row[1].ToString() + row[2].ToString() + row[3].ToString());
               //          try
               //          {
               //               transactions.Rows.Add(row);
               //          }
               //          catch (Exception ex)
               //          {
               //               Response.Write(row[1].ToString() + ": " + row[2].ToString() +"<br />");
               //          }

               //          row[4] = MatchAndLog((DateTime) row[1], row[2].ToString(), (decimal)row[3]);
               //     }
               //     pos = pos + 3;
               //}
          }
          else if (file.EndsWith(".pdf"))
          {
               //org.pdfbox.pdmodel.PDDocument doc = org.pdfbox.pdmodel.PDDocument.load(@"W:\Projects\Weavver\Accounting\MJC Personal\Schoolsfirst\2009\09.pdf");
               //org.pdfbox.util.PDFTextStripper strip = new org.pdfbox.util.PDFTextStripper();
               //string pdfText = strip.getText(doc);
          }
     }
//-------------------------------------------------------------------------------------------
     protected void OFXImport_Click(object sender, EventArgs e)
     {
          List<Accounting_OFXLedgerItem> PreviewLedgerItems = (List<Accounting_OFXLedgerItem>)Session["Import_Transactions"];
          using (WeavverEntityContainer data = new WeavverEntityContainer())
          {
               for (int i = 0; i < TransactionsDetected.Items.Count; i++)
               {
                    Guid rowId = new Guid(TransactionsDetected.Items[i].Cells[0].Text);
                    CheckBox importRow = (CheckBox)FindControlRecursive(TransactionsDetected.Items[i].Cells[1], "ImportRow");
                    if (importRow == null || !importRow.Checked)
                    {
                         continue;
                    }

                    // Load from safe server side dataset
                    var item = (from y in PreviewLedgerItems
                                   where y.LedgerItem.Id == rowId
                                   select y).First();

                    TextBox memoField = (TextBox)FindControlRecursive(TransactionsDetected.Items[i].Cells[5], "Memo");
                    if (memoField != null && item.LedgerItem.Memo != memoField.Text)
                    {
                         item.LedgerItem.Memo = memoField.Text;
                    }                         

                    data.Accounting_LedgerItems.AddObject(item.LedgerItem);
               }
               ClearError();
               decimal successCount = data.SaveChanges();
               ShowError("Imported " + successCount.ToString() + " row(s).");
          }

          List<Accounting_LedgerItems> LedgerItems = new List<Accounting_LedgerItems>();
          foreach (var item in PreviewLedgerItems)
               LedgerItems.Add(item.LedgerItem);
          var sortedItems = LedgerItems.OrderByDescending(x => x.PostAt);
          TransactionsDetected.DataSource = sortedItems;
          TransactionsDetected.DataBind();
     }
//-------------------------------------------------------------------------------------------
     // Load settings from Template
     //void OFXBankList_SelectedIndexChanged(object sender, EventArgs e)
     //{
     //     Guid ofxBankId = new Guid(OFXBankList.SelectedValue);
     //     OFXBank bank = DatabaseHelper.Session.Get<OFXBank>(ofxBankId);
     //     OFXUrl.Text = bank.Url;
     //     OFXFinancialInstituationId.Text = bank.FinancialInstitutionId.ToString();
     //     OFXFinancialInstituationName.Text = bank.FinancialInstitutionName;
     //     OFXBankId.Text = bank.BankId;
     //}
//-------------------------------------------------------------------------------------------
}
