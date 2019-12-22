using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Linq.Expressions;
using ExpressionTreesAndRuleEngine.SampleRules;

namespace ExpressionTreesAndRuleEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            // build sql database
            using var connect = new SQLiteConnection("Data Source=../../../MyRuleDatabase.sqlite");
            connect.Open();
            CreateRulesTable(connect);
            InsertDummyData(connect);
            
            connect.
            
            var cmd = new SQLiteCommand("select * from rules", connect);
            var result = cmd.ExecuteReader();
            while (result.Read())
            {
                Console.WriteLine(string.Format($"Id: {result.GetString(0)}"));
                Console.WriteLine(string.Format($"Predicate: {result.GetString(1)}"));
                Console.WriteLine(string.Format($"Operator: {result.GetString(2)}"));
                Console.WriteLine(string.Format($"Value: {result.GetString(3)}"));
            }
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
            catch (SQLiteException e)
            {
                Console.WriteLine(e);
            }
        }

        private static void CreateRulesTable(SQLiteConnection connect)
        {
            string sql = $@"
                CREATE TABLE IF NOT EXISTS Rules (
                id INTEGER PRIMARY KEY,
                predicate VARCHAR(50) NOT NULL,
                operator VARCHAR(50) NOT NULL,
                value VARCHAR(50) NOT NULL)";
            try
            {
                new SQLiteCommand(sql, connect).ExecuteReader();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("Attempted to create table: " + ex.Message);
            }
        }
    }
}