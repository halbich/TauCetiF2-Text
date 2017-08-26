namespace PosterCreator.Attributes
{
    internal struct Offset
    {
        #region Public Constructors

        public Offset(float all) : this(all, all, all, all)
        {
        }

        public Offset(float top, float right) : this(top, right, top, right)
        {
        }

        public Offset(float top, float right, float bottom, float left)
        {
            Top = top;
            Right = right;
            Bottom = bottom;
            Left = left;
        }

        #endregion Public Constructors

        #region Public Properties

        public float Bottom { get; set; }
        public float Left { get; set; }
        public float Right { get; set; }
        public float Top { get; set; }

        #endregion Public Properties

        #region Public Methods

        public override string ToString()
        {
            return $"T: {Top},R: {Right}, B: {Bottom},L: {Left}";
        }

        #endregion Public Methods
    }
}