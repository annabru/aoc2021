using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021.Day4
{
    public class Board
    {
        List<List<Cell>> cells = new List<List<Cell>>();
        bool bingo = false;
        int score = -1;

        public Board(List<string> boardInput)
        {
            foreach (var rowInput in boardInput)
            {
                var rowAsStrings = System.Text.RegularExpressions.Regex.Split(rowInput.Trim(), @"\s+");
                var row = rowAsStrings.Select(r => new Cell(Int32.Parse(r))).ToList();
                cells.Add(row);
            }
        }

        public int GetScore()
        {
            return score;
        }

        internal bool CheckBoardAndReturnTrueIfBingo(int nbr)
        {
            bool isBingo = false;
            for (int row = 0; row < cells.Count; row++)
            {
                for (int col = 0; col < cells[row].Count; col++)
                {
                    if (cells[row][col].MarkCell(nbr))
                    {
                        if (bingo) { return false; }
                        isBingo = CheckIfBingo(row, col);
                        if (isBingo)
                        {
                            score = GetScore(nbr);
                        }
                    }
                }
            }
            return isBingo;
        }

        private int GetScore(int nbr)
        {
            return nbr * GetSumOfUnmarked();
        }

        internal int GetSumOfUnmarked()
        {
            int sumOfUnmarked = 0;
            for (int i = 0; i < cells.Count; i++)
            {
                for (int j = 0; j < cells[i].Count; j++)
                {
                    if (!cells[i][j].IsMarked())
                    {
                        sumOfUnmarked += cells[i][j].GetValue();
                    }
                }
            }
            return sumOfUnmarked;
        }

        private bool CheckIfBingo(int row, int col)
        {
            if (!bingo)
            {
                var isBingoRow = cells[row].All(cell => cell.IsMarked());

                var isBingoCol = GetColumn(col).All(cell => cell.IsMarked());

                bingo = isBingoCol || isBingoRow;
            }
            return bingo;
        }

        private List<Cell> GetColumn(int col)
        {
            var column = new List<Cell>();
            foreach (var row in cells)
            {
                column.Add(row[col]);
            }
            return column;
        }
    }

    internal class Cell
    {
        private readonly int number;
        private bool isMarked;

        public Cell(int number)
        {
            this.number = number;
            isMarked = false;
        }

        public bool MarkCell(int nbr)
        {
            if (nbr == number)
            {
                isMarked = true;
                return true;
            }
            return false;
        }

        public bool IsMarked()
        {
            return isMarked;
        }

        internal int GetValue()
        {
            return number;
        }
    }
}
