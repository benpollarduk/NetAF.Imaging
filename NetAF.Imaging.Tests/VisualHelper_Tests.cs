using NetAF.Imaging.Textures;
using NetAF.Targets.Console.Rendering;

namespace NetAF.Imaging.Tests
{
    [TestClass]
    public class VisualHelper_Tests
    {
        [TestMethod]
        public void GivenWhiteImageAsPath_WhenCreateFrame_ThenFrameIsNotNull()
        {
            var path = "Images/FullWhite.bmp";

            var result = VisualHelper.CreateFrame(path, new(5, 5), CellAspectRatio.Square, new NoTexturizer());

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GivenWhiteImage_WhenFromImage_ThenImageIsBrightWhite()
        {
            var path = "Images/FullWhite.bmp";
            var frame = VisualHelper.FromImage(path, new(5, 5), CellAspectRatio.Square, new NoTexturizer());

            var result = frame.GetCellBackgroundColor(0, 0);

            Assert.AreEqual(AnsiColor.BrightWhite, result);
        }

        [TestMethod]
        public void GivenBlackImage_WhenFromImage_ThenImageIsBlack()
        {
            var path = "Images/FullBlack.bmp";
            var frame = VisualHelper.FromImage(path, new(5, 5), CellAspectRatio.Square, new NoTexturizer());
            
            var result = frame.GetCellBackgroundColor(0, 0);

            Assert.AreEqual(AnsiColor.Black, result);
        }

        [TestMethod]
        public void GivenCellWidth1To2AndImage5x5_WhenFromImage_ThenReturnedHeightIs2()
        {
            var path = "Images/FullWhite.bmp";
            var frame = VisualHelper.FromImage(path, new(5, 5), new CellAspectRatio(1, 2), new NoTexturizer());

            var result = frame.DisplaySize.Height;

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void GivenCellWidth2To1AndImage5x5_WhenFromImage_ThenReturnedWidthIs2()
        {
            var path = "Images/FullWhite.bmp";
            var frame = VisualHelper.FromImage(path, new(5, 5), new CellAspectRatio(2, 1), new NoTexturizer());

            var result = frame.DisplaySize.Width;

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void GivenFullBlackAndBrightnessTexturizer_WhenFromImage_ThenTextureCharacterApplied()
        {
            var path = "Images/FullBlack.bmp";
            var frame = VisualHelper.FromImage(path, new(5, 5), new CellAspectRatio(2, 1), new BrightnessTexturizer());

            var result = frame.GetCharacter(0, 0);

            Assert.AreNotEqual((char)0, result);
        }

        [TestMethod]
        public void GivenWhiteImageAsStream_WhenCreateFrame_ThenFrameIsNotNull()
        {
            var path = "Images/FullWhite.bmp";
            var fileBytes = File.ReadAllBytes(path);
            var stream = new MemoryStream(fileBytes);

            var result = VisualHelper.CreateFrame(stream, new(5, 5), CellAspectRatio.Square, new NoTexturizer());

            Assert.IsNotNull(result);
        }
    }
}