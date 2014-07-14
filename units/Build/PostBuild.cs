using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weavver.Testing.App;

namespace Weavver.Testing.Staging
{
     public partial class Build
     {
          [ManualTest]
          public void RunTests()
          {
               Weavver.Testing.Accounting.Accounting_RecurringBillables rb = new Accounting.Accounting_RecurringBillables();
               rb.TestFixtureSetUp();
               rb.RunTest();
               rb.TestFixtureTearDown();

               Weavver.Testing.Sales.WebStore.ShoppingCart cart = new Weavver.Testing.Sales.WebStore.ShoppingCart();
               cart.TestFixtureSetUp();
               cart.PlaceOrder();
               cart.TestFixtureTearDown();

               WeavverApp app = new WeavverApp();
               app.TestFixtureSetUp();
               app.RunTests();
               app.TestFixtureTearDown();

               Weavver.Testing.Sales.SoftwareLicenseKeyService slkas = new Sales.SoftwareLicenseKeyService();
               slkas.RunTest();

               // VENDOR TESTS
               Weavver.Testing.Vendors.FreeSwitch.Directory fsDirectory = new Vendors.FreeSwitch.Directory();
               fsDirectory.RunTest();
          }
     }
}