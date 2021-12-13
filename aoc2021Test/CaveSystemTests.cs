using aoc2021.Day12;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021Test
{
    [TestClass]
    public class CaveSystemTests
    {
        [TestMethod]
        public void test()
        {
            List<string> input = new List<string>
            {
                "start-A",
                "start-b",
                "A-c",
                "A-b",
                "b-d",
                "A-end",
                "b-end",
            };

            var cs = new CaveSystem(input, false);

            Assert.AreEqual(10, cs.Paths.Count);
        }

        [TestMethod]
        public void test2()
        {
            List<string> input = new List<string>
            {
                "start-A",
                "start-b",
                "A-c",
                "A-b",
                "b-d",
                "A-end",
                "b-end",
            };

            var cs = new CaveSystem(input, true);

            //Assert.AreEqual(36, cs.Paths.Count);
        }
    }
}
