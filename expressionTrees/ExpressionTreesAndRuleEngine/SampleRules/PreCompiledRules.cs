using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionTreesAndRuleEngine.SampleRules
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
                    var propertyType = typeof(T).GetProperty(rule.ComparisonPredicate)?.PropertyType;
                    var value = Expression.Constant(Convert.ChangeType(rule.ComparisonValue, propertyType));
                    var binaryExpression = Expression.MakeBinary(rule.ComparisonOperator, key, value);

                    return Expression.Lambda<Func<T, bool>>(binaryExpression, genericType).Compile();
                })
                .ToList();
        }
    }
}