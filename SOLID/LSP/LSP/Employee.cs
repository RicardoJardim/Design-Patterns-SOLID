using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSP
{/*
    //NAO IMPLEMENTA A LSP
    public abstract class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }



        public Employee()
        {

        }

        public Employee(int id, string name)
        {
            this.ID = id;
            this.Name = name;

        }

        //Permite adicionar futuras alterações sem alterar o codigo
        //PRINCIPIO ABERTO/FECHADO
        public abstract decimal CalculateBonus(decimal salary);


        public override string ToString()
        {
            return string.Format("ID : {0} Name : {1}", this.ID, this.Name);
        }
    }

    public class PermeneteEmployee : Employee
    {
        public PermeneteEmployee()
        {
        }

        public PermeneteEmployee(int id, string name) : base(id, name)
        {
        }

        public override decimal CalculateBonus(decimal salary)
        {
            return salary * 2;
        }
    }
    public class TempEmployee : Employee
    {
        public TempEmployee()
        {
        }

        public TempEmployee(int id, string name) : base(id, name)
        {
        }

        public override decimal CalculateBonus(decimal salary)
        {
            return salary;
        }
    }

    public class ContractEmployee : Employee
    {
        public ContractEmployee() { }

        public ContractEmployee(int id, string name) : base(id, name)
        {
           
        }
        //CASO UMA DAS SUBCLASSES NAO IMPLEMENTE ESTE MÉTODO 
        //NAO PRESPEITA O PRINCIPIO DE LISKOV
        public override decimal CalculateBonus(decimal salary)
        {
            throw new NotImplementedException();
        }
    }

    */
}