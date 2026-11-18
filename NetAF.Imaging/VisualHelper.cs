using NetAF.Imaging.Textures;
using NetAF.Targets.Console.Rendering;
using SkiaSharp;
using System.Data.Common;

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
            using var bitmap = SKBitmap.Decode(path);
            return FromImage(bitmap, targetSize, cellAspectRatio, texturizer);
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
            using var bitmap = SKBitmap.Decode(stream);
            return FromImage(bitmap, targetSize, cellAspectRatio, texturizer);
        }

        /// <summary>
        /// Create a new GridVisualBuilder from an image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="targetSize">The target size of the GridVisualBuilder.</param>
        /// <param name="cellAspectRatio">The aspect ratio of the cells used to display the image. For square cells use CellAspectRatio.Square.</param>
        /// <param name="texturizer">The texturizer to use for providing texture.</param>
        /// <returns>An approximation of the image as a GridVisualBuilder.</returns>
        private static GridVisualBuilder FromImage(SKBitmap image, Assets.Size targetSize, CellAspectRatio cellAspectRatio, ITexturizer texturizer)
        {
            // the ratio of the cells used to display the pixels may not be square, image may need to be adjusted to accommodate this.
            // when it is rendered the natural stretching of the target will correct this
            Assets.Size ratioCorrectedTargetSize = new((int)(targetSize.Width * cellAspectRatio.HeightRatio), (int)(targetSize.Height * cellAspectRatio.WidthRatio));

            // resize the image to match the target size so that pixels in the image match 1:1 with the target
            using var resized = image.Resize(new SKImageInfo(ratioCorrectedTargetSize.Width, ratioCorrectedTargetSize.Height), SKSamplingOptions.Default);

            // the builder will be used to display the image
            GridVisualBuilder builder = new(AnsiColor.Black, AnsiColor.White);
            builder.Resize(ratioCorrectedTargetSize);

            AnsiColor[,] ansiImage = new AnsiColor[ratioCorrectedTargetSize.Width, ratioCorrectedTargetSize.Height];

            // firstly create the image in ANSI
            for (var y = 0; y < ratioCorrectedTargetSize.Height; y++)
            {
                for (var x = 0; x < ratioCorrectedTargetSize.Width; x++)
                {
                    SKColor pixel = resized.GetPixel(x, y);
                    var normalisedAlpha = 1d / byte.MaxValue * pixel.Alpha;
                    ansiImage[x, y] = new AnsiColor((byte)(pixel.Red * normalisedAlpha), (byte)(pixel.Green * normalisedAlpha), (byte)(pixel.Blue * normalisedAlpha));
                }
            }

            // now texturize the target image
            for (var y = 0; y < ratioCorrectedTargetSize.Height; y++)
            {
                for (var x = 0; x < ratioCorrectedTargetSize.Width; x++)
                {
                    AnsiColor getColor(int column, int row, AnsiColor fallback)
                    {
                        if (column < 0 || column >= ratioCorrectedTargetSize.Width || row < 0 || row >= ratioCorrectedTargetSize.Height)
                            return fallback;

                        return ansiImage[column, row];
                    }

                    // get the central color, also the fallback for the edge of the image when getting colors
                    var central = ansiImage[x, y];

                    // create the kernel
                    var kernel = new Kernel
                    (
                        getColor(x - 1, y - 1, central), getColor(x, y - 1, central), getColor(x + 1, y - 1, central),
                        getColor(x - 1, y, central), central, getColor(x + 1, y, central),
                        getColor(x - 1, y + 1, central), getColor(x, y + 1, central), getColor(x + 1, y + 1, central)
                    );

                    // set the cell to the central color
                    builder.SetCell(x, y, kernel.MiddleCenter);

                    // apply texture
                    builder.SetCell(x, y, texturizer.GetTextureCharacter(kernel), texturizer.GetHighlightColor(kernel));
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
