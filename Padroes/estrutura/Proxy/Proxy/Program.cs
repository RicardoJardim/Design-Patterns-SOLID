using System;

namespace Proxy
{
    //INTERFACE COM METODO UTILIZADO POR AMBOS OS SUBJECTS E PROXY
    public interface ISubject
    {
        void Request();
    }

    //OBJETO EM CONCRETO QUE IRA RESPONDER AO REQUEST
    public class RealSubject : ISubject
    {
        public void Request()
        {
            Console.WriteLine("RealSubject: Handling Request.");
        }
    }

    public class DifferentSubject : ISubject
    {
        public void Request()
        {
            Console.WriteLine("DifferentSubject: Handlign Request");
        }
    }

    //PROXY QUE PERMITE VERIFICAR CONDIÇÕES DE ACESSO 
    public class Proxy : ISubject
    {
       /* private RealSubject _realSubject;
        public Proxy(RealSubject real)
        {
            _realSubject = real;
        } */

        private ISubject _realSubject;
        public Proxy(ISubject real)
          {
              _realSubject = real;
          }

        public void Request()
        {
            if (CheckAccess())
            {
                _realSubject.Request();

                LogAccess();
            }
        }

        public bool CheckAccess()
        {
            Console.WriteLine("Proxy: Checking access prior to firing a real request ");
            return true;
        }

        public void LogAccess()
        {
            Console.WriteLine("Proxy: Logging the time of request.");
        }
    }

    public class Client
    {
        public void ClientCode(ISubject subject)
        {
            subject.Request();
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            //É POSSIVEL PEDIR LOGO AO REALSUBJECT
            var client = new Client();
            Console.WriteLine("Client: Executing the client code with a real subject");
            var realSubject = new RealSubject();
            client.ClientCode(realSubject);
            Console.WriteLine();

            //UTILIZANDO A PROXY PARA CONTROLAR O ACESSO 
            Console.WriteLine("Client: Executing the same client code with the proxy");
            var proxy = new Proxy(realSubject);
            client.ClientCode(proxy);

            Console.WriteLine();

            //UTILIZANDO A PROXY PARA CONTROLAR O ACESSO DE OUTRAS SUBCLASSES O SUBJECT
            var diffSubject = new DifferentSubject();
            Console.WriteLine("Client: Executing the same client code with the proxy");
            proxy = new Proxy(diffSubject);
            client.ClientCode(proxy);
            Console.Read();

        }
    }
}