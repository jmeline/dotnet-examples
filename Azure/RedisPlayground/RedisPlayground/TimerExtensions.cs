using System.Diagnostics;

namespace RedisPlayground;

public static class TimerExtensions
{
    public static TOutput TimeIt<TOutput>(Func<TOutput> func)
    {
        var stopwatch = Stopwatch.StartNew();
        var output = func();
        stopwatch.Stop();
        var ts = stopwatch.Elapsed;
        Console.WriteLine($"Took: {ts.Minutes}Minutes, {ts.Seconds} seconds to execute");
        return output;
    }

    public static async Task<List<TOutput>> TimeItAsync<TOutput>(Func<Task<List<TOutput>>> func)
    {
        var stopwatch = Stopwatch.StartNew();
        var output = await func();
        stopwatch.Stop();
        var ts = stopwatch.Elapsed;
        Console.WriteLine($"Took: {ts.Minutes}Minutes, {ts.Seconds} seconds to execute");
        return output;
    }
}