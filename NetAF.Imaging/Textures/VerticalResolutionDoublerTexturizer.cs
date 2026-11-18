using NetAF.Imaging.Extensions;
using NetAF.Targets.Console.Rendering;

namespace NetAF.Imaging.Textures
{
    /// <summary>
    /// Provides a texturizer than doubles vertical resolution.
    /// </summary>
    public class VerticalResolutionDoublerTexturizer : ITexturizer
    {
        #region Constants

        /// <summary>
        /// Get the upper half block caharcter.
        /// </summary>
        private const char UpperHalfBlock = '\u2584';

        #endregion

        #region Implementation of ITexturizer

        /// <inheritdoc/>
        public char GetTextureCharacter(Kernel kernel)
        {
            return UpperHalfBlock;
        }

        /// <inheritdoc/>
        public AnsiColor GetHighlightColor(Kernel kernel)
        {
            var r = (kernel.MiddleCenter.R + kernel.TopCenter.R) / 2;
            var g = (kernel.MiddleCenter.G + kernel.TopCenter.G) / 2;
            var b = (kernel.MiddleCenter.B + kernel.TopCenter.B) / 2;

            return new AnsiColor(r.ClampToByte(),  g.ClampToByte(), b.ClampToByte());
        }

        #endregion
    }
}
