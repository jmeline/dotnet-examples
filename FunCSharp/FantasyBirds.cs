using System;

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
        public static Func<TA, TB> Applicator<TA, TB>(Func<TA, TB> f) => f;

        /// <summary>
        /// becard :: (c -> d) -> (b -> c) -> (a -> b) -> a -> d
        /// blackbird(x => x * -1)(x => y => x + y)(3)(5) == -4
        /// const becard = curry((f, g, h, x) => f(g(h(x))))
        /// B3 combinator or function composition(for three functions)
        /// </summary>
        public static Func<Func<TB, TC>, Func<Func<TA, TB>, Func<TA, TD>>>
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
        public static Func<Func<TA, Func<TB, TC>>, Func<TA, Func<TB, TD>>> 
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
        public static Func<Func<TA, TB>, Func<TA, TC>> 
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
        public static Func<TA, Func<Func<TB, TC>, Func<TB, TD>>>
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
        public static Func<Func<TA, Func<TB, Func<TC, TD>>>, Func<TA, Func<TB, Func<TC, TE>>>>
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
        public static Func<TB, Func<TA, TC>>
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
        public static Func<Func<TB, TC>, Func<TA, Func<TB, TD>>> 
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
        public static Func<TA, Func<TB, Func<TC, TD>>>
            CardinalStar
            <TA, TC, TB, TD>
            (
                Func<TA, Func<TC, Func<TB, TD>>> f
            ) => a => b => c => f(a)(c)(b);
        
        /// <summary>
        /// cardinalstarstar :: (a -> b -> d -> c -> e) -> a -> b -> c -> d -> e
        /// cardinalstarstar(a => b => separator => postfix => a + separator + b + postfix)('fantasy')('birds')('!')('-') == 'fantasy-birds!'        /// </summary>
        /// C** combinator - cardinal twice removed.
        public static Func<TA, Func<TB, Func<TC, Func<TD, TE>>>>
            CardinalStarStar
            <TA, TB, TD, TC, TE>
            (
                Func<TA, Func<TB, Func<TD, Func<TC, TE>>>> f
            ) => a => b => d => c => f(a)(b)(c)(d);

        /// <summary>
        /// dickcissel :: (a -> b -> d -> e) -> a -> b -> (c -> d) -> c -> e
        /// dickcissel(prefix => postfix => str => prefix + str + postfix)('-')('!')(x => x.toUpperCase())('birds') == '-BIRDS!'
        /// D1 combinator
        public static Func<TA, Func<TB, Func<Func<TC, TD>, Func<TC, TE>>>>
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
        public static Func<TA, Func<Func<TB, TC>, Func<TB, TD>>>
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
        public static Func<Func<TA, TC>, Func<TA, Func<Func<TB, TD>, Func<TB, TE>>>>
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
        public static Func<TA, Func<Func<TB, Func<TC, TD>>, Func<TB, Func<TC, TE>>>>
            Eagle
            <TA, TB, TD, TC, TE>
            (
                Func<TA, Func<TD, TE>> f
            ) => a => g => b => c => f(a)(g(b)(c));

        /// <summary>
        /// eaglebald :: (e -> f -> g) -> (a -> b -> e) -> a -> b -> (c -> d -> f) -> c -> d -> g
        /// eaglebald(x => y => y + x)(a => b => b + a)('!')('birds')(a => b => a + b)('fantasy')('-') =='fantasy-birds!' 
        /// E^ combinator
        /// </summary>
        public static Func<Func<TA, Func<TB, TE>>, Func<TA, Func<TB, Func<Func<TC, Func<TD, TF>>, Func<TC, Func<TD, TG>>>>>>
            EagleBald<TE, TF, TA, TB, TC, TD, TG>
            (
                Func<TE, Func<TF, TG>> f
            ) => g => a => b => h => c => d => f(g(a)(b))(h(c)(d));

        /// <summary>
        /// finch :: a -> b -> (b -> a -> c) -> c
        /// finch(-1, 3)(x => y => x * y) == -3
        /// F combinato
        public static Func<TB, Func<Func<TB, Func<TA, TC>>, TC>>
            Finch<TA, TB, TC>(TA a) => b => f => f(b)(a);

        /// <summary>
        /// finchstar :: (c -> b -> a -> d) -> a -> b -> c -> d
        /// </summary>
        public static Func<TA, Func<TB, Func<TC, TD>>> 
            FinchStar<TC, TB, TA, TD>
            (
                Func<TC, Func<TB, Func<TA, TD>>> f
            ) => a => b => c => f(c)(b)(a);
        
        /// <summary>
        /// finchstarstar :: (a -> d -> c -> b -> e) -> a -> b -> c -> d -> e
        /// </summary>
        public static Func<TA, Func<TB, Func<TC, Func<TD, TE>>>>
            FinchStarStar<TA, TD, TC, TB, TE>
            (
                Func<TA, Func<TD, Func<TC, Func<TB, TE>>>> f
            ) => a => b => c => d =>f(a)(d)(c)(b);
                    
                            /// <summary>
        /// goldfinch :: (b -> c -> d) -> (a -> c) -> a -> b -> d
        /// </summary>
        public static Func<Func<TA, TC>, Func<TA, Func<TB, TD>>>
            GoldFinch<TB, TA, TC, TD>
            (
                Func<TB, Func<TC, TD>> f
            ) => g => a => b => f(b)(g(a));

        /// <summary>
        /// hummingbird :: (a -> b -> a -> c) -> a -> b -> c
        /// </summary>
        public static Func<TA, Func<TB, TC>>
            HummingBird<TA, TB, TC>
            (
                Func<TA, Func<TB, Func<TA, TC>>> f
            ) => a => b => f(a)(b)(a);

        /// <summary>
        /// idiot :: a -> a
        /// </summary>
        public static TA Idiot<TA> (TA a) => a;

        /// <summary>
        /// idstar :: (a -> b) -> a -> b
        /// </summary>
        public static Func<TA, TB> IdStar<TA, TB>(Func<TA, TB> f) => f;

        /// <summary>
        /// idstarstar :: (a -> b -> c) -> a -> b -> c
        /// </summary>
        public static Func<TA, Func<TB, TC>> 
            IdStarStar<TA, TB, TC>
            (
                Func<TA, Func<TB, TC>> f
            ) => a => b => f(a)(b);

        /// <summary>
        /// jalt :: (a -> c) -> a -> b -> c
        /// </summary>
        public static Func<TA, Func<TB, TC>> Jalt<TA, TB, TC>(Func<TA, TC> f)
            => a => b => f(a);
        
        /// <summary>
        /// jalt_ :: (a -> b -> d) -> a -> b -> c -> d
        /// </summary>
        public static Func<TA, Func<TB, Func<TC, TD>>> Jalt_<TA, TB, TC, TD>(Func<TA, Func<TB, TD>> f)
            => a => b => c => f(a)(b);

        /// <summary>
        /// ?? Not sure, need to double check this function
        /// jay :: (a -> b -> b) -> a -> b -> a -> b
        /// </summary>
        public static Func<TA, Func<TB, Func<TA, TB>>> Jay<TA, TB>(Func<TA, Func<TB, TB>> f)
            => a => b => a => f(a)(b);

        /// <summary>
        /// kestrel :: a -> b -> a
        /// </summary>
        public static Func<TB, TA> Kestrel<TA, TB>(TA a) => b => a;
        
        /// <summary>
        /// kite :: a -> b -> b
        /// </summary>
        public static Func<TB, TB> Kite<TA, TB>(TA a) => b => b;

        /// <summary>
        /// owl :: ((a -> b) -> a) -> (a -> b) -> b
        /// </summary>
        public static Func<Func<TA, TB>, TB> 
            Owl<TA, TB>(Func<Func<TA, TB>, TA> f) => g => g(f(g));
        
        /// <summary>
        /// phoenix :: (b -> c -> d) -> (a -> b) -> (a -> c) -> a -> d
        /// </summary>
        public static Func<Func<TA, TB>, Func<Func<TA, TC>, Func<TA, TD>>>
            Phoenix<TA, TB, TC, TD>(Func<TB, Func<TC, TD>> f) 
                => g 
                    => k 
                        => a => f(g(a))(k(a));

        /// <summary>
        // psi :: (b -> b -> c) -> (a -> b) -> a -> a -> c
        // says ^ on the github readme, but the example demonstrates the below signature
        // psi :: (a -> b -> c) -> (c -> d) -> a -> b -> d
        /// </summary>
        public static Func<Func<TC, TD>, Func<TA, Func<TB, TD>>>
            Psi<TA, TB, TC, TD>(Func<TA, Func<TB, TC>> f)
            => g
                => a
                    => b => g(f(a)(b));

