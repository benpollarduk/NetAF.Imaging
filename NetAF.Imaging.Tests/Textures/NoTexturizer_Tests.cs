using NetAF.Imaging.Textures;
using NetAF.Targets.Console.Rendering;

namespace NetAF.Imaging.Tests.Textures
{
    [TestClass]
    public class NoTexturizer_Tests
    {
        [TestMethod]
        public void GivenBlack_WhenGetTextureCharacter_ThenReturnNullCharacter()
        {
            var texturizer = new NoTexturizer();

            var result = texturizer.GetTextureCharacter(Kernel.FromColor(AnsiColor.Black));

            Assert.AreEqual((char)0, result);
        }

        [TestMethod]
        public void GivenBlack_WhenGetHighlightColor_ThenReturnBlack()
        {
            var texturizer = new NoTexturizer();

            var result = texturizer.GetHighlightColor(Kernel.FromColor(AnsiColor.Black));

            Assert.AreEqual(AnsiColor.Black, result);
        }
    }
}