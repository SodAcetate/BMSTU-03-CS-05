using System;
using System.Collections;

namespace Lab_05_3
{
    class Program
    {   
        class MyDictionary<TKey,TValue> : IEnumerable{
            Tuple<TKey,TValue>[] _data;
            uint _size;

            public uint Count{ get => _size; }

            public MyDictionary(int size){
                _data = new Tuple<TKey,TValue>[size];
                _size = 0;
            }

            public void Add(TKey key,TValue val){
                if (_size == _data.Length){
                    Tuple<TKey,TValue>[] newData = new Tuple<TKey,TValue>[_size*2];
                    for (int i = 0 ; i < _size ; i ++){
                        newData[i] = _data[i];
                    }
                    _data = newData;
                }
                _data[_size] = new Tuple<TKey,TValue>(key,val);
                _size++;
            }

            public Tuple<TKey,TValue> this[int index]{
                get => _data[index];
            }

            IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)_data.GetEnumerator();
        }
        static void Main(string[] args)
        {
            MyDictionary<int,string> testDictionary = new MyDictionary<int, string>(2);
            testDictionary.Add(1,"Meow");
            testDictionary.Add(1,"Mrrr");
            testDictionary.Add(2,"Woof");
            testDictionary.Add(3,"Ribbit");

            for (int i = 0 ; i < testDictionary.Count ; i ++){
                Console.WriteLine(testDictionary[i]);
            }
            Console.WriteLine("=============");
            foreach (Tuple<int,string> pair in testDictionary){
                Console.WriteLine(pair);
            }

        }
    }
}