using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.String
{
    public class CreateEmptySpaces : WorkFlowActivityBase
    {
        public CreateEmptySpaces() : base(typeof(CreateEmptySpaces)) { }

        [RequiredArgument]
        [Input("Number Of Spaces")]
        public InArgument<int> NumberOfSpaces { get; set; }

        [Output("Empty String")]
        public OutArgument<string> EmptyString { get; set; }

        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            int numberOfSpaces = NumberOfSpaces.Get(context);

            string emptyString = new string(' ', numberOfSpaces);

            EmptyString.Set(context, emptyString);
        }
    }
}