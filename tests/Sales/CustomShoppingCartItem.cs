using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weavver.Testing.Sales
{
     //[TestFixture]
     public partial class WebStore
     {
//-------------------------------------------------------------------------------------------
          //[SetUp]
          public void SetUp()
          {
               //TestHelper.DatabaseHelper.InitializeSession();

               //var weavverdbConnString = ConfigurationManager.AppSettings["staging_db"];
               //TestHelper.DatabaseHelper.WVVRDB = new WeavverDatabase();
               //TestHelper.DatabaseHelper.WVVRDB.InitAsMSSQL(weavverdbConnString);
               //if (TestHelper.DatabaseHelper.WVVRDB.MSSQLDB.State != System.Data.ConnectionState.Open)
               //     TestHelper.DatabaseHelper.WVVRDB.MSSQLDB.Open();

               //TestHelper.DatabaseHelper.DeploySchema();
          }
//-------------------------------------------------------------------------------------------
          /// <summary>
          /// This does not check the /system/test page
          /// </summary>
          //[Test]
          //public void AuthorizeNet()
          //{
          //     Weavver.Vendors.Authorize.Net.AMIGateway gateway = new Weavver.Vendors.Authorize.Net.AMIGateway();
          //}
//-------------------------------------------------------------------------------------------
          //[StagingTest]
          public void TestPlugin()
          {
          //     //string file = @"W:\Projects\Weavver\Main\Servers\web\c\Inetpub\www\Bin\";
          //     //string type = "CustomShoppingCartItem";
          //     //ShoppingCartItem item = ShoppingCartItem.GetInstance(file, type);
          //     //Assert.AreEqual("CustomShoppingCartItem", item.GetType().Name);
          //     //Order order = new Order();
          //     //item.ItemPurchased(order);
          //     return;
          }
//-------------------------------------------------------------------------------------------
          //[TearDown]
          public void TearDown()
          {
               //TestHelper.DatabaseHelper.WVVRDB.MSSQLDB.Close();
          }
//-------------------------------------------------------------------------------------------
     }
//-------------------------------------------------------------------------------------------
     //public class CustomShoppingCartItem : Weavver.Company.Sales.ShoppingCartItem
     //{
     //}
//-------------------------------------------------------------------------------------------
}
