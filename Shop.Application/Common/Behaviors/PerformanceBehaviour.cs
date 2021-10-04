using MediatR;
using Microsoft.Extensions.Logging;
using Shop.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Common.Behaviors
{
    public class PerformanceBehavior<TRequest, TResponce> : IPipelineBehavior<TRequest, TResponce>
    {

        private readonly Stopwatch _stopwatch;
        private readonly ICurrentUserService _currentUserService;
        private readonly ILogger<TRequest> _logger; 


        public PerformanceBehavior(ICurrentUserService currentUserService, ILogger<TRequest> logger)
        {
            _stopwatch = new Stopwatch();
            _currentUserService = currentUserService;
            _logger = logger;
        }
        public async Task<TResponce> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponce> next)
        {
            // przed wykonaniem delegata
            _stopwatch.Start();

            // wykonywany przekazywany delegat
            var responce = await next();

            // po wykoaniu delegata
            _stopwatch.Stop();

            var elapsedMiliseconds = _stopwatch.ElapsedMilliseconds;

            if (elapsedMiliseconds > 500)
            {
                var requestName = typeof(TRequest).Name;
                var userId = _currentUserService.UserId ?? string.Empty;
                _logger.LogWarning($"Long Request {requestName} {elapsedMiliseconds} ms ");
            }

            return responce;
        }
    }
}
