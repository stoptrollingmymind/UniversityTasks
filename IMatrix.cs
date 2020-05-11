using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix_AS
{
    public interface IMatrix<T>
    {
        void ShowMatrix();
        void middle_of_rows_vector();
        void middle_of_cells_vector();
        bool IsSquare();
        int Rank();
        double Determinant();
        void ProcessFunctionOverData(Action<int, int> func);
        void Add(int x, int y, double value);
    }
}






