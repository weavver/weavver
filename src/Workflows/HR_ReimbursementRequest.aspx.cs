using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Workflow.Runtime.Tracking;
using System.Workflow.Runtime;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Configuration;
using System.Workflow.Runtime.Hosting;

using Weavver.Workflows;

public partial class Company_Accounting_ReimbursementRequests : SkeletonPage
{
     protected void Page_Load(object sender, EventArgs e)
     {
          Master.FormTitle = "Reimbursement Requests";
     }

     private void GetReimbursementVoid(Guid id)
     {
          // Initialize Windows Workflow Foundation
          WorkflowApplication _wfApp = new WorkflowApplication(new ReimbursementRequest());

          SqlWorkflowInstanceStore store = new SqlWorkflowInstanceStore(ConfigurationManager.ConnectionStrings["workflows"].ConnectionString);
          _wfApp.InstanceStore = store;
          _wfApp.PersistableIdle = delegate(WorkflowApplicationIdleEventArgs ex)
          {
               return PersistableIdleAction.Persist;
          };
          _wfApp.Run();
          _wfApp.Unload();
          Session["wfid"] = _wfApp.Id;
     }

     protected void NewWF_Click(object sender, EventArgs e)
     {
     }

     protected void Approve_Click(object sender, EventArgs e)
     {
          WorkflowApplication wfApp = (WorkflowApplication)Session["wf"];

          wfApp.ResumeBookmark("RequestApproval", "Approved");
          //3988df24-02aa-4e5b-9de3-5a925759dbc7
         
         //Guid workflowId = new Guid(Request["id"]);
     }
}