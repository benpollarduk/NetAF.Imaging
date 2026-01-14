using NetAF.Imaging.Extensions;

namespace NetAF.Imaging.Tests
{
    [TestClass]
    public class IntExtensions_Tests
    {
        [TestMethod]
        public void Given127_WhenClampToByte_ThenReturn127()
        {
            var result = 127.ClampToByte();

            Assert.AreEqual(127, result);
        }

        [TestMethod]
        public void GivenMinus1_WhenClampToByte_ThenReturn0()
        {
            var result = (-1).ClampToByte();

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Given256_WhenClampToByte_ThenReturn255()
        {
            var result = 256.ClampToByte();

            Assert.AreEqual(255, result);
        }
    }
}