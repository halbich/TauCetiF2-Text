using System.Drawing;
using System.Globalization;
using System.Xml.Linq;
using PosterCreator.Attributes;

namespace PosterCreator.Elements
{
    internal class Rectangle : IRenderableNode
    {
        #region Private Fields

        private static int rectID;

        #endregion Private Fields

        #region Public Constructors

        public Rectangle()
        {
            ID = $"rect{++rectID}";
            StrokeWidth = 0.01f;
            StrokeOpacity = 1;
            FillOpacity = 1;
        }

        #endregion Public Constructors

        #region Public Properties

        public V2D Dimensions { get; set; }
        public Color? Fill { get; set; }
        public float FillOpacity { get; set; }
        public string ID { get; set; }
        public Color? Stroke { get; set; }

        public float StrokeOpacity { get; set; }
        public float StrokeWidth { get; set; }
        public V2D XY { get; set; }

        #endregion Public Properties

        #region Public Methods

        public XElement GetNode()
        {
            var cult = new CultureInfo("en-US");

            var style = $"fill:{Fill.ToHex()};fill-opacity:{FillOpacity.ToString(cult)};stroke:{Stroke.ToHex()};stroke-width:{StrokeWidth.ToString(cult)}px;stroke-opacity:{StrokeOpacity.ToString(cult)}";

            var r = new XElement(Svg.ns + "rect",
              new XAttribute("id", ID),
              new XAttribute("width", Dimensions.X.ToString(cult)),
              new XAttribute("height", Dimensions.Y.ToString(cult)),
              new XAttribute("x", XY.X.ToString(cult)),
              new XAttribute("y", XY.Y.ToString(cult)),
              new XAttribute("style", style)
              );

            return r;
        }

        #endregion Public Methods
    }
}