<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Marketing_Blogs.ascx.cs" Inherits="DynamicData_EntityTemplates_Accounting_Checks" %>

<div class="blog" style="border: solid 0px black;">
     <div style="padding: 3px; padding-bottom: 15px;">
          <div style="float:right;" title="<%# Eval("UpdatedAt") %>">
               <table style="padding-left: 25px; padding-top: 5px;" cellpadding="0" cellspacing="0">
               <tr>
                    <td>Published @ </td>
                    <td><asp:DynamicControl ID="DynamicControl3" runat="server" DataField="PublishAt" OnInit="DynamicControl_Init" /></td>
               </tr>
               </table>
          </div>
          <h2><asp:DynamicControl ID="DynamicControl2" runat="server" DataField="Title" OnInit="DynamicControl_Init" /></h2>
          <div class="blog-body" style="clear:both;">
               <asp:DynamicControl ID="DynamicControl1" runat="server" DataField="Body" OnInit="DynamicControl_Init" />
          </div>
     </div>
     <div style="margin-left: 60px; margin-right: 20px; padding: 10px; padding-bottom: 0px;"></div>
</div>
<asp:Panel ID="ItemView" runat="server" Visible="false">
     <div id="disqus_thread"></div>
     <asp:Literal ID="DisqusJS" runat="server"></asp:Literal>
     <script type="text/javascript">
          /* * * CONFIGURATION VARIABLES: EDIT BEFORE PASTING INTO YOUR WEBPAGE * * */
              
          // The following are highly recommended additional parameters. Remove the slashes in front to use.
          // var disqus_identifier = 'unique_dynamic_id_1234';
          // var disqus_url = 'http://example.com/permalink-to-page.html';

          /* * * DON'T EDIT BELOW THIS LINE * * */
          (function() {
               var dsq = document.createElement('script'); dsq.type = 'text/javascript'; dsq.async = true;
               dsq.src = 'http://' + disqus_shortname + '.disqus.com/embed.js';
               (document.getElementsByTagName('head')[0] || document.getElementsByTagName('body')[0]).appendChild(dsq);
          })();
     </script>
     <noscript>Please enable JavaScript to view the <a href="http://disqus.com/?ref_noscript">comments powered by Disqus.</a></noscript>
     <a href="http://disqus.com" class="dsq-brlink">blog comments powered by <span class="logo-disqus">Disqus</span></a>
     <br />
     <br />
     <div style="background-image: url('/images/Marketing/SquareDivider.png'); height:75px; margin-top: 10px; clear:both; margin-bottom: 30px;"></div>
</asp:Panel>