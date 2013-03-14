using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DynamicData_QuickAdd_HR_TimeLogs : WeavverUserControl
{
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {

     }
//-------------------------------------------------------------------------------------------
     protected void QuickPunch_Click(object sender, EventArgs e)
     {
     //     Guid employeeId = HRHelper.GetEmployeeIdByUserId(LoggedInUser.Id);
     //     if (employeeId != Guid.Empty)
     //     {
     //          HRHelper.PunchIn(SelectedOrganization.Id, employeeId);
     //     }
     //     else
     //     {
     //          ShowError("Your login is not associated with an Employee/Staff ID. Please fix this database error.");
     //     }
     //     UpdatePage();
     }
     ////-------------------------------------------------------------------------------------------
     //protected void QuickPunchOut_Click(object sender, EventArgs e)
     //{
     //     HRHelper.PunchOut(TimeLogId);
     //     UpdatePage();
     //}
//-------------------------------------------------------------------------------------------
}