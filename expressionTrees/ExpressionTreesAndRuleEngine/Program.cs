using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using ExpressionTreesAndRuleEngine.DataAccess;
using ExpressionTreesAndRuleEngine.Infrastructure;
using ExpressionTreesAndRuleEngine.SampleRules;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Dynamic.Core;

namespace ExpressionTreesAndRuleEngine
{
    public class Program
    {
        public static void Main()
        {
            // build sql database
            // CreateRulesTable(connect);
            // InsertDummyData(connect);
            
            var provider = new ServiceProviderGenerator().SetupServiceProvider();
            
            var dbAccess = provider.GetService<IDataAccess>();
            var rules = dbAccess.LoadRules();
            var funcs = PreCompiledRules.CompileRule<Car>(rules);

            var cars = new List<Car>
            {
                new Car {Make = "El Diablo", Model = "Torch", Year = 2013},
                new Car {Make = "El Diablo", Model = "Torche", Year = 2012},
                new Car {Make = "El Diabl", Model = "Torch", Year = 2012},
                new Car {Make = "El Diabl", Model = "Torch", Year = 2010}
            };

            
            var IsCoolCar = (Func<Car, bool>) DynamicExpressionParser
                .ParseLambda(
                    typeof(Car),
                    typeof(bool),
                    "Make == @0 && Year == @1",
                    "El Diablo",
                    2012)
                .Compile();
            Console.WriteLine(cars
                .Where(IsCoolCar)
                .Select(x => $"{x.Make} {x.Model} {x.Year}"));
            // Console.WriteLine(func(cars.First()));
            
            var results = cars
                .Where(model => funcs
                    .All(f => f(model)));
        }

        private static void InsertDummyData(SQLiteConnection connect)
        {
            var command = new SQLiteCommand($@"
                INSERT INTO 
                    Rules (id, predicate, operator, value)
                VALUES
                    (1, 'Year', 'GreaterThan', '2012'),
                    (2, 'Make', 'Equal', 'El Diablo'),
                    (3, 'Model', 'Equal', 'Torch')
            ", connect);

            try
            {
                command.ExecuteReader();
            }
            catch (SQLiteException)
            {
            }
        }

        private static void CreateRulesTable(SQLiteConnection connect)
        {
            string sql = $@"
                CREATE TABLE IF NOT EXISTS Rules (
                id         INT PRIMARY KEY,
                predicate  VARCHAR(50) NOT NULL,
                operator   VARCHAR(50) NOT NULL,
                value      VARCHAR(50) NOT NULL)";
            try
            { 
                new SQLiteCommand(sql, connect).ExecuteReader();
            }
            catch (SQLiteException)
            {
            }
        }
    }
}