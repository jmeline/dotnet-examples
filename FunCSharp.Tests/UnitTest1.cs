using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace FunCSharp.Tests
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public UnitTest1(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        private readonly Func<int, Func<int, int>> add = x => y => x + y;
        private readonly Func<int, Func<int, int>> sub = x => y => x - y;
        private readonly Func<int, Func<int, int>> mult = x => y => x * y;

        //   private readonly Func<int, int> tap = x =>
        //   {
        //       _testOutputHelper.WriteLine(x.ToString());
        //       return x;
        //   };

        [Fact]
        public void Test1()
        {
            var fn = sub(40)
                .ComposeWith(add(10))
                .ComposeWith(mult(10))
                .ComposeWith(add(1));
            fn(2).ShouldBe(0);
        }

        public class Options
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }
        
        [Fact]
        public void Test2()
        {
            Func<Options, Options> applyDefaults = options =>
            {
                options.Id = 1337;
                options.FirstName = "bob";
                options.LastName = "dude";
                options.Age = 10;
                return options;
            };
            
            Func<Options, Options> setOptions = options =>
            {
                options.FirstName = "jacob";
                return options;
            };

            var result = setOptions.ComposeWith(applyDefaults)(new Options());
            result.ShouldSatisfyAllConditions(
                () => result.Id.ShouldBe(1337),
                () => result.FirstName.ShouldBe("jacob"),
                () => result.LastName.ShouldBe("dude"),
                () => result.Age.ShouldBe(10));

            


        }
    }
}