using System;
using System.Reflection.Metadata;
using Xunit.Sdk;

namespace FunCSharp
{
    /// <summary>
    /// Fantasy Birds based off https://github.com/fantasyland/fantasy-birds
    /// </summary>
    public class FantasyBirds
    {
        ///
        /// applicator :: (a -> b) -> a -> b
        /// A combinator or apply
        ///
        public Func<TInput, TOutput> Applicator<TInput, TOutput>(Func<TInput, TOutput> f) => f;

        /// <summary>
        /// becard :: (c -> d) -> (b -> c) -> (a -> b) -> a -> d
        /// B3 combinator or function composition(for three functions)
        /// const becard = curry((f, g, h, x) => f(g(h(x))))
        /// </summary>
        public Func<Func<TInput2, TInput1>, Func<Func<TInput3, TInput2>, Func<TInput3, TOutput>>>
            Becard
            <TInput1, TInput2, TInput3, TOutput>
            (
                Func<TInput1, TOutput> f
            ) => g => h => x => f(g(h(x)));

        /// <summary>
        ///  blackbird :: (c -> d) -> (a -> b -> c) -> a -> b -> d
        ///  B1 Combinator
        /// </summary>
        /// <returns></returns>
        public Func<Func<TInput1, Func<TInput2, TInput3>>, Func<TInput1, Func<TInput2, TOutput>>> 
            BlackBird
            <TInput1, TInput2, TInput3, TOutput>
            (
                Func<TInput3, TOutput> f
            ) => g => a => b => f(g(a)(b));

        /// <summary>
        ///  bluebird :: (b -> c) -> (a -> b) -> a -> c
        ///  B combinator or function composition
        /// </summary>
        public Func<Func<TInput1, TInput2>, Func<TInput1, TOutput>> 
            Bluebird
            <TInput1, TInput2, TOutput>
            (
                Func<TInput2, TOutput> f
            ) => g => x => f(g(x));
    }
}