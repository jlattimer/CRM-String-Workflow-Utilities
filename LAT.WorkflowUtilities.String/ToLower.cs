using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.String
{
    public sealed class ToLower : WorkFlowActivityBase
    {
        public ToLower() : base(typeof(ToLower)) { }

        [RequiredArgument]
        [Input("String To Lower")]
        public InArgument<string> StringToLower { get; set; }

        [Output("Lowered String")]
        public OutArgument<string> LoweredString { get; set; }

        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            string stringToLower = StringToLower.Get(context);

            string loweredString = stringToLower.ToLower();

            LoweredString.Set(context, loweredString);
        }
    }
}