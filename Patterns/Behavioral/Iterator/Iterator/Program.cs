using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    //CLASSE ITERATOR QUE IRA ABSTRAIR TODOS OS ALGORITMOS DESEJADOS
    //ITERAÇÃO GENERICA 
    public abstract class Iterator : IEnumerator
    { 
        object IEnumerator.Current => Current();
        public abstract int Key();
        public abstract object Current();
        public abstract bool MoveNext();
        public abstract void Reset();
    }

    //CLASSE AGGREGATE QUE IRA TER OS TIPOS DE DADOS
    //A SER UTILIZADOS PELOS ALGORITMOS 
    public abstract class Aggregate : IEnumerable
    {
        //RETORNA QUAL A ITERAÇÃO UTILIZADA
        public abstract IEnumerator GetEnumerator();
    }

    //CLASSE COM ALGURITMO QUE IRA UTILIZAR A COLEÇÃO DE DADOS
    public class AlphabeticalIterator : Iterator
    {
        //COLEÇÃO DE DADOS
        private WordsCollection _collection;

        private int _position = -1;
        private bool _reverse = false;

        //CONSTRUTOR RECEBE A COLEÇÃO
        public AlphabeticalIterator(WordsCollection collection, bool reverse = false)
        {
            this._collection = collection;
            this._reverse = reverse;

            if (reverse)
            {
                this._position = collection.GetItems().Count;
            }
        }
        //POSIÇÃO ATUAL
        public override int Key()
        {
            return this._position;
        }
        //POSIÇÃO ATUAL NA COLEÇÃO
        public override object Current()
        {
            return this._collection.GetItems()[_position];
        }
        //MOVER PARA O PROXIMO
        public override bool MoveNext()
        {
            int updatedPosition = this._position + (this._reverse ? -1 : 1);

            if (updatedPosition >= 0 && updatedPosition < this._collection.GetItems().Count)
            {
                this._position = updatedPosition;
                return true;
            }
            else
            {
                return false;
            }
        }
        //RESET
        public override void Reset()
        {
            this._position = this._reverse ? this._collection.GetItems().Count - 1 : 0;
        }
    }

    //CLASSE COM A COLEÇÃO DE DADOS 
    public class WordsCollection : Aggregate
    {
        private List<string> _collection = new List<string>();

        private bool _direction = false;

        //MODIFICA A DIREÇÃO
        public void ReverseDirection()
        {
            _direction = !_direction;
        }
        public List<string> GetItems()
        {
            return _collection;
        }
        public void AddItem(string item)
        {
            this._collection.Add(item);
        }
        //RETORNA QUAL O ITERATOR A SER UTILIZADO
        public override IEnumerator GetEnumerator()
        {
            Console.WriteLine("ENUMERATOR INIT");
           return new AlphabeticalIterator(this,_direction);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new WordsCollection();
            collection.AddItem("First");
            collection.AddItem("Second");
            collection.AddItem("Third");
            Console.WriteLine("Straight traversal:");
            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine("\n Reverse traversal:");
            collection.ReverseDirection();
            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }

            Console.ReadLine();
        }
    }
}
