using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Text.RegularExpressions;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.String
{
    public sealed class RegexReplace : WorkFlowActivityBase
    {
        public RegexReplace() : base(typeof(RegexReplace)) { }

        [RequiredArgument]
        [Input("String To Search")]
        public InArgument<string> StringToSearch { get; set; }

        [Input("Replacement Value")]
        public InArgument<string> ReplacementValue { get; set; }

        [RequiredArgument]
        [Input("Pattern")]
        public InArgument<string> Pattern { get; set; }

        [Output("Replaced String")]
        public OutArgument<string> ReplacedString { get; set; }

        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            string stringToSearch = StringToSearch.Get(context);
            string replacementValue = ReplacementValue.Get(context);
            string pattern = Pattern.Get(context);

            if (string.IsNullOrEmpty(replacementValue))
                replacementValue = "";

            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            string replacedString = regex.Replace(stringToSearch, replacementValue);

            ReplacedString.Set(context, replacedString);
        }
    }
}