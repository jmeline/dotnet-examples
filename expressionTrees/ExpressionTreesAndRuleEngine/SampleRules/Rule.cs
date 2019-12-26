using System;
using System.Linq.Expressions;

namespace ExpressionTreesAndRuleEngine.SampleRules
{
    ///
    /// The Rule type
    /// 
    public class Rule
    {
        ///
        /// Denotes the rules predictate (e.g. Name); comparison operator(e.g. ExpressionType.GreaterThan); value (e.g. "Cole")
        ///
        public int Id { get; set; }
        public string Predicate { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }
    }
}