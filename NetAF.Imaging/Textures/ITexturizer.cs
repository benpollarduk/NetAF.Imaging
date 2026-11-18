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
        /// <param name="kernel">The 3x3 kernel of colors to get the texture for.</param>
        /// <returns>The texture character.</returns>
        char GetTextureCharacter(Kernel kernel);
        /// <summary>
        /// Get a highlight color for a background color.
        /// </summary>
        /// <param name="kernel">The 3x3 kernel of background colors.</param>
        /// <returns>The highlight color.</returns>
        AnsiColor GetHighlightColor(Kernel kernel);
    }
}
