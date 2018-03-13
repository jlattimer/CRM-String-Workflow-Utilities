using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Text.RegularExpressions;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.String
{
    public class RegexExtract : WorkFlowActivityBase
    {
        public RegexExtract() : base(typeof(RegexExtract)) { }

        [RequiredArgument]
        [Input("String To Search")]
        public InArgument<string> StringToSearch { get; set; }

        [RequiredArgument]
        [Input("Pattern")]
        public InArgument<string> Pattern { get; set; }

        [Output("Extracted String")]
        public OutArgument<string> ExtractedString { get; set; }

        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            string stringToSearch = StringToSearch.Get(context);
            string pattern = Pattern.Get(context);

            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            Match match = regex.Match(stringToSearch);

            if (match.Success)
            {
                string extractedString = match.Value;
                ExtractedString.Set(context, extractedString);
                return;
            }

            ExtractedString.Set(context, null);
        }
    }
}