using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using Shouldly;
using Xunit;

namespace ExpressionTreesAndRuleEngine.Tests.SampleRules
{
    public class DynamicExpressionsTests
    {
        public List<CarData> Cars { get; set; }

        public DynamicExpressionsTests()
        {
            Cars = LoadSampleData();
        }

        public Func<CarData, bool> CreateFunc(string expression, params string[] values)
        {
            return (Func<CarData, bool>) DynamicExpressionParser
                .ParseLambda(typeof(CarData), typeof(bool), expression, values.Length > 0 ? values : null)
                .Compile();
        }

        [Fact]
        public void BasicTest()
        {
            var values = new[] {"48", "100"};
            var func = CreateFunc("it.EngineSize <= @0 and it.Height > @1", values);
            var func2 = CreateFunc("EngineSize <= @0  and Height > \"100\"", "48");
            var func3 = CreateFunc("EngineSize <= \"48\" and Height > \"100\"");
            // var func4 = CreateFunc("Date >= DateTime(2010, 1, 1) and Date <= DateTime(2010, 7, 1)");
            // This will not work, haven't figured out why. Seems like I need to quote variables?
            //var func3 = CreateFunc("EngineSize <= 48 and Height > \"100\"");

            Cars.Where(func).Count().ShouldBe(139);
            Cars.Where(func2).Count().ShouldBe(139);
            Cars.Where(func3).Count().ShouldBe(139);
            //Cars.Where(func4).Count().ShouldBe(89);
        }
        
        // [Fact]
        // public void ManyFuncsTest()
        // {
        //     var funcs = new List<Func<CarData, bool>>
        //     {
        //         CreateFunc("NumberOrDoors == @0 or NumberOfCylinders > @1", "two", ""),
        //         CreateFunc("EngineSize <= @0 or Height > @1", "48", "100"),
        //         CreateFunc("EngineSize <= @0 or Height > @1", "48", "100")
        //     };
        //
        // }
        private List<CarData> LoadSampleData()
        {
            return File.ReadAllLines(@"../../../car_data.csv")
                .Skip(1)
                .Select(CarData.FromCsv)
                .ToList();
        }

    }
}