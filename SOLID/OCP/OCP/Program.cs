using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee2 empJohn = new PermeneteEmployee(1, "John");
            Employee2 empJason = new TempEmployee(2, "Jason");


            Console.WriteLine(string.Format("Employee {0} Bonus: {1} ",
                empJohn.ToString(),
                empJohn.CalculateBonus(1000).ToString()));
            Console.WriteLine(string.Format("Employee {0} Bonus: {1} ",
                empJason.ToString(),
                empJason.CalculateBonus(1000).ToString()));
            Console.ReadLine();
        }
    }
}
