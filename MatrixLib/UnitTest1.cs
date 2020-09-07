using Microsoft.VisualStudio.TestTools.UnitTesting;
using matrix_AS;
using MatrixLib;
using System;

namespace MatrixTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ZeroMatrix_MustWorkTest()
        {
            Matrix<int> matrix = new Matrix<int>(3, 3);
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    matrix.Add(i, j, 0);
                }
            }
            Console.WriteLine(matrix);
            Assert.AreEqual(0, matrix.Rank());
            Assert.AreEqual(0, int.Parse(matrix.ShowDeterminant()));
        }
        [TestMethod]
        public void OneMatrix_MustWorkTest()
        {
            Matrix<int> matrix = new Matrix<int>(3, 3);
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    if (i == j)
                    {
                        matrix.Add(i, j, 1);
                    }
                    else matrix.Add(i, j, 0);
                }
            }
            Console.WriteLine(matrix);
            Assert.AreEqual(3, matrix.Rank());
            Assert.AreEqual(1, int.Parse(matrix.ShowDeterminant()));
        }
        [TestMethod]
        public void RandomMatrix_MustWorkTest()
        {
            int p = 2;
            Matrix<int> matrix = new Matrix<int>(3, 3);
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    matrix.Add(i, j, p);
                    p++;
                }
            }
            Console.WriteLine(matrix);
            Assert.AreEqual(0, int.Parse(matrix.ShowDeterminant()));
            Assert.AreEqual(3, matrix.Rank());
            
        }
        [TestMethod]
        public void One_X_One_Matrix_MustWorkTest()
        {
            Matrix<int> matrix = new Matrix<int>(1, 1);

            matrix.Add(1, 1, 5);

           
            Console.WriteLine(matrix);
            Assert.AreEqual(1, matrix.Rank());
           Assert.AreEqual(5, int.Parse(matrix.ShowDeterminant()));
        }
        [TestMethod]
        public void Zero_X_Zero_Matrix_MustWorkTest()
        {
            Matrix<int> matrix = new Matrix<int>(3,3);

           


            
            Assert.AreEqual(0, matrix.Rank());
            Assert.AreEqual(0, int.Parse(matrix.ShowDeterminant()));
        }

        
      
    } 
}
