using NetAF.Imaging.Textures;
using NetAF.Targets.Console.Rendering;

namespace NetAF.Imaging.Tests
{
    [TestClass]
    public class Kernel_Tests
    {
        [TestMethod]
        public void GivenIncorrectWidthArray_WhenFromArray_ThenArgumentException()
        {
            AnsiColor[,] array = new AnsiColor[1,3];

            Assert.Throws<ArgumentException>(() => Kernel.FromArray(array));
        }

        [TestMethod]
        public void GivenIncorrectHeightArray_WhenFromArray_ThenArgumentException()
        {
            AnsiColor[,] array = new AnsiColor[3, 1];

            Assert.Throws<ArgumentException>(() => Kernel.FromArray(array));
        }

        [TestMethod]
        public void GivenCorrectDimensionedArray_WhenFromArray_ThenNotNull()
        {
            AnsiColor[,] array = new AnsiColor[3, 3];

            var result = Kernel.FromArray(array);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GivenBlack_WhenFromColor_ThenNotNull()
        {
            AnsiColor color = AnsiColor.Black;

            var result = Kernel.FromColor(color);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GivenKernel_WhenToArray_ThenNotNull()
        {
            var kernel = Kernel.FromColor(AnsiColor.Black);

            var result = kernel.ToArray();

            Assert.IsNotNull(result);
        }
    }
}