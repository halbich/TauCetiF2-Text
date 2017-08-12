using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using PosterCreator.Attributes;

namespace PosterCreator.Elements
{
    internal class Path : RenderableNode
    {
        private static int pathID;

        public string ID { get; set; }
        public string Label { get; set; }

        public Path(string label)
        {
            Label = label;
            ID = $"layer{++pathID}";
        }

        public List<V2D> Points { get; set; }

        public bool Closed { get; set; }

        public string Fill => "none";

        public Color Stroke => Color.Black;

        public float StrokeWidth => 1;

        public float StrokeOpacity => 1;

        public override XElement GetNode()
        {
            var path = Points.Aggregate("M ", (a, c) => a += c.ToString() + " ");

            if (Closed)
                path += "Z";

            var style = $"fill:{Fill};stroke:{Stroke.ToHex()};stroke-width:{StrokeWidth}px;stroke-opacity:{StrokeOpacity}";

            var g = new XElement(Svg.ns + "path",
                new XAttribute("style", style),
                new XAttribute("d", path),
                new XAttribute("id", ID),
                new XAttribute(Svg.ink + "connector-curvature", 0));

            return g;
        }
    }
}