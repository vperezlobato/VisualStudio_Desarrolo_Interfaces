using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PongSignalR
{
    public class LoggingPipelineModule : HubPipelineModule
    {
        //Trazamos cualquier error no manejado aquí. No olvide registrar esta clase en la tubería.
        protected override void OnIncomingError(ExceptionContext exceptionContext, IHubIncomingInvokerContext invokerContext)
        {
            Trace.TraceError("=> Exception " + exceptionContext.Error.Message);
            if (exceptionContext.Error.InnerException != null)
            {
                Trace.TraceError("=> Inner Exception " + exceptionContext.Error.InnerException.Message);
            }

            base.OnIncomingError(exceptionContext, invokerContext);
        }
    }
}