using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSP
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IEmployee> employees = new List<IEmployee>();
            employees.Add(new PermeneteEmployee(1,"John"));
            employees.Add(new TempEmployee(2,"Jason"));
            employees.Add(new ContractEmployee(3, "Mike"));


            foreach (var employee in employees)
            {
                Console.WriteLine(string.Format("Employee {0} Bonus: {1} ",
                    employee.ToString(),
                    employee.GetMinimumSalary().ToString()));

            }

            Console.ReadLine();
        }
    }
}
