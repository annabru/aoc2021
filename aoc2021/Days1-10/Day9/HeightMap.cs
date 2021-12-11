using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021.Day9
{
    public class HeightMap
    {
        private List<List<int>> heightMap;
        private int nbrOfRows;
        private int nbrOfCols;

        public List<(int, int)> lowPoints { get; private set; }

        public HeightMap(List<List<int>> heightMap)
        {
            this.heightMap = heightMap;
            nbrOfRows = heightMap.Count;
            nbrOfCols = heightMap.First().Count;
            lowPoints = GetLowPoints();
        }

        public int GetSumOfLowpoints()
        {

            var sum = 0;
            foreach(var lp in lowPoints)
            {
                sum += heightMap[lp.Item1][lp.Item2] + 1;
            }

            return sum;
        }

        private List<(int,int)> GetLowPoints()
        {
            lowPoints = new List<(int, int)>();
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

        public int GetProductOfThreeLargestBasins()
        {
            var sizes = GetSizeOfBasins();

            sizes.Sort();

            return sizes[sizes.Count - 1] * sizes[sizes.Count - 2] * sizes[sizes.Count - 3];
        }

        public List<int> GetSizeOfBasins()
        {
            var basinsSizes = new List<int>();

            foreach( var lp in lowPoints)
            {
                basinsSizes.Add(GetBasinSize(lp));
            }

            return basinsSizes;
        }

        private int GetBasinSize((int, int) lp)
        {
            var basinHashSet = new HashSet<(int,int)>();

            basinHashSet.Add(lp);

            AddAdjecentToBasin(basinHashSet, lp.Item1, lp.Item2);

            return basinHashSet.Count;
        }

        private void AddIfHigher(HashSet<(int, int)> basinHashSet, int row, int col, int rDiff, int cDiff)
        {
            if (basinHashSet.Contains((row + rDiff, col + cDiff))) return;

            if(heightMap[row + rDiff][col + cDiff] < 9 && heightMap[row][col] <= heightMap[row + rDiff][col + cDiff])
            {
                basinHashSet.Add((row + rDiff, col + cDiff));
                AddAdjecentToBasin(basinHashSet, row + rDiff, col + cDiff);
            }
        }

        private void AddAdjecentToBasin(HashSet<(int, int)> basinHashSet, int row, int col)
        {
            if (row == 0 && col == 0)
            {
                //upper left conner
                AddIfHigher(basinHashSet, row, col, 1, 0);
                AddIfHigher(basinHashSet, row, col, 0, 1);
            }
            else if (row == 0 && col == nbrOfCols - 1)
            {
                // upper right conner

                AddIfHigher(basinHashSet, row, col, 1, 0);
                AddIfHigher(basinHashSet, row, col, 0, -1);
            }
            else if (row == 0)
            {
                //upper row
                AddIfHigher(basinHashSet, row, col, 1, 0);
                AddIfHigher(basinHashSet, row, col, 0, 1);
                AddIfHigher(basinHashSet, row, col, 0, -1);

            }
            else if (row == nbrOfRows - 1 && col == 0)
            {
                // down left conner
                AddIfHigher(basinHashSet, row, col, -1, 0);
                AddIfHigher(basinHashSet, row, col, 0, 1);
            }
            else if (col == 0)
            {
                // left col
                AddIfHigher(basinHashSet, row, col, -1, 0);
                AddIfHigher(basinHashSet, row, col, 1, 0);
                AddIfHigher(basinHashSet, row, col, 0, 1);
            }
            else if (row == nbrOfRows - 1 && col == nbrOfCols - 1)
            {
                // right down corner
                AddIfHigher(basinHashSet, row, col, -1, 0);
                AddIfHigher(basinHashSet, row, col, 0, -1);
            }
            else if (row == nbrOfRows - 1)
            {
                //down row
                AddIfHigher(basinHashSet, row, col, -1, 0);
                AddIfHigher(basinHashSet, row, col, 0, -1);
                AddIfHigher(basinHashSet, row, col, 0, 1);
            }
            else if (col == nbrOfCols - 1)
            {
                // right col
                AddIfHigher(basinHashSet, row, col, -1, 0);
                AddIfHigher(basinHashSet, row, col, 1, 0);
                AddIfHigher(basinHashSet, row, col, 0, -1);
            }
            else
            {
                // in the middle
                AddIfHigher(basinHashSet, row, col, -1, 0);
                AddIfHigher(basinHashSet, row, col, 1, 0);
                AddIfHigher(basinHashSet, row, col, 0, 1);
                AddIfHigher(basinHashSet, row, col, 0, -1);
            }
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
            return heightMap[row][col] < heightMap[row-1][col];
        }

        private bool LowerThanLeft(int row, int col)
        {
            return heightMap[row][col] < heightMap[row][col-1];
        }

        private bool LowerThanBelow(int row, int col)
        {
            return heightMap[row][col] < heightMap[row+1][col];
        }

        private bool LowerThanRight(int row, int col)
        {
            return heightMap[row][col] < heightMap[row][col+1];
        }
    }
}
