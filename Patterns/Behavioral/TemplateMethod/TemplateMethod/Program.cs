using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{

    public abstract class AbstractClass
    {
        //DEFINE A ESTRUTURA DO ALGORITMO
        public void TemplateMethod()
        {
            this.BaseOperation1();
            this.RequiredOperation1();
            this.BaseOperation2();
            this.Hook1();
            this.RequiredOperation2();
            this.BaseOperation3();
            this.Hook2();

        }
        public void BaseOperation1()
        {
            Console.WriteLine("Base Operation 1");
        }
        public void BaseOperation2()
        {
            Console.WriteLine("Base Operation 2");
        }
        public void BaseOperation3()
        {
            Console.WriteLine("Base Operation 3");
        }

        //OPERAÇÕES OBRIGATORIAS A SER IMPLEMENTADAS
        public abstract void RequiredOperation1();
        public abstract void RequiredOperation2();

        //HOOKS SAO FUNÇÕES RESCRITAS CASO AS SUBCLASSES NECESSITEM
        public virtual void Hook1(){}
        public virtual void Hook2(){}

    }

    //CLASSE QUE IMPLEMENTA A CLASSE ABSTRACT
    public class ClassConcreta1 : AbstractClass
    {
        public override void RequiredOperation1()
        {
            Console.WriteLine("Implementação da Base Operation 1 - ClassConcreta1");
        }
        public override void RequiredOperation2()
        {
            Console.WriteLine("Implementação da Base Operation 2 - ClassConcreta1");
        }
    }
    //CLASSE QUE IMPLEMENTA A CLASSE ABSTRACT
    public class ClassConcreta2 : AbstractClass
    {
        public override void RequiredOperation1()
        {
            Console.WriteLine("Implementação da Base Operation 1 - ClassConcreta2");
        }

        public override void RequiredOperation2()
        {
            Console.WriteLine("Implementação da Base Operation 2 - ClassConcreta2");
        }

        public override void Hook1()
        {
            Console.WriteLine("ConcreteClass2 says: Overridden Hook1");
        }
    }
    //CLASSE CLIENTE QUE "CORRE " O ALGORITMO
    public class Client
    {
        //O CODIGO DO CLIENTE INSTANCIA O METODO TEMPLATE
        public static void ClientCode(AbstractClass abstractClass)
        { 
            abstractClass.TemplateMethod();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Same client code can work with different subclasses:");

            Client.ClientCode(new ClassConcreta1());

            Console.Write("\n");

            Console.WriteLine("Same client code can work with different subclasses:");
            Client.ClientCode(new ClassConcreta2());
            Console.ReadLine();

            AbstractCaminho carro = new carro();
            carro.TemplateMethod();
            Console.ReadLine();

        }
    }
}
