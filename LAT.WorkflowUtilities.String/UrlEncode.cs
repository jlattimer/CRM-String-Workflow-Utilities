using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.String
{
    public class UrlEncode : WorkFlowActivityBase
    {
        public UrlEncode() : base(typeof(UrlEncode)) { }

        [RequiredArgument]
        [Input("String To Encode")]
        public InArgument<string> StringToEncode { get; set; }

        [Output("Encoded String")]
        public OutArgument<string> EncodedString { get; set; }

        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            string strToEncode = StringToEncode.Get(context);
            
            string encodedString = Uri.EscapeDataString(strToEncode);

            EncodedString.Set(context, encodedString);
        }
    }
}