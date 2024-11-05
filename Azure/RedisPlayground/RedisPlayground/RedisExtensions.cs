using Newtonsoft.Json;
using RedisPlayground.Models;
using StackExchange.Redis;

namespace RedisPlayground;

public class RedisExtensions
{
    private readonly ConnectionMultiplexer _redis;
    private readonly string _redisHost;

    public RedisExtensions(string redisConnection, string redisHost)
    {
        Console.WriteLine($"host: {redisHost}: connecting to {redisConnection}");
        _redisHost = redisHost;
        _redis = ConnectionMultiplexer.Connect(redisConnection);
    }

    public List<string> GetAllKeys()
    {
        var listKeys = new List<string>();
        var keys = _redis.GetServer(_redisHost, 6380).Keys(pattern: "AccountLoanSummary").ToList();
        listKeys.AddRange(keys.Select(key => (string) key).ToList());
        return listKeys;
    }

    public async Task<List<AccountLoanSummary>> GetAllRecords(List<string> keys)
    {
        var db = _redis.GetDatabase();
        var results = new List<AccountLoanSummary>();
        var totalKeys = keys.Count;
        var count = 1;
        var errorCount = 0;
        foreach (var key in keys)
        {
            var redisValue = (await db.StringGetAsync(key)).ToString();
            // var accountLoanSummary = new AccountLoanSummary
            // {
            //     
            // }
            try
            {
                var decompressedResult = Extensions.Decompress(redisValue);
                var result = JsonConvert.DeserializeObject<AccountLoanSummary>(decompressedResult);
                
                results.Add(result);
                Console.WriteLine($"Grabbed {count}/{totalKeys} - {errorCount}");
                count++;
            }
            catch (Exception ex)
            {
                errorCount++;
            }
        }
        
        return results;
    }
}

public class NullConverter: JsonConverter
{
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        return existingValue;
    }

    public override bool CanConvert(Type objectType)
    {
        throw new NotImplementedException();
    }
}