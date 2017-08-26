using System.Globalization;
using System.IO;
using System.Xml.Linq;
using PosterCreator.Attributes;

namespace PosterCreator.Elements
{
    internal class Image : RenderableNode
    {
        #region Private Fields

        private static int imgID;

        #endregion Private Fields

        public string Path { get; set; }

        public V2D XY { get; set; }

        public V2D Dimensions { get; set; }

        public string ID { get; set; }

        public Image(string path)
        {
            Path = path;
            ID = $"image{++imgID}";
        }

        public override XElement GetNode()
        {
            var cult = new CultureInfo("en-US");

            var t = File.ReadAllText(Path + ".txt");

            var g = new XElement(Svg.ns + "image",
              new XAttribute("x", XY.X.ToString(cult)),
              new XAttribute("y", XY.Y.ToString(cult)),
              new XAttribute("id", ID),
              new XAttribute(Svg.xlink + "href", t),
              new XAttribute("style", "image-rendering:optimizeQuality"),
              new XAttribute("preserveAspectRatio", "none"),
              new XAttribute("height", Dimensions.Y.ToString(cult)),
              new XAttribute("width", Dimensions.X.ToString(cult)));

            return g;
        }
    }
}