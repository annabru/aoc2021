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
    public class PositionTests
    {

        [TestMethod]
        public void GetLocation_NoSteps_0_0()
        {
            var position = new Position();
            (int d, int h) = position.GetPosition();

            Assert.AreEqual(0,d);
            Assert.AreEqual(0,h);
        }

        [TestMethod]
        public void GetLocation_DepthNegOne_0_0()
        {
            var position = new Position();

            position.ChangeDepth(-1);

            (int d, int h) = position.GetPosition();

            Assert.AreEqual(0, d);
            Assert.AreEqual(0,h);
        }

        [TestMethod]
        public void GetLocation_DepthOne_1_0()
        {
            var position = new Position();

            position.ChangeDepth(1);

            (int d, int h) = position.GetPosition();

            Assert.AreEqual(1, d);
            Assert.AreEqual(0, h);
        }

        [TestMethod]
        [DataRow(3, -2)]
        [DataRow(1, -2)] //Can not be above surface, skip second step.
        public void GetLocation_ChangeStepInTwoStepsGet_1_0(int firstStep, int secondStep)
        {
            var position = new Position();

            position.ChangeDepth(firstStep);
            position.ChangeDepth(secondStep);

            (int d, int h) = position.GetPosition();

            Assert.AreEqual(1, d);
            Assert.AreEqual(0, h);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(-1)]
        [DataRow(22)]
        public void GetLocation_HorizontalSteps_0_x(int horisontalStep)
        {
            var position = new Position();

            position.Forward(horisontalStep);

            (int d, int h) = position.GetPosition();

            Assert.AreEqual(0, d);
            Assert.AreEqual(horisontalStep, h);
        }


        [TestMethod]
        public void GetLocation_Example_10_15()
        {
            var position = new Position();

            position.Forward(5);
            position.Down(5);
            position.Forward(8);
            position.Up(3);
            position.Down(8);
            position.Forward(2);


            (int d, int h) = position.GetPosition();

            Assert.AreEqual(10, d);
            Assert.AreEqual(15, h);
        }

    }
}
