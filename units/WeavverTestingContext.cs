using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Weavver.Testing;

namespace Weavver.Units
{
     public class WeavverTestingContext : WeavverTest
     {
//-------------------------------------------------------------------------------------------
          public string RepoPath
          {
               get
               {
                    string repoPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    return Directory.GetParent(repoPath).Parent.Parent.FullName;
               }
          }
//-------------------------------------------------------------------------------------------
     }
}
