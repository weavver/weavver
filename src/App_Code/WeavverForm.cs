using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Weavver.Web
{
     public class WeavverForm : System.Web.UI.HtmlControls.HtmlForm
     {
          protected bool _render;
//------------------------------------------------------------------------------------------
          public bool RenderFormTag
          {
               get { return _render; }
               set { _render = value; }
          }
//------------------------------------------------------------------------------------------
          public WeavverForm()
          {
               _render = true;
          }
//------------------------------------------------------------------------------------------
          protected override void RenderBeginTag(HtmlTextWriter writer)
          {
               if (_render)
                    base.RenderBeginTag(writer);
          }
//------------------------------------------------------------------------------------------
          protected override void RenderEndTag(HtmlTextWriter writer)
          {
               if (_render)
                    base.RenderEndTag(writer);
          }
//------------------------------------------------------------------------------------------
     }
}