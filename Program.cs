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


            var matrix = new Matrix<int>(rows, cells);
            matrix.Add(2, 2, 99);
            matrix.ShowMatrix();

           

            
            

            matrix.Rank();

            
            
            Console.ReadLine();
        }
    }
}




