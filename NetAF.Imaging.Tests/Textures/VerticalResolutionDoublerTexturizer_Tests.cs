using NetAF.Imaging.Textures;
using NetAF.Targets.Console.Rendering;

namespace NetAF.Imaging.Tests.Textures
{
    [TestClass]
    public class VerticalResolutionDoublerTexturizer_Tests
    {
        [TestMethod]
        public void GivenBlackCenterWhitePerimiter_WhenGetTextureCharacter_ThenReturnUpperHalfBlock()
        {
            var kernel = new Kernel
            (
                AnsiColor.White,
                AnsiColor.White,
                AnsiColor.White,
                AnsiColor.White,
                AnsiColor.Black,
                AnsiColor.White,
                AnsiColor.White,
                AnsiColor.White,
                AnsiColor.White
            );
            var texturizer = new VerticalResolutionDoublerTexturizer();

            var result = texturizer.GetTextureCharacter(kernel);

            Assert.AreEqual('\u2584', result);
        }

        [TestMethod]
        public void GivenBlackCenterWhitePerimiter_WhenGetHighlightColor_ThenReturnGrey()
        {
            var kernel = new Kernel
            (
                AnsiColor.White,
                AnsiColor.White,
                AnsiColor.White,
                AnsiColor.White,
                AnsiColor.Black,
                AnsiColor.White,
                AnsiColor.White,
                AnsiColor.White,
                AnsiColor.White
            );
            var texturizer = new VerticalResolutionDoublerTexturizer();

            var result = texturizer.GetTextureCharacter(kernel);

            Assert.AreEqual('\u2584', result);
        }
    }
}