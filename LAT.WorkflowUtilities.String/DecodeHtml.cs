using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Net;

namespace LAT.WorkflowUtilities.String
{
    public class DecodeHtml : CodeActivity
    {
        [RequiredArgument]
        [Input("String To Decode")]
        public InArgument<string> StringToDecode { get; set; }

        [Output("Decoded String")]
        public OutArgument<string> DecodedString { get; set; }

        protected override void Execute(CodeActivityContext executionContext)
        {
            ITracingService tracer = executionContext.GetExtension<ITracingService>();

            try
            {
                string strToDecode = StringToDecode.Get(executionContext);
                string decodedString = WebUtility.HtmlDecode(strToDecode);
                DecodedString.Set(executionContext, decodedString);
            }
            catch (Exception e)
            {
                tracer.Trace("Exception: {0}", e.ToString());
                throw new InvalidPluginExecutionException(e.Message);
            }
        }
    }
}
