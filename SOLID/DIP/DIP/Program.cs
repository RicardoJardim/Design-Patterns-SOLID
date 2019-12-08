using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP
{ 
    
    //PRINCIPIO DE INVERSÃO DE DEPENDENCIAS 
    //DEVEMOS PROGRAMAR PARA UMA INTERFACE E NAO PARA UMA IMPLEMENTAÇÃO
    // INTERFACE COM O METODO QUE RECEBE UM OBJETO 
    interface IRepositoryLayer
    {
        void Save(Object details);
    }

    //CLASSE QUE TEM ASSOCIAÇÃO DE DAL
    public class BusinessLogicLayer
    {
        private readonly IRepositoryLayer DAL;

        public BusinessLogicLayer(Object details, DataAccesLayer dal)
        {
            DAL = dal;
            DAL.Save(details);
        }
    }
    //IMPLEMENTA A INTERFACE
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
