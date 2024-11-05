// See https://aka.ms/new-console-template for more information

using RedisPlayground;


// var devRedisHost = "localhost";
// var devRedisPort = 6380;
// var devRedisConnection = "localhost:6379";
// var devRedisConnection = "";
var testRedisConnection = "";
var testRedisHost = "";

var redisExtensions = new RedisExtensions(testRedisConnection, testRedisHost);

var keys = TimerExtensions.TimeIt(redisExtensions.GetAllKeys);
var results = await TimerExtensions.TimeItAsync(() => redisExtensions.GetAllRecords(keys));

Console.WriteLine($"Got back {results.Count} results");
