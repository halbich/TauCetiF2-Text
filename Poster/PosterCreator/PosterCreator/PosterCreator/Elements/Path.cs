using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using PosterCreator.Attributes;
using PosterCreator.Interfaces;

namespace PosterCreator.Elements
{
    internal class Path : IRenderableNode
    {
        #region Private Fields

        private static int pathID;

        #endregion Private Fields

        #region Public Constructors

        public Path(string label)
        {
            Label = label;
            ID = $"path{++pathID}";
            Points = new List<V2D>();
            RenderParams = new RenderingParams
            {
                Stroke = Color.Black,
                StrokeWidth = 0.01f
            };
        }

        public Path(string label, params V2D[] points) : this(label)
        {
            Points.AddRange(points);
        }

        #endregion Public Constructors

        #region Public Properties

        public bool Closed { get; set; }

        public string ID { get; set; }
        public string Label { get; set; }
        public List<V2D> Points { get; set; }
        public RenderingParams RenderParams { get; set; }

        #endregion Public Properties

        #region Public Methods

        public XElement GetNode()
        {
            var path = Points.Aggregate("M ", (a, c) => a += c.ToString() + " ");

            if (Closed)
                path += "Z";

            var g = new XElement(Svg.ns + "path",
                new XAttribute("style", RenderParams.GetStyle(TextSource.UsedCulture)),
                new XAttribute("d", path),
                new XAttribute("id", ID),
                new XAttribute(Svg.ink + "connector-curvature", 0));

            return g;
        }

        public Path SetFillStroke(Color c)
        {
            RenderParams.SetFillStroke(c);
            return this;
        }

        #endregion Public Methods
    }
}