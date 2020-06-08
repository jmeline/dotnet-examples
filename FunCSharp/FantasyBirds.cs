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
        /// <summary>
        /// applicator :: (a -> b) -> a -> b
        /// applicator(x => x + 1)(3) == 4
        /// A combinator or apply
        /// </summary>
        public Func<TA, TB> Applicator<TA, TB>(Func<TA, TB> f) => f;

        /// <summary>
        /// becard :: (c -> d) -> (b -> c) -> (a -> b) -> a -> d
        /// blackbird(x => x * -1)(x => y => x + y)(3)(5) == -4
        /// const becard = curry((f, g, h, x) => f(g(h(x))))
        /// B3 combinator or function composition(for three functions)
        /// </summary>
        public Func<Func<TB, TC>, Func<Func<TA, TB>, Func<TA, TD>>>
            Becard
            <TC, TB, TA, TD>
            (
                Func<TC, TD> f
            ) => g => h => x => f(g(h(x)));

        /// <summary>
        /// blackbird :: (c -> d) -> (a -> b -> c) -> a -> b -> d
        /// blackbird(x => x * -1)(x => y => x + y)(3)(5) == -8
        /// B1 Combinator
        /// </summary>
        public Func<Func<TA, Func<TB, TC>>, Func<TA, Func<TB, TD>>> 
            BlackBird
            <TC, TA, TB, TD>
            (
                Func<TC, TD> f
            ) => g => a => b => f(g(a)(b));

        /// <summary>
        /// bluebird :: (b -> c) -> (a -> b) -> a -> c
        /// bluebird(x => x * 2)(x => x - 1)(3) ==  4
        /// B combinator or function composition
        /// </summary>
        public Func<Func<TA, TB>, Func<TA, TC>> 
            Bluebird
            <TB, TA, TC>
            (
                Func<TB, TC> f
            ) => g => x => f(g(x));

        /// <summary>
        /// bluebird_ :: (a -> c -> d) -> a -> (b -> c) -> b -> d
        /// bluebird_(x => y => x * y)(2)(x => x + 1)(2) == 6
        /// B' combinator
        /// </summary>
        public Func<TA, Func<Func<TB, TC>, Func<TB, TD>>>
            Bluebird_
            <TA, TB, TC, TD>
            (
                Func<TA, Func<TC, TD>> f
            ) => a => g => b => f(a)(g(b));
        
        /// <summary>
        /// bunting :: (d -> e) -> (a -> b -> c -> d) -> a -> b -> c -> e
        /// bunting(x =>  x * -1)(x => y => z => x + y + z)(1)(2)(3) == -6
        /// B2 combinator
        /// </summary>
        public Func<Func<TA, Func<TB, Func<TC, TD>>>, Func<TA, Func<TB, Func<TC, TE>>>>
            Bunting
            <TD, TA, TB, TC, TE>
        (
               Func<TD, TE> f
        ) => g => a => b => c => f(g(a)(b)(c));

        /// <summary>
        /// cardinal :: (a -> b -> c) -> b -> a -> c
        /// cardinal(str => prefix => prefix + str)('-')('birds') == '-birds'
        /// C combinator or flip
        /// </summary>
        public Func<TB, Func<TA, TC>>
            Cardinal
            <TA, TB, TC>
            (
                Func<TA, Func<TB, TC>> f
            ) => b => a => f(a)(b);

        /// <summary>
        /// cardinal_ :: (c -> a -> d) -> (b -> c) -> a -> b -> d
        /// cardinal_ (x => y => x * y)(x => x + 1)(2)(3) == 8
        /// C' combinator
        /// </summary>
        public Func<Func<TB, TC>, Func<TA, Func<TB, TD>>> 
            Cardinal_
            <TC, TA, TB, TD>
            (
                Func<TC, Func<TA, TD>> f
            ) => g => a => b => f(g(b))(a);

        /// <summary>
        /// cardinalstar :: (a -> c -> b -> d) -> a -> b -> c -> d
        /// cardinalstar(str => prefix => postfix => prefix + str + postfix)('birds')('!')('-') == '-birds!'
        /// C* combinator - cardinal once removed.
        /// </summary>
        public Func<TA, Func<TB, Func<TC, TD>>>
            CardinalStar
            <TA, TC, TB, TD>
            (
                Func<TA, Func<TC, Func<TB, TD>>> f
            ) => a => b => c => f(a)(c)(b);
        
        /// <summary>
        /// cardinalstarstar :: (a -> b -> d -> c -> e) -> a -> b -> c -> d -> e
        /// cardinalstarstar(a => b => separator => postfix => a + separator + b + postfix)('fantasy')('birds')('!')('-') == 'fantasy-birds!'        /// </summary>
        /// C** combinator - cardinal twice removed.
        public Func<TA, Func<TB, Func<TC, Func<TD, TE>>>>
            CardinalStarStar
            <TA, TB, TD, TC, TE>
            (
                Func<TA, Func<TB, Func<TD, Func<TC, TE>>>> f
            ) => a => b => d => c => f(a)(b)(c)(d);

        /// <summary>
        /// dickcissel :: (a -> b -> d -> e) -> a -> b -> (c -> d) -> c -> e
        /// dickcissel(prefix => postfix => str => prefix + str + postfix)('-')('!')(x => x.toUpperCase())('birds') == '-BIRDS!'
        /// D1 combinator
        public Func<TA, Func<TB, Func<Func<TC, TD>, Func<TC, TE>>>>
            Dickcissel
            <TA, TB, TD, TC, TE>
            (
                Func<TA, Func<TB, Func<TD, TE>>> f
            ) => a => b => g => c => f(a)(b)(g(c));

        /// <summary>
        /// dove :: (a -> c -> d) -> a -> (b -> c) -> b -> d
        /// dove(postfix => str => str + postfix)('!')(x => x.toUpperCase())('birds') == 'BIRDS!'
        /// D combinator
        /// </summary>
        public Func<TA, Func<Func<TB, TC>, Func<TB, TD>>>
            Dove
            <TA, TB, TD, TC>
            (
                Func<TA, Func<TC, TD>> f
            ) => a => g => b => f(a)(g(b));
        
        /// <summary>
        /// dovekie :: (c -> d -> e) -> (a -> c) -> a -> (b -> d) -> b -> e
        /// dovekie(prefix => str => prefix + str)(x => x.toUpperCase())('fantasy-')(x => x.toLowerCase())('BIRDS') == 'FANTASY-birds'        /// </summary>
        /// D2 combinator
        /// </summary>
        public Func<Func<TA, TC>, Func<TA, Func<Func<TB, TD>, Func<TB, TE>>>>
            Dovekie
            <TC, TA, TB, TD, TE>
            (
                Func<TC, Func<TD, TE>> f
            ) => g => a => h => b => f(g(a))(h(b));

        /// <summary>
        /// eagle :: (a -> d -> e) -> a -> (b -> c -> d) -> b -> c -> e
        /// eagle(prefix => str => prefix + str)('-')(str => postfix => str + postfix)('birds')('!') == '-birds!'        /// </summary>
        /// E combinator
        /// </summary>
        public Func<TA, Func<Func<TB, Func<TC, TD>>, Func<TB, Func<TC, TE>>>>
            Eagle
            <TA, TB, TD, TC, TE>
            (
                Func<TA, Func<TD, TE>> f
            ) => a => g => b => c => f(a)(g(b)(c));
    }
}