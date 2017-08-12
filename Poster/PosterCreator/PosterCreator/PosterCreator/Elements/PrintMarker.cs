using System.Linq;

namespace PosterCreator.Elements
{
    internal class PrintMarker : GraphicalElement
    {
        public override void Render(Svg svg)
        {
            var layer = svg.Layers.Last();
        }
    }
}