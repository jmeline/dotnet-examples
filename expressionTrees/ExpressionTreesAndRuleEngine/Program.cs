using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ExpressionTreesAndRuleEngine.DataAccess;
using ExpressionTreesAndRuleEngine.SampleRules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ExpressionTreesAndRuleEngine
{
    public class Program
    {
        public static void Main()
        {
            // build sql database
            // CreateRulesTable(connect);
            // InsertDummyData(connect);
            
            var serviceProvider = SetupServiceProvider();
            var dbAccess = serviceProvider.GetService<IDataAccess>();
            var rules = dbAccess.LoadRules();
            var funcs = PreCompiledRules.CompileRule<Car>(rules);

            var cars = new List<Car>
            {
                new Car {Make = "El Diablo", Model = "Torch", Year = 2013},
                new Car {Make = "El Diablo", Model = "Torche", Year = 2012},
                new Car {Make = "El Diabl", Model = "Torch", Year = 2012},
                new Car {Make = "El Diabl", Model = "Torch", Year = 2010}
            };
            
            var results = cars
                .Where(model => funcs
                    .All(f => f(model)));
        }

        private static ServiceProvider SetupServiceProvider()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json",
                    optional: true,
                    reloadOnChange: true)
                .Build();

            var services = new ServiceCollection();
            services.AddSingleton(configuration);
            services.AddTransient<IDataAccess, SqliteDataAccess>();
            services.Configure<AppSettings>(x =>
                x.ConnectionString = configuration.GetConnectionString("source"));
            return services.BuildServiceProvider();
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