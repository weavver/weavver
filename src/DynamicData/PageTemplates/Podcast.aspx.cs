using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Text;
using System.IO;

using System.Xml;

public partial class Feed : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
          string folderpath = @"/var/www/weavver.com/messages";
          if (!Directory.Exists(folderpath))
              return;

          XmlTextWriter writer    = new XmlTextWriter(Response.OutputStream, System.Text.Encoding.UTF8);
          writer.Indentation      = 5;
          writer.Formatting       = Formatting.Indented;
          WriteRSSPrologue(writer);
          int i = 0;

          Random r = new Random(10);
          foreach (string file in System.IO.Directory.GetFiles(folderpath))
          {
               if (file.EndsWith("wav"))
               {
                    string num = r.Next(10).ToString() + r.Next(10).ToString() + r.Next(10).ToString() + "-" + r.Next(10).ToString() + r.Next(10).ToString() + r.Next(10).ToString() + r.Next(10).ToString();
                    AddRSSItem(writer, "Jane Doe left you a message from 714-" + num, file, System.IO.Path.GetFileName(file), DateTime.Now.Subtract(TimeSpan.FromDays(i)).ToString("r"));
                    i++;
               }
               if (i > 10)
               {
                    break;
               }
          }
          WriteRSSClosing(writer);
          writer.Flush();
          writer.Close();

          Response.ContentEncoding = System.Text.Encoding.UTF8;
          Response.ContentType     = "text/xml";
          Response.Cache.SetCacheability(HttpCacheability.Private);
          Response.End();
     }

     public XmlTextWriter WriteRSSPrologue(XmlTextWriter writer)
     { 
          writer.WriteStartDocument();
          writer.WriteStartElement("rss");
          writer.WriteAttributeString("version",           "2.0");
          //writer.WriteAttributeString("xmlns:atom",        "xmlns:blogChannel", "http://feeds.weavver.com");
          writer.WriteStartElement("channel");
          writer.WriteElementString("title",               "John Doe's Weavver Feed");
          writer.WriteElementString("link",                "http://my.weavver.com");
          writer.WriteElementString("language",            "en-us");
          writer.WriteElementString("description",         "");
          writer.WriteElementString("copyright",           "Copyright 2002-2003 Feed");
          writer.WriteElementString("generator",           "Weavver Syndication");
          return writer;
     }

     public XmlTextWriter AddRSSItem(XmlTextWriter writer, string sItemTitle, string sItemLink, string sItemDescription, string datetime)
     {
          string itemname = System.IO.Path.GetFileName(sItemLink);
          writer.WriteStartElement("item");
               writer.WriteElementString("title",       sItemTitle);
               writer.WriteElementString("link",        "http://www.weavver.com/?redirect=" + itemname);
               writer.WriteElementString("description", "");
               writer.WriteElementString("author",      "Jane Doe");
               writer.WriteElementString("contact",     "tel://17148531212");
               writer.WriteElementString("pubDate",     datetime);
               writer.WriteElementString("tags",        "Unheard,Work");
               writer.WriteStartElement("enclosure");
                    writer.WriteAttributeString("url",                 "http://www.weavver.com/messages/" + itemname);
                    writer.WriteAttributeString("length",              "572345");
                    writer.WriteAttributeString("type",                "audio/wav");
                    writer.WriteStartElement("transcription");
                         writer.WriteAttributeString("confidence", "1.0");
                         writer.WriteValue("THIS IS THE TRANSCRIPTION.");
                    writer.WriteEndElement();
               writer.WriteEndElement();
          writer.WriteEndElement();
          return writer;
     }

     public XmlTextWriter WriteRSSClosing(XmlTextWriter writer)
     {
       writer.WriteEndElement();
       writer.WriteEndElement();
       writer.WriteEndDocument();

       return writer;
     }
}
