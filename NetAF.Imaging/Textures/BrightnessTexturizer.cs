using NetAF.Rendering.Console;

namespace NetAF.Imaging.Textures
{
    /// <summary>
    /// Provides a texturizer than generates textures based on the brightness of the background.
    /// </summary>
    /// <param name="texture">The texture characters to use.</param>
    /// <param name="highlightStrength">The strength of the highlighting.</param>
    public class BrightnessTexturizer(string texture = BrightnessTexturizer.Full, byte highlightStrength = 20) : ITexturizer
    {
        #region Constants

        /// <summary>
        /// Get the full texture set.
        /// </summary>
        public const string Full = "▓@$#▒%░*+=~-;:,. ";

        /// <summary>
        /// Get the hatching only texture set
        /// </summary>
        public const string Hatching = "▓▒░ ";

        #endregion

        #region Implementation of ITexturizer

        /// <summary>
        /// Get a texture character for a color.
        /// </summary>
        /// <param name="color">The color to get the texture for.</param>
        /// <returns>The texture character.</returns>
        public char GetTextureCharacter(AnsiColor color)
        {
            var brightness = (color.R + color.G + color.B) / 3d;
            var normalisedBrightness = 1d / byte.MaxValue * brightness;
            int index = (int)((texture.Length - 1) * normalisedBrightness);
            return texture[index];
        }

        /// <summary>
        /// Get a highlight color for a background color.
        /// </summary>
        /// <param name="color">The background color.</param>
        /// <returns>The highlight color.</returns>
        public AnsiColor GetHighlightColor(AnsiColor color)
        {
            var r = color.R + highlightStrength;
            var g = color.G + highlightStrength;
            var b = color.B + highlightStrength;

            return new AnsiColor(ClampToByte(r), ClampToByte(g), ClampToByte(b));
        }

        #endregion

        #region StaticMethods

        /// <summary>
        /// Clamp an integer value to a byte value.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <returns>The clamped value.</returns>
        internal static byte ClampToByte(int value)
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
