using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
   
    class Program
    {
        //CLASSE ABSTRATA QUE IRA TER O DECORATOR E OS COMPONENTES
        //A QUAL O DECORATOR IRA "ADICONAR"
        public abstract class BeverageComponent
        {
            private string description = "Unknown Beverage";

            public virtual string Description
            {
                get => description;
                set => description = value;
            }

            public abstract double Cost();
        }

        //COMPONENTE A QUAL IRA SER ADICONADO OU MODIFICADO
        public class Expresso : BeverageComponent
        {
            public override string Description { get; set; }
            public Expresso()
            {
                Description = "Expresso";
            }

            public override double Cost()
            {
                return 1.99;
            }
        }
        //COMPONENTE A QUAL IRA SER ADICONADO OU MODIFICADO
        public class HouseBlend : BeverageComponent
        {
            public override string Description { get; set; }

            public HouseBlend()
            {
                Description = "HouseBlend";
            }
            public override double Cost()
            {
                return 0.89;
            }
        }

        //DECORATOR QUE IRA TRAZER RECURSOS DOS COMPONENTES
        public abstract class CondimentDecorator : BeverageComponent
        {
            public abstract override string Description { get; }
        }

        //ADICAO OU MODIFICAÇÃO AO COMPONENTE ESCOLHIDO
        public class Mocha : CondimentDecorator
        {
            private BeverageComponent mBeverage;

            public Mocha(BeverageComponent aBeverage)
            {
                this.mBeverage = aBeverage;
            }

            public override string Description
            {
                get { return mBeverage.Description + ", Mocha" ; }
            }

            public override double Cost()
            {
                return 0.2 + mBeverage.Cost();
            }
        }
        
        static void Main(string[] args)
        {
            BeverageComponent beverage1 = new Expresso();
            beverage1 = new Mocha(beverage1);

           Console.WriteLine(beverage1.Description
                              + " $ " + beverage1.Cost());

            BeverageComponent beverage2 = new HouseBlend();
            beverage2 = new Mocha(beverage2);
            beverage2 = new Mocha(beverage2);
            Console.WriteLine(beverage2.Description
                              + " $ " +beverage2.Cost());
            Console.ReadLine();
        }
    }
}
