using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

namespace LAT.WorkflowUtilities.String
{
    //Contributed by RyanPerry 2019.08.02
    public sealed class SearchIndexOf : WorkFlowActivityBase
    {
        public SearchIndexOf() : base(typeof(SearchIndexOf)) { }

        [RequiredArgument]
        [Input("String To Parse")]
        public InArgument<string> StringToParse { get; set; }

        [RequiredArgument]
        [Input("Start Position")]
        public InArgument<int> StartPosition { get; set; }

        [Input("Search String")]
        public InArgument<string> SearchString { get; set; }

        [Output("IndexOf")]
        public OutArgument<int> FoundIndexOf { get; set; }

        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            string stringToParse = StringToParse.Get(context);
            int startPosition = StartPosition.Get(context);
            string searchString = SearchString.Get(context);
            int foundIndexOf = -1; //Default value if not found. 


            if (startPosition < 0)
                startPosition = 0;

            if (startPosition > stringToParse.Length)
            {
                localContext.TracingService.Trace("Specified start position [" + startPosition + "] is after end of string [" + stringToParse + "]");
                FoundIndexOf.Set(context, -1);
            }

            foundIndexOf = stringToParse.IndexOf(searchString, startPosition);
            FoundIndexOf.Set(context, foundIndexOf);

        }
    }
}