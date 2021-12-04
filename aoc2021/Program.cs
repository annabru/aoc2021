// See https://aka.ms/new-console-template for more information
using aoc2021;
using aoc2021.Day2;
using aoc2021.Day3;
using aoc2021.Day4;

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
