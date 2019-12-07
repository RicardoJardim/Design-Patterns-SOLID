using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class Context2
    {
        private State2 _state = null;

        public Context2(State2 state)
        {
            this.TransistionTo(state);
        }
        public void TransistionTo(State2 state)
        {
            Console.WriteLine($"Context: Transition to {state.GetType().Name}");
            this._state = state;
            this._state.SetContext(this);
        }

        public void InserirMoeda()
        {
            this._state.InserirMoeda();
        }
        public void RemoverMoeda()
        {
            this._state.RemoverMoeda();
        }

        public void PedirCafe()
        {
            this._state.PedirCafe();
        }
        public void RetirarCafe()
        {
            this._state.RetirarCafe();
        }
    }
    public abstract class State2
    {
        protected Context2 _context;
        //MODIFICA O CONTEXTO
        public void SetContext(Context2 context)
        {
            this._context = context;
        }

        //AÇÕES POSSIVEIS NA MAQUINA DE ESTADOS
        public abstract void InserirMoeda();

        public abstract void RemoverMoeda();
        public abstract void PedirCafe();

        public abstract void RetirarCafe();
    }

    public class StateA : State2
    {
        public override void InserirMoeda()
        {
            Console.WriteLine("Inserir Moeda");
            this._context.TransistionTo(new StateB());
        }

        public override void RemoverMoeda()
        {
            Console.WriteLine("Tem que inserir moeda");
        }

        public override void PedirCafe()
        {
            Console.WriteLine("Tem que inserir moeda");
        }

        public override void RetirarCafe()
        {
            Console.WriteLine("Tem que inserir moeda");
        }
    }

    public class StateB : State2
    {
        public override void InserirMoeda()
        {
            Console.WriteLine("Ja inserio uma moeda");
        }

        public override void RemoverMoeda()
        {
            Console.WriteLine("Devolvendo a moeda");
            this._context.TransistionTo(new StateA());
        }

        public override void PedirCafe()
        {
            Console.WriteLine("Tirando o cafe");
            this._context.TransistionTo(new StateC());
        }

        public override void RetirarCafe()
        {
            Console.WriteLine("Tem que pedir cafe");
        }
    }
    public class StateC : State2
    {
        public override void InserirMoeda()
        {
            Console.WriteLine("Ja inserio uma moeda");
        }

        public override void RemoverMoeda()
        {
            Console.WriteLine("Impossivel devolver a moeda");
        }

        public override void PedirCafe()
        {
            Console.WriteLine("Ja ta tirando o cafe");
        }

        public override void RetirarCafe()
        {
            this._context.TransistionTo(new StateA());
        }
    }

   public class Client
    {
        Context2 context2;
        
        public void InicarMaquina()
        {
            context2 = new Context2(new StateA());
                Console.WriteLine("Insira a moeda");
                Console.ReadLine();
                context2.InserirMoeda();
                Console.WriteLine("Retirar moeda?");
                var y = Console.ReadLine();
                if (Int32.Parse(y) == 2)
                {
                    context2.PedirCafe();
                    context2.RetirarCafe();
                    Console.WriteLine("Obrigado");
                    return;
                }
                else
                {
                    Console.WriteLine("Entao vai po crl");
                    return;
                }
                
           
        }
    }
}
