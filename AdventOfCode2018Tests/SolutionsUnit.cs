using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2018;

namespace AoC18Tests
{
    [TestClass]
    public class SolutionsUnit
    {
        private readonly PuzzleManager puzzleManager;

        public SolutionsUnit()
        {
            puzzleManager = new PuzzleManager();
        }

        [TestMethod]
        public void TestD1P1()
        {
            Assert.AreEqual("531", puzzleManager.Solutions[0]);
        }

        [TestMethod]
        public void TestD1P2()
        {
            Assert.AreEqual("76787",puzzleManager.Solutions[1]);
        }

        [TestMethod]
        public void TestD2P1()
        {
            Assert.AreEqual("7776", puzzleManager.Solutions[2]);
        }

        [TestMethod]
        public void TestD2P2()
        {
            Assert.AreEqual("wlkigsqyfecjqqmnxaktdrhbz", puzzleManager.Solutions[3]);
        }

        [TestMethod]
        public void TestD3P1()
        {
            Assert.AreEqual("103482", puzzleManager.Solutions[4]);
        }

        [TestMethod]
        public void TestD3P2()
        {
            Assert.AreEqual("686", puzzleManager.Solutions[5]);
        }

        [TestMethod]
        public void TestD4P1()
        {
            Assert.AreEqual("19025", puzzleManager.Solutions[6]);
        }

        [TestMethod]
        public void TestD4P2()
        {
            Assert.AreEqual("23776", puzzleManager.Solutions[7]);
        }

        [TestMethod]
        public void TestD5P1()
        {
            Assert.AreEqual("11476", puzzleManager.Solutions[8]);
        }

        [TestMethod]
        public void TestD5P2()
        {
            Assert.AreEqual("5446", puzzleManager.Solutions[9]);
        }
    }
}
