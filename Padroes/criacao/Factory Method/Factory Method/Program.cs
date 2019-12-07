using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method
{
        //CRIAÇÃO DO CONJUNTO DE FABRICAS
        public abstract class PizzaStore
        {
            public IPizza orderPizza(string type)
            {
                IPizza pizza = createPizza(type);
                pizza.preprare();
                pizza.bake();
                pizza.cut();
                pizza.box();

                return pizza;

            }
            //CADA FABRICA TERA O SEU METODO DE CRIAÇÃO DE PIZZAS
            public abstract IPizza createPizza(string type);
        }

        //FABRICA DO FUNCHAL CONTEM AS PIZZAS PRINCIPAIS
        public class PizzaFunchal : PizzaStore
        {
            public override IPizza createPizza(string type)
            {
                IPizza pizza = null;
                if (type.Equals( "cheese" ))
                {
                    pizza = new CheesePizza();
                }
                else if (type.Equals("greek") )
                {
                    pizza = new GreekPizza();
                }
                return pizza;
            }
        }
        //FABRICA DE LISBOA CONTEM AS PIZZAS PRINCIPAIS
        public class PizzaLisboa : PizzaStore
        {
            public override IPizza createPizza(string type)
            {
                IPizza pizza = null;
                if (type.Equals("pepperoni") )
                {
                    pizza = new PepperoniPizza();
                }
                else if (type.Equals("greek"))
                {
                    pizza = new GreekPizza();
                }
                return pizza;
            }
        }

        //INTERFACE PARA O OBJETO PIZZA, COM AS FUNÇÕES PREDEFINIDAS
        public interface IPizza
        {
                void preprare();
                void bake();
                void cut();
                void box();
        }
        
        //CADA OBJETO DE PIZZA
        public class CheesePizza : IPizza
        {
            public void preprare()
            {
                Console.WriteLine("Preparando a CheesePizza");
            }

            public void bake()
            {
            Console.WriteLine("Cozendo a CheesePizza");
        }

            public void cut()
            {
            Console.WriteLine("Cortando a CheesePizza");
        }

            public void box()
            {
            Console.WriteLine("Enviado a CheesePizza");
             }
        }

        public class PepperoniPizza : IPizza
        {
            public void preprare()
            {
                Console.WriteLine("Preparando a PepperoniPizza");
            }

            public void bake()
            {
                Console.WriteLine("Cozendo a PepperoniPizza");
            }

            public void cut()
            {
                Console.WriteLine("Cortando a PepperoniPizza");
            }

            public void box()
            {
                Console.WriteLine("Enviado a PepperoniPizza");
            }
        }
        public class GreekPizza : IPizza
        {
            public void preprare()
            {
                Console.WriteLine("Preparando a GreekPizza");
            }

            public void bake()
            {
                Console.WriteLine("Cozendo a GreekPizza");
            }

            public void cut()
            {
                Console.WriteLine("Cortando a GreekPizza");
            }

            public void box()
            {
                Console.WriteLine("Enviado a GreekPizza");
            }
        }

    public class Client
    {
        public void Main(string pizza)
        {
            Console.WriteLine("App: Launched with the PizzaFunchal.");
            ClientCode(new PizzaFunchal(),pizza);

            Console.WriteLine("");

            Console.WriteLine("App: Launched with the PizzaLisboa.");
            ClientCode(new PizzaLisboa(),pizza);

            Console.ReadLine();
        }


        public void ClientCode(PizzaStore creator, string pizza)
        {
           creator.orderPizza(pizza);
          
        }
    }

    class Program
        {
        static void Main(string[] args)
        {
            // new Client().Main("greek");

            Console.WriteLine("App: Launched with the PizzaFunchal.");
            PizzaStore store =  new PizzaFunchal();
            store.orderPizza("greek");

            Console.WriteLine("");

            Console.WriteLine("App: Launched with the PizzaLisboa.");
            store = new PizzaLisboa();
            store.orderPizza("pepperoni");


            Console.ReadLine();
        }
    }
}
