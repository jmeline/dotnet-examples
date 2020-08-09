using System;
using Shouldly;
using Xunit;
using Xunit.Sdk;

namespace FunCSharp.Tests
{
    public class FantasyBirdsTest
    {
        [Fact]
        public void FantasyBird_Applicator()
        {
            FantasyBirds.Applicator<int, int>(x => x + 1)(3).ShouldBe(4);
            FantasyBirds.Applicator<double, double>(x => x * x)(3.5).ShouldBe(12.25d);
            FantasyBirds.Applicator<string, double>(x => x != null ? Convert.ToInt32(x) : 0)("10").ShouldBe(10);
        }

        [Fact]
        public void FantasyBird_Becard()
        {
            FantasyBirds.Becard<int, int, int, int>(x => x * -1)(x => x * 2)(x => x - 1)(3).ShouldBe(-4);
        }

        [Fact]
        public void FantasyBird_Blackbird()
        {
            FantasyBirds.BlackBird<int, int, int, int>(x => x * -1)(x => y => x + y)(3)(5).ShouldBe(-8);
        }
        
        [Fact]
        public void FantasyBird_Bluebird()
        {
            FantasyBirds.Bluebird<int, int, int>(x => x * -1)(x => x + 10)(5)
               .ShouldBe(-15);
        }

        [Fact]
        public void FantasyBird_Bluebird_()
        {
            FantasyBirds.Bluebird_<int, int, int, int>(x => y => x * y)(2)(x => x + 1)(2)
               .ShouldBe(6);
            FantasyBirds.Bluebird_<string, string, string, string>(x => y => $"{x} {y}")("Hello")(x => x.ToUpper())("World")
               .ShouldBe("Hello WORLD");
        }

        [Fact]
        public void FantasyBird_Bunting()
        {
            FantasyBirds.Bunting<int, int, int, int, int>(x => x * -1)
                (x => y => z => x + y + z)
                (1)
                (2)
                (3)
               .ShouldBe(-6);
        }

        [Fact]
        public void FantasyBird_Cardinal()
        {
            FantasyBirds.Cardinal<string, string, string>(str => prefix => prefix + str)
                    ("-")
                    ("birds")
                .ShouldBe("-birds");
        }
        
        [Fact]
        public void FantasyBird_Cardinal_()
        {
            FantasyBirds.Cardinal_<int, int, int, int>(x => y => x - y)
                    (x => x + 1)
                    (2)
                    (4)
                .ShouldBe(3);
        }
        
        [Fact]
        public void FantasyBird_CardinalStar()
        {
            FantasyBirds.CardinalStar<string, string, string, string>(str => prefix => postfix => prefix + str + postfix)("birds")("!")("-")
                .ShouldBe("-birds!");
        }
        
        [Fact]
        public void FantasyBird_CardinalStarStar()
        {
            FantasyBirds.CardinalStarStar<string, string, string, string, string>(a => b => separator => postfix => a + separator + b + postfix)("fantasy")("birds")("!")("-")
                .ShouldBe("fantasy-birds!");
        }
        
        [Fact]
        public void FantasyBird_Dickcissel()
        {
            FantasyBirds.Dickcissel<string, string, string, string, string>(prefix => postfix => str => prefix + str + postfix)
                    ("-")
                    ("!")
                    (x => x.ToUpper())
                    ("birds")
                .ShouldBe("-BIRDS!");
        }
        
        [Fact]
        public void FantasyBird_Dove()
        {
            FantasyBirds.Dove<string, string, string, string>(postfix => str => str + postfix)
                ("!")
                (x => x.ToUpper())
                ("birds") 
                .ShouldBe("BIRDS!");
        }
        
        [Fact]
        public void FantasyBird_Dovekie()
        {
            FantasyBirds.Dovekie<string, string, string, string, string>(prefix => str => prefix + str)
                (x => x.ToUpper())
                ("fantasy-")
                (x => x.ToLower())
                ("BIRDS")
                .ShouldBe("FANTASY-birds");
        }
        [Fact]
        public void FantasyBird_Eagle()
        {
            FantasyBirds.Eagle<string, string, string, string, string>(prefix => str => prefix + str)
                ("-")
                (str => postfix => str + postfix)
                ("birds")
                ("!")
                .ShouldBe("-birds!");
        }

        [Fact]
        public void FantasyBird_EagleBald()
        {
            FantasyBirds.EagleBald<string, string, string, string, string, string, string>(x => y => y + x)
                (a => b => b + a)
                ("!")
                ("birds")
                (a => b => a + b)
                ("fantasy")("-")
                .ShouldBe("fantasy-birds!");
        }

        [Fact]
        public void FantasyBird_Finch()
        {
            FantasyBirds.Finch<int, int, int>(-1)
            (3)
            (x => y => x * y)
            .ShouldBe(-3);
            
            FantasyBirds.Finch<string, string, string>("World")
            ("Hello")
            (x => y => $"{x} {y}!")
            .ShouldBe("Hello World!");
        }
        
        [Fact]
        public void FantasyBird_FinchStar()
        {
            FantasyBirds.FinchStar<string, string, string, string>(
                x => y => z => $"{x}-{y}_{z}")
                ("unique")
                ("key")
                ("100")
                .ShouldBe("100-key_unique");
        }
        
        [Fact]
        public void FantasyBird_FinchStarStar()
        {
            FantasyBirds.FinchStarStar<string, string, string, string, (string, string, string, string)>(
                a => d => c => b => (a, b, c, d))
                ("unique")
                ("key")
                ("100")
                ("1000")
                .ShouldBe(("unique", "key", "100", "1000"));
        }
        
        [Fact]
        public void FantasyBird_GoldFinch()
        {
            FantasyBirds.GoldFinch<string, string, string, string> (
                b => c => $"{b}_{c}")
                (a => $"*{a}*")
                ("unique")
                ("key")
                .ShouldBe("key_*unique*");
        }
        
        [Fact]
        public void FantasyBird_HummingBird()
        {
            FantasyBirds.HummingBird<string, string, (string, string)>(
                a => b => a2 => ($"{a}", $"{a2}_{b}"))
                ("10")
                ("key")
                .ShouldBe(("10", "10_key"));
        }
        
        [Theory]
        [InlineData("10")]
        [InlineData("sup")]
        [InlineData("sup1")]
        public void FantasyBird_Idiot(string value)
        {
            FantasyBirds.Idiot(value).ShouldBe(value);
        }
    }
}