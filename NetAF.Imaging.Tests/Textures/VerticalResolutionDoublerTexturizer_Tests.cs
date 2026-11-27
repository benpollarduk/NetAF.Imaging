using NetAF.Imaging.Textures;
using NetAF.Targets.Console.Rendering;

namespace NetAF.Imaging.Tests.Textures
{
    [TestClass]
    public class VerticalResolutionDoublerTexturizer_Tests
    {
        [TestMethod]
        public void GivenBlackCenterBrightWhitePerimiter_WhenGetTextureCharacter_ThenReturnUpperHalfBlock()
        {
            var kernel = new Kernel
            (
                AnsiColor.BrightWhite,
                AnsiColor.BrightWhite,
                AnsiColor.BrightWhite,
                AnsiColor.BrightWhite,
                AnsiColor.Black,
                AnsiColor.BrightWhite,
                AnsiColor.BrightWhite,
                AnsiColor.BrightWhite,
                AnsiColor.BrightWhite
            );
            var texturizer = new VerticalResolutionDoublerTexturizer();

            var result = texturizer.GetTextureCharacter(kernel);

            Assert.AreEqual('\u2580', result);
        }

        [TestMethod]
        public void GivenBlackCenterBrightWhitePerimiter_WhenGetHighlightColor_ThenReturnGrey()
        {
            var kernel = new Kernel
            (
                AnsiColor.BrightWhite,
                AnsiColor.BrightWhite,
                AnsiColor.BrightWhite,
                AnsiColor.BrightWhite,
                AnsiColor.Black,
                AnsiColor.BrightWhite,
                AnsiColor.BrightWhite,
                AnsiColor.BrightWhite,
                AnsiColor.BrightWhite
            );
            var texturizer = new VerticalResolutionDoublerTexturizer();

            var result = texturizer.GetHighlightColor(kernel);

            Assert.AreEqual(127, result.R);
            Assert.AreEqual(127, result.G);
            Assert.AreEqual(127, result.B);
        }
    }
}
