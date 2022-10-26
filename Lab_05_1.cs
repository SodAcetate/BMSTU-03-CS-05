using System;

namespace Lab_05_1
{
    class Program
    {
        static int min = 1;
        static int max = 100;

        static Random rng = new Random();
        class MyMatrix{
            double[][] _matrix;
            uint _height;
            uint _width;

            public MyMatrix(uint m, uint n){
                _height = m;
                _width = n;
                _matrix = new double[m][];
                for (int i = 0 ; i < m ; i++){
                    _matrix[i] = new double[n];
                    for (int j = 0 ; j < n ; j ++){
                        _matrix[i][j] = rng.Next(min, max);
                    }
                }
            }

            public void Fill(){
                for (int i = 0 ; i < _height ; i++){
                    for (int j = 0 ; j < _width ; j ++){
                        _matrix[i][j] = rng.Next(min, max);
                    }
                }
            }

            public void ChangeSize(uint m, uint n){
                double[][] newMatrix = new double[m][];
                for (int i = 0 ; i < m ; i++){
                    newMatrix[i] = new double[n];
                    for (int j = 0 ; j < n ; j ++){
                        if (i < _height && j < _width)
                            newMatrix[i][j] = _matrix[i][j];
                        else
                            newMatrix[i][j] = rng.Next(min, max);
                    }
                }
                _matrix = newMatrix;
                _height = m;
                _width = n;
            }

            public void ShowPartially(uint mMin, uint mMax, uint nMin, uint nMax){
                for (uint i = mMin ; i < mMax+1 ; i++){
                    for (uint j = nMin ; j < nMax+1 ; j ++){
                        Console.Write($"{_matrix[i][j]}\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            public void Show(){
                ShowPartially(0,_height-1,0,_width-1);
            }

            public double this[uint i, uint j]{
                get => _matrix[i][j];
                set => _matrix[i][j] = value;
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            MyMatrix testMatrixA = new MyMatrix(3,3);
            testMatrixA.Show();
            testMatrixA.ShowPartially(1,2,1,2);
            testMatrixA.ChangeSize(2,5);
            testMatrixA.Show();
            testMatrixA.Fill();
            testMatrixA.Show();
            testMatrixA[1,2] = 10000;
            testMatrixA.Show();
        }
    }
}