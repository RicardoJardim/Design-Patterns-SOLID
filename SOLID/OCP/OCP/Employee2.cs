using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP
{
    public abstract class Employee2
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
        public abstract decimal CalculateBonus(decimal salary);


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

            public PermeneteEmployee(int id, string name) : base(id,name)
            {
            }

            public override decimal CalculateBonus(decimal salary)
            {
                return salary * 2;
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

        public override decimal CalculateBonus(decimal salary)
        {
            return salary ;
        }
    }
}