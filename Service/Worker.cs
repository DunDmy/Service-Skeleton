using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Service
{
    public class Worker : IHostedService //BackgroundService
    {

        private Timer _timer;
        private readonly ILogger<Worker> _logger;


        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        private void DoWork(object state)
        {
            //TODO: add logic here
            _logger.LogInformation("Timed Background Service is working.");
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is starting.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        // protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        // while (!stoppingToken.IsCancellationRequested)
        //{
        //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
        //  await Task.Delay(1000, stoppingToken);
        // }
        // }
    }
}
