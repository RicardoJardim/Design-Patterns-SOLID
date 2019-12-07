using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    //CLASSE FACADE QUE IRA CONTER TODOS OS SUBSISTEMAS
    //NAO PERMITINDO QUE O CLIENTE TENHA QUE ENTENDER TODOS OS SUBSISTEMAS
    //INTERAGINDO APENAS COM O FACADE
    public class Facade
    {
        private Subsystem1 _subsystem1;
        private Subsystem2 _subsystem2;

        //RECEBE OS SUBSISTEMAS
        public Facade(Subsystem1 sub1, Subsystem2 sub2)
        {
            this._subsystem1 = sub1;
            this._subsystem2 = sub2;
        }

        //EXEMPLO DE FUNÇÃO
        public string Operation()
        {
            string result = "Facade initializes subsystems:\n";
            result += this._subsystem1.operation1();
            result += this._subsystem2.operation1();
            result += "Facade orders subsystems to perform the action: \n";
            result += this._subsystem1.operationN();
            result += this._subsystem2.operationZ();
            return result;
        }
    }
    //SUBSISTEMA 1
    public class Subsystem1
    {
        public string operation1()
        {
            return "Subsystem1: Ready! \n";
        }
        public string operationN()
        {
            return "Subsystem1: Go! \n";
        }
    }
    //SUBSISTEMA 2
    public class Subsystem2
    {
        public string operation1()
        {
            return "Subsystem2: Ready! \n";
        }
        public string operationZ()
        {
            return "Subsystem2: Fire! \n";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Subsystem1 sub1 = new Subsystem1();
            Subsystem2 sub2 = new Subsystem2();

            Facade facade = new Facade(sub1,sub2);
            Console.WriteLine(facade.Operation());
            Console.ReadLine();
        }
    }
}
