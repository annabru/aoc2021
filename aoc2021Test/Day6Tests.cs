using aoc2021.Day6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021Test
{
    [TestClass]
    public class Day6Tests
    {

        [TestMethod]
        public void ReproduceUntil()
        {
            var day6 = new Day6("3,4,3,1,2");

            var res = day6.ReproduceUntil(18);

            Assert.AreEqual(26, res);
        }
    }
}
