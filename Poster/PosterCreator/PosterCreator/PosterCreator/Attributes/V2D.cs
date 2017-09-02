namespace PosterCreator.Attributes
{
    internal struct V2D
    {
        #region Public Constructors

        public V2D(float x, float y)
        {
            X = x;
            Y = y;
        }

        #endregion Public Constructors

        #region Public Properties

        public float X { get; set; }

        public float Y { get; set; }

        #endregion Public Properties

        #region Public Methods

        public static V2D operator -(V2D p1, V2D p2)
        {
            return new V2D(p1.X - p2.X, p1.Y - p2.Y);
        }

        public static V2D operator +(V2D p1, V2D p2)
        {
            return new V2D(p1.X + p2.X, p1.Y + p2.Y);
        }

        public V2D MoveX(float x)
        {
            return new V2D
            {
                X = X + x,
                Y = Y
            };
        }

        public V2D MoveY(float y)
        {
            return new V2D
            {
                X = X,
                Y = Y + y
            };
        }

        public override string ToString()
        {
            var c = TextSource.UsedCulture;
            return $"{X.ToString(c)},{Y.ToString(c)}";
        }

        #endregion Public Methods
    }
}