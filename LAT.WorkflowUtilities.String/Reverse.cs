using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.String
{
    public sealed class Reverse : WorkFlowActivityBase
    {
        public Reverse() : base(typeof(Reverse)) { }

        [RequiredArgument]
        [Input("String To Reverse")]
        public InArgument<string> StringToReverse { get; set; }

        [Output("Reversed String")]
        public OutArgument<string> ReversedString { get; set; }

        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            string stringToReverse = StringToReverse.Get(context);

            char[] letters = stringToReverse.ToCharArray();
            Array.Reverse(letters);
            string reversedString = new string(letters);

            ReversedString.Set(context, reversedString);
        }
    }
}