using PosterCreator.Attributes;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace PosterCreator.Elements
{
    internal class Path : RenderableNode
    {
        #region Private Fields

        private static int pathID;

        #endregion Private Fields

        #region Public Constructors

        public Path(string label)
        {
            Label = label;
            ID = $"layer{++pathID}";
            Points = new List<V2D>();
            Fill = "none";
            Stroke = Color.Black;
            StrokeWidth = 1;
            StrokeOpacity = 1;
        }

        public Path(string label, params V2D[] points) : this(label)
        {
            Points.AddRange(points);
        }

        #endregion Public Constructors

        #region Public Properties

        public string ID { get; set; }
        public string Label { get; set; }
        public List<V2D> Points { get; set; }

        public bool Closed { get; set; }

        public string Fill { get; set; }

        public Color Stroke { get; set; }

        public float StrokeWidth { get; set; }

        public float StrokeOpacity { get; set; }

        #endregion Public Properties

        #region Public Methods

        public override XElement GetNode()
        {
            var path = Points.Aggregate("M ", (a, c) => a += c.ToString() + " ");

            if (Closed)
                path += "Z";
            var cult = new CultureInfo("en-US");
            var style = $"fill:{Fill};stroke:{Stroke.ToHex()};stroke-width:{StrokeWidth.ToString(cult)}px;stroke-opacity:{StrokeOpacity.ToString(cult)}";

            var g = new XElement(Svg.ns + "path",
                new XAttribute("style", style),
                new XAttribute("d", path),
                new XAttribute("id", ID),
                new XAttribute(Svg.ink + "connector-curvature", 0));

            return g;
        }

        #endregion Public Methods
    }
}