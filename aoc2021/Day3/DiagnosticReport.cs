using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021.Day3
{
    public class DiagnosticReport
    {
        private List<List<int>> columns;

        private int gammaVal = 0;
        private int epsilonVal = 0;

        private string gamma = "";
        private string epsilon = "";

        public int PowerConsumption(bool[,] matrix)
        {
            List<int> bitCount = GetMostCommonBitInColumns(matrix);

            foreach (int mostCommonBit in bitCount)
            {
                if (mostCommonBit >= 0)
                {
                    gamma += "1";
                    epsilon += "0";
                }
                else
                {
                    gamma += "0";
                    epsilon += "1";
                }
            }

            gammaVal = GetDecimalFromBinary(gamma);
            epsilonVal = GetDecimalFromBinary(epsilon);

            return gammaVal * epsilonVal;
        }

        public int GetLifeSupportRating(bool[,] matrix)
        {
            var ox = GetOxygenGeneratorRating(matrix);
            var c02 = GetCO2ScrubberRating(matrix);

            return ox * c02;
        }

        private int GetCO2ScrubberRating(bool[,] matrix)
        {
            bool[,] reducedMatrix = GetCO2ScrubberReducer(matrix, 0);

            var row = GetRow(reducedMatrix, 0);

            int val = GetDecimalFromBinary(row);

            return val;
        }


        private int GetOxygenGeneratorRating(bool[,] matrix)
        {
            bool[,] reducedMatrix = OxygenGeneratorReducer(matrix, 0);

            var row = GetRow(reducedMatrix, 0);

            int val = GetDecimalFromBinary(row);

            return val;
        }

        private int GetDecimalFromBinary(bool[] row)
        {
            string bin = "";
            foreach (bool b in row)
            {
                if (b)
                {
                    bin += "1";
                }
                else
                {
                    bin += "0";
                }
            }
            return GetDecimalFromBinary(bin);
        }

        private bool[,] GetCO2ScrubberReducer(bool[,] matrix, int checkColumn)
        {
            bool[,] newMatrix;
            var col = GetColumn(matrix, checkColumn);
            if (GetMostCommonBitFromColum(col) >= 0)
            {
                newMatrix = RemoveRows(matrix, checkColumn, false);
            }
            else
            {
                newMatrix = RemoveRows(matrix, checkColumn, true);
            }

            if (newMatrix.GetLength(0) <= 1 || checkColumn >= matrix.GetLength(1))
            {
                return newMatrix;
            }
            return GetCO2ScrubberReducer(newMatrix, checkColumn + 1);
        }

        private bool[,] OxygenGeneratorReducer(bool[,] matrix, int checkColumn)
        {
            bool[,] newMatrix;
            var col = GetColumn(matrix, checkColumn);
            if (GetMostCommonBitFromColum(col) >= 0)
            {
                newMatrix = RemoveRows(matrix, checkColumn, true);
            }
            else
            {
                newMatrix = RemoveRows(matrix, checkColumn, false);
            }

            if(newMatrix.GetLength(0) <= 1 || checkColumn >= matrix.GetLength(1))
            {
                return newMatrix;
            }
            return OxygenGeneratorReducer(newMatrix, checkColumn+1);
        }

        private bool[,] RemoveRows(bool[,] matrix, int columIndex, bool keepRowIfValIs)
        {
            int rowCount = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if( matrix[i, columIndex] == keepRowIfValIs)
                {
                    rowCount++;
                }
            }

            var newMatrix = new bool[rowCount,matrix.GetLength(1)];
            var newRowCount = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, columIndex] == keepRowIfValIs)
                {
                    SetRow(newMatrix, GetRow(matrix, i), newRowCount); 
                    newRowCount++;
                }
            }

            return newMatrix;
        }

        private void SetRow(bool[,] matrix, bool[] row, int rowNumber)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[rowNumber, i] = row[i];
            }
        }

        private static List<int> GetMostCommonBitInColumns(bool[,] matrix)
        {
            var bitCount = Enumerable.Repeat(0, matrix.GetLength(1)).ToList();

            for (int i = 0; i < bitCount.Count; i++)
            {
                bitCount[i] = GetMostCommonBitFromColum(GetColumn(matrix, i) );
            }

            return bitCount;
        }

        private static int GetMostCommonBitFromColum(bool[] column)
        {
            int bitCount = 0;
            foreach (bool colBit in column)
            {
                if (colBit)
                {
                    bitCount = bitCount + 1;
                }
                else
                {
                    bitCount = bitCount - 1;
                }
            }
            return bitCount;
        }

        private int GetDecimalFromBinary(string binary)
        {
            return Convert.ToInt32(binary, 2);
        }

        public static bool[] GetColumn(bool[,] matrix, int columnNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(0))
                    .Select(x => matrix[x, columnNumber])
                    .ToArray();
        }

        public static bool[] GetRow(bool[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                    .Select(x => matrix[rowNumber, x])
                    .ToArray();
        }
    }
}
