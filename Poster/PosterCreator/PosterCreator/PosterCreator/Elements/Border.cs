using System.Collections.Generic;
using System.Linq;

namespace PosterCreator.Elements
{
    internal class Border : GraphicalElement
    {
        public override void Render(Svg svg)
        {
            var p = new Path("Border")
            {
                Points = new List<Attributes.V2D>
                {
                    Location,
                    new Attributes.V2D
                    {
                        X = Location.X + Size.X,
                        Y = Location.Y + Size.Y
                    }
                }
            };

            svg.Layers.Last().Nodes.Add(p);
        }
    }
}