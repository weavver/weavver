using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Weavver.Testing;

namespace Weavver.Units
{
     public static class WeavverUnitContext
     {
//-------------------------------------------------------------------------------------------
          public static string RepoPath
          {
               get
               {
                    string repoPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    return Directory.GetParent(repoPath).Parent.Parent.Parent.FullName;
               }
          }
//-------------------------------------------------------------------------------------------
     }
}
