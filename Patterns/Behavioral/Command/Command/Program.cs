using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    //INTERFACE COMMAND -> REPRESENTAÇÃO DE UM CONJUNTO DE COMMANDOS
    public interface ICommand
    {
        //FUNCÇÃO PERTENCE A TODOS OS COMANDOS
        void Execute();
        //TAMBEM PODERIA TER O undo(), redo(), save()
    }

    //EXEMPLO DE UM COMANDO SIMPLES APENAS COM UM PAYLOAD
    public class ConcreteCommand : ICommand
    {
        private string _payload = "";

        public ConcreteCommand(string payload)
        {
            this._payload = payload;
        }
        public void Execute()
        {
            Console.WriteLine($"ConcreteCommand: See, I can do simple things like printing ({_payload})");
        }
    }

    //EXEMPLO DE UM COMANDO COMPLEXO COM UM RECEIVER E PAYLOAD
    public class ComplexCommand : ICommand
    {
        private Receiver _receiver;
        // Context data, required for launching the receiver's methods.
        private string _a;
        private string _b;

        public ComplexCommand(Receiver receiver, string a, string b)
        {
            this._receiver = receiver;
            this._a = a;
            this._b = b;
        }

        //EXECUTA A AÇÃO DO RECEIVER INDIRETAMENTE 
        public void Execute()
        {
            Console.WriteLine("ComplexCommand: Complex stuff should be done by a receiver object.");
            this._receiver.action(this._a);
            this._receiver.actionElse(this._b);
        }
    }

    //RECIVER QUE CONTEM UM CONJUNTO DE AÇÕES
    public class Receiver
    {
        public void action(string a)
        {
            Console.WriteLine($"Receiver: Working on ({a}.)");
        }

        public void actionElse(string b)
        {
            Console.WriteLine($"Receiver: Also working on ({b}.)");
        }
    }

    //CONJUNTO DOS COMANDOS COM ALGORITMO PARA APLICAR OS COMANDOS
    public class Invoker
    {
        //COMANDO PARA O INICO
        private ICommand _onStart;
        //COMANDO PARA O FIM
        private ICommand _onFinish;

        //INICIALIZA OS COMANDOS
        public void SetOnStart(ICommand command)
        {
            this._onStart = command;
        }
        public void SetOnFinish(ICommand command)
        {
            this._onFinish = command;
        }
        // O INVOKER NAO DEPENDE DO CONCRETE COMMAND NEM DO RECEIVER
        // O INVOKER PASSA UMA SOLICITAÇÃO PARA UM RECEIVER INDIRETAMENTE, EXECUTANDO UM COMANDO
        public void SetCommand()
        {
            Console.WriteLine("Invoker: Does anybody want something done before I begin?");
            if (this._onStart is ICommand)
            {
                this._onStart.Execute();
            }

            Console.WriteLine("Invoker: ...doing something really important...");

            Console.WriteLine("Invoker: Does anybody want something done after I finish?");
            if (this._onFinish is ICommand)
            {
                this._onFinish.Execute();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //INSTANCIA O INVOCAR
            Invoker invoker = new Invoker();

            //REALIZA NO INICO O CONCRETE COMANDO 
            invoker.SetOnStart(new ConcreteCommand("Say Hi!"));
            
            //INSTANCIA O RECEIVER PARA O INVOKER
            Receiver receiver = new Receiver();

            //REALIZA NO FIM O COMPLEX COMANDO 
            invoker.SetOnFinish(new ComplexCommand(receiver, "Send email", "Save report"));

            //REALIZA AS FUNÇÕES
            invoker.SetCommand();

            Console.ReadLine();
        }
    }
}
