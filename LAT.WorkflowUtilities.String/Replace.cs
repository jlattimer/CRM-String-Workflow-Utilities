using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.String
{
    public sealed class Replace : WorkFlowActivityBase
    {
        public Replace() : base(typeof(Replace)) { }

        [RequiredArgument]
        [Input("String To Search")]
        public InArgument<string> StringToSearch { get; set; }

        [RequiredArgument]
        [Input("Value To Replace")]
        public InArgument<string> ValueToReplace { get; set; }

        [Input("Replacement Value")]
        public InArgument<string> ReplacementValue { get; set; }

        [Output("Replaced String")]
        public OutArgument<string> ReplacedString { get; set; }

        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            string stringToSearch = StringToSearch.Get(context);
            string valueToReplace = ValueToReplace.Get(context);
            string replacementValue = ReplacementValue.Get(context);

            if (string.IsNullOrEmpty(replacementValue))
                replacementValue = "";

            string replacedString = stringToSearch.Replace(valueToReplace, replacementValue);

            ReplacedString.Set(context, replacedString);
        }
    }
}