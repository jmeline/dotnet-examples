namespace DesignPatterns.CreationalPatterns.AbstractFactory
{
    /*
     * Abstract factory
     *
     * A creational design pattern that lets you produce
     * families of related objects without specifying
     * their concrete classes
     * 
     */

    interface IAbstractFactory
    {
        IAbstractProductA CreateProductA();
        IAbstractProductB CreateProductB();
    }

    class ConcreteFactory1 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            throw new System.NotImplementedException();
        }

        public IAbstractProductB CreateProductB()
        {
            throw new System.NotImplementedException();
        }
    }
    
    class ConcreteFactory2 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            throw new System.NotImplementedException();
        }

        public IAbstractProductB CreateProductB()
        {
            throw new System.NotImplementedException();
        }
    }
    
    internal interface IAbstractProductA
    {
        string UsefulFunctionA();
    }

    internal interface IAbstractProductB
    {
        string UsefulFunctionB();
    }

    public class AbstractFactory
    {
        
    }
}