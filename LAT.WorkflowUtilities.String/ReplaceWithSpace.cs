using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.String
{
    public sealed class ReplaceWithSpace : WorkFlowActivityBase
    {
        public ReplaceWithSpace() : base(typeof(ReplaceWithSpace)) { }

        [RequiredArgument]
        [Input("String To Search")]
        public InArgument<string> StringToSearch { get; set; }

        [RequiredArgument]
        [Input("Value To Replace")]
        public InArgument<string> ValueToReplace { get; set; }

        [RequiredArgument]
        [Input("Number Of Spaces")]
        public InArgument<int> NumberOfSpaces { get; set; }

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
            int numberOfSpaces = NumberOfSpaces.Get(context);

            string spaces = "";
            spaces = spaces.PadRight(numberOfSpaces, ' ');

            string replacedString = stringToSearch.Replace(valueToReplace, spaces);

            ReplacedString.Set(context, replacedString);
        }
    }
}