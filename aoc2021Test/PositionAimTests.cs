using aoc2021.Day2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021Test
{
    [TestClass]
    public class PositionAimTests
    {
        // neg numbers

        [TestMethod]
        [DataRow(1)]
        [DataRow(7)]
        public void Down_xOnes_x(int steps)
        {
            var position = new PositionAim();

            position.Down(steps);

            var aim = position.GetAim();

            Assert.AreEqual(steps, aim);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(7)]
        public void Down_100DownxUp_100minusX(int steps)
        {
            var position = new PositionAim();

            position.Down(100);
            position.Up(steps);

            var aim = position.GetAim();

            Assert.AreEqual(100-steps, aim);
        }


        [TestMethod]
        public void Down_testCase_900()
        {
            var position = new PositionAim();

            position.Forward(5);
            position.Down(5);
            position.Forward(8);
            position.Up(3);
            position.Down(8);
            position.Forward(2);

            var prd = position.GetProduct();

            Assert.AreEqual(900, prd);
        }
    }
}
