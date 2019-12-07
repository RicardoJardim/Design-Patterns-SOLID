using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    
    public abstract class AbstractComponent
    {
        public abstract string Operation();
    }

    //COMPONENTE ESPECIFICO 
    public class Componente : AbstractComponent
    {
        //RETORNA A SUA ESPECIFICA OPERAÇÃO
        public override string Operation()
        {
            return "Concrete Component";
        }
    }

    //DECORATOR 
    public abstract class Decorator : AbstractComponent
    {
        private AbstractComponent _component;

        public Decorator(AbstractComponent component)
        {
            this._component = component;
        }
        
        public override string Operation()
        {
            if (this._component != null)
            {
                return this._component.Operation();
            }
            else
            {
                return string.Empty;
            }
        }
    }

    public class ConcreteDecoratorA : Decorator
    {
        public ConcreteDecoratorA(AbstractComponent comp) : base(comp)
        {

        }
        public override string Operation()
        {
            return $"ConcreteDecoratorA( {base.Operation()} )";
        }
    }
    public class ConcreteDecoratorB : Decorator
    {
        public ConcreteDecoratorB(AbstractComponent comp) : base(comp)
        {

        }
        public override string Operation()
        {
            return $"ConcreteDecoratorB( {base.Operation()} )";
        }
    }
    /*class Program
    {
        static void Main(string[] args)
        {
            var simple = new ConcreteComponent();
            Console.WriteLine("Client: I get a simple component:");
            Console.WriteLine(simple.Operation());
            Console.WriteLine();

            ConcreteDecoratorA decorator1 = new ConcreteDecoratorA(simple);
            ConcreteDecoratorB decorator2 = new ConcreteDecoratorB(decorator1);
            Console.WriteLine("Client: Now I've got a decorated component:");
            Console.WriteLine(decorator1.Operation());
            Console.ReadLine();
        }
    }*/
}
