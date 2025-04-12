using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>
        (ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull, IRequest<TResponse>
        where TResponse : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            logger.LogInformation("[START] Handle request={request} - Response={Respone} - RequestData={RequestData}",
                    typeof(TRequest).Name, typeof(TResponse).Name,request);

            var timer = new Stopwatch();
            timer.Start();

            var response = await next();

            timer.Stop();
            var TimeTake = timer.Elapsed;
            if(TimeTake.Seconds > 3)
            {
                logger.LogWarning("[PERFORMANCE] The Request {Request} took {TimeTake} ",
                    typeof(TRequest).Name, TimeTake.Seconds);
            }

            logger.LogInformation("[END] Handled {Request} with {Response}", typeof(TRequest).Name, typeof(TResponse).Name);
            return response;
        }
    }
}
