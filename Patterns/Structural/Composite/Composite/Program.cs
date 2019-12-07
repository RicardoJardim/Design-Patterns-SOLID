using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    //CLASSE ABSTRATA QUE IRA ABSTRAIR A CONSTRUÇÃO DA ARVORE
    public abstract class Component
    {
        public Component() { }
        //OPERAÇÃO QUE CADA FOLHA E COMPOSITE IRÁ REALIZAR 
        public abstract string Operation();
        //ADICIONAR COMPONENTE A OUTRO COMPONENTE
        public virtual void Add(Component component)
        {

        }
        //REMOVER COMPONENTE DE OUTRO COMPONENTE
        public virtual void Remove(Component component)
        {

        }
        //BUSCAR COMPONENTE DENTRO DE UM COMPONENTE
        public virtual Component GetChild(int index)
        {
            return null;
        }
        //VERIFICA SE PODE TER FILHOS
        public virtual bool IsComposite()
        {
            return true;
        }
    }

    //CONSISTE NUMA CLASSE QUE NAO TEM FILHOS "FOLHA"
    public class Leaf : Component
    {
        public override string Operation()
        {
            return "Leaf";
        }
        public override bool IsComposite()
        {
            return false;
        }
    }

    //CONSISTE NUMA CLASSE QUE TEM FILHOS
    //LISTA COM CONJUNTO DE COMPONENTES
    public class Composite : Component
    {
        private List<Component> _children = new List<Component>();

        //RETORNA O FILHO PELO INDEX DESTE COMPONENTE
        public override Component GetChild(int index)
        {
            return this._children.ElementAt(index);
        }

        //ADICIONA FILHOS
        public override void Add(Component component)
        {
            this._children.Add(component);
        }

        //REMOVE FILHOS
        public override void Remove(Component component)
        {
            this._children.Remove(component);
        }

        //FUNÇÃO PRINCIPAL
        public override string Operation()
        {

            int i = 0;
            string result = "Branch(";

            foreach (Component component in this._children)
            {
                result += component.Operation();
                if (i != this._children.Count - 1)
                {
                    result += "+";
                }
                i++;
            }

            return result + ")";
        }
    }

    //CLASSE CLIENTE
    public class Client
    {
        public void ClientCode(Component leaf)
        {
            Console.WriteLine($"Result: {leaf.Operation()}\n");
        }

        //ADICIONA UM COMPONENTE A OUTRO COMPONENTE
        public void AddComponentToComponent(Component component1, Component component2)
        {
            if (component1.IsComposite())
            {
                component1.Add(component2);
            }

            Console.WriteLine($"Result: {component1.Operation()}");
        }
        public void RemoveComponentofComponent(Component component1, Component component2)
        {
            if (component1.IsComposite())
            {
                component1.Remove(component2);
            }

            Console.WriteLine($"Result: {component1.Operation()}");
        }
        public void GetElementofComponent(Component component1, int index)
        {
            if (component1.IsComposite())
            {
                component1.GetChild(index);
            }

            Console.WriteLine($"Result: {component1.Operation()}");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Client cli = new Client();

            Leaf leaf = new Leaf();
            Console.WriteLine("Client: I get a simple component: ");
            cli.ClientCode(leaf);

            //CRIAÇÃO DOS RAMOS E ARVORE
            Composite MainTree = new Composite();
            Composite ramo1 = new Composite();
            Composite ramo2 = new Composite();
            
            //MANEIRA DE ADICONAR PELA CLASSE
            ramo1.Add(leaf);
           
            //CLIENTE NAO TEM DE SE PREOCUPAR A VERIFICAR OS COMPONENTES
            Console.WriteLine("Primeiro Ramo");
            cli.AddComponentToComponent(ramo1, leaf);
            // ramo1.Add(leaf);

            Console.WriteLine("Segundo Ramo");
            cli.AddComponentToComponent(ramo2, leaf);
            //  ramo2.Add(leaf);
            Console.WriteLine("Arvore com 1 e 2 ramo");
            cli.AddComponentToComponent(MainTree, ramo1);
            cli.AddComponentToComponent(MainTree, ramo2);
            //   MainTree.Add(ramo1);
            //    MainTree.Add(ramo2);

            Console.WriteLine("Client: Now I've got a composite tree:");
            cli.ClientCode(MainTree);
            Console.Write("Client: I don't need to check the components classes even when managing the tree:\n");

            cli.AddComponentToComponent(MainTree, leaf);

            Console.ReadLine();


        }

    }
}
