using NetAF.Imaging.Extensions;
using NetAF.Targets.Console.Rendering;

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

        /// <inheritdoc/>
        public char GetTextureCharacter(Kernel kernel)
        {
            var brightness = (kernel.MiddleCenter.R + kernel.MiddleCenter.G + kernel.MiddleCenter.B) / 3d;
            var normalisedBrightness = 1d / byte.MaxValue * brightness;
            int index = (int)((texture.Length - 1) * normalisedBrightness);
            return texture[index];
        }

        /// <inheritdoc/>
        public AnsiColor GetHighlightColor(Kernel kernel)
        {
            var r = kernel.MiddleCenter.R + highlightStrength;
            var g = kernel.MiddleCenter.G + highlightStrength;
            var b = kernel.MiddleCenter.B + highlightStrength;

            return new AnsiColor(r.ClampToByte(),  g.ClampToByte(), b.ClampToByte());
        }

        #endregion
    }
}
