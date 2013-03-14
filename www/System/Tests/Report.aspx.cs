using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.Reporting.WebForms;
using Weavver.Data;

public partial class System_Tests_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         //CreatePDF(@"W:\Projects\Weavver\Main\Servers\web\c\Inetpub\www\System\Tests\test.pdf");

         if (!IsPostBack)
         {
              WeavverEntityContainer data = new WeavverEntityContainer();
              var orders = from x in data.Sales_Order
                           select x;
              ReportViewer1.ProcessingMode = ProcessingMode.Local;
              ReportViewer1.LocalReport.EnableHyperlinks = true;
              ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Sales_Order", orders));

              List<Sales_OrderReportSettings> settings = new List<Sales_OrderReportSettings>();
              settings.Add(orders.First().ReportSettings);
              ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Sales_OrderReportSettings", settings));

              ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Accounting_LedgerItems", orders.First().LineItems));

              ReportViewer1.LocalReport.ReportPath = @"W:\Projects\Weavver\Main\Projects\WeavverLib\TestReport1.rdlc";
         }
    }

    private void CreatePDF(string fileName)
    {
         // Variables
         Warning[] warnings;
         string[] streamIds;
         string mimeType = string.Empty;
         string encoding = string.Empty;
         string extension = string.Empty;

         using (WeavverEntityContainer data = new WeavverEntityContainer())
         {
              var orders = from x in data.Sales_Order
                          select x;

              // Setup the report viewer object and get the array of bytes
              ReportViewer viewer = new ReportViewer();
              viewer.ProcessingMode = ProcessingMode.Local;
              viewer.LocalReport.EnableHyperlinks = true;
              viewer.LocalReport.DataSources.Add(new ReportDataSource("Sales_Order", orders));

              List<Sales_OrderReportSettings> settings = new List<Sales_OrderReportSettings>();
              settings.Add(orders.First().ReportSettings);
              viewer.LocalReport.DataSources.Add(new ReportDataSource("Sales_OrderReportSettings", settings));

              viewer.LocalReport.ReportPath = @"W:\Projects\Weavver\Main\Projects\WeavverLib\TestReport1.rdlc";

              byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

              // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
              Response.Buffer = true;
              Response.Clear();
              Response.ContentType = mimeType;
              Response.AddHeader("content-disposition", "attachment; filename=" + fileName + "." + extension);
              Response.BinaryWrite(bytes); // create the file
              Response.Flush(); // send it to the client to download
         }
    }
}