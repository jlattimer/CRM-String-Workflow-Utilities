using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Net;

namespace LAT.WorkflowUtilities.String
{
    public class EncodeHtml : CodeActivity
    {
        [RequiredArgument]
        [Input("String To Encode")]
        public InArgument<string> StringToEncode { get; set; }

        [Output("Encoded String")]
        public OutArgument<string> EncodedString { get; set; }

        protected override void Execute(CodeActivityContext executionContext)
        {
            ITracingService tracer = executionContext.GetExtension<ITracingService>();

            try
            {
                string strToEncode = StringToEncode.Get(executionContext);
                string encodedString = WebUtility.HtmlEncode(strToEncode);
                EncodedString.Set(executionContext, encodedString);
            }
            catch (Exception e)
            {
                tracer.Trace("Exception: {0}", e.ToString());
                throw new InvalidPluginExecutionException(e.Message);
            }
        }
    }
}
