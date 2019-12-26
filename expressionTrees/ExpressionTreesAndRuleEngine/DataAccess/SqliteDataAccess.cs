using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using ExpressionTreesAndRuleEngine.SampleRules;
using Microsoft.Extensions.Options;

namespace ExpressionTreesAndRuleEngine.DataAccess
{
    public class SqliteDataAccess : IDataAccess 
    {
        private string _connectionString { get; set; }
        
        public SqliteDataAccess(IOptions<AppSettings> option)
        {
             _connectionString = option.Value.ConnectionString;
        }

        public List<Rule> LoadRules()
        {
            using var connect = new SQLiteConnection(_connectionString);
            return connect
                .Query<Rule>("SELECT * FROM rules")
                .ToList();
        }
    }
}