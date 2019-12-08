using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSP
{
  
    //DESTE MODO A CLASSE ABSTRATA IMPLEMENTA O IEMPLOYEE E BONUS
    //CONTINUA A RESPEITAR O PRINCIPIO ABERTO/FECHADO
    public abstract class Employee2 : IEmployee, IEmployeeBonus
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Employee2()
        {
        }

        public Employee2(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        //Permite adicionar futuras alterações sem alterar o codigo
        public abstract decimal CalculteBonus(decimal salary);
        public abstract decimal GetMinimumSalary();

        public override string ToString()
        {
            return string.Format("ID : {0} Name : {1}", this.ID, this.Name);
        }
    }

    public class PermeneteEmployee : Employee2
    {
        public PermeneteEmployee()
        {
        }

        public PermeneteEmployee(int id, string name) : base(id, name)
        {
        }

        public override decimal CalculteBonus(decimal salary)
        {
            return salary * 2;
        }

        public override decimal GetMinimumSalary()
        {
            return 150000;
        }


    }
    public class TempEmployee : Employee2
    {
        public TempEmployee()
        {
        }

        public TempEmployee(int id, string name) : base(id, name)
        {
        }

        public override decimal CalculteBonus(decimal salary)
        {
            return salary * 1;
        }

        public override decimal GetMinimumSalary()
        {
            return 5000;
        }
    }

    public class ContractEmployee : IEmployee
    {
        public int ID { get; set; }
       public  string Name { get; set; }
        public ContractEmployee() { }

        public ContractEmployee(int id, string name) 
        {
            this.ID = id;
            this.Name = name;

        }
        //NAO RESPEITA POR TAR A DAR EXCEPTION
        public decimal GetMinimumSalary()
        {
            return 5000;
        }
        public override string ToString()
        {
            return string.Format("ID : {0} Name : {1}", this.ID, this.Name);
        }

    }


}