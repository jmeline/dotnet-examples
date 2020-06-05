using System;

namespace FunCSharp
{
    public static class Extensions
    {
        // x => f(g(x))
        public static Func<T1, T3> ComposeWith<T1, T2, T3>(this Func<T2, T3> f, Func<T1, T2> g)
        {
            return x => f(g(x));
        }

        public static T1 Identity<T1>(this T1 x) => x;
    }
}