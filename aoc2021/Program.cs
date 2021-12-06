// See https://aka.ms/new-console-template for more information
using aoc2021;
using aoc2021.Day2;
using aoc2021.Day3;
using aoc2021.Day4;
using aoc2021.Day5;
using aoc2021.Day6;

Console.WriteLine("Advent of Code 2021!");

Console.WriteLine("*** Day 1 ***");

Console.WriteLine($"Number of increaes is: {Day1.CountIncreasesFromFile(@"C:\Users\annab\source\repos\aoc2021\aoc2021\data\day1_1.txt", 1) }. ");
Console.WriteLine($"Number of increaes, when summing 3, is: {Day1.CountIncreasesFromFile(@"C:\Users\annab\source\repos\aoc2021\aoc2021\data\day1_1.txt", 3) }. ");


Console.WriteLine("*** Day 2 ***");

Console.WriteLine($"Product of position after given instructions are {Day2.GetPositionFromFile(@"C:\Users\annab\source\repos\aoc2021\aoc2021\data\day2_1.txt")}. " );
Console.WriteLine($"Product of position with aim after given instructions are {Day2.GetPositionAimFromFile(@"C:\Users\annab\source\repos\aoc2021\aoc2021\data\day2_1.txt")}. ");


Console.WriteLine("*** Day 3 ***");
Console.WriteLine($"Power consumption is {Day3.CalculatePowerConsumptionFromFile(@"C:\Users\annab\source\repos\aoc2021\aoc2021\data\day3_1.txt")}. ");
Console.WriteLine($"Life support rating is {Day3.CalculateLifeSupportRatingFromFile(@"C:\Users\annab\source\repos\aoc2021\aoc2021\data\day3_1.txt")}. ");

Console.WriteLine("*** Day 4 ***");
var (win, lose) = BingoReader.ReadBingoFromFile(@"C:\Users\annab\source\repos\aoc2021\aoc2021\data\day4_1.txt");
Console.WriteLine($"Score of winning board is {win}. ");
Console.WriteLine($"Score of losing board is {lose}. ");

Console.WriteLine("*** Day 5 ***");
var above2 = new Day5(@"C:\Users\annab\source\repos\aoc2021\aoc2021\data\day5_1.txt", false).NumberOfCoordinatesWithValue2orHigher();
var above2WithDiagonal = new Day5(@"C:\Users\annab\source\repos\aoc2021\aoc2021\data\day5_1.txt", true).NumberOfCoordinatesWithValue2orHigher();
Console.WriteLine($"Number of position where at least two lines overlap is {above2}. ");
Console.WriteLine($"Number of position where at least two lines overlap when counting diagonals is {above2WithDiagonal}. ");

Console.WriteLine("*** Day 6 ***");
var day6_1 = new Day6(FileHelper.GetFirstLineFromFile(@"C:\Users\annab\source\repos\aoc2021\aoc2021\data\day6_1.txt"));
var day6_2 = new Day6(FileHelper.GetFirstLineFromFile(@"C:\Users\annab\source\repos\aoc2021\aoc2021\data\day6_1.txt"));
Console.WriteLine($"Number of fishes after 80 days are {day6_1.ReproduceUntil(80)}. ");
Console.WriteLine($"Number of fishes after 80 days are {day6_2.ReproduceUntil(256)}. ");
