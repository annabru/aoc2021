using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021.Day11;

public class Octupus
{
    private List<List<int>> energyMap; 
    private int flashes = 0;
    private int nbrOfCols;
    private int nbrOfRows;

    public Octupus(List<List<int>> energyMap)
    {
        this.energyMap = energyMap;
        nbrOfRows = energyMap.Count;
        nbrOfCols = energyMap[0].Count;
    }

    public int NumberOfFlashesAfterNSteps(int steps)
    {
        for (int i = 0; i < steps; i++)
        {
            TakeAStep();
        }
        return flashes;
    }

    public int NumberOfStepsUntilSync()
    {
        var flashBefore = flashes;
        var flashAfter = flashes;
        var steps = 0;
        while ((flashAfter - flashBefore) != energyMap.Count * energyMap[0].Count)
        {
            flashBefore = flashes;
            TakeAStep();
            flashAfter = flashes;
            steps++;
        }
        return steps;
    }

    private void TakeAStep()
    {
        //increase all cells by one.
        for (int row = 0; row < energyMap.Count; row++)
        {
            for (var col = 0; col < energyMap[row].Count; col++)
            {
                energyMap[row][col]++;
            }
        }

        for (int row = 0;row < energyMap.Count; row++)
        {
            for(var col = 0;col < energyMap[row].Count; col++)
            {
                if(energyMap[row][col] > 9)
                {
                    FlashAndSpread(row,col);
                }
            }

        }
    }

    private void FlashAndSpread(int row, int col)
    {
        Flash(row, col);

        IncreaseAdjecentAndFlashIfLT9(row, col);
    }

    private void IncreaseAdjecentAndFlashIfLT9(int row, int col)
    {
        if (row == 0 && col == 0)
        {
            //upper left conner
            CheckAdjecent(row, 0, col, 1);
            CheckAdjecent(row, 1, col, 0);
            CheckAdjecent(row, 1, col, 1);
        }
        else if (row == 0 && col == nbrOfCols - 1)
        {
            // upper right conner
            CheckAdjecent(row, 0, col, -1);
            CheckAdjecent(row, 1, col, 0);
            CheckAdjecent(row, 1, col, -1);
        }
        else if (row == 0)
        {
            //upper row
            CheckAdjecent(row, 0, col, -1);
            CheckAdjecent(row, 1, col, -1);
            CheckAdjecent(row, 1, col, 0);
            CheckAdjecent(row, 1, col, 1);
            CheckAdjecent(row, 0, col, 1);
        }
        else if (row == nbrOfRows - 1 && col == 0)
        {
            // down left conner
            CheckAdjecent(row, -1, col, 0);
            CheckAdjecent(row, -1, col, 1);
            CheckAdjecent(row, 0, col, 1);
        }
        else if (col == 0)
        {
            // left col
            CheckAdjecent(row, -1, col, 0);
            CheckAdjecent(row, -1, col, 1);
            CheckAdjecent(row, 0, col, 1);
            CheckAdjecent(row, 1, col, 1);
            CheckAdjecent(row, 1, col, 0);
        }
        else if (row == nbrOfRows - 1 && col == nbrOfCols - 1)
        {
            // right down corner
            CheckAdjecent(row, -1, col, 0);
            CheckAdjecent(row, -1, col, -1);
            CheckAdjecent(row, 0, col, -1);
        }
        else if (row == nbrOfRows - 1)
        {
            //down row
            CheckAdjecent(row, 0, col, -1);
            CheckAdjecent(row, -1, col, -1);
            CheckAdjecent(row, -1, col, 0);
            CheckAdjecent(row, -1, col, 1);
            CheckAdjecent(row, 0, col, 1);
        }
        else if (col == nbrOfCols - 1)
        {
            // right col
            CheckAdjecent(row, -1, col, 0);
            CheckAdjecent(row, -1, col, -1);
            CheckAdjecent(row, 0, col, -1);
            CheckAdjecent(row, 1, col, -1);
            CheckAdjecent(row, 1, col, 0);
        }
        else
        {
            // in the middle
            CheckAdjecent(row, -1, col, 0);

            CheckAdjecent(row, -1, col, -1);
            CheckAdjecent(row, 0, col, -1);
            CheckAdjecent(row, 1, col, -1);

            CheckAdjecent(row, 1, col, 0);

            CheckAdjecent(row, -1, col, 1);
            CheckAdjecent(row, 0, col, 1);
            CheckAdjecent(row, 1, col, 1);

        }
    }


    private void CheckAdjecent(int row, int rowDiff, int col, int colDiff)
    {
        if (energyMap[row + rowDiff][col + colDiff] != 0)
        {
            energyMap[row + rowDiff][col + colDiff]++;
        }

        if (energyMap[row+rowDiff][col+colDiff] > 9)
        {
            FlashAndSpread(row + rowDiff, col + colDiff);
        }
    }

    private void Flash(int row, int col)
    {
        energyMap[row][col] = 0;
        flashes++;
    }
}
