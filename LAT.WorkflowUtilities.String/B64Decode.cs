using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.String
{
    public sealed class B64Decode : WorkFlowActivityBase
    {
        public B64Decode() : base(typeof(B64Decode)) { } 

        [RequiredArgument]
        [Input("String To Decode")]
        public InArgument<string> StringToDecode { get; set; }

        [Output("B64 Decoded String")]
        public OutArgument<string> B64DecodedString { get; set; }

        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            string stringToDencode = StringToDecode.Get(context);

            var base64EncodedBytes = Convert.FromBase64String(stringToDencode);

            string b64DecodedString = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

            B64DecodedString.Set(context, b64DecodedString);
        }
    }
}