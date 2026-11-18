using NetAF.Targets.Console.Rendering;

namespace NetAF.Imaging.Textures
{
    /// <summary>
    /// Provides a texturizer than generates no texture.
    /// </summary>
    public class NoTexturizer : ITexturizer
    {
        #region Constants

        /// <summary>
        /// Get a blank character.
        /// </summary>
        private const char Null = (char)0;

        #endregion

        #region Implementation of ITexturizer

        /// <inheritdoc/>
        public char GetTextureCharacter(Kernel kernel)
        {
            return Null;
        }

        /// <inheritdoc/>
        public AnsiColor GetHighlightColor(Kernel kernel)
        {
            return kernel.MiddleCenter;
        }

        #endregion
    }
}
