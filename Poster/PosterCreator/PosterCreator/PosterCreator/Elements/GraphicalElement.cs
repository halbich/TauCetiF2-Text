using PosterCreator.Attributes;

namespace PosterCreator.Elements
{
    internal abstract class GraphicalElement
    {
        public V2D Location { get; set; }
        public V2D Size { get; set; }

        public Offset Margin { get; set; }
        public Offset Padding { get; set; }

        public abstract void Render(Svg svg);
    }
}