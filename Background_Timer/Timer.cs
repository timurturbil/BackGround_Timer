namespace Background_Timer
{
    public class Timer : BackgroundService
    {
        private readonly ILogger<Timer> _logger;

        public Timer(ILogger<Timer> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
           
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Timer running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
                //var isContinue = CheckIfContinue();
                //if (isContinue){
                //    _logger.LogInformation("Timer running at: {time}", DateTimeOffset.Now);
                //    await Task.Delay(1000, stoppingToken);
                //    continue;
                //      }
                //else{
                //    break;
                //  }
            }
        }
    }
}
