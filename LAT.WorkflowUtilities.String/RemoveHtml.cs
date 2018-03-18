using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Text.RegularExpressions;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.String
{
    public class RemoveHtml : WorkFlowActivityBase
    {
        public RemoveHtml() : base(typeof(RemoveHtml)) { }

        [RequiredArgument]
        [Input("HTML String")]
        public InArgument<string> HtmlString { get; set; }

        [Output("HTML Removed String")]
        public OutArgument<string> HtmlRemovedString { get; set; }

        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            string htmlString = HtmlString.Get(context);

            string replacedString = RemoveTags(htmlString);

            HtmlRemovedString.Set(context, replacedString);
        }

        public static string RemoveTags(string html)
        {
            if (string.IsNullOrEmpty(html))
                return html;

            //Remove line breaks 
            html = html.Replace(Environment.NewLine, "");
            html = html.Replace(@"\r\n", "");
            html = html.Replace(@"\r", "");
            html = html.Replace(@"\n", "");
            html = Regex.Replace(html, @"([^\r])\n", "$1 ");
            html = Regex.Replace(html, @"<o:p>&nbsp;</o:p>", "");

            //Compress white space
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            html = regex.Replace(html, " ");

            //Replace tags that cause a break
            html = html.Replace("<p>", "");
            html = html.Replace("</p>", "<br />");
            html = html.Replace("<br>", "<br />");
            html = html.Replace("<br/>", "<br />");
            html = html.Replace("</h1>", "<br />");
            html = html.Replace("</h2>", "<br />");
            html = html.Replace("</h3>", "<br />");
            html = html.Replace("</li>", "<br />");
            html = html.Replace("<br />", Environment.NewLine);

            //Remove tags
            Regex regHtml = new Regex("<[^>]*>", RegexOptions.IgnoreCase);
            html = regHtml.Replace(html, "");

            //Add back BR tags
            html = html.Replace(Environment.NewLine, "<br />");

            //Cleans up spaces around tags
            html = Regex.Replace(html, @"\s*(<[^>]+>)\s*", "$1", RegexOptions.Singleline);

            return html;
        }
    }
}