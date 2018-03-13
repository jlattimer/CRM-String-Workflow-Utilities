using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.String
{
    public sealed class Substring : WorkFlowActivityBase
    {
        public Substring() : base(typeof(Substring)) { }

        [RequiredArgument]
        [Input("String To Parse")]
        public InArgument<string> StringToParse { get; set; }

        [RequiredArgument]
        [Input("Start Position")]
        public InArgument<int> StartPosition { get; set; }

        [Input("Length")]
        public InArgument<int> Length { get; set; }

        [Output("Partial String")]
        public OutArgument<string> PartialString { get; set; }

        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            string stringToParse = StringToParse.Get(context);
            int startPosition = StartPosition.Get(context);
            int length = Length.Get(context);

            if (startPosition < 0)
                startPosition = 0;

            if (startPosition > stringToParse.Length)
            {
                localContext.TracingService.Trace("Specified start position [" + startPosition + "] is after end is string [" + stringToParse + "]");
                PartialString.Set(context, null);
            }

            if (length > stringToParse.Length)
                length = stringToParse.Length - startPosition;

            string partialString = (length == 0)
                ? stringToParse.Substring(startPosition)
                : stringToParse.Substring(startPosition, length);

            PartialString.Set(context, partialString);
        }
    }
}