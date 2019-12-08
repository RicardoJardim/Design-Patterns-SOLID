using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    public abstract class AbstractCaminho
    {
        public void TemplateMethod()
        {
            Login();
            var x = escolha();
            adicionar();
            var y = confirmar(x);
            if (y == 1)
                Logout();
            else
            {
                Console.WriteLine("ADEUS");
            }
        }

        public abstract int escolha();
        public abstract int confirmar(int x);

        public virtual void adicionar() { }

        public void Login()
        {
            Console.WriteLine("Bem vindo ao website ");
        }

        public void Logout()
        {
            Console.WriteLine("Obrigado pela visita");
        }
    }

    public class carro : AbstractCaminho
    {
        public override int escolha()
        {
            Console.WriteLine("Escolha o caminho");
            Console.WriteLine("1 - Madeira Shopping, 2 - Forum Madeira, 3 - Anadia");
            var x = Console.ReadLine();
            return Int32.Parse(x);
        }

        public override int confirmar(int x)
        {
            Console.WriteLine("Confirmar Caminho?");
            Console.WriteLine("1 - Sim, 2- Nao");
            var y = Console.ReadLine();
            return Int32.Parse(y);
        }
    }

    public class pe: AbstractCaminho
    {
        public override int escolha()
        {
            Console.WriteLine("Escolha o caminho");
            Console.WriteLine("1 - Madeira Shopping, 2 - Forum Madeira, 3 - Anadia");
            var x = Console.ReadLine();
            return Int32.Parse(x);
        }

        public override int confirmar(int x)
        {
            Console.WriteLine("Confirmar Caminho?");
            Console.WriteLine("1 - Sim, 2- Nao");
            var y = Console.ReadLine();
            return Int32.Parse(y);
        }

        public override void adicionar()
        {
            Console.WriteLine("Escolha o caminho");
            Console.WriteLine("1 - terra, 2- estrada");
            Console.ReadLine();
        }
    }
}
