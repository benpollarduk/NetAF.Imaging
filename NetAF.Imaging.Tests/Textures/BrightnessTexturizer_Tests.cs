using NetAF.Imaging.Textures;
using NetAF.Targets.Console.Rendering;

namespace NetAF.Imaging.Tests
{
    [TestClass]
    public class BrightnessTexturizer_Tests
    {
        [TestMethod]
        public void GivenBlack_WhenGetTextureCharacter_ThenReturnDarkestCharacter()
        {
            var brightnessTexturizer = new BrightnessTexturizer("#.");

            var result = brightnessTexturizer.GetTextureCharacter(AnsiColor.Black);

            Assert.AreEqual('#', result);
        }

        [TestMethod]
        public void GivenBrightWhite_WhenGetTextureCharacter_ThenReturnLightestCharacter()
        {
            var brightnessTexturizer = new BrightnessTexturizer("#.");

            var result = brightnessTexturizer.GetTextureCharacter(AnsiColor.BrightWhite);

            Assert.AreEqual('.', result);
        }

        [TestMethod]
        public void GivenBlackAndHightlightOf10_WhenGetHighlightColor_ThenHighlight10BrighterOnAllChannels()
        {
            var brightnessTexturizer = new BrightnessTexturizer("#.", 10);

            var result = brightnessTexturizer.GetHighlightColor(AnsiColor.Black);

            Assert.AreEqual(10, result.R);
            Assert.AreEqual(10, result.G);
            Assert.AreEqual(10, result.B);
        }

        [TestMethod]
        public void Given127_WhenClampToByte_ThenReturn127()
        {
            var result = BrightnessTexturizer.ClampToByte(127);

            Assert.AreEqual(127, result);
        }

        [TestMethod]
        public void GivenMinus1_WhenClampToByte_ThenReturn0()
        {
            var result = BrightnessTexturizer.ClampToByte(-1);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Given256_WhenClampToByte_ThenReturn255()
        {
            var result = BrightnessTexturizer.ClampToByte(256);

            Assert.AreEqual(255, result);
        }
    }
}