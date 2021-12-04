using aoc2021.Day3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021Test
{
    [TestClass]
    public class DiagnosticReportTests
    {
        [TestMethod]
        public void PowerConsumption_1()
        {
            var report = new DiagnosticReport();
            bool[,] matrix = { { false } };

            var res = report.PowerConsumption(matrix);

            Assert.AreEqual(0, res);
        }

        [TestMethod]
        public void PowerConsumption_2()
        {
            var report = new DiagnosticReport();
            bool[,] matrix = { { true } };

            var res = report.PowerConsumption(matrix);

            Assert.AreEqual(0, res);
        }

        [TestMethod]
        public void PowerConsumption_3()
        {
            var report = new DiagnosticReport();
            bool[,] matrix = { 
                { true },
                { false },
                { false }
            };

            var res = report.PowerConsumption(matrix);

            Assert.AreEqual(0, res);
        }

        [TestMethod]
        public void PowerConsumption_4()
        {
            var report = new DiagnosticReport();
            bool[,] matrix = { { true, false, false } };

            var res = report.PowerConsumption(matrix);

            Assert.AreEqual(3*4, res);
        }

        [TestMethod]
        public void PowerConsumption_5()
        {
            var report = new DiagnosticReport();
            bool[,] matrix = {
                { false, false, true, false, false},
                { true, true, true, true, false},
                { true, false, true, true, false},

                { true, false, true, true, true},
                { true, false, true, false, true},
                { false, true, true, true, true},

                { false, false, true, true, true},
                { true, true, true, false, false},
                { true, false, false, false, false},

                { true, true, false, false, true},
                { false, false, false, true, false},
                { false, true, false, true, false}
            };

            var res = report.PowerConsumption(matrix);

            Assert.AreEqual(198, res);
        }

        [TestMethod]
        public void GetLifeSupportRating_1()
        {
            var report = new DiagnosticReport();
            bool[,] matrix = {
                { false, false, true, false, false},
                { true, true, true, true, false},
                { true, false, true, true, false},

                { true, false, true, true, true},
                { true, false, true, false, true},
                { false, true, true, true, true},

                { false, false, true, true, true},
                { true, true, true, false, false},
                { true, false, false, false, false},

                { true, true, false, false, true},
                { false, false, false, true, false},
                { false, true, false, true, false}
            };

            var res = report.GetLifeSupportRating(matrix);

            Assert.AreEqual(230, res);
        }

    }
}
