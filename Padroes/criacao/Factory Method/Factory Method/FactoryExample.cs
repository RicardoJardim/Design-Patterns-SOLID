using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace Factory_Method
{
    //CLASSE ABSTRATA PARA PODER CRIARMOS VARIAS SUB FACTORIES COM VARIOS PRODUTOS
    abstract class Factory 
    {
        public abstract IProduct FactoryMethod();

        public string SomeOperation()
        {
            // Call the factory method to create a Product object.
            var product = FactoryMethod();
            // Now, use the product.
            var result = "Creator: The same creator's code has just worked with "
                + product.Operation();

            return result;
        }
    }

    //CLASSE DA PRIMEIRA FABRICA
    class LisbonFactory : Factory
    {
       
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct1();
        }
    }

    //CLASSE DA SEGUNDA FABRICA
    class FunchalFactory : Factory
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct2();
        }
    }

    //INTERFACE PARA OS PRODUTOS
    public interface IProduct
    {
        string Operation();
    }

    //PRODUTO CONCRETO DE IPRODUCT QUE SERA INSTANCIADO PELA PRIMEIRA FABRICA
    class ConcreteProduct1 : IProduct
    {
        public string Operation()
        {
            return "{Result of ConcreteProduct1}";
        }
    }
   
    //PRODUTO CONCRETO DE IPRODUCT QUE SERA INSTANCIADO PELA SEGUNDA FABRICA
    class ConcreteProduct2 : IProduct
    {
        public string Operation()
        {
            return "{Result of ConcreteProduct2}";
        }
    }

    //CLASSE CLIENTE QUE IRA CHAMAR A FABRICA PARA CRIAR OS OBJETOS NECESSÁRIOS
    class Client
    {
        public void Main()
        {
            Console.WriteLine("App: Launched with the ConcreteCreator1.");
            ClientCode(new LisbonFactory());

            Console.WriteLine("");

            Console.WriteLine("App: Launched with the ConcreteCreator2.");
            ClientCode(new FunchalFactory());
        }

        
        public void ClientCode(Factory creator)
        {
            // ...
            Console.WriteLine("Client: I'm not aware of the creator's class," +
                "but it still works.\n" + creator.SomeOperation());
            // ...
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }
}
*/