using NetAF.Rendering.Console;

namespace NetAF.Imaging.Tests
{
    [TestClass]
    public class VisualHelper_Tests
    {
        [TestMethod]
        public void GivenWhiteImage_WhenFromImage_ThenImageIsBrightWhite()
        {
            var path = "Resources/FullWhite.bmp";
            var frame = VisualHelper.FromImage(path, new(5, 5), CellSize.Square);

            var result = frame.GetCellBackgroundColor(0, 0);

            Assert.AreEqual(AnsiColor.BrightWhite, result);
        }

        [TestMethod]
        public void GivenBlackImage_WhenFromImage_ThenImageIsBlack()
        {
            var path = "Resources/FullBlack.bmp";
            var frame = VisualHelper.FromImage(path, new(5, 5), CellSize.Square);
            
            var result = frame.GetCellBackgroundColor(0, 0);

            Assert.AreEqual(AnsiColor.Black, result);
        }

        [TestMethod]
        public void GivenCellWidth1To2AndImage5x5_WhenFromImage_ThenReturnedHeightIs2()
        {
            var path = "Resources/FullWhite.bmp";
            var frame = VisualHelper.FromImage(path, new(5, 5), new CellSize(1, 2));

            var result = frame.DisplaySize.Height;

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void GivenCellWidth2To1AndImage5x5_WhenFromImage_ThenReturnedWidthIs2()
        {
            var path = "Resources/FullWhite.bmp";
            var frame = VisualHelper.FromImage(path, new(5, 5), new CellSize(2, 1));

            var result = frame.DisplaySize.Width;

            Assert.AreEqual(2, result);
        }
    }
}