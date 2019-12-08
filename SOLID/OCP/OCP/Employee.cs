using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string EmployeeType { get; set; }

        public Employee()
        {

        }

        public Employee(int id, string name, string employeeType)
        {
            this.ID = id;
            this.Name = name;
            this.EmployeeType = employeeType;
        }

        //NAO SEGUE O PRINCIPIO ABERTO/FECHADO
        //NAO PERMITE FUTURAS ALTERAÇÕES
        public decimal CalculateBonus(decimal salary)
        {
            if (this.EmployeeType == "Permanent")
                return salary * 2;
            else
                return salary * 1;
        }

        public override string ToString()
        {
            return string.Format("ID : {0} Name : {1}", this.ID, this.Name);
        }
    }
}
