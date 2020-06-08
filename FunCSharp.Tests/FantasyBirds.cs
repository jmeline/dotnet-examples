using System;
using Shouldly;
using Xunit;
using Xunit.Sdk;

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
            _fb.Bluebird<int, int, int>(x => x * -1)(x => x + 10)(5)
               .ShouldBe(-15);
        }

        [Fact]
        public void FantasyBird_Bluebird_()
        {
            _fb.Bluebird_<int, int, int, int>(x => y => x * y)(2)(x => x + 1)(2)
               .ShouldBe(6);
            _fb.Bluebird_<string, string, string, string>(x => y => $"{x} {y}")("Hello")(x => x.ToUpper())("World")
               .ShouldBe("Hello WORLD");
        }

        [Fact]
        public void FantasyBird_Bunting()
        {
            _fb.Bunting<int, int, int, int, int>
                (x => x * -1)
                (x => y => z => x + y + z)
                (1)
                (2)
                (3)
               .ShouldBe(-6);
        }

        [Fact]
        public void FantasyBird_Cardinal()
        {
            _fb
                .Cardinal<string, string, string>
                    (str => prefix => prefix + str)
                    ("-")
                    ("birds")
                .ShouldBe("-birds");
        }
        
        [Fact]
        public void FantasyBird_Cardinal_()
        {
            _fb
                .Cardinal_<int,int,int,int>
                    (x => y => x - y)
                    (x => x + 1)
                    (2)
                    (4)
                .ShouldBe(3);
        }
        
        [Fact]
        public void FantasyBird_CardinalStar()
        {
            _fb
                .CardinalStar<string,string,string,string>
                    (str => prefix => postfix => prefix + str + postfix)("birds")("!")("-")
                .ShouldBe("-birds!");
        }
        
        [Fact]
        public void FantasyBird_CardinalStarStar()
        {
            _fb
                .CardinalStarStar<string, string, string, string, string>
                    (a => b => separator => postfix => a + separator + b + postfix)("fantasy")("birds")("!")("-")
                .ShouldBe("fantasy-birds!");
        }
        
        [Fact]
        public void FantasyBird_Dickcissel()
        {
            _fb
                .Dickcissel<string, string, string, string, string>
                    (prefix => postfix => str => prefix + str + postfix)
                    ("-")
                    ("!")
                    (x => x.ToUpper())
                    ("birds")
                .ShouldBe("-BIRDS!");
        }
        
        [Fact]
        public void FantasyBird_Dove()
        {
            _fb
                .Dove<string, string, string, string>
                (postfix => str => str + postfix)
                ("!")
                (x => x.ToUpper())
                ("birds") 
                .ShouldBe("BIRDS!");
        }
        
        [Fact]
        public void FantasyBird_Dovekie()
        {
            _fb
                .Dovekie<string, string, string, string, string>
                (prefix => str => prefix + str)
                (x => x.ToUpper())
                ("fantasy-")
                (x => x.ToLower())
                ("BIRDS")
                .ShouldBe("FANTASY-birds");
        }
        [Fact]
        public void FantasyBird_Eagle()
        {
            _fb
                .Eagle<string, string, string, string, string>
                (prefix => str => prefix + str)
                ("-")
                (str => postfix => str + postfix)
                ("birds")
                ("!")
                .ShouldBe("-birds!");
        }
        
    }
}