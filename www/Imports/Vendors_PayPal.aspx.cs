using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Weavver.Vendors.PayPal.Data;

public partial class Company_Accounting_Import_PayPal : SkeletonPage
{
     protected void Page_Load(object sender, EventArgs e)
     {
          if (Request["testing"] == "true")
               return;
          //fdata.DataSource = csv;
          //fdata.DataBind();

          List<PayPalRecord> PayPalRecords = new List<PayPalRecord>();

          decimal totalfees  = Decimal.Parse("0.0");
          decimal totalgross = Decimal.Parse("0.0");
          decimal totalnet   = Decimal.Parse("0.0");
          string  text       = "";
          foreach (string directory in Directory.GetDirectories(@"W:\Projects\Weavver\Accounting\Paypal"))
          {
               foreach (string file in Directory.GetFiles(directory))
               {
                    Response.Write(file);
                    if (!file.EndsWith(".txt"))
                         continue;

                    LumenWorks.Framework.IO.Csv.CsvReader csv = new LumenWorks.Framework.IO.Csv.CsvReader(new StreamReader(file), true, '\t');

                    int fieldCount = csv.FieldCount;
                    string[] headers = csv.GetFieldHeaders();
                    decimal fees  = Decimal.Parse("0.0");
                    decimal gross = Decimal.Parse("0.0");
                    decimal net   = Decimal.Parse("0.0");

                    while (csv.ReadNextRecord())
                    {
                         string itemtitle = null;
                         try
                         {
                              itemtitle = csv["Item Title"];
                         }
                         catch (Exception ex)
                         {
                              ShowError(ex, "Import error");
                              continue;
                         }
                         if (itemtitle == "Snap Pro")
                         {
                              PayPalRecord item = new PayPalRecord();
                              item.Date                = csv["Date"];
                              item.Time                = csv["Time"];
                              item.TimeZone            = csv["Time Zone"];
                              item.Name                = csv["Name"];
                              item.Type                = csv["Type"];
                              item.Status              = csv["Status"];
                              item.Currency            = csv["Currency"];
                              item.Gross               = csv["Gross"];
                              item.Net                 = csv["Net"];
                              item.FromEmailAddress    = csv["From Email Address"];
                              item.ToEmailAddress      = csv["To Email Address"];
                              item.TransactionID       = csv["Transaction ID"];
                              item.CounterpartyStatus  = csv["Counterparty Status"];
                              item.ShippingAddress     = csv["Shipping Address"];
                              item.AddressStatus       = csv["Address Status"];
                              item.ItemTitle           = csv["Item Title"];
                              item.ItemID              = csv["Item ID"];
                              item.ShippingandHandlingAmount = Decimal.Parse(csv["Shipping and Handling Amount"]);
                              item.InsuranceAmount     = csv["Insurance Amount"];
                              item.SalesTax            = Decimal.Parse(csv["Sales Tax"]);
                              item.Option1Name         = csv["Option 1 Name"];
                              item.Option1Value        = csv["Option 1 Value"];
                              item.Option2Name         = csv["Option 2 Name"];
                              item.Option2Value        = csv["Option 2 Value"];
                              item.AuctionSite         = csv["Auction Site"];
                              item.BuyerID             = csv["Buyer ID"];
                              item.ReferenceTxnID      = csv["Reference Txn ID"];
                              item.InvoiceNumber       = csv["Invoice Number"];
                              item.CustomNumber        = csv["Custom Number"];
                              item.ReceiptID           = csv["Receipt ID"];
                              item.Balance             = csv["Balance"];
                              item.ContactPhoneNumber  = csv["Contact Phone Number"];
                              item.BalanceImpact       = csv["Balance Impact"];

                              PayPalRecords.Add(item);

                              fees                     += Decimal.Parse(csv["Fee"]);
                              gross                    += Decimal.Parse(csv["Gross"]);
                              net                      += Decimal.Parse(csv["Net"]);
                              continue;
                         }
                    }
                    text       += "<hr />";
                    totalfees  += fees;
                    totalgross += gross;
                    totalnet   += net;
               }
          }

          fdata.DataSource = PayPalRecords;

          //for (int i = 0; i < PayPalRecords.Count; i++)
          //{
          //     PayPalRecords[i].Commit();
          //}
          //fdata.DataBind();

          //FileData.Text  = text;
          //totalfees      = -1 * totalfees;
          //Fees.Text      = "Fees: $" + totalfees.ToString();
          //Totals.Text    = "Gross: $" + totalgross.ToString();
          //Net.Text       = "Net: $" + totalnet.ToString();
          
          //Net.Text        += "<br>Total Records: " + PayPalRecords.Count;
          //Console.ReadLine();
     }
}
