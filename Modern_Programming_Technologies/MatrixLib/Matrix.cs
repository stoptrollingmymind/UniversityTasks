using matrix_AS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{


    public static class Calculator<T>
    {
        static Calculator()
        {
            Add = CreateDelegate<T>(Expression.AddChecked, "Addition", true);
            Subtract = CreateDelegate<T>(Expression.SubtractChecked, "Substraction", true);
            Multiply = CreateDelegate<T>(Expression.MultiplyChecked, "Multiply", true);
            Divide = CreateDelegate<T>(Expression.Divide, "Divide", true);
            Modulo = CreateDelegate<T>(Expression.Modulo, "Modulus", true);
            Negate = CreateDelegate(Expression.NegateChecked, "Negate", true);
            Plus = CreateDelegate(Expression.UnaryPlus, "Plus", true);
            Increment = CreateDelegate(Expression.Increment, "Increment", true);
            Decrement = CreateDelegate(Expression.Decrement, "Decrement", true);
            
        }

        static private Func<T, T2, T> CreateDelegate<T2>(Func<Expression, Expression, Expression> @operator, string operatorName, bool isChecked)
        {
            try
            {
                Type convertToTypeA = ConvertTo(typeof(T));
                Type convertToTypeB = ConvertTo(typeof(T2));
                ParameterExpression parameterA = Expression.Parameter(typeof(T), "a");
                ParameterExpression parameterB = Expression.Parameter(typeof(T2), "b");
                Expression valueA = (convertToTypeA != null) ? Expression.Convert(parameterA, convertToTypeA) : (Expression)parameterA;
                Expression valueB = (convertToTypeB != null) ? Expression.Convert(parameterB, convertToTypeB) : (Expression)parameterB;
                Expression body = @operator(valueA, valueB);
                if (convertToTypeA != null)
                {
                    if (isChecked)
                        body = Expression.ConvertChecked(body, typeof(T));
                    else
                        body = Expression.Convert(body, typeof(T));
                }
                return Expression.Lambda<Func<T, T2, T>>(body, parameterA, parameterB).Compile();
            }
            catch
            {
                return (a, b) =>
                {
                    throw new InvalidOperationException("Operator " + operatorName + " is not supported by type " + typeof(T).FullName + ".");
                };
            }
        }

        static private Func<T, T> CreateDelegate(Func<Expression, Expression> @operator, string operatorName, bool isChecked)
        {
            try
            {
                Type convertToType = ConvertTo(typeof(T));
                ParameterExpression parameter = Expression.Parameter(typeof(T), "a");
                Expression value = (convertToType != null) ? Expression.Convert(parameter, convertToType) : (Expression)parameter;
                Expression body = @operator(value);
                if (convertToType != null)
                {
                    if (isChecked)
                        body = Expression.ConvertChecked(body, typeof(T));
                    else
                        body = Expression.Convert(body, typeof(T));
                }
                return Expression.Lambda<Func<T, T>>(body, parameter).Compile();
            }
            catch
            {
                return (a) =>
                {
                    throw new InvalidOperationException("Operator " + operatorName + " is not supported by type " + typeof(T).FullName + ".");
                };
            }
        }

        static private Type ConvertTo(Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Char:
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.Int16:
                case TypeCode.UInt16:
                    return typeof(int);
            }
            return null;
        }
       
        /// Adds two values of the same type.
        /// Supported by: All numeric values.
        public static readonly Func<T, T, T> Add;
        
        /// Subtracts two values of the same type.
        /// Supported by: All numeric values.
        
        public static readonly Func<T, T, T> Subtract;

       
        /// Multiplies two values of the same type.
        /// Supported by: All numeric values.       
        
        public static readonly Func<T, T, T> Multiply;

        
        /// Divides two values of the same type.
        /// Supported by: All numeric values.
        
        public static readonly Func<T, T, T> Divide;

       
        /// Divides two values of the same type and returns the remainder.
        /// Supported by: All numeric values.
        
        public static readonly Func<T, T, T> Modulo;

       
        /// Gets the negative value of T.
        /// Supported by: All numeric values, but will throw an OverflowException on unsigned values which are not 0.
        
        public static readonly Func<T, T> Negate;

       
        /// Gets the negative value of T.
        /// Supported by: All numeric values.
       
        public static readonly Func<T, T> Plus;

        
        /// Gets the negative value of T.
        /// Supported by: All numeric values.
        
        public static readonly Func<T, T> Increment;

        
        /// Gets the negative value of T.
        /// Supported by: All numeric values.
        
        public static readonly Func<T, T> Decrement;

    }

    public class Matrix<T> : IMatrix<T> where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {
        int n;
        int m;

        T[,] mx;

        public Matrix(int n, int m)
        {

            this.n = n;
            this.m = m;
            mx = new T[n, m];

        }






        public override string ToString()
        {
            string matrix = "";
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

                    AvgValue = Calculator<T>.Add(AvgValue, mx[i, j]);

                }

                VectorR[i] = AvgValue;

            }
            return VectorR;
        }


        public string ShowVectorOfMiddleRows()
        {
            string result = "";
            for (int i = 0; i < VectorOfMiddleRows().Length; i++)
            {
                result += VectorOfMiddleRows()[i].ToString();
                result += " ";
            }
            return result;

        }


        public T[] VectorOfMiddleColumns()
        {
            var VectorC = new T[m];
            T avgValue;



            for (int i = 0; i < mx.GetLength(1); i++)
            {
                avgValue = default(T);
                for (int j = 0; j < mx.GetLength(0); j++)
                {

                    avgValue = Calculator<T>.Add(avgValue, mx[j, i]);

                }

                VectorC[i] = avgValue;

            }
            return VectorC;
        }
        public string ShowVectorOfMiddleColumns()
        {
            string result = "";
            for (int i = 0; i < VectorOfMiddleRows().Length; i++)
            {
                result += VectorOfMiddleColumns()[i].ToString();
                result += " ";
            }

            return result;
        }

        public bool IsSquare { get => this.n == this.m; }

        public int Rank()
        {
            int rank = 0;


            for (int k = 0; k < n; k++)
            {
                for (int i = k + 1; i < n; i++)
                {
                    T c = default(T);

                    if (mx[k, k].Equals(default(T)))
                    {

                        mx = RowPivot(mx, k);
                        
                    }
                    if (!mx[k, k].Equals(default(T)))
                        c = Calculator<T>.Divide(mx[i, k], mx[k, k]);


                    for (int k1 = 0; k1 < m; k1++)
                    {
                        mx[i, k1] = Calculator<T>.Subtract(mx[i, k1], Calculator<T>.Multiply(mx[k, k1], c));
                    }
                }



                T sum = default(T);

                for (int i = 0; i < m; i++)
                {
                    sum = Calculator<T>.Add(sum, mx[k, i]);
                }

                if (!sum.Equals(default(T))) { rank++; }
            }


            return rank;
        }

        private T[,] RowPivot(T[,] matrix, int k)
        {

            for (int i = k + 1; i < matrix.GetLength(0); i++)
            {
                if (!matrix[i, i].Equals(default(T)))
                {
                    T[] x = new T[mx.GetLength(1)];

                    for (int j = 0; j < mx.GetLength(1); j++)
                    {
                        x[j] = matrix[k, j];
                        mx[k, j] = matrix[i, j];
                        mx[i, j] = matrix[j, 0];
                    }
                    break;
                }
            }

            return matrix;
        }

        public T Determinant(T[,] matrix)
        {
            if (matrix.Length == 1)
            {
                return mx[0, 0];
            }
            if (matrix.Length == 4)
            {
                return Calculator<T>.Subtract(Calculator<T>.Multiply(matrix[0, 0], matrix[1, 1]), Calculator<T>.Multiply(matrix[0, 1], matrix[1, 0]));
            }
            T sign = default(T);
            sign = Calculator<T>.Increment(sign);
            T result = default(T);
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                T[,] minor = GetMinor(matrix, i);
                result = Calculator<T>.Add(result, Calculator<T>.Multiply(Calculator<T>.Multiply(sign, matrix[0, i]), Determinant(minor)));
                sign = Calculator<T>.Negate(sign);
            }
            return result;
        }

        private static T[,] GetMinor(T[,] matrix, int n)
        {
            T[,] result = new T[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 0, col = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == n)
                        continue;
                    result[i - 1, col] = matrix[i, j];
                    col++;
                }
            }
            return result;
        }

        private double MinValue(double a, double b)
        {
            if (a > b)
                return b;
            else
                return a;
        }

        static T SignOfElement(int i, int j)
        {
            if ((i + j) % 2 == 0)
            {
                return Calculator<T>.Increment(default(T));
            }
            else
            {
                return Calculator<T>.Decrement(default(T));
            }
        }

        public T ShowDet()
        {
            return Determinant(mx);
        }
        public T this[int x, int y]
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

        public T Add(int x, int y, T value)
        {
            return mx[x - 1, y - 1] = value;
        }
        public string ShowDeterminant()
        {
            return Determinant(mx).ToString();
        }


    }

}





