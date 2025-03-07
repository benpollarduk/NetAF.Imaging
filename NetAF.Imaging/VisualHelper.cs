using NetAF.Imaging.Textures;
using NetAF.Targets.Console.Rendering;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace NetAF.Imaging
{
    /// <summary>
    /// Provides helper functions for visuals.
    /// </summary>
    public static class VisualHelper
    {
        #region StaticMethods

        /// <summary>
        /// Create a new GridVisualBuilder from an image.
        /// </summary>
        /// <param name="path">The path to the image.</param>
        /// <param name="targetSize">The target size of the GridVisualBuilder.</param>
        /// <param name="cellAspectRatio">The aspect ratio of the cells used to display the image. For square cells use CellAspectRatio.Square.</param>
        /// <param name="texturizer">The texturizer to use for providing texture.</param>
        /// <returns>An approximation of the image as a GridVisualBuilder.</returns>
        public static GridVisualBuilder FromImage(string path, Assets.Size targetSize, CellAspectRatio cellAspectRatio, ITexturizer texturizer)
        {
            using var image = Image.Load<Rgba32>(path);
            return FromImage(image, targetSize, cellAspectRatio, texturizer);
        }

        /// <summary>
        /// Create a new GridVisualBuilder from a a stream.
        /// </summary>
        /// <param name="stream">A stream containing the image.</param>
        /// <param name="targetSize">The target size of the GridVisualBuilder.</param>
        /// <param name="cellAspectRatio">The aspect ratio of the cells used to display the image. For square cells use CellAspectRatio.Square.</param>
        /// <param name="texturizer">The texturizer to use for providing texture.</param>
        /// <returns>An approximation of the image as a GridVisualBuilder.</returns>
        public static GridVisualBuilder FromImage(Stream stream, Assets.Size targetSize, CellAspectRatio cellAspectRatio, ITexturizer texturizer)
        {
            using var image = Image.Load<Rgba32>(stream);
            return FromImage(image, targetSize, cellAspectRatio, texturizer);
        }

        /// <summary>
        /// Create a new GridVisualBuilder from an image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="targetSize">The target size of the GridVisualBuilder.</param>
        /// <param name="cellAspectRatio">The aspect ratio of the cells used to display the image. For square cells use CellAspectRatio.Square.</param>
        /// <param name="texturizer">The texturizer to use for providing texture.</param>
        /// <returns>An approximation of the image as a GridVisualBuilder.</returns>
        private static GridVisualBuilder FromImage(Image<Rgba32> image, Assets.Size targetSize, CellAspectRatio cellAspectRatio, ITexturizer texturizer)
        {
            // the ratio of the cells used to display the pixels may not be square, image may need to be adjusted to accommodate this.
            // when it is rendered the natural stretching of the target will correct this
            Assets.Size ratioCorrectedTargetSize = new((int)(targetSize.Width * cellAspectRatio.HeightRatio), (int)(targetSize.Height * cellAspectRatio.WidthRatio));

            // treat as 32 bit data
            Rgba32[] pixelArray = new Rgba32[ratioCorrectedTargetSize.Width * ratioCorrectedTargetSize.Height];

            // resize the image to match the target size so that pixels in the image match 1:1 with the target
            image.Mutate(x => x.Resize(ratioCorrectedTargetSize.Width, ratioCorrectedTargetSize.Height));

            // pull the pixel data into the buffer
            image.CopyPixelDataTo(pixelArray);

            // the builder will be used to display the image
            GridVisualBuilder builder = new(AnsiColor.Black, AnsiColor.White);
            builder.Resize(ratioCorrectedTargetSize);

            for (var y = 0; y < ratioCorrectedTargetSize.Height; y++)
            {
                for (var x = 0; x < ratioCorrectedTargetSize.Width; x++)
                {
                    Rgba32 pixel = pixelArray[y * ratioCorrectedTargetSize.Width + x];

                    // account for alpha when assigning background color
                    var normalisedAlpha = 1d / byte.MaxValue * pixel.A;
                    var background = new AnsiColor((byte)(pixel.R * normalisedAlpha), (byte)(pixel.G * normalisedAlpha), (byte)(pixel.B * normalisedAlpha));
                    builder.SetCell(x, y, background);

                    // apply texture
                    builder.SetCell(x, y, texturizer.GetTextureCharacter(background), texturizer.GetHighlightColor(background));
                }
            }

            return builder;
        }

        /// <summary>
        /// Create a new GridVisualFrame from an image.
        /// </summary>
        /// <param name="path">The path to the image.</param>
        /// <param name="targetSize">The target size of the GridVisualFrame.</param>
        /// <param name="cellAspectRatio">The aspect ratio of the cells used to display the image. For square cells use CellAspectRatio.Square.</param>
        /// <param name="texturizer">The texturizer to use for providing texture.</param>
        /// <returns>An approximation of the image as a GridVisualFrame.</returns>
        public static GridVisualFrame CreateFrame(string path, Assets.Size targetSize, CellAspectRatio cellAspectRatio, ITexturizer texturizer)
        {
            return new GridVisualFrame(FromImage(path, targetSize, cellAspectRatio, texturizer));
        }

        /// <summary>
        /// Create a new GridVisualFrame from a stream.
        /// </summary>
        /// <param name="stream">The stream containing the image.</param>
        /// <param name="targetSize">The target size of the GridVisualFrame.</param>
        /// <param name="cellAspectRatio">The aspect ratio of the cells used to display the image. For square cells use CellAspectRatio.Square.</param>
        /// <param name="texturizer">The texturizer to use for providing texture.</param>
        /// <returns>An approximation of the image as a GridVisualFrame.</returns>
        public static GridVisualFrame CreateFrame(Stream stream, Assets.Size targetSize, CellAspectRatio cellAspectRatio, ITexturizer texturizer)
        {
            return new GridVisualFrame(FromImage(stream, targetSize, cellAspectRatio, texturizer));
        }

        #endregion;
    }
}
