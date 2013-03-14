using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Collections.ObjectModel;

public partial class System_Tests_TimeZones : SkeletonPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
         DateTimeFormatInfo dateFormats = CultureInfo.CurrentCulture.DateTimeFormat;
      ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones(); 

      foreach (TimeZoneInfo timeZone in timeZones)
      {
         bool hasDST = timeZone.SupportsDaylightSavingTime;
         TimeSpan offsetFromUtc = timeZone.BaseUtcOffset;
         TimeZoneInfo.AdjustmentRule[] adjustRules;
         string offsetString;

         Response.Write(String.Format("ID: {0}", timeZone.Id) + "<br />");
         //Response.Write(String.Format("   Display Name: {0, 40}", timeZone.DisplayName) + "<br />");
         //Response.Write(String.Format("   Standard Name: {0, 39}", timeZone.StandardName) + "<br />");
         //Response.Write(String.Format("   Daylight Name: {0, 39}", timeZone.DaylightName) + "<br />");
         //Response.Write(hasDST ? "   ***Has " : "   ***Does Not Have " + "<br />");
         //Response.Write("Daylight Saving Time***" + "<br />");
         //offsetString = String.Format("{0} hours, {1} minutes", offsetFromUtc.Hours, offsetFromUtc.Minutes) + "<br />";
         //Response.Write(String.Format("   Offset from UTC: {0, 40}", offsetString) + "<br />");
         //adjustRules = timeZone.GetAdjustmentRules();
         //Response.Write(String.Format("   Number of adjustment rules: {0, 26}", adjustRules.Length) + "<br />");
         //if (adjustRules.Length > 0)
         //{
         //     Response.Write("   Adjustment Rules:" + "<br />");
         //   foreach (TimeZoneInfo.AdjustmentRule rule in adjustRules)
         //   {
         //      TimeZoneInfo.TransitionTime transTimeStart = rule.DaylightTransitionStart;
         //      TimeZoneInfo.TransitionTime transTimeEnd = rule.DaylightTransitionEnd;

         //      Response.Write(String.Format("      From {0} to {1}", rule.DateStart, rule.DateEnd) + "<br />");
         //      Response.Write(String.Format("      Delta: {0}", rule.DaylightDelta) + "<br />");
         //      if (! transTimeStart.IsFixedDateRule)
         //      {
         //           Response.Write(String.Format("      Begins at {0:t} on {1} of week {2} of {3}", transTimeStart.TimeOfDay, 
         //                                                                       transTimeStart.DayOfWeek,                                                                                 
         //                                                                       transTimeStart.Week,
         //                                                                       dateFormats.MonthNames[transTimeStart.Month - 1]) + "<br />");
         //           Response.Write(String.Format("      Ends at {0:t} on {1} of week {2} of {3}", transTimeEnd.TimeOfDay,
         //                                                                       transTimeEnd.DayOfWeek, 
         //                                                                       transTimeEnd.Week,
         //                                                                       dateFormats.MonthNames[transTimeEnd.Month - 1]) + "<br />");
         //      }
         //      else
         //      {
         //           Response.Write(String.Format("      Begins at {0:t} on {1} {2}", transTimeStart.TimeOfDay, 
         //                                                        transTimeStart.Day,
         //                                                        dateFormats.MonthNames[transTimeStart.Month - 1]) + "<br />");
         //           Response.Write(String.Format("      Ends at {0:t} on {1} {2}", transTimeEnd.TimeOfDay, 
         //                                                      transTimeEnd.Day,
         //                                                      dateFormats.MonthNames[transTimeEnd.Month - 1]) + "<br />");
         //      }
         //   }
         //}            
   }
    }
}