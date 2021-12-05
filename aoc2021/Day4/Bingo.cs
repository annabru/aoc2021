using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021.Day4;
public class Bingo
{
    private List<int> randomNumbers = new List<int>();
    private List<Board> boards = new List<Board>();

    public Bingo(List<Board> boards, List<int> randomNumbers)
    {
        this.boards = boards;
        this.randomNumbers = randomNumbers;
    }

    public int Play(out int winningBoard)
    {
        winningBoard = -1;
        foreach (var nbr in randomNumbers)
        {
            if (MarkBoardsAndReturnTrueIfBingo(nbr, out winningBoard) > 0) {
                return boards[winningBoard].GetScore();
            }
        }

        return -1;
    }

    public int PlayUntilEnd(out int winningBoard)
    {
        winningBoard = -1;
        var lastWinningBoard = -1;
        int nbrOfBoards = boards.Count;
        foreach (var nbr in randomNumbers)
        {
            if (MarkBoardsAndReturnTrueIfBingo(nbr, out winningBoard) > 0)
            {
                var test = boards[winningBoard].GetScore();
                if(winningBoard > -1)
                {
                    lastWinningBoard = winningBoard;
                }
                if (--nbrOfBoards == 0)
                {
                    return boards[winningBoard].GetScore();
                }
            }
        }

        return boards[lastWinningBoard].GetScore();
    }

    private int MarkBoardsAndReturnTrueIfBingo(int nbr, out int winningBoard)
    {
        winningBoard = -1;
        var nbrOfBingos = 0;

        for (int i = 0; i < boards.Count; i++)
        {
            if(MarkBoardAndReturnTrueIfBingo(nbr, boards[i]))
            {
                nbrOfBingos++;
                winningBoard = i;
            }
        }

        return nbrOfBingos;
    }

    private bool MarkBoardAndReturnTrueIfBingo(int nbr, Board board)
    {
        return board.CheckBoardAndReturnTrueIfBingo(nbr);
    }

}

