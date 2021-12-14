using Background_Timer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Background_Timer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        readonly IHost host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddHostedService<Timer>();
            })
            .Build();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task StartTimer()
        {
            Console.WriteLine("StartTimer");
            await host.RunAsync();
            //await host.StartAsync();
        }
        [HttpPost]
        public async Task StopTimer1()
        {
            Console.WriteLine("StopTimer1");
            await host.StopAsync();
            //await host.StopAsync(cancellationToken: CancellationToken.None);
            //await host.WaitForShutdownAsync();
            //host.Dispose();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}