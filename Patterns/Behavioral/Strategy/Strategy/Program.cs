using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    //Classe que ira excecutar a operação desejada
    //utilizando algoritmos definidos pelas subclasses do IStrategy
    public class Context
    {
        //associação com a interface
        private IStrategy _strategy;
        public Context() { }

        public Context(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        //Aplicação da strategy
        public void SetStrategy(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        //funcção principal que irá correr quando precisarmos de uma estratégia
        public void Operation()
        {
            Console.WriteLine("Context: Sorting data using the strategy (not sure how it'll do it)");
            //Chama a strategy atualmente associada com o seu algoritmo
            var result = this._strategy.DoAlgorithm(new List<string> { "c", "a", "d", "f", "e" });

            string resultStr = string.Empty;
            foreach (var element in result as List<string>)
            {
                resultStr += element + ",";
            }

            Console.WriteLine(resultStr);
        }
    }

    //Interface IStrategy
    public interface IStrategy
    {
        object DoAlgorithm(object data);
    }

    //Estratégia 1
    public class ConcreteStrategyA : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;
            list.Sort();
            return list;
        }
    }
    //Estratégia 2
    public class ConcreteStrategyB : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;
            list.Sort();
            list.Reverse();
            return list;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Instancia o Context
            var context = new Context();
            Console.WriteLine("Client: Strategy is set to normal sorting,");
            //Aplica a estratégia 
            context.SetStrategy(new ConcreteStrategyA());
            //Corre a estragégia e retorna o resultado
            context.Operation();

            Console.WriteLine();
            Console.WriteLine("Client: Change strategy for reverse");
            context.SetStrategy(new ConcreteStrategyB());
            context.Operation();
            Console.ReadLine();
        }
    }
}
