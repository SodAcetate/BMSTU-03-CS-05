using System;

namespace Lab_05_2
{
    class Program
    {
        class MyList<T>{
            T[] _data;
            uint _size;

            public uint Count { get => _size; }

            public MyList(){
                _data = new T[0];
                _size = 0;
            }
            public MyList(uint size){
                _data = new T[size];
                _size = 0;
            }

            public MyList(T[] src){
                _data = src;
                _size = (uint)src.Length;
            }

            public void Add(T item){
                if (_size == _data.Length){
                    T[] newData = new T[_size*2];
                    for (int i = 0 ; i < _size ; i ++){
                        newData[i] = _data[i];
                    }
                    _data = newData;
                }
                _data[_size] = item;
                _size++;
            }  

            public T this[uint index]{
                get => _data[index];
                set => _data[index] = value;
            }



        }
        static void Main(string[] args)
        {
            MyList<string> testList = new MyList<string>(new string[] {new string("Meow"),
                                                    new string("Moo"),
                                                    new string("Ribbit"),
                                                    new string("Woof"),
                                                    new string("Squeak")});

            for (uint i = 0 ; i < testList.Count ; i ++){
                Console.WriteLine(testList[i]);
            }
            Console.WriteLine("================");

            testList.Add("Hoot-hoot");

            for (uint i = 0 ; i < testList.Count ; i ++){
                Console.WriteLine(testList[i]);
            }
        }
    }
}