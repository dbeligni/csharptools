using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiscCodeSamples;

namespace UnitTests
{
    [TestClass]
    public class TestBoatLoader
    {
        [TestMethod]
        public void TestSplitOnTwoBoat()
        {
            var loader = new BoatLoadOptimizer(2, new int[] { 25, 30, 65, 55 });
            var split = loader.GetBoatWeights();
            Assert.AreEqual(90, split[0]);
            Assert.AreEqual(85, split[1]);
        }

        [TestMethod]
        public void TestSplitOnThreeBoat()
        {
            var loader = new BoatLoadOptimizer(3, new int[] { 25, 30, 65, 55 });
            var split = loader.GetBoatWeights();
            Assert.AreEqual(65, split[0]);
            Assert.AreEqual(55, split[1]);
            Assert.AreEqual(55, split[1]);
        }

        [TestMethod]
        public void TestLowerWeighIndexFinder()
        {
            var testList = new int[] { 25, 3, 65, 55 };
            var minIndex = BoatLoadOptimizer.GetMinimumWeightIndex(testList);
            Assert.AreEqual(1, minIndex);
        }
    }
}
