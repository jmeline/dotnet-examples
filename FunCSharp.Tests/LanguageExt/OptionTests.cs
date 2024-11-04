using LanguageExt;
using Shouldly;
using Xunit;

namespace FunCSharp.Tests.LanguageExt;

public class OptionTests
{
    [Fact]
    public void SimpleOptions()
    {
        Option<int> x = new Some<int>(123);
        x.ShouldBe(123);
        x.IsNone.ShouldBeFalse();
        x.IsSome.ShouldBeTrue();
    }
}