/*
       
        quacky :: a -> (a -> b) -> (b -> c) -> c
        queer :: (a -> b) -> (b -> c) -> a -> c
        quirky :: (a -> b) -> a -> (b -> c) -> c
        quixotic :: (b -> c) -> a -> (a -> b) -> c
        quizzical :: a -> (b -> c) -> (a -> b) -> c
        robin :: a -> (b -> a -> c) -> b -> c
        robinstar :: (b -> c -> a -> d) -> a -> b -> c -> d
        robinstarstar :: (a -> c -> d -> b -> e) -> a -> b -> c -> d -> e
        starling :: (a -> b -> c) -> (a -> b) -> a -> c
        starling_ :: (b -> c -> d) -> (a -> b) -> (a -> c) -> a -> d
        thrush :: a -> (a -> b) -> b
        vireo :: a -> b -> (a -> b -> c) -> c
        vireostar :: (b -> a -> b -> d) -> a -> b -> b -> d
        vireostarstar :: (a -> c -> b -> c -> e) -> a -> b -> c -> c -> e
        warbler :: (a -> a -> b) -> a -> b
        warbler1 :: a -> (a -> a -> b) -> b
        warblerstar :: (a -> b -> b -> c) -> a -> b -> c
        warblerstarstar :: (a -> b -> c -> c -> d) -> a -> b -> c -> d
    */
    }
}