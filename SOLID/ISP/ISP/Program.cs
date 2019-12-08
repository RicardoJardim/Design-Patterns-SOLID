using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP
{
    //INTERFACE COM TUDOS OS METODOS OBRIGA AS CLASSES A 
    //IMPLEMENTAREM TODOS ESTES
    interface IPrintTask
    {
        bool PrintContent(string content);
        bool ScanContent(string content);
        // bool FaxContent(string content);

    }

    //PRINCIPIO DE SEGREGAÇÃO DE INTERFACES
    //MOSTRA QUE DEVEMOS OBRIGAR A IMPLEMENTAR APENAS OS METODOS NECESSÁRIOS
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
