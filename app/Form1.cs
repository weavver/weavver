using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace Weavver_App
{
     public partial class Form1 : Form
     {
          CassiniDev.Server serv = null;
          System.Diagnostics.Process proc = new System.Diagnostics.Process();

          public Form1()
          {
               InitializeComponent();
          }

          private void Form1_Load(object sender, EventArgs e)
          {
               int port = 8080;
               //while (!Weavver.Net.Helper.IsPortAvailable(port))
               //{
               //     port++;
               //}

               webBrowser1.Navigate("about:blank");
               webBrowser1.Document.Write("Loading...");
               string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase );
               //path = path.Substring(6);
               path = path.Substring(0, path.LastIndexOf("\\"));
               string dir = path + "\\www\\";

#if DEBUG
               dir = @"C:\Weavver\Main\Servers\web\c\Inetpub\www";
#endif

               //proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
               //proc.StartInfo.FileName = path + @"\vendors\Apache\couchdb\bin\erl.exe";
               //proc.StartInfo.Arguments = "-sasl errlog_type error -s couch";
               //proc.StartInfo.WorkingDirectory = @"C:\Program Files (x86)\Weavver\Core\vendors\Apache\couchdb\bin";
               //proc.Start();

               //dir = @"C:\Program Files\Weavver\Core\www\";

               serv = new CassiniDev.Server(port, "/", dir);
               serv.Start();
               webBrowser1.Navigate("http://www.weavver.local:" + port + "/");
          }

          private void Form1_FormClosing(object sender, FormClosingEventArgs e)
          {
               serv.ShutDown();
          }
     }
}
