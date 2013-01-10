using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

using Weavver.Data;

/// <summary>
/// Summary description for WebServices
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class WebServices : System.Web.Services.WebService
{
//-------------------------------------------------------------------------------------------
     public WebServices()
     {
     }
//-------------------------------------------------------------------------------------------
     //[System.Web.Services.WebMethod]
     //[System.Web.Script.Services.ScriptMethod]
     //public string[] GetPayeeList(string prefixText, int count, string contextKey)
     //{
     //     Guid orgId = new Guid(contextKey);
     //     //string[] list = { "dog", "cat" };
     //     WeavverDatabaseHelper DatabaseHelper = new WeavverDatabaseHelper();
     //     DatabaseHelper.InitializeSession();
     //     LogisticsHelper logistics = new LogisticsHelper();
     //     logistics.DatabaseHelper = DatabaseHelper;

     //     ICriteria criteria = DatabaseHelper.Session.CreateCriteria(typeof(Logistics_Organizations))
     //               .Add(NHibernate.Criterion.Expression.Or(Restrictions.Eq("OrganizationId", orgId), Restrictions.Eq("Id", orgId)))
     //               .Add(NHibernate.Criterion.Restrictions.Like("Name", prefixText + "%"));
     //     var docs = criteria.List();
     //     List<string> itemList = new List<string>();
     //     foreach (var doc in docs)
     //     {
     //          Organization item = (Organization) doc;
     //          string keypair = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(item.Name, item.Id.ToString());
     //          itemList.Add(keypair);
     //     }
     //     return itemList.ToArray();
     //}
//-------------------------------------------------------------------------------------------
}

