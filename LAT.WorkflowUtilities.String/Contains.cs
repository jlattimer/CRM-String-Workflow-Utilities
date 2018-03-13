using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.String
{
    public sealed class Contains : WorkFlowActivityBase
    {
        public Contains() : base(typeof(Contains)) { }

        [RequiredArgument]
        [Input("String To Search")]
        public InArgument<string> StringToSearch { get; set; }

        [RequiredArgument]
        [Input("Search For")]
        public InArgument<string> SearchFor { get; set; }

        [RequiredArgument]
        [Input("Case Sensitive")]
        [Default("false")]
        public InArgument<bool> CaseSensitive { get; set; }

        [Output("Contains String")]
        public OutArgument<bool> ContainsString { get; set; }

        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            string stringToSearch = StringToSearch.Get(context);
            string searchFor = SearchFor.Get(context);
            bool caseSensitive = CaseSensitive.Get(context);

            if (!caseSensitive)
            {
                stringToSearch = stringToSearch.ToUpper();
                searchFor = searchFor.ToUpper();
            }

            bool containsString = stringToSearch.Contains(searchFor);

            ContainsString.Set(context, containsString);
        }
    }
}