using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.String
{
    public sealed class Join : WorkFlowActivityBase
    {
        public Join() : base(typeof(Join)) { }

        [RequiredArgument]
        [Input("String 1")]
        public InArgument<string> String1 { get; set; }

        [RequiredArgument]
        [Input("String 2")]
        public InArgument<string> String2 { get; set; }

        [Input("Joiner")]
        public InArgument<string> Joiner { get; set; }

        [Output("Joined String")]
        public OutArgument<string> JoinedString { get; set; }

        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            string string1 = String1.Get(context);
            string string2 = String2.Get(context);
            string joiner = Joiner.Get(context);

            string joinedString = string.Join(joiner, string1, string2);

            JoinedString.Set(context, joinedString);
        }
    }
}