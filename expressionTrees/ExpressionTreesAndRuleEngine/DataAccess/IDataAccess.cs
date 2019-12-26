using System.Collections.Generic;
using ExpressionTreesAndRuleEngine.SampleRules;

namespace ExpressionTreesAndRuleEngine.DataAccess
{
    public interface IDataAccess
    {
        List<Rule> LoadRules();

    }
}