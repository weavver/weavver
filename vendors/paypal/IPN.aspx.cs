using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Weavver.Company.Accounting;
using Weavver.Data;
using Weavver.Vendors.PayPal;

public partial class Vendors_PayPal_IPN : System.Web.UI.Page
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          if (Request.QueryString.Count > 10)
          {
               HandleIPN();
          }
          else
          {
               Response.Write("Not enough parameters (passed data) was found in your request.");
          }
     }
//-------------------------------------------------------------------------------------------
     /*
               Txn_id = "CREDITCARD";
               First_name = "John";
               Last_name = "Doe";
               Payer_email = "jdoe@yahoo.com";
               response = "VERIFIED";
               Quantity = "1";
               Payment_gross = "100.00";
               Custom = "GUID";
               Payment_status = "Completed";
     */
     private void HandleIPN()
     {
          Weavver.Utilities.Common.Log("PayPal Report", "Report...\r\n" + Request.Form.ToString() + "\r\n" + Request.QueryString.ToString());

          IPN ipn             = new IPN();
          ipn.Receiver_email  = Request.Params["receiver_email"];
          ipn.Item_name       = Request.Params["item_name"];
          ipn.Item_number     = Request.Params["item_number"];
          ipn.Quantity        = Request.Params["quantity"];
          ipn.Invoice         = Request.Params["invoice"];
          ipn.Custom          = Request.Params["custom"];
          ipn.Payment_status  = Request.Params["payment_status"];
          ipn.Pending_reason  = Request.Params["pending_reason"];
          ipn.Payment_date    = Request.Params["payment_date"];
          ipn.Payment_fee     = Request.Params["payment_fee"];
          ipn.Payment_gross   = Decimal.Parse(Request.Params["payment_gross"]);
          ipn.Txn_id          = Request.Params["txn_id"];
          ipn.Txn_type        = Request.Params["txn_type"];
          ipn.First_name      = Request.Params["first_name"];
          ipn.Last_name       = Request.Params["last_name"];
          ipn.Address_street  = Request.Params["address_street"];
          ipn.Address_city    = Request.Params["address_city"];
          ipn.Address_state   = Request.Params["address_state"];
          ipn.Address_zip     = Request.Params["address_zip"];
          ipn.Address_country = Request.Params["address_country"];
          ipn.Address_status  = Request.Params["address_status"];
          ipn.Payer_email     = Request.Params["payer_email"];
          ipn.Payer_status    = Request.Params["payer_status"];
          ipn.Payment_type    = Request.Params["payment_type"];
          ipn.Notify_version  = Request.Params["notify_version"];
          ipn.Verify_sign     = Request.Params["verify_sign"];

          string postdata	= "cmd = _notify-validate" + Request.Form.ToString();
          string formvalues   = Request.Form.ToString();
          string newvalue     = "";
          string response     = "";
 
          HttpWebRequest req       = (HttpWebRequest) WebRequest.Create("https://www.paypal.com/cgi-bin/webscr");
          req.Method               = "POST";
          req.ContentType          = "application/x-www-form-urlencoded";
          newvalue                 = formvalues + "&cmd=_notify-validate";
          req.ContentLength        = newvalue.Length;

          StreamWriter   stout     = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
          stout.Write(newvalue);
          stout.Close();
          StreamReader   stIn      = new StreamReader(req.GetResponse().GetResponseStream());
          response                 = stIn.ReadToEnd();
          stIn.Close();

          switch (response)
          {
               case "VERIFIED":
                    Guid orderId = new Guid(ipn.Custom);     
                    // process data


                    Weavver.Utilities.Common.Log("Vendors/PayPal/IPN.aspx.cs, Unhandled:", newvalue);

                    //Sales_Order order = helper.Session.Get<Sales_Order>(orderId);

                    //LedgerItem payment = new LedgerItem();
                    //payment.Id = Guid.NewGuid();
                    ////payment.OrganizationId = ipn.;
                    //payment.LedgerType = LedgerType.Receivable;
                    //payment.Code = CodeType.Payment;
                    //payment.Memo = "PayPal #" + ipn.Txn_id;
                    //payment.Amount = ipn.Payment_gross;
                    //payment.EntryType = EntryType.Credit;
                    //payment.CreatedAt = DateTime.UtcNow;
                    //payment.CreatedBy = Guid.Empty;
                    //payment.UpdatedAt = DateTime.UtcNow;
                    //payment.UpdatedBy = Guid.Empty;
                    //payment.Commit();

                    //helper.Link(order, payment);
                    break;

               default:
                    Weavver.Utilities.Common.Log("Vendors/PayPal/IPN.aspx.cs, Possible fraud", newvalue);
                    break;
          }
     }
//-------------------------------------------------------------------------------------------
}
