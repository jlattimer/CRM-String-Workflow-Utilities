using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Net;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.String
{
    public class DecodeHtml : WorkFlowActivityBase
    {
        public DecodeHtml() : base(typeof(DecodeHtml)) { }

        [RequiredArgument]
        [Input("String To Decode")]
        public InArgument<string> StringToDecode { get; set; }

        [Output("Decoded String")]
        public OutArgument<string> DecodedString { get; set; }

        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            string strToDecode = StringToDecode.Get(context);
            string decodedString = WebUtility.HtmlDecode(strToDecode);

            DecodedString.Set(context, decodedString);
        }
    }
}