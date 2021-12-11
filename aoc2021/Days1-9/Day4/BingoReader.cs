using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static aoc2021.Day4.Bingo;

namespace aoc2021.Day4
{
    public class BingoReader
    {
        public static (int,int) ReadBingoFromFile(string filepath)
        {
            var lines = File.ReadAllLines(filepath).ToList();

            var randomNumbers = ReadRandomNumbers(lines[0]);

            List<Board> boards = ReadBoards(lines);

            var bingoGameWin = new Bingo(boards, randomNumbers);
            var bingoGameLose = new Bingo(boards, randomNumbers);

            return (bingoGameWin.Play(out _), bingoGameLose.PlayUntilEnd(out _));
        }

        private static List<Board> ReadBoards(List<string> lines)
        {
            var boards = new List<Board>();
            for (int i = 2; i < lines.Count; i++)
            {
                var boardLines = new List<string>();
                while (lines[i] != "" )
                {
                    boardLines.Add(lines[i]);
                    if( ++i >= lines.Count)
                    {
                        break;
                    }
                }
                boards.Add(new Board(boardLines));
            }
            return boards;
        }

        private static List<int> ReadRandomNumbers(string v)
        {
            return v.Split(',').Select(nbr => Int32.Parse(nbr)).ToList();
        }
    }
}
