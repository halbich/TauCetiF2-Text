using System.Globalization;
using System.IO;
using System.Xml.Linq;
using PosterCreator.Attributes;
using PosterCreator.BaseClasses;
using PosterCreator.Interfaces;

namespace PosterCreator.Elements
{
    internal class Image : IRenderableNode
    {
        #region Private Fields

        private static int imgID;

        #endregion Private Fields

        #region Public Constructors

        public Image(GraphicalElement elem, string path) : this(path)
        {
            XY = elem.Location;
            Dimensions = elem.Size;
        }

        public Image(string path)
        {
            Path = path;
            ID = $"image{++imgID}";
            PreserveAspectRatio = true;
        }

        #endregion Public Constructors

        #region Public Properties

        public V2D Dimensions { get; set; }
        public string ID { get; set; }
        public string Path { get; set; }

        public V2D XY { get; set; }

        public bool? PreserveAspectRatio { get; set; }

        #endregion Public Properties

        #region Public Methods

        public XElement GetNode()
        {
            var cult = new CultureInfo("en-US");

            var t = File.ReadAllText("images/" + Path + ".txt");

            var g = new XElement(Svg.ns + "image",
              new XAttribute("x", XY.X.ToString(cult)),
              new XAttribute("y", XY.Y.ToString(cult)),
              new XAttribute("id", ID),
              new XAttribute(Svg.xlink + "href", t),
              new XAttribute("style", "image-rendering:optimizeQuality"),
              new XAttribute("preserveAspectRatio", PreserveAspectRatio.HasValue ? (PreserveAspectRatio.Value ? "1" : "0") : "none"),
              new XAttribute("height", Dimensions.Y.ToString(cult)),
              new XAttribute("width", Dimensions.X.ToString(cult)));

            return g;
        }

        #endregion Public Methods
    }
}