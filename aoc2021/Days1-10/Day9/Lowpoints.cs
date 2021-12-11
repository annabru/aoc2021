using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021.Day9
{
    public class Lowpoints
    {
        private List<List<int>> heightMap;
        private int nbrOfRows;
        private int nbrOfCols;

        public Lowpoints(List<List<int>> heightMap)
        {
            this.heightMap = heightMap;
            nbrOfRows = heightMap.Count;
            nbrOfCols = heightMap.First().Count;
        }

        public int GetSumOfLowpoints()
        {
            var lps = GetLowPoints();

            var sum = 0;
            foreach(var lp in lps)
            {
                sum += heightMap[lp.Item1][lp.Item2] + 1;
            }

            return sum;
        }

        public List<(int,int)> GetLowPoints()
        {
            var lowPoints = new List<(int, int)>();
            for( int row = 0; row < heightMap.Count; row++)
            {
                for( int col = 0; col < heightMap[row].Count; col++)
                {
                    if( NoHigherAdjecent(row, col))
                    {
                        lowPoints.Add((row, col));
                    }
                }
            }
            return lowPoints;
        }

        private bool NoHigherAdjecent(int row, int col)
        {
            if(row == 0 && col == 0)
            {
                //upper left conner
                return LowerThanRight(row, col) && LowerThanBelow(row, col);
            }
            else if(row == 0 && col == nbrOfCols - 1)
            {
                // upper right conner
                return LowerThanLeft(row, col) && LowerThanBelow(row,col);
            }
            else if(row == 0)
            {
                //upper row
                return LowerThanRight(row, col) && LowerThanLeft(row, col) && LowerThanBelow(row, col);
            }
            else if(row == nbrOfRows -1 && col == 0)
            {
                // down left conner
                return LowerThanRight(row, col) && LowerThanAbove(row, col);
            }
            else if(col == 0)
            {
                // left col
                return LowerThanRight(row,col) && LowerThanBelow(row,col) && LowerThanAbove(row,col);
            }
            else if(row == nbrOfRows -1 && col == nbrOfCols - 1)
            {
                // right down corner
                return LowerThanLeft(row, col) && LowerThanAbove(row, col);
            }
            else if( row == nbrOfRows -1)
            {
                //down row
                return LowerThanRight(row, col) && LowerThanLeft(row, col) && LowerThanAbove(row, col);
            }
            else if( col == nbrOfCols - 1)
            {
                // left col
                return LowerThanLeft(row, col) && LowerThanAbove(row, col) && LowerThanBelow(row, col);
            }
            else 
            {
                // in the middle
                return LowerThanLeft(row, col) && LowerThanRight(row,col) && LowerThanAbove(row, col) && LowerThanBelow(row, col);
            }
        }

        private bool LowerThanAbove(int row, int col)
        {
            return heightMap[row][col] <= heightMap[row-1][col];
        }

        private bool LowerThanLeft(int row, int col)
        {
            return heightMap[row][col] <= heightMap[row][col-1];
        }

        private bool LowerThanBelow(int row, int col)
        {
            return heightMap[row][col] <= heightMap[row+1][col];
        }

        private bool LowerThanRight(int row, int col)
        {
            return heightMap[row][col] <= heightMap[row][col+1];
        }
    }
}
