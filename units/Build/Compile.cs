using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml;

using Weavver.Data;

namespace Weavver.Testing.Staging
{
     //[TestFixture]
     public partial class Build
     {
//-------------------------------------------------------------------------------------------
          //[SetUp]
          public void SetUp()
          {
               //TestHelper.DatabaseHelper.InitializeSession();

               //var weavverdbConnString = Helper.GetAppSetting("staging_db");
               //Helper.DatabaseHelper.WVVRDB = new WeavverDatabase();
               //Helper.DatabaseHelper.WVVRDB.InitAsMSSQL(weavverdbConnString);
               ////Helper.DatabaseHelper.InitializeSession();
               //if (Helper.DatabaseHelper.WVVRDB.MSSQLDB.State != System.Data.ConnectionState.Open)
               //     Helper.DatabaseHelper.WVVRDB.MSSQLDB.Open();

               //TestHelper.DatabaseHelper.DeploySchema();
          }
//-------------------------------------------------------------------------------------------
          /// <summary>
          /// This does not check the /system/test page
          /// </summary>
          //[Test]
          public void CompileAllPages()
          {
          //     string basepath = System.Environment.CurrentDirectory;
          //     basepath = basepath.Substring(0, basepath.LastIndexOf(@"\"));
          //     foreach (string file in Directory.GetFiles(basepath, "*", SearchOption.AllDirectories))
          //     {
          //          if (Path.GetExtension(file) != ".aspx" || file.Contains(".wave-vs"))
          //               continue;
          //          string urlpath = file.Substring(basepath.Length + 1).Replace("\\", "/").ToLower() + "?testing=true";
          //          if (!urlpath.Contains("."))
          //          {
          //               urlpath += urlpath.Replace(".aspx", "");
          //          }
          //          urlpath = Helper.GetAppSetting("weavver_url") + urlpath;
          //          Console.WriteLine("Checking " + urlpath + "...");
          //          try
          //          {
          //               HttpWebRequest client = (HttpWebRequest) HttpWebRequest.Create(urlpath);
          //               HttpWebResponse response = (HttpWebResponse) client.GetResponse();
          //               if (response.StatusCode == HttpStatusCode.OK)
          //               {
          //                    Assert.AreEqual(response.StatusCode, HttpStatusCode.OK, "Page " + urlpath + ", " + HttpStatusCode.OK);
          //               }
          //               else
          //               {
          //                    throw new Exception("Page status: " + response.StatusCode.ToString() + "\r\nFile Path: " + file);
          //               }
          //          }
          //          catch (Exception ex)
          //          {
          //               Assert.Fail("Failed for url: " + urlpath + "\r\n\tMessage: " + ex.Message);
          //          }
          //     }
          }
//-------------------------------------------------------------------------------------------
//          [Test]
//          public void GetTableName()
//          {
//               //return;
//               //var helper = new Weavver.Data.WeavverDatabaseHelper();
//               //Account item = new Account();
//               //item.DatabaseHelper = helper;
//               //item.Id = Guid.NewGuid();
//               //item.AccountType = LedgerType.Savings;
//               //item.Name = "Bank Of America";
//               //item.CreatedAt = DateTime.UtcNow;
//               //item.CreatedBy = Guid.Empty;
//               //item.UpdatedAt = DateTime.UtcNow;
//               //item.UpdatedBy = Guid.Empty;
//               //item.Commit();

//               //string tablename = helper.FindTableNameById(item.Id, Helper.DatabaseHelper.WVVRDB.MSSQLDB);
//               //Assert.AreEqual("Accounting_Accounts", tablename);

//               //item.Delete();
//          }
////-------------------------------------------------------------------------------------------
//          [Test]
//          public void GetName()
//          {
//               //string objName = Helper.DatabaseHelper.GetName(new Guid("a25e3890-5ada-4a97-9127-faacc4664ec6"));
//               //Assert.AreEqual("Bank of America", objName); //should be: Bank of America
//          }
////-------------------------------------------------------------------------------------------
//          [Test]
//          public void GetTypePath()
//          {
//               //Assert.AreEqual("Unknown Class (VoiceScribe_Files)", Helper.DatabaseHelper.GetClassType(Guid.Empty));
//          }
//-------------------------------------------------------------------------------------------
          //[TearDown]
          public void TearDown()
          {
               //TestHelper.DatabaseHelper.WVVRDB.MSSQLDB.Close();
          }
//-------------------------------------------------------------------------------------------
     }
}