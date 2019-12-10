using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Memento
{
    //INTEFACE PARA O MEMENTO
    public interface IMemento
    {
        //GUARDA O OBJETO
        void Save(string label, object value);
        //BUSCA O ELEMENTO
        object ObjectRestore(string label);
    }

    //CLASSE MEMENTO
    public class Memento : IMemento
    {
        //DICIONARIO PARA KEY E VAL PARA GUARDAR OBEJTOS NO MEMENTO
        private IDictionary<string,object> mData = new Dictionary<string, object>();

        //VERIFICA SE CONTEM
        //GAURDA SE NAO CONTEM
        public void Save(string label, object value)
        {
            if (mData.ContainsKey(label))
                mData[label] = value;
            else
                mData.Add(label,value);
        }

        //RESTORE DO OBJETO
        public object ObjectRestore(string label)
        {
            if(!mData.ContainsKey(label))
                throw new NotImplementedException();
            return mData[label];
        }
    }

    //CLASS USER QUE IRA GUARDAR OS DADOS 
    public class User
    {
        private string name = "Ricardo";
        private int id = 1;
        private int code = 12345;

        //FUNCAO PARA GUARDAR OS DADOS
        public void Serielize(IMemento memento)
        {
            memento.Save("name",name);
            memento.Save("id", id);
            memento.Save("code", code);

        }

        //FUNCAO PARA RETORNAR OS DADOS
        public void Deserielise(IMemento memento)
        {
            name = (string) memento.ObjectRestore("name");
            id = (int)memento.ObjectRestore("id");
            code = (int)memento.ObjectRestore("code");

        }

    }

    //CLASSE QUE IRA RELACIONAR O MOMENTO COM A CLASSE USER EM QUESTAO
    public class StateHolder
    {
        private IDictionary<User,IMemento> mPreviusState = new ConcurrentDictionary<User, IMemento>();

        //GUARDA VALORES DO USER NO MOMENTO 
        public void Regist(User user)
        {
            var memento = new Memento();
            user.Serielize(memento);
            mPreviusState.Add(user,memento);
        }

        //RESTORE DOS ELEMENTOS DO USER EM QUESTAO
        public void RollBack(User user)
        {
            var memento = mPreviusState[user];
            user.Deserielise(memento);
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            User cli = new User();
            StateHolder state = new StateHolder();
            state.Regist(cli);

            Console.ReadLine();

        }
    }
}
