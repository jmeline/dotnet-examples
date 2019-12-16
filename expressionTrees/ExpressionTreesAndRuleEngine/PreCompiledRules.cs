using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionTreesAndRuleEngine
{
    public class PreCompiledRules
    {
        
        ///
        /// A method used to precompile rules for a provided type
        /// 
        public static List<Func<T, bool>> CompileRule<T>(List<Rule> rules)
        {
            // Loop through the rules and compile them against the properties of the supplied shallow object 
            return rules
                .Select(rule =>
                {
                    var genericType = Expression.Parameter(typeof(T));
                    var key = Expression.Property(genericType, rule.ComparisonPredicate);
                    var propertyType = typeof(T).GetProperty(rule.ComparisonPredicate).PropertyType;
                    var value = Expression.Constant(Convert.ChangeType(rule.ComparisonValue, propertyType));
                    var binaryExpression = Expression.MakeBinary(rule.ComparisonOperator, key, value);

                    return Expression.Lambda<Func<T, bool>>(binaryExpression, genericType).Compile();
                })
                .ToList();
        }
    }
    
    ///
    /// The Rule type
    /// 
    public class Rule
    {
        ///
        /// Denotes the rules predictate (e.g. Name); comparison operator(e.g. ExpressionType.GreaterThan); value (e.g. "Cole")
        /// 
        public string ComparisonPredicate { get; set; }
        public ExpressionType ComparisonOperator { get; set; }
        public string ComparisonValue { get; set; }

        /// 
        /// The rule method that 
        /// 
        public Rule(string comparisonPredicate, ExpressionType comparisonOperator, string comparisonValue)
        {
            ComparisonPredicate = comparisonPredicate;
            ComparisonOperator = comparisonOperator;
            ComparisonValue = comparisonValue;
        }
    }
    
    public class Car : ICar
    {
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }

    public interface ICar
    {
        int Year { get; set; }
        string Make { get; set; }
        string Model { get; set; }
    }

}