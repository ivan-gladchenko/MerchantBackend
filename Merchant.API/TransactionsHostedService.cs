using Merchant.Core;

namespace Merchant.API
{
    public class TransactionsHostedService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly ILogger<TransactionsHostedService> _logger;
        private Timer? _timer;
        private readonly IServiceScopeFactory scopeFactory;

        public TransactionsHostedService(ILogger<TransactionsHostedService> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            this.scopeFactory = scopeFactory;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(60));

            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            var count = Interlocked.Increment(ref executionCount);
            
            _logger.LogInformation(
                "Timed Hosted Service is working. Count: {Count}", count);
            using var scope = scopeFactory.CreateScope();
            var db =
                scope.ServiceProvider
                    .GetRequiredService<MerchantDbContext>();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
