using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP
{
    public class BusinessLogicLayer
    {
        private readonly DataAccesLayer DAL;

        public BusinessLogicLayer(Object details)
        {
            DAL.Save(details);
        }
    }

    interface IRepositoryLayer
    {
        void Save(Object details);
    }

    public class DataAccesLayer : IRepositoryLayer
    {
        public void Save(Object details)
        {
            //perform save
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
