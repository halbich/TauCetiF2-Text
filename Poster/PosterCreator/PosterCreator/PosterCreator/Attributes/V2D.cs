namespace PosterCreator.Attributes
{
    internal struct V2D
    {
        public float X { get; set; }

        public float Y { get; set; }

        public override string ToString()
        {
            return $"{X},{Y}";
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
                X = X ,
                Y = Y + y
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
    }
}