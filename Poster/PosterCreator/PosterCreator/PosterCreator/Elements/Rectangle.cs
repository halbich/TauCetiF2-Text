using System.Drawing;
using System.Xml.Linq;
using PosterCreator.Attributes;
using PosterCreator.BaseClasses;
using PosterCreator.Interfaces;

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

            RenderParams = new RenderingParams();
        }

        public Rectangle(GraphicalElement elem) : this()
        {
            XY = elem.Location.MoveXY(elem.Padding.Left, elem.Padding.Top);
            Dimensions = elem.Size.MoveXY(-elem.Padding.Left - elem.Padding.Right, -elem.Padding.Top - elem.Padding.Bottom);

#if DEBUG
            RenderParams.Stroke = Color.Red;
            RenderParams.StrokeWidth = 1;
#endif
        }

        #endregion Public Constructors

        #region Public Properties

        public V2D Dimensions { get; set; }

        public string ID { get; set; }
        public RenderingParams RenderParams { get; set; }
        public V2D XY { get; set; }

        #endregion Public Properties

        #region Public Methods

        public XElement GetNode()
        {
            var cult = TextSource.UsedCulture;

            var r = new XElement(Svg.ns + "rect",
              new XAttribute("id", ID),
              new XAttribute("width", Dimensions.X.ToString(cult)),
              new XAttribute("height", Dimensions.Y.ToString(cult)),
              new XAttribute("x", XY.X.ToString(cult)),
              new XAttribute("y", XY.Y.ToString(cult)),
              new XAttribute("style", RenderParams.GetStyle(cult))
              );

            return r;
        }

        #endregion Public Methods
    }
}