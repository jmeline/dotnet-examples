using Xunit;
using ExpressionTreesAndRuleEngine;
using System;
using Shouldly;

namespace ExpressionTreesAndRuleEngine.Tests.SampleRules
{
    public class PredicateBuilderTests
    {
        [Fact]
        public void TryingOutPredicateClass() {
            Predicate<int> p = new Predicate<int>(x => x > 2);
            p(5).ShouldBeTrue();
        }

        [Fact]
        public void CanCreateDynamicLinq() {
            var predicate = PredicateBuilder
                .True<CarData>()
                .And(x => Convert.ToDecimal(x.EngineSize) > 10);
                
        }
    }
}
