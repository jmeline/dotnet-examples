using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExpressionTreesAndRuleEngine.SampleRules;
using Shouldly;
using Xunit;
using Rule = ExpressionTreesAndRuleEngine.SampleRules.Rule;

namespace ExpressionTreesAndRuleEngine.Tests.SampleRules
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // List<Rule> rules = new List<Rule> 
            // {
            //     // Create some rules using LINQ.ExpressionTypes for the comparison operators
            //     
            //     new Rule ( "Year", ExpressionType.GreaterThan, "2012"),
            //     new Rule ( "Make", ExpressionType.Equal, "El Diablo"),
            //     new Rule ( "Model", ExpressionType.Equal, "Torch" )
            // };
            //
            // var compiledMakeModelYearRules = PreCompiledRules.CompileRule<ICar>(rules);
            //
            // // Create a list to house your test cars
            // var cars = new List<ICar>
            // {
            //     new Car { Year = 2011, Make = "El Diablo", Model = "Torche" },
            //     new Car { Year = 2015, Make = "El Diablo", Model = "Torch" }
            // };
            //
            //
            //
            // // Iterate through your list of cars to see which ones meet the rules vs. the ones that don't
            // cars.ForEach(car => {
            //     if (compiledMakeModelYearRules.TakeWhile(rule => rule(car)).Any())
            //     {
            //         car.Model.ShouldBe("Torch");
            //     }
            //     else
            //     {
            //         car.Model.ShouldBe("Torche");
            //     }
            // });
        }
    }
}