using aoc2021;
using aoc2021.Day9;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021Test
{
    [TestClass]
    public class HeightMapTests
    {

        [TestMethod]
        public void GetSumOfLowpoints()
        {
            var hm = new HeightMap(FileHelper.GetHeightMapFromFile(@"C:\Users\annab\source\repos\aoc2021\aoc2021\data\day9_testdata.txt"));
            
            var res = hm.GetSumOfLowpoints();
            Assert.AreEqual(15, res);
            Assert.AreEqual(4, hm.lowPoints.Count());
        }

        [TestMethod]
        public void test()
        {
            var hm = new HeightMap(FileHelper.GetHeightMapFromFile(@"C:\Users\annab\source\repos\aoc2021\aoc2021\data\day9_testdata.txt"));

            var res = hm.GetSizeOfBasins();

            Assert.AreEqual(4, res.Count);
            Assert.AreEqual(3, res[0]);
            Assert.AreEqual(9, res[1]);
            Assert.AreEqual(14, res[2]);
            Assert.AreEqual(9, res[3]);

            Assert.AreEqual(9*14*9, hm.GetProductOfThreeLargestBasins());
        }
    }
}
