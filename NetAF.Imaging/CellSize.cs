namespace NetAF.Imaging
{
    /// <summary>
    /// Represents the size of a cell.
    /// </summary>
    /// <param name="width">The width of the cell.</param>
    /// <param name="height">The height of the cell.</param>
    public readonly struct CellSize(double width, double height)
    {
        #region StaticProperties

        /// <summary>
        /// Get the default value for a square cell.
        /// </summary>
        public static CellSize Square { get; } = new CellSize(1, 1);

        #endregion

        #region Properties

        /// <summary>
        /// Get the width of the cell.
        /// </summary>
        public double Width { get; } = width;

        /// <summary>
        /// Get the height of the cell.
        /// </summary>
        public double Height { get; } = height;

        /// <summary>
        /// Get the width ratio.
        /// </summary>
        public double WidthRatio => Width >= Height ? 1 : Width / Height;

        /// <summary>
        /// Get the height ratio.
        /// </summary>
        public double HeightRatio => Height >= Width ? 1 : Height / Width;

        #endregion
    }
}
