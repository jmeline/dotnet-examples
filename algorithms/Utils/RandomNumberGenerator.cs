using System;
using System.Linq;

namespace Algorithms.Utils
{
    public static class RandomNumberGenerator
    {
        public static int[] GenerateRandomIntArray(int repeats, int max = 2000)
        {
            var randNum = new Random();
            return Enumerable
                .Repeat(0, repeats)
                .Select(i => randNum.Next(1, max))
                .ToArray();
        }
    }
}