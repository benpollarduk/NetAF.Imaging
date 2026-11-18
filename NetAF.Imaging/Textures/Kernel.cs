using NetAF.Targets.Console.Rendering;

namespace NetAF.Imaging.Textures
{
    /// <summary>
    /// Represents a 3x3 kernel of AnsiColor values arranged by row and column position.
    /// </summary>
    /// <param name="TopLeft">Color at row 0, column 0.</param>
    /// <param name="TopCenter">Color at row 0, column 1.</param>
    /// <param name="TopRight">Color at row 0, column 2.</param>
    /// <param name="MiddleLeft">Color at row 1, column 0.</param>
    /// <param name="MiddleCenter">Color at row 1, column 1.</param>
    /// <param name="MiddleRight">Color at row 1, column 2.</param>
    /// <param name="BottomLeft">Color at row 2, column 0.</param>
    /// <param name="BottomCenter">Color at row 2, column 1.</param>
    /// <param name="BottomRight">Color at row 2, column 2.</param>
    public record Kernel(
        AnsiColor TopLeft, AnsiColor TopCenter, AnsiColor TopRight, 
        AnsiColor MiddleLeft, AnsiColor MiddleCenter, AnsiColor MiddleRight, 
        AnsiColor BottomLeft, AnsiColor BottomCenter, AnsiColor BottomRight)
    {
        #region Methods

        /// <summary>
        /// Convert this Kernel to a 2D array.
        /// </summary>
        /// <returns>The 2D array.</returns>
        public AnsiColor[,] ToArray()
        {
            return new AnsiColor[3, 3]
            {
                { TopLeft, TopCenter, TopRight },
                { MiddleLeft, MiddleCenter, MiddleRight },
                { BottomLeft, BottomCenter, BottomRight }
            };
        }

        #endregion

        #region StaticMethods

        /// <summary>
        /// Create a new Kernel from a 2D array of AnsiColor. The array must be 3x3.
        /// </summary>
        /// <param name="array">The 3x3 array of AnsiColor to create the kernel from.</param>
        /// <returns>The created Kernel.</returns>
        public static Kernel FromArray(AnsiColor[,] array)
        {
            if (array.GetLength(0) != 3 || array.GetLength(1) != 3)
                throw new ArgumentException("Array must be 3x3.", nameof(array));

            return new Kernel
            (
                array[0, 0], array[0, 1], array[0, 2],
                array[1, 0], array[1, 1], array[1, 2],
                array[2, 0], array[2, 1], array[2, 2]
            );
        }

        /// <summary>
        /// Create a new Kernel from a AnsiColor.
        /// </summary>
        /// <param name="color">The AnsiColor to create the kernel from.</param>
        /// <returns>The created Kernel.</returns>
        public static Kernel FromColor(AnsiColor color)
        {
            return new Kernel
            (
                color, color, color,
                color, color, color,
                color, color, color
            );
        }

        #endregion
    }
}
