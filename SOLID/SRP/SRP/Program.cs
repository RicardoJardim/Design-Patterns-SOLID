using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    interface IUser
    {
        bool Login(string username, string password);
        bool Register(string username, string password, string email);
        //  void LogError(string error);
        //  bool SendEmail(string emailContent);
    }
    interface ILogger
    {
        void LogError(string error);
    }
    interface IEmail
    {
        bool SendEmail(string emailContent);
    }

    //CADA CLASSE DEVERA TER APENAS 1 RESPONSABILIDADE
    public class User : IUser
    {
        public bool Login(string username, string password)
        {
            return true;
        }

        public bool Register(string username, string password, string email)
        {
            return true;
        }

       /* public void LogError(string error)
        {
            Console.WriteLine(error);
        }
        public bool SendEmail(string emailContent){
            return true;
        }*/
    }

    //RESPONSABILIDADE DE RESOLVER ERROS
    public class HandleError : ILogger
    {
        public void LogError(string error)
        {
            Console.WriteLine(error);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IUser user = new User();
            var x = user.Login("Ric", "12345");
            if (!x)
            {
                ILogger error = new HandleError();
                error.LogError("Wrong credentials");
            }
            else
            {
                Console.WriteLine("Welcome");
            }

            Console.ReadLine();

        }
    }
}
