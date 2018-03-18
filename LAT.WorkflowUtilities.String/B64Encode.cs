using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.String
{
    public sealed class B64Encode : WorkFlowActivityBase
    {
        public B64Encode() : base(typeof(B64Encode)) { } 

        [RequiredArgument]
        [Input("String To Encode")]
        public InArgument<string> StringToEncode { get; set; }

        [Output("B64 Encoded String")]
        public OutArgument<string> B64EncodedString { get; set; }

        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            string stringToEncode = StringToEncode.Get(context);

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(stringToEncode);

            string b64EncodedString = Convert.ToBase64String(plainTextBytes);

            B64EncodedString.Set(context, b64EncodedString);
        }
    }
}