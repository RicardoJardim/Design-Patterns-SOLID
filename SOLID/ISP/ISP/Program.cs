using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP
{
    //Interfaces com tudo obriga as classes implementarem todos 
    //os metodos
    interface IPrintTask
    {
        bool PrintContent(string content);
        bool ScanContent(string content);
        // bool FaxContent(string content);

    }

    //Principio mostra que devemos obrigar a implementação 
    //apenas do metodos necessários
    interface IFaxContent
    {
        bool FaxContent(string content);
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
