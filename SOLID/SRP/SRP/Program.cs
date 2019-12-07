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
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
