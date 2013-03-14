using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Activities.DurableInstancing;
using System.Workflow.Runtime.Tracking;
using System.Workflow.Runtime;
using System.Configuration;

public partial class System_FieldChangeWorkflow : SkeletonPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
         SqlTrackingQueryOptions options = new SqlTrackingQueryOptions();
         options.WorkflowStatus = WorkflowStatus.Running;
         SqlTrackingQuery query = new SqlTrackingQuery(ConfigurationManager.ConnectionStrings["workflows"].ConnectionString);
         IList<SqlTrackingWorkflowInstance> workflows = query.GetWorkflows(options);
         foreach (SqlTrackingWorkflowInstance workflow in workflows)
         {
              foreach (WorkflowTrackingRecord workflowEvent in workflow.WorkflowEvents)
              {
                   TrackingWorkflowTerminatedEventArgs args = workflowEvent.EventArgs as TrackingWorkflowTerminatedEventArgs;
                   if (args != null)
                   {
                        Response.Write(workflow.WorkflowInstanceId + ": " + args.Exception.Message);
                   }
              }
         }
    }
}