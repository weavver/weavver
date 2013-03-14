using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

using PHP.Core;
using System.Configuration;

/// <summary>
/// To recompile the HTMLPurifier.php library use this: phpc /target:dll /out:HTMLPurifier.dll Library.php
/// 
/// Library.php:
/// 
/// <?
///  include "HTMLPurifier.standalone.php";
///
///  function Purify($dirty_html)
///  {
///      $purifier = new HTMLPurifier($config);
///      $clean_html = $purifier->purify( $dirty_html );
///      echo $clean_html;
///  }
///
/// ?>
/// </summary>
public class HTMLPurifierLib
{
	public HTMLPurifierLib()
	{
		//
		// TODO: Add constructor logic here
		//
	}

     public static string Purify(string unsafeHTML)
     {
          ScriptContext context = ScriptContext.CurrentContext;

          // redirect PHP output to the console:
          StringWriter sw = new StringWriter();
          context.Output = sw; // Unicode text output
          context.OutputStream = Console.OpenStandardOutput(); // byte stream output

          // include the Library.php script, which initializes the 
          // whole library (it is also possible to include more 
          // scripts if necessary by repeating this call with various 
          // relative script paths):
          context.Config.FileSystem.IncludePaths = Path.Combine(ConfigurationManager.AppSettings["base_folder"], @"Vendors\HTMLPurifier\");
          //context.WorkingDirectory = @"C:\Weavver\Main\Servers\web\c\Inetpub\www\";
          context.Include("Library.php", true);

          try
          {
               //int trimError = 0;
               //if (sw.ToString().Contains("HTMLPurifier_StringHash"))
               //     trimError = sw.GetStringBuilder().Remove(0, sw.ToString().Length);

               context.Call("Purify", unsafeHTML);
               return sw.ToString().Replace("[code]", "<div id=\"editor\" style=\"height:200px; width: 300px; position: relative;\">").Replace("[/code]", "</div>");
          }
          catch (Exception ex)
          {
               Weavver.Utilities.ErrorHandling.LogError(HttpContext.Current.Request, "htmlpurifierlib", ex);
               return "BAD HTML, PLEASE REFORM YOUR INPUT";
          }
     }
}

// create an instance of type C, passes array 
// ("a" => 1, "b" => 2) as an argument to the C's ctor:
//var c = (PhpObject)context.NewObject("C", PhpArray.Keyed("a", 1, "b", 2));

//// var_dump the object:
//PhpVariable.Dump(c);


//// call static method
//var foo = new PhpCallback("C", "foo", context);
//var ret1 = foo.Invoke(null, new object[] {/*arg1, arg2, ...*/});

//// call instance method
//var bar = new PhpCallback(c, "bar"); // PhpCallback of instance method
//var ret2 = bar.Invoke(null, new object[] {/*arg1, arg2, ...*/});