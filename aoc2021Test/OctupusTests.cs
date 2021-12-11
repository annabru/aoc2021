using aoc2021;
using aoc2021.Day11;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021Test;

[TestClass]
public class OctupusTests
{

    [TestMethod]
    [DataRow(1)]
    [DataRow(2)]
    public void NumberOfFlashesAfterNSteps_smallTest_9Flashes(int steps)
    {

        var input = new List<List<int>>()
        {
            new List<int>{1,1,1,1,1},
            new List<int>{1,9,9,9,1},
            new List<int>{1,9,1,9,1},
            new List<int>{1,9,9,9,1},
            new List<int>{1,1,1,1,1},
        };

        var handler = new Octupus(input);

        var flashes = handler.NumberOfFlashesAfterNSteps(steps);

        Assert.AreEqual(9, flashes);
    }

    [TestMethod]
    public void NumberOfFlashesAfterNSteps_largerTest_flashesFromSite()
    {
        var handler = new Octupus(FileHelper.GetHeightMapFromFile(@"C:\Users\annab\source\repos\aoc2021\aoc2021\data\day11_testdata.txt"));

        var expected = 0;
        var flashes = handler.NumberOfFlashesAfterNSteps(1);
        Assert.AreEqual(expected, flashes);

        expected += 1+3+1+2+5+3+4+6+6+4;
        flashes += handler.NumberOfFlashesAfterNSteps(1);
        Assert.AreEqual(expected, flashes);
    }
}
