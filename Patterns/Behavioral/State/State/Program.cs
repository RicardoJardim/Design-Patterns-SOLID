using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    //CLASSE CONTEXT QUE IRÁ TER O STATE ATUAL COMO CONTEXTO
    public class Context
    {
        private State _state = null;

        //INICIALIZADO COM A TRANSISÇÃO PARA O ESTADO ATUAL
        public Context(State state)
        {
            this.TransistionTo(state);
        }

        //FUNÇÃO QUE PERMITE TRANSITAR DE ESTADO PARA OUTRO ESTADO
        public void TransistionTo(State state)
        {
            Console.WriteLine($"Context: Transition to {state.GetType().Name}");
            this._state = state;
            this._state.SetContext(this);
        }

        //AÇÃO REQUEST1
        public void Request1()
        {
            this._state.Handle1();
        }

        //AÇÃO REQUEST2
        public void Request2()
        {
            this._state.Handle2();
        }
    }

    //CLASSE ABSTRATA DO STATE ASSOCIADO COM O STATE
    public abstract class State
    {
        protected Context _context;
        //MODIFICA O CONTEXTO
        public void SetContext(Context context)
        {
            this._context = context;
        }

        //AÇÕES POSSIVEIS NA MAQUINA DE ESTADOS
        public abstract void Handle1();

        public abstract void Handle2();
    }

    //PRIMEIRO ESTADO - INICIAL
    public class ConcreteStateA : State
    {
        //HANDLE 1 PERMITE TRANSISTAR DE ESTADO PARA B 
        public override void Handle1()
        {
            Console.WriteLine("ConcreteStateA handles request1");
            Console.WriteLine("ConcreteStateA wants to change the state of the context.");
            this._context.TransistionTo(new ConcreteStateB());
        }
        //CONTINUA NO MESMO ESTADO
        public override void Handle2()
        {
            Console.WriteLine("ConcreteStateA handles request2.");
        }
    }
    //SEGUNDO ESTADO
    public class ConcreteStateB : State
    {
        public override void Handle1()
        {
            Console.WriteLine("ConcreteStateB handles request1");
            
        }
        //AÇÃO QUE PERMITE TRANSITAR DE ESTADO
        public override void Handle2()
        {
            Console.WriteLine("ConcreteStateB handles request2.");
            Console.WriteLine("ConcreteStateB wants to change the state of the context.");
            this._context.TransistionTo(new ConcreteStateA());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //INICALIZAR A MAQUINA DE ESTADO
           /* var context = new Context(new ConcreteStateA());
             Console.WriteLine("Request1");
             // PRIEMRIA AÇÃO
            context.Request1();
            context.Request1();
            Console.WriteLine("Request2");
            //SEGUNDA AÇÃO
            context.Request2();
            Console.ReadLine();*/

           //Exemplo da maquina do cafe
           Client cli = new Client();
           Console.WriteLine("Deseja ligar a maquina?");
           var x = Console.ReadLine();
           var bols = bool.Parse(x);
           while (bols)
           {
               Console.WriteLine("Bem Vindo deseja pedir cafe? 1-Sim | 2-Nao");
               var y = Console.ReadLine();
               if (Int32.Parse(y) == 1)
               {
                   cli.InicarMaquina();
               }
               else
               {
                   Console.WriteLine("Vai po crl");
                   bols = false;
               }
           }

           Console.ReadLine();
        }
    }
}
