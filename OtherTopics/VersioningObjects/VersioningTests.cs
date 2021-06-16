using System;
using Xunit;

namespace OtherTopics.VersioningObjects
{
    public class VersioningTests
    {
        public enum FavoriteFood
        {
            Sushi,
            Cake,
            HotDog,
            Pizza
        }

        public class A
        {
            public string FirstName { get; set; }    
            public string LastName { get; set; }    
            public string Address { get; set; }    
            public int Age { get; set; }    
        }
        
        public class B : A
        {
            public FavoriteFood FavoriteFood { get; set; } 
        }

        public class C : B
        {
            public int Happy { get; set; }
        }

        public class D : C
        {
            public new bool Happy { get; set; }
        }
        
        // public void DoesVersioning()
        // {
        //     var a = new A();
        //     var b = new B();
        //     var c = new C();
        //     var d = new D();
        //
        //     A f(B b)
        //     {
        //
        //         return new A();
        //     }
        //
        //     B Bb = (B) a;
        //     f(Bb);
        //     f(b);
        //     f(c);
        //     f(d);
        // }
    }
}