using System;
using System.Collections;
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

public partial class Company_Human_Resources_Time_Logs_Reports_ByMonth : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          //Report.BorderStyle = BorderStyle.Solid;
          //Report.BorderColor = System.Drawing.Color.Black;
          //TableRow row = new TableRow();
          //TableCell cellMonday = new TableCell();
          //cellMonday.Text = "Monday";
          //row.Cells.Add(cellMonday);


          //int offset = DateTime.Now.Day;
          //int currentmonth = DateTime.Now.Month;;
          //int i = 0;
          //while (offset > 0)
          //{
          //     DateTime reportDate = DateTime.Now.Subtract(TimeSpan.FromDays(offset));

          //     if (currentmonth != reportDate.Month)
          //     {
          //          RenderMonthRow(reportDate.Month);
          //          currentmonth = reportDate.Month;
          //     }
          //     RenderDateRange(reportDate.Date.Subtract(TimeSpan.FromDays(7)), reportDate);
          //     offset = offset - 7;
          //}



          //List.DataSource = HRHelper.TotalTime_ForPerson_ByDay(LoggedInUser.Id, DateTime.Now.Subtract(TimeSpan.FromDays(999)), DateTime.Now);
          //List.DataBind();

          //ListM.DataSource = HRHelper.TotalTime_ForPerson_ByMonth(LoggedInUser.Id, DateTime.Now.Subtract(TimeSpan.FromDays(999)), DateTime.Now);
          //ListM.DataBind();

          //if (docs.Count() > 0)
          //{
          //     foreach (var doc in docs.Rows())
          //     {
          //          tcTime.Text = doc["value"].ToString();
          //     }
          //}
          //else
          //{
          //     tcTime.Text = "0";
          //}




//          RenderMonthRow(4);
          //TableRow row2 = new TableRow();
          //for (int i = 0; i < 15; i++)
          //{
          //     DateTime reportDate = DateTime.Now.Subtract(TimeSpan.FromDays(i));

          //}
          //Report.Rows.Add(row2);
     }
//-------------------------------------------------------------------------------------------
//     private void RenderMonthRow(int month)
//     {
//          TableRow monthRow = new TableRow();
//          TableCell monthCell = new TableCell();
//          monthCell.Text = month.ToString();
//          monthRow.Cells.Add(monthCell);
//          Report.Rows.Add(monthRow);


//          int daysinmonth = DateTime.DaysInMonth(2010, month);
//          DateTime startdate = DateTime.MinValue;
//          DateTime enddate = DateTime.MinValue;
//          for (int i = 1; i <= daysinmonth; i++)
//          {
//               DateTime currDate = new DateTime(2010, month, i);
//               if (startdate == DateTime.MinValue)
//               {
//                    startdate = currDate;
//               }
//               if (currDate.DayOfWeek == DayOfWeek.Saturday || i == daysinmonth)
//               {
//                    enddate = currDate;
//                    RenderDateRange(startdate, enddate);
//                    startdate = DateTime.MinValue;
//                    enddate = DateTime.MinValue;
//               }
//          }
//     }
////-------------------------------------------------------------------------------------------
//     private int GetDayNameinNumberForm(DayOfWeek dow)
//     {
//          switch (dow)
//          {
//               case DayOfWeek.Sunday: return 0;
//               case DayOfWeek.Monday: return 1;
//               case DayOfWeek.Tuesday: return 2;
//               case DayOfWeek.Wednesday: return 3;
//               case DayOfWeek.Thursday: return 4;
//               case DayOfWeek.Friday: return 5;
//               case DayOfWeek.Saturday: return 6;
//               default: return 0;
//          }
//     }
//-------------------------------------------------------------------------------------------
     //private void RenderDateRange(DateTime startDate, DateTime endDate)
     //{
     //     DateTime currDateTime = startDate;

     //     TableRow headerRow = new TableRow();
     //     headerRow.BackColor = System.Drawing.Color.AliceBlue;
     //     TableRow timeRow = new TableRow();

     //     int offset = GetDayNameinNumberForm(startDate.DayOfWeek);
     //     for (int x = 0; x < offset; x++)
     //     {
     //          TableCell headerCell = new TableCell();
     //          headerCell.BackColor = System.Drawing.Color.White;
     //          headerRow.Cells.Add(headerCell);
     //          timeRow.Cells.Add(new TableCell());
     //     }

     //     while (currDateTime <= endDate)
     //     {
     //          TableCell tcHeader = new TableCell();
     //          tcHeader.HorizontalAlign = HorizontalAlign.Center;
     //          tcHeader.Text = currDateTime.Day.ToString();
     //          tcHeader.ToolTip = currDateTime.ToString("MM/d/yy");
     //          headerRow.Cells.Add(tcHeader);

     //          TableCell tcTime = new TableCell();
     //          tcTime.HorizontalAlign = HorizontalAlign.Center;

     //          string date = LoggedInUser.Id.ToString() + "-" + currDateTime.ToString("yyyy/MM/d");
     //          var docs = db.Query("weavver.company.accounting.timelogs", "timelogs_sumbyday").Key(date).GetResult();
     //          if (docs.Count() > 0)
     //          {
     //               foreach (var doc in docs.Rows())
     //               {
     //                    tcTime.Text = doc["value"].ToString();
     //               }
     //          }
     //          else
     //          {
     //               tcTime.Text = "0";
     //          }
     //          timeRow.Cells.Add(tcTime);

     //          currDateTime = currDateTime.AddDays(1);
     //     }
     //     Report.Rows.Add(headerRow);
     //     Report.Rows.Add(timeRow);
     //}
//-------------------------------------------------------------------------------------------
}
