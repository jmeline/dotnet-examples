using LanguageExt;
using Shouldly;
using Xunit;

namespace FunCSharp.Tests.LanguageExt;

// https://yoan-thirion.medium.com/functional-programming-made-easy-in-c-with-language-ext-c4e9d4a512ac

public class OptionTests
{
    [Fact]
    public void SimpleOptions()
    {
        Option<int> x = 123;
        x.ShouldBe(123);
        x.IsNone.ShouldBeFalse();
        x.IsSome.ShouldBeTrue();
    }

    [Fact]
    public void SimpleOptions_PresenseOfAValue()
    {
        Option<int> aValue = 2;
        aValue.Map(x => x + 3).ShouldBe(5);
        aValue.Match(x => x + 3, () => 0).ShouldBe(5);
        aValue.IfNone(1).ShouldBe(2);
    }
    
    [Fact]
    public void SimpleOptions_LackOfAValue()
    {
        var aValue = Option<int>.None;
        aValue.Map(x => x + 3).ShouldBe(Option<int>.None);
        aValue.Match(x => x + 3, () => 0).ShouldBe(0);
        aValue.IfNone(1).ShouldBe(1);
    }

    [Fact]
    public void SimpleOptions_ListsAreFunctors()
    {
        var items = new[] { 2, 4, 6 };
        //Map.(x => x + 3).ShouldBe(5);
    }
}