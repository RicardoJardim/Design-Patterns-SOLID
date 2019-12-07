using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Abstract_Factory
{
    // Interface para as factories, ambos têm mesas e cadeiras
    public interface IAbstractFactory
    {
        IProductMesa CreateMesa();
        IPRoductCadeira CreateCadeira();
    }

    //Factory aki com produtos em madeira
    public class FactoryAki : IAbstractFactory
    {
        public IProductMesa CreateMesa()
        {
            return new MesaMadeira();
        }
        public IPRoductCadeira CreateCadeira()
        {
            return new CadeiraMadeira();
        }
    }
    //Factory conforama com produtos em vidro
    public class FactoryConforama : IAbstractFactory
    {
        public IProductMesa CreateMesa()
        {
            return new MesaVidro();
        }
        public IPRoductCadeira CreateCadeira()
        {
            return new CadeiraVidro();
        }
    }

    //Interface para produto Mesa
    public interface IProductMesa
    {
        void Mesa();
    }
    //Mesa de madeira
    class MesaMadeira : IProductMesa
    {
        public void Mesa()
        {
            Console.WriteLine( "Criando uma mesa de madeira");
        }
    }
    //Mesa de Vidro
    class MesaVidro : IProductMesa
    {
        public void Mesa()
        {
            Console.WriteLine("Criando uma mesa de vidro");
        }
    }

    //Interface para cadeiras, criando um conjunto com as mesas
    public interface IPRoductCadeira
    {
        void Cadeira();

        void CadeiraComMesa(IProductMesa collaborator);
    }
    //Cadeira de Madeira como seu colaborador
    class CadeiraMadeira : IPRoductCadeira
    {
        public void Cadeira()
        {
            Console.WriteLine("Criando uma Cadeira de madeira");
        }

        public void CadeiraComMesa(IProductMesa collaborator)
        {

            Console.WriteLine( "Em conjunto com :");
            collaborator.Mesa();
        }
    }
    //Cadeira de Vidro como seu colaborador
    class CadeiraVidro : IPRoductCadeira
    {
        public void Cadeira()
        {
            Console.WriteLine("Criando uma Cadeira de vidro");
        }
        public void CadeiraComMesa(IProductMesa collaborator)
        {
            Console.WriteLine("Em conjunto com: ");
            collaborator.Mesa();
        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("Client: Conjuntos de madeira no Aki ...");
            ClientMethod(new FactoryAki());
            Console.WriteLine();

            Console.WriteLine("Client: Conjuntos de vidro no conforama...");
            ClientMethod(new FactoryConforama());
            Console.ReadLine();
        }

        public void ClientMethod(IAbstractFactory factory)
        {
            var productA = factory.CreateMesa();
            var productB = factory.CreateCadeira();

            productB.Cadeira();
            productB.CadeiraComMesa(productA);
            
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }
}
