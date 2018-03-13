using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Text.RegularExpressions;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.String
{
    public sealed class RegexReplaceWithSpace : WorkFlowActivityBase
    {
        public RegexReplaceWithSpace() : base(typeof(RegexReplaceWithSpace)) { }

        [RequiredArgument]
        [Input("String To Search")]
        public InArgument<string> StringToSearch { get; set; }

        [RequiredArgument]
        [Input("Number Of Spaces")]
        public InArgument<int> NumberOfSpaces { get; set; }

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
            int numberOfSpaces = NumberOfSpaces.Get(context);
            string pattern = Pattern.Get(context);

            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            string spaces = "";
            spaces = spaces.PadRight(numberOfSpaces, ' ');

            string replacedString = regex.Replace(stringToSearch, spaces);

            ReplacedString.Set(context, replacedString);
        }
    }
}