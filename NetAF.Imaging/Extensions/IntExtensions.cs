namespace NetAF.Imaging.Extensions
{
    /// <summary>
    /// Provides extension methods for integers.
    /// </summary>
    public static class IntExtensions
    {
        #region Extensions

        /// <summary>
        /// Clamp an integer value to a byte value.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <returns>The clamped value.</returns>
        public static byte ClampToByte(this int value)
        {
            if (value < byte.MinValue)
                return byte.MinValue;

            if (value > byte.MaxValue)
                return byte.MaxValue;

            return (byte)value;
        }

        #endregion
    }
}
