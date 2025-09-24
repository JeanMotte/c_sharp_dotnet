using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;
using GenericHostDemo.Config;

namespace GenericHostDemo.Services
{
    public class MyService : BackgroundService
    {
        private readonly ILogger<MyService> _logger;
        private readonly IOptions<MyConfig> _config;

        public MyService(ILogger<MyService> logger, IOptions<MyConfig> config)
        {
            _logger = logger;
            _config = config;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Service démaré!!");
            MyConfig cf = _config.Value;
            _logger.LogInformation("Message injecté : {Message}", cf.Message);

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Service fonctionne");
                await Task.Delay(5000, stoppingToken);
            }
            _logger.LogInformation("Service arrête.");
        }
    }
}