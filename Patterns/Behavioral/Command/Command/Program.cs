using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public interface ICommand
    {
        void Execute();
       
    }

    public interface ICommandUndo
    {
        void Undo();
        void Redo();
    }

    public class TaskManager : ICommandUndo
    {

        private Stack<ICommand> UndoList = new Stack<ICommand>();
        private Stack<ICommand> RedoList = new Stack<ICommand>();

        public void Redo()
        {

            var ele = RedoList.Peek();
            ele.Execute();
            UndoList.Push(ele);
            RedoList.Pop();

        }
        public void Undo()
        {
           
            var ele = UndoList.Peek();
            ele.Execute();
            RedoList.Push(ele);
            UndoList.Pop();

        }

        public void AddCommand(ICommand command)
        {
            UndoList.Push(command);
            Console.WriteLine(UndoList.Count);
        }
    }

    public class ComplexCommand : ICommand
    {
        private Receiver mReceiver;
        private string a;
        private string b;

        private TaskManager manager;

        public ComplexCommand(Receiver aReceiver, TaskManager taskManager, string aA, string bB)
        {
            manager = taskManager;
            mReceiver = aReceiver;
            a = aA;
            b = bB;
        }
        public void Execute()
        {
            Console.WriteLine("Complex Command will execute action A");
            mReceiver.actionA("Complex Command " + a);

            Console.WriteLine("Complex Command will execute action A");
            mReceiver.actionB("Complex Command " + b);

            manager.AddCommand(this);
        }


    }

    public class SimpleCommand : ICommand
    {
        private string mParameter;
        public SimpleCommand(string parms)
        {
            mParameter = parms;
        }
        public void Execute()
        {
            Console.WriteLine($"Simple Command says {mParameter}");
        }
    }

    public class Receiver
    {
        public void actionA(string a)
        {
            Console.WriteLine($"Action A from {a}");
        }
        public void actionB(string b)
        {
            Console.WriteLine($"Action b {b}");
        }

    }

    public class Invoker
    {
        private ICommand _onStart;
        private ICommand _onEnd;

        public void SetOnStart(ICommand command)
        {
            _onStart = command;
        }
        public void SetOnEnd(ICommand command)
        {
            _onEnd = command;
        }

        public void SetCommand()
        {
            Console.WriteLine("Starting execution");
            _onStart.Execute();
            _onEnd.Execute();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Invoker invoker = new Invoker();

            TaskManager task = new TaskManager();

            //REALIZA NO INICO O CONCRETE COMANDO 
            invoker.SetOnStart(new SimpleCommand("Say Hi!"));

            //INSTANCIA O RECEIVER PARA O INVOKER
            Receiver receiver = new Receiver();

            //REALIZA NO FIM O COMPLEX COMANDO 
            invoker.SetOnEnd(new ComplexCommand(receiver, task, "Send email", "Save report"));

            //REALIZA AS FUNÇÕES
            invoker.SetCommand();

            task.Redo();
            Console.ReadLine();
        }
    }
}
