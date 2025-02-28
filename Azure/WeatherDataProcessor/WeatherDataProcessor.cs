using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace WeatherDataProcessor;

public static class WeatherDataProcessor
{
    [FunctionName("WeatherDataProcessor")]
    public static async Task RunAsync(
        [ServiceBusTrigger("add-weather-data", Connection = "WeatherDataConnection")] string myQueueItem,
        ILogger log)
    {
        log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        
    }
}