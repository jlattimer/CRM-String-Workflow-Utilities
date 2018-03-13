using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.String
{
    public sealed class ToUpper : WorkFlowActivityBase
    {
        public ToUpper() : base(typeof(ToUpper)) { }

        [RequiredArgument]
        [Input("String To Upper")]
        public InArgument<string> StringToUpper { get; set; }

        [Output("Uppered String")]
        public OutArgument<string> UpperedString { get; set; }

        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            string stringToUpper = StringToUpper.Get(context);
            string upperedString = stringToUpper.ToUpper();

            UpperedString.Set(context, upperedString);
        }
    }
}