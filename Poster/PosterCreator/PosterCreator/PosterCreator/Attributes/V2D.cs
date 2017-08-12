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
    }
}