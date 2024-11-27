using NetAF.Imaging.Textures;
using NetAF.Rendering.Console;

namespace NetAF.Imaging.Tests
{
    [TestClass]
    public class NoTexturizer_Tests
    {
        [TestMethod]
        public void GivenBlack_WhenGetTextureCharacter_ThenReturnNullCharacter()
        {
            var noTexturizer = new NoTexturizer();

            var result = noTexturizer.GetTextureCharacter(AnsiColor.Black);

            Assert.AreEqual((char)0, result);
        }

        [TestMethod]
        public void GivenBlack_WhenGetHighlightColor_ThenReturnBlack()
        {
            var noTexturizer = new NoTexturizer();

            var result = noTexturizer.GetHighlightColor(AnsiColor.Black);

            Assert.AreEqual(AnsiColor.Black, result);
        }
    }
}