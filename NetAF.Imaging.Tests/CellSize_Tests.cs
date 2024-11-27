namespace NetAF.Imaging.Tests
{
    [TestClass]
    public class CellSize_Tests
    {
        [TestMethod]
        public void GivenWidth1Height1_WhenGetWidthRatio_Then1()
        {
            var cell = new CellSize(1, 1);

            var result = cell.WidthRatio;

            Assert.IsTrue(result is >= 0.9999 and <= 1.0001);
        }

        [TestMethod]
        public void GivenWidth1Height1_WhenGetHeightRatio_Then1()
        {
            var cell = new CellSize(1, 1);

            var result = cell.HeightRatio;

            Assert.IsTrue(result is >= 0.9999 and <= 1.0001);
        }

        [TestMethod]
        public void GivenWidth1Height2_WhenGetWidthRatio_Then0P5()
        {
            var cell = new CellSize(1, 2);

            var result = cell.WidthRatio;

            Assert.IsTrue(result is >= 0.4999 and <= 0.5001);
        }

        [TestMethod]
        public void GivenWidth2Height1_WhenGetHeightRatio_Then0P5()
        {
            var cell = new CellSize(2, 1);

            var result = cell.HeightRatio;

            Assert.IsTrue(result is >= 0.4999 and <= 0.5001);
        }
    }
}