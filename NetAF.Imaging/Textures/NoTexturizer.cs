using NetAF.Rendering.Console;

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

        /// <summary>
        /// Get a texture character for a color.
        /// </summary>
        /// <param name="color">The color to get the texture for.</param>
        /// <returns>The texture character.</returns>
        public char GetTextureCharacter(AnsiColor color)
        {
            return Null;
        }

        /// <summary>
        /// Get a highlight color for a background color.
        /// </summary>
        /// <param name="color">The background color.</param>
        /// <returns>The highlight color.</returns>
        public AnsiColor GetHighlightColor(AnsiColor color)
        {
            return color;
        }

        #endregion
    }
}
