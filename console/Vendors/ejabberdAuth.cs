using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Weavver.Security;

using MiscUtil.IO;

namespace Weavver.Vendors
{
     public class ejabberdAuth
     {
          public void Check()
          {
               System.IO.Stream reader = Console.OpenStandardInput();
               MiscUtil.Conversion.BigEndianBitConverter bebc = new MiscUtil.Conversion.BigEndianBitConverter();
               EndianBinaryWriter writer = new MiscUtil.IO.EndianBinaryWriter(bebc, Console.OpenStandardOutput());
               byte[] input = new byte[2];

               // is there a better way to check for data on the stream?
               while (reader.Read(input, 0, 2) > -1)
               {
                    ushort len = bebc.ToUInt16(input, 0);
                    byte[] incomingBytes = new byte[len];
                    reader.Read(incomingBytes, 0, len);
                    string incomingData = System.Text.Encoding.ASCII.GetString(incomingBytes);

                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\\output.log", true))
                    {
                         file.WriteLine(incomingData + "\r\n---------------------------------------\r\n");
                    }  

                    string[] parse = System.Text.RegularExpressions.Regex.Split(incomingData, ":");
                    string command = parse[0];
                    string username = parse[1];
                    string domain = parse[2];

                    short aa = 2;
                    writer.Write(aa);
                    short bbtrue = 1;
                    short bbfalse = 0;
                    switch (command)
                    {
                         case "auth":
                              if (domain == "web.chat")
                              {
                                   writer.Write(bbtrue);
                              }
                              else
                              {
                                   string password = parse[3];
                                   WeavverMembershipProvider wup = new WeavverMembershipProvider();
                                   if (wup.ValidateUser(username, password))
                                   {
                                        writer.Write(bbtrue);
                                   }
                                   else
                                   {
                                        writer.Write(bbfalse);
                                   }
                              }
                              break;

                         case "isuser":
                              writer.Write(bbtrue);
                              break;

                         case "setpass":
                              writer.Write(bbfalse);
                              break;
                    }
               }
               System.Threading.Thread.Sleep(100);
          }
     }
}
