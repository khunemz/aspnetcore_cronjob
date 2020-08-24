using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WebApplication1.Repository;

namespace WebApplication1.CronJob
{
    public class MyCronJob : CronJobService
    {
        private readonly ILogger<MyCronJob> _logger;
        private ICronJobRepository _repo;

        public MyCronJob(IScheduleConfig<MyCronJob> config, ILogger<MyCronJob> logger, ICronJobRepository repo)
            : base(config.CronExpression, config.TimeZoneInfo )
        {
            _logger = logger;
            _repo = repo;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CronJob starts.");
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{DateTime.Now:hh:mm:ss} CronJob is working.");
            _repo.WriteDebugTrace($"{DateTime.Now:hh:mm:ss} CronJob repository is also working.");
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CronJob is stopping.");
            return base.StopAsync(cancellationToken);
        }
    }
}
