using aoc2021;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021Test
{
    [TestClass]
    public class Day1HelperTests
    {
        [TestMethod]
        [DataRow(1,2)]
        [DataRow(-2,2)]
        [DataRow(-4,-3)]
        public void IsIncrease_increases_true(int x, int y)
        {
            var res = Day1Helper.IsIncrease(x, y);

            Assert.IsTrue(res);
        }

        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(2, 1)]
        [DataRow(3, -3)]
        public void IsIncrease_decreaesAndEquals_false(int x, int y)
        {
            var res = Day1Helper.IsIncrease(x, y);

            Assert.IsFalse(res);
        }


        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(-1)]
        [DataRow(22)]
        [DataRow(0)]
        public void CountIncreasesBulkOfX_ListIsNull_0(int bulkSize)
        {
            int res = Day1Helper.CountIncreasesBulkOfX(null, bulkSize);

            Assert.AreEqual(0, res);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(-1)]
        [DataRow(22)]
        [DataRow(0)]
        public void CountIncreasesBulkOfX_emptyList_0(int bulkSize)
        {
            int res = Day1Helper.CountIncreasesBulkOfX(new List<int>(), bulkSize);

            Assert.AreEqual(0, res);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(-1)]
        [DataRow(22)]
        [DataRow(0)]
        public void CountIncreasesBulkOfX_OneItem_0(int bulkSize)
        {
            int res = Day1Helper.CountIncreasesBulkOfX(new List<int>() { 1 }, bulkSize);

            Assert.AreEqual(0, res);
        }

        [TestMethod]
        [DataRow(-3)]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(3)]
        [DataRow(50)]
        public void CountIncreasesBulkOfX_ListOneLessThanBulk_1(int bulkSize)
        {
            List<int> input = GetIncrementingList(bulkSize);

            int res = Day1Helper.CountIncreasesBulkOfX(input, bulkSize);

            Assert.AreEqual(0, res);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(3)]
        [DataRow(10)]
        public void CountIncreasesBulkOfX_ListWithOneIncrease_1(int bulkSize)
        {
            List<int> input = GetIncrementingList(bulkSize + 1);

            int res = Day1Helper.CountIncreasesBulkOfX(input, bulkSize);

            Assert.AreEqual(1, res);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(3)]
        [DataRow(10)]
        public void CountIncreasesBulkOfX_ListWithOneDecrease_0(int bulkSize)
        {
            List<int> input = GetDecrementingList(bulkSize + 1);

            int res = Day1Helper.CountIncreasesBulkOfX(input, bulkSize);

            Assert.AreEqual(0, res);
        }

        [TestMethod]
        public void CountIncreasesBulkOfX_ListWithOneDecreaseOneIncrease_0()
        {
            int res = Day1Helper.CountIncreasesBulkOfX(new List<int> { 1, 0, 5 }, 1);

            Assert.AreEqual(1, res);
        }

        [TestMethod]
        public void CountIncreasesBulkOfX_ListWith4Decrease4Increase_4()
        {
            int res = Day1Helper.CountIncreasesBulkOfX(new List<int> { 0, 1, -4, 1, 2, 2, 5, 0, 0 }, 1);

            Assert.AreEqual(4, res);
        }


        [TestMethod]
        public void CountIncreasesBulkOfX_ListWithOneDecreaseOneIncreaseBulk3_0()
        {
            int res = Day1Helper.CountIncreasesBulkOfX(new List<int> {
                607,
                618,
                618,
                617,
                647,
                716,
                769,
                792
            }, 3);

            Assert.AreEqual(5, res);
        }

        private static List<int> GetIncrementingList(int bulkSize)
        {
            var input = new List<int>();
            for (int i = 0; i < bulkSize; i++)
            {
                input.Add(i);
            }

            return input;
        }

        private static List<int> GetDecrementingList(int bulkSize)
        {
            var input = new List<int>();
            for (int i = 0; i < bulkSize; i++)
            {
                input.Add(i*-1);
            }

            return input;
        }

    }
}
