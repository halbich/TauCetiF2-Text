using System.Collections.Generic;
using System.Linq;

namespace PosterCreator.Elements
{
    internal class Border : GraphicalElement
    {
        public override void Render(Svg svg)
        {
            var p = new Path("Border", Location, Location.MoveX(Size.X), Location.MoveXY(Size.X, Size.Y), Location.MoveY(Size.Y));
            p.Closed = true;

            svg.GL(LayerType.Border).Add(p);
        }
    }
}