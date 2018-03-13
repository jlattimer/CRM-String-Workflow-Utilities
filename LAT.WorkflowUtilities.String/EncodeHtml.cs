using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Net;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.String
{
    public class EncodeHtml : WorkFlowActivityBase
    {
        public EncodeHtml() : base(typeof(EncodeHtml)) { }

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
            string encodedString = WebUtility.HtmlEncode(strToEncode);

            EncodedString.Set(context, encodedString);
        }
    }
}