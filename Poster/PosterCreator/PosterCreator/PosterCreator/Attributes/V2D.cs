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

        public V2D MoveX(float x)
        {
            return new V2D
            {
                X = X + x,
                Y = Y
            };
        }

        public V2D MoveXY(float x, float y)
        {
            return new V2D
            {
                X = X + x,
                Y = Y + y
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
            return $"{X},{Y}";
        }

        #endregion Public Methods
    }
}