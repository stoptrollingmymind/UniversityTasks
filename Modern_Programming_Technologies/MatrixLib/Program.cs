using MatrixLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace matrix_AS
{
    class program { 
    

        static void Main(string[] args)
        {
            
            Console.Write("Какого размера создадим матрицу ?\nКоличество строк - ");
            int rows = int.Parse(Console.ReadLine());

            Console.Write("Количество столбцов - ");
            int cells = int.Parse(Console.ReadLine());



            Matrix<int> matrix = new Matrix<int>(3, 3);
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    matrix.Add(i, j, 0);
                }
            }
            Console.WriteLine(matrix);
            Console.WriteLine(matrix.Rank());
            Console.WriteLine(int.Parse(matrix.ShowDeterminant()));









            Console.ReadLine();
        }
    }
}




