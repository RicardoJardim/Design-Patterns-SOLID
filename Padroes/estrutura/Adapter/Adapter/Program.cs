using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    //INTERFACE A QUAL O CLIENTE QUER COMUNICAR PARA RECEBER OS DADAOS
    interface ITarget
    {
        string GetRequest();
    }

    //DADOS A QUER SER ACEDIDOS PELO CLIENTE
    //MAS NO QUAL SAO INCOMPATIVEIS
    public class Adaptee
    {
        public string GetSpecificRequest()
        {
            return "Specific Request. ";
        }
    }

    //CLASSE QUE IRA ADAPTAR OS DADOS A QUAL O CLIENTE PRECISA
    public class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;

        public Adapter(Adaptee adaptee)
        {
            this._adaptee = adaptee;
        }

        public string GetRequest()
        {
            return $"This is '{this._adaptee.GetSpecificRequest()}'";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);

            Console.WriteLine("Adaptee interface is incompatible with the client.");
            Console.WriteLine("But with adapter client can call it's method.");

            Console.WriteLine(target.GetRequest());
            Console.ReadLine();
        }
    }
}
