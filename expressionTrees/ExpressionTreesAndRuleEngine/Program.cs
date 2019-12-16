using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionTreesAndRuleEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Rule> rules = new List<Rule> 
            {
                // Create some rules using LINQ.ExpressionTypes for the comparison operators
                
                new Rule ( "Year", ExpressionType.GreaterThan, "2012"),
                new Rule ( "Make", ExpressionType.Equal, "El Diablo"),
                new Rule ( "Model", ExpressionType.Equal, "Torch" )
            };

            var compiledMakeModelYearRules = PreCompiledRules.CompileRule<ICar>(rules);

            // Create a list to house your test cars
            var cars = new List<ICar>
            {
                new Car { Year = 2011, Make = "El Diablo", Model = "Torche" },
                new Car { Year = 2015, Make = "El Diablo", Model = "Torch" }
            };
            
            // Iterate through your list of cars to see which ones meet the rules vs. the ones that don't
            cars.ForEach(car => {
                if (compiledMakeModelYearRules.TakeWhile(rule => rule(car)).Any())
                {
                    Console.WriteLine(string.Concat("Car model: ", car.Model, " Passed the compiled rules engine check!"));
                }
                else
                {
                    Console.WriteLine(string.Concat("Car model: ", car.Model, " Failed the compiled rules engine check!"));
                }
            });
            
            Console.WriteLine("Press any key to end...");
            Console.ReadKey();
            Console.WriteLine("Hello World!");
        }
    }
}