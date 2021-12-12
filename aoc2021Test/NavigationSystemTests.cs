using aoc2021;
using aoc2021.Day10;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021Test
{
    [TestClass]
    public class NavigationSystemTests
    {

        [TestMethod]
        public void Initialize_empty()
        {
            var chunk1 = new Chunk("");

            Assert.IsFalse(chunk1.IsIncomplete);
            Assert.IsFalse(chunk1.IsCorrupted);
            Assert.AreEqual(0, chunk1.Length);
            Assert.AreEqual(ChunkType.line, chunk1.Type);
        }

        [TestMethod]
        public void Initialize_soft()
        {
            var chunk1 = new Chunk("()");

            Assert.IsFalse(chunk1.IsIncomplete);
            Assert.IsFalse(chunk1.IsCorrupted);
            Assert.AreEqual(1, chunk1.Length);
            Assert.AreEqual(ChunkType.line, chunk1.Type);
            Assert.AreEqual(0, chunk1.GetCorruptedScore());
        }

        [TestMethod]
        public void Initialize_corrupted()
        {
            var chunk1 = new Chunk("(]");

            Assert.IsFalse(chunk1.IsIncomplete);
            Assert.IsFalse(chunk1.IsCorrupted);
            Assert.IsTrue(chunk1.IsOrContainsCorrupted);
            Assert.AreEqual(1, chunk1.Length);
            Assert.AreEqual(ChunkType.line, chunk1.Type);
            Assert.AreEqual(57, chunk1.GetCorruptedScore());
        }

        [TestMethod]
        public void Initialize_corruptedInsideSoft()
        {
            var chunk1 = new Chunk("(<])");

            Assert.IsFalse(chunk1.IsIncomplete);
            Assert.IsFalse(chunk1.IsCorrupted);
            Assert.IsTrue(chunk1.IsOrContainsCorrupted);
            Assert.AreEqual(1, chunk1.Length);
            Assert.AreEqual(ChunkType.line, chunk1.Type);

            Assert.AreEqual(57, chunk1.GetCorruptedScore());
        }

        [TestMethod]
        public void Initialize_multipleCorrupted()
        {
            var chunk1 = new Chunk("(<](>)");

            Assert.IsFalse(chunk1.IsIncomplete);
            Assert.IsFalse(chunk1.IsCorrupted);
            Assert.IsTrue(chunk1.IsOrContainsCorrupted);
            Assert.AreEqual(1, chunk1.Length);
            Assert.AreEqual(ChunkType.line, chunk1.Type);

            Assert.AreEqual(57+ 25137, chunk1.GetCorruptedScore());
        }

        [TestMethod]
        public void Initialize_multipleCorrupted_()
        {
            var chunk1 = new Chunk("(");

            Assert.IsFalse(chunk1.IsIncomplete);
            Assert.IsFalse(chunk1.IsCorrupted);
            Assert.IsFalse(chunk1.IsOrContainsCorrupted);
            Assert.IsTrue(chunk1.IsOrContainsIncompletes);

            Assert.AreEqual(1, chunk1.Length);
            Assert.AreEqual(ChunkType.line, chunk1.Type);

            Assert.AreEqual(0, chunk1.GetCorruptedScore());
        }

        [TestMethod]
        public void testdata_first_corrupted()
        {
            var chunk1 = new Chunk("{([(<{}[<>[]}>{[]{[(<()>");

            Assert.IsFalse(chunk1.IsIncomplete);
            Assert.IsFalse(chunk1.IsCorrupted);

            Assert.IsTrue(chunk1.IsOrContainsCorrupted);
            Assert.IsTrue(chunk1.IsOrContainsIncompletes);

            Assert.AreEqual(1, chunk1.Length);
            Assert.AreEqual(ChunkType.line, chunk1.Type);

            Assert.AreEqual(1197, chunk1.GetCorruptedScore());
        }

        [TestMethod]
        public void testdata_last_incomplete()
        {
            var chunk1 = new Chunk("<{([{{}}[<[[[<>{}]]]>[]]");

            Assert.IsFalse(chunk1.IsIncomplete);
            Assert.IsFalse(chunk1.IsCorrupted);

            Assert.IsFalse(chunk1.IsOrContainsCorrupted);
            Assert.IsTrue(chunk1.IsOrContainsIncompletes);

            Assert.AreEqual(1, chunk1.Length);
            Assert.AreEqual(ChunkType.line, chunk1.Type);

            Assert.AreEqual(294, chunk1.GetCompleteScore());
        }


        [TestMethod]
        public void testing_with_testdata()
        {
            var ns = new NavigationSystem(FileHelper.GetLinesFromFile(@"C:\Users\annab\source\repos\aoc2021\aoc2021\data\day10_testdata.txt"));

            var corRes = ns.GetCorruptedScore();
            var incomRes = ns.GetIncompleteScore();


            Assert.AreEqual(26397, corRes);
            Assert.AreEqual(288957, incomRes);
        }
    }
}
