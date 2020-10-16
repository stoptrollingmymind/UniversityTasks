using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix_AS
{
    public interface IMatrix<T>
    {
        string ShowVectorOfMiddleRows();
        T[] VectorOfMiddleRows();
        T[] VectorOfMiddleColumns();       
        int Rank();
        T Determinant(T[,] matrix);
        T Add(int x, int y, T value);
        T ShowDet();
    }
}       







