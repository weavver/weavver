using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Activities;
using System.Activities.Hosting;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Configuration;

using Weavver.Workflows;

public partial class Workflows : SkeletonPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
         //List.ItemDataBound += new DataGridItemEventHandler(List_ItemDataBound);
         //using (var ctx = new WorkflowContainer())
         //{
         //     var items = from x in ctx.InstancesTables
         //                 //orderby comp.
         //                 select new { x.Id, x.CreationTime, x.BlockingBookmarks };

         //     List.DataKeyField = "Id";
         //     List.DataSource = items;
         //     List.DataBind();
         //}



         //WorkflowRuntime workflowRuntime = new WorkflowRuntime();
         //SqlWorkflowPersistenceService persister = new SqlWorkflowPersistenceService(ConfigurationManager.ConnectionStrings["workflows"].ConnectionString, false, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(5));
         //workflowRuntime.AddService(persister);
         //workflowRuntime.StartRuntime();
         //System.Workflow.Runtime.WorkflowInstance inst = workflowRuntime.GetWorkflow(new Guid("d2a3178b-bf58-476b-a09e-7b8132b1c797"));
         //workflowRuntime.StopRuntime();
         //WorkflowInst
    }

    void List_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
         if (e.Item.ItemType == ListItemType.Item)
         {
              //dynamic x = e.Item.DataItem as dynamic;
              //Response.Write(x.Id);ance inst;
              //inst.i
              //inst.
         }
    }
}