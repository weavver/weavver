using System;
using System.Collections.Generic;
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

using Weavver.Data;
using Weavver.Sys;

public partial class System_Links : SkeletonPage
{
//-------------------------------------------------------------------------------------------
     protected void Page_Init(object sender, EventArgs e)
     {
          List.ItemDataBound += new DataGridItemEventHandler(List_ItemDataBound);

          Master.FormTitle = "Links";
          Master.FixedWidth = false;
     }
//-------------------------------------------------------------------------------------------
     protected void Page_Load(object sender, EventArgs e)
     {
          //ICriteria criteria = DatabaseHelper.Session.CreateCriteria(typeof(DataLink))
          //     .Add(NHibernate.Criterion.Restrictions.Eq("OrganizationId", SelectedOrganization.Id))
          //     //.Add(NHibernate.Criterion.Restrictions.Le("PublishAt", DateTime.Now))
          //     .AddOrder(NHibernate.Criterion.Order.Desc("UpdatedAt"));

          //List.DataKeyField = "Id";
          //List.DataSource = criteria.List<DataLink>();
          //List.DataBind();
     }
//-------------------------------------------------------------------------------------------
     protected void List_ItemDataBound(object sender, DataGridItemEventArgs e)
     {
          //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
          //{
          //     DataLink item = (DataLink) e.Item.DataItem;
          //     e.Item.Cells[6].Text = item.CreatedAt.Value.ToLocalTime().ToString("MM/dd/yy @ hh:mm tt");
          //}
     }
//-------------------------------------------------------------------------------------------
}
