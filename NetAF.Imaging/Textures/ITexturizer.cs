using NetAF.Targets.Console.Rendering;

namespace NetAF.Imaging.Textures
{
    /// <summary>
    /// Represents any object that can provide a texture for a color.
    /// </summary>
    public interface ITexturizer
    {
        /// <summary>
        /// Get a texture character for a color.
        /// </summary>
        /// <param name="color">The color to get the texture for.</param>
        /// <returns>The texture character.</returns>
        char GetTextureCharacter(AnsiColor color);
        /// <summary>
        /// Get a highlight color for a background color.
        /// </summary>
        /// <param name="color">The background color.</param>
        /// <returns>The highlight color.</returns>
        AnsiColor GetHighlightColor(AnsiColor color);
    }
}
