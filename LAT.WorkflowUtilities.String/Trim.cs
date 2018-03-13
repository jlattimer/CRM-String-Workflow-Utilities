using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.String
{
    public class Trim : WorkFlowActivityBase
    {
        public Trim() : base(typeof(Trim)) { }

        [RequiredArgument]
        [Input("String To Trim")]
        public InArgument<string> StringToTrim { get; set; }

        [Output("Trimmed String")]
        public OutArgument<string> TrimmedString { get; set; }

        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            string stringToTrim = StringToTrim.Get(context);

            if (string.IsNullOrEmpty(stringToTrim))
            {
                TrimmedString.Set(context, stringToTrim);
                return;
            }

            string trimmedString = stringToTrim.Trim();

            TrimmedString.Set(context, trimmedString);
        }
    }
}