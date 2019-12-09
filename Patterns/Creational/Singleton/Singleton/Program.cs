using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public sealed class Singleton
    {
        //CRIA ESTA CLASSE UNICA UTILIZANDO O CLASS INSTANCE
         static Singleton instance = new Singleton();

         static Singleton() { }
         private Singleton() { }

         public static Singleton Instance
         {
             get { return instance; }
         }

        //USANDO TRINCOS PARA MULTITHREAD
       /* private static readonly object _lock = new object();
        private static Singleton instance = null;
       private Singleton() { }
       public static Singleton Instance
       {
           get
           {
               if (instance != null) return instance;
               lock (_lock)
               {
                   if (instance == null)
                       instance = new Singleton();
                   return instance;
               }
           }
       }*/
    }

    class Program
    {
        static void Main(string[] args)
        {
            //TESTE COM O TRINCO
            Console.WriteLine(
                "{0}\n{1}\n\n{2}\n",
                "If you see the same value, then singleton was reused (yay!)",
                "If you see different values, then 2 singletons were created (booo!!)",
                "RESULT:"
            );

            Thread process1 = new Thread(() =>
            {
                TestSingleton("FOO");
            });
            Thread process2 = new Thread(() =>
            {
                TestSingleton("BAR");
            });

            process1.Start();
            process2.Start();

            process1.Join();
            process2.Join();
            Console.ReadLine();
        }

        //TESTE UNITÀRIO
        public static void TestSingleton(string value)
        {
            Singleton singleton = Singleton.Instance;
            Console.WriteLine(singleton);
        }
    }
}

