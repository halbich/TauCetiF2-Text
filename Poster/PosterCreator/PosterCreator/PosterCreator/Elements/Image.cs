using System.Globalization;
using System.IO;
using System.Xml.Linq;
using PosterCreator.Attributes;
using PosterCreator.BaseClasses;
using PosterCreator.Interfaces;
using System;

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
            XY = elem.Location + elem.Padding.LeftTop;
            Dimensions = elem.Size - elem.Padding.LeftTop - elem.Padding.RightBottom;
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

        public bool? PreserveAspectRatio { get; set; }
        public V2D XY { get; set; }

        #endregion Public Properties

        #region Public Methods

        public XElement GetNode()
        {
            var cult = new CultureInfo("en-US");


           var t = @"data:image/gif;base64," + Convert.ToBase64String(File.ReadAllBytes("images/" + Path + ".png"));

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