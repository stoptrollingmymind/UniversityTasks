using matrix_AS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{


    public class Matrix<T> where T : struct,IComparable,IComparable<T>,IConvertible,IEquatable<T>,IFormattable
    {
        int n;
        int m;
        T[,] mx;
        T[,] TempMatrix;
        public Matrix(int n,int m)
        {

            this.n = n;
            this.m = m;
            mx = new T[n, m];
            
        }



        public override string ToString()
        {
            string matrix="";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    matrix += mx[i, j] + " ";
                matrix += "\n";
            }
            return matrix; 
        }
        
        public T[] VectorOfMiddleRows()
        {
            var VectorR = new T[n];
            T AvgValue;

            for (int i = 0; i < mx.GetLength(0); i++)
            {
                AvgValue = default(T);
                for (int j = 0; j < mx.GetLength(1); j++)
                {

                    AvgValue += mx[i, j];

                }

                VectorR[i] = AvgValue;
                
            }
            return VectorR;
}



            
        
        public T[] VectorOfMiddleCells()
        {
            var VectorC = new T[m];
            T avgValue;



            for (int i = 0; i < mx.GetLength(1); i++)
            {
                avgValue = default(T);
                for (int j = 0; j < mx.GetLength(0); j++)
                {

                    avgValue += mx[j, i];

                }

                VectorC[i] = avgValue;
                
            }
            return VectorC;
        }
        public bool IsSquare { get => this.n == this.m; }
        public int Rank()
        {
           
            if (this.IsSquare)
            {
                int rang = 0;
                int q = 1;

                while (q <= MinValue(mx.GetLength(0), mx.GetLength(1)))
                {
                    double[,] matbv = new double[q, q];
                    for (int i = 0; i < (mx.GetLength(0) - (q - 1)); i++)
                    {
                        for (int j = 0; j < (mx.GetLength(1) - (q - 1)); j++)
                        {
                            for (int k = 0; k < q; k++)
                            {
                                for (int c = 0; c < q; c++)
                                {
                                    matbv[k, c] = mx[i + k, j + c];
                                }
                            }

                            if (Determinant() != 0)
                            {

                                rang = q;
                            }
                        }
                    }
                    q++;
                }

                return rang;
            }
            else
            {
                throw new ArgumentException("matrix is not square");
            }
        }

        private double MinValue(double a, double b)
        {
            if (a > b)
                return b;
            else
                return a;
        }
        private Matrix<T> CreateMatrixWithoutColumn(int column)
        {
            if (column < 0 || column >= this.m)
            {
                throw new ArgumentException("invalid column index");
            }
            var result = new Matrix<T>(this.n, this.m - 1);
            result.ProcessFunctionOverData((i, j) =>
                result[i, j] = j < column ? this[i, j] : this[i, j + 1]);
            return result;
        }
        private Matrix <T> CreateMatrixWithoutRow(int row)
            {
                if (row < 0 || row >= this.n)
                {
                    throw new ArgumentException("invalid row index");
                }
                var result = new Matrix <T>(this.n - 1, this.m);
                result.ProcessFunctionOverData((i, j) =>
                    result[i, j] = i < row ? this[i, j] : this[i + 1, j]);
                return result;
            }
            
            public double Determinant()
            {
                
                if (this.m == 2)
                {
                    return this[0, 0] * this[1, 1] - this[0, 1] * this[1, 0];
                }
                double result = 0;
                for (var j = 0; j < this.m; j++)
                {
                    result += (j % 2 == 1 ? 1 : -1) * this[1, j] *
                        this.CreateMatrixWithoutColumn(j).
                        CreateMatrixWithoutRow(1).Determinant();
                }
                return result;
            }
            public T this[T x, T y]
            {
                get
                {
                    return this.mx[x, y];
                }
                set
                {
                    this.mx[x, y] = value;
                }
            }
            public void ProcessFunctionOverData(Action<int, int> func)
            {
                for (var i = 0; i < this.n; i++)
                {
                    for (var j = 0; j < this.m; j++)
                    {
                        func(i, j);
                    }
                }
            }
             public T Add (int x , int y , T value )
            {
                return mx[x-1, y-1] = value;
            }

        
    }
        
    }





