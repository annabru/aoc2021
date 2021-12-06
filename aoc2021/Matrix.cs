using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021
{
    public class Matrix<T>
    {
        T[,] matrix;

        public Matrix(int size){
            matrix = new T[size,size];
        }

        public T[] GetColumn(int columnNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(0))
                    .Select(x => matrix[x, columnNumber])
                    .ToArray();
        }

        public T[] GetRow(int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                    .Select(x => matrix[rowNumber, x])
                    .ToArray();
        }

        public void SetRow(T[] row, int rowNumber)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[rowNumber, i] = row[i];
            }
        }

        public void SetColumn(T[] row, int colNumber)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[colNumber, i] = row[i];
            }
        }
    }
}
