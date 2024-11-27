using NetAF.Rendering.Console;
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
        /// <returns>An approximation of the image as a GridVisualBuilder.</returns>
        public static GridVisualBuilder FromImage(string path, Assets.Size targetSize)
        {
            return FromImage(path, targetSize, CellSize.Square);
        }

        /// <summary>
        /// Create a new GridVisualBuilder from an image.
        /// </summary>
        /// <param name="path">The path to the image.</param>
        /// <param name="targetSize">The target size of the GridVisualBuilder.</param>
        /// <param name="cellSize">The size of the cells used to display the image. For square cells use CellSize.Square.</param>
        /// <returns>An approximation of the image as a GridVisualBuilder.</returns>
        public static GridVisualBuilder FromImage(string path, Assets.Size targetSize, CellSize cellSize)
        {
            using var image = Image.Load<Rgba32>(path);

            // the ratio of the cells used to display the pixels may not be square, image may need to be adjusted to accommodate this.
            // when it is rendered the natural stretching of the target will correct this
            Assets.Size ratioCorrectedTargetSize = new((int)(targetSize.Width * cellSize.HeightRatio), (int)(targetSize.Height * cellSize.WidthRatio));
            
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

                    // account for alpha when assigning 
                    var normalisedAlpha = 1d / byte.MaxValue * pixel.A;
                    builder.SetCell(x, y, new((byte)(pixel.R * normalisedAlpha), (byte)(pixel.G * normalisedAlpha), (byte)(pixel.B * normalisedAlpha)));
                }
            }

            return builder;
        }

        #endregion;
    }
}
