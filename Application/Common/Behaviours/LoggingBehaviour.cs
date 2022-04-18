using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Common.Behaviours
{
    /// <summary>
    /// Mediatr pipeline to trace in a log all request made by a CorrelationId.
    /// </summary>
    /// <typeparam name="TRequest"></typeparam> Request
    /// <typeparam name="TResponse"></typeparam> Response
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var requestName = request.GetType().Name;
            var correlationId = Guid.NewGuid().ToString();

            _logger.LogInformation($"[START] [{correlationId}] {requestName} ");

            var stopWatch = Stopwatch.StartNew();

            try
            {
                try
                {
                    _logger.LogInformation($"[REQUEST] [{correlationId}] {requestName} {JsonSerializer.Serialize(request)}");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"[SERIALIZE ERROR] [{correlationId}] {requestName} Error when the request is serialized");
                }

                try
                {
                    return await next();
                     
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex,"[ERROR] [{@correlationId}] {@requestName} Unhandled Exception for Request {@Request}", correlationId, requestName, request);
                    throw;
                }
            }
            finally
            {
                stopWatch.Stop();
                _logger.LogInformation($"[END] [{correlationId}] {requestName}; Completed in ={stopWatch.ElapsedMilliseconds}ms");
            }
        }
    }
}
