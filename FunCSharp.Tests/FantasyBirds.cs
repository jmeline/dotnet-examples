using System;
using Shouldly;
using Xunit;

namespace FunCSharp.Tests
{
    public class FantasyBirdsTest
    {
        private readonly FantasyBirds _fb;
        
        public FantasyBirdsTest() => _fb = new FantasyBirds();
        
        [Fact]
        public void FantasyBird_Applicator()
        {
            _fb.Applicator<int, int>(x => x + 1)(3).ShouldBe(4);
            _fb.Applicator<double, double>(x => x * x)(3.5).ShouldBe(12.25d);
            _fb.Applicator<string, double>(x => x != null ? Convert.ToInt32(x) : 0)("10").ShouldBe(10);
        }

        [Fact]
        public void FantasyBird_Becard()
        {
            _fb.Becard<int, int, int, int>(x => x * -1)(x => x * 2)(x => x - 1)(3).ShouldBe(-4);
        }

        [Fact]
        public void FantasyBird_Blackbird()
        {
            _fb.BlackBird<int, int, int, int>(x => x * -1)(x => y => x + y)(3)(5).ShouldBe(-8);
        }
        
        [Fact]
        public void FantasyBird_Bluebird()
        {
            _fb.Bluebird<int, int, int>(x => x * -1)(x => x + 10)(5).ShouldBe(-15);
        }
    }
}