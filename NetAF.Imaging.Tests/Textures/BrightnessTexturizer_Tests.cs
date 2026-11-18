using NetAF.Imaging.Textures;
using NetAF.Targets.Console.Rendering;

namespace NetAF.Imaging.Tests.Textures
{
    [TestClass]
    public class BrightnessTexturizer_Tests
    {
        [TestMethod]
        public void GivenBlack_WhenGetTextureCharacter_ThenReturnDarkestCharacter()
        {
            var texturizer = new BrightnessTexturizer("#.");

            var result = texturizer.GetTextureCharacter(Kernel.FromColor(AnsiColor.Black));

            Assert.AreEqual('#', result);
        }

        [TestMethod]
        public void GivenBrightWhite_WhenGetTextureCharacter_ThenReturnLightestCharacter()
        {
            var texturizer = new BrightnessTexturizer("#.");

            var result = texturizer.GetTextureCharacter(Kernel.FromColor(AnsiColor.BrightWhite));

            Assert.AreEqual('.', result);
        }

        [TestMethod]
        public void GivenBlackAndHighlightOf10_WhenGetHighlightColor_ThenHighlight10BrighterOnAllChannels()
        {
            var texturizer = new BrightnessTexturizer("#.", 10);

            var result = texturizer.GetHighlightColor(Kernel.FromColor(AnsiColor.Black));

            Assert.AreEqual(10, result.R);
            Assert.AreEqual(10, result.G);
            Assert.AreEqual(10, result.B);
        }
    }
}