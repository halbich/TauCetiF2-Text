using System.Collections.Generic;
using System.Drawing;
using System.Xml.Linq;
using PosterCreator.Attributes;
using PosterCreator.Interfaces;

namespace PosterCreator.Elements
{
    internal class FlowRoot : IRenderableNode
    {
        #region Private Fields

        private static int flowRegID;

        private static int flowRootID;

        private static int useID;

        #endregion Private Fields

        #region Public Constructors

        public FlowRoot(Rectangle href)
        {
            RootID = $"flowRoot{++flowRootID}";
            RegionID = $"flowRegion{++flowRegID}";
            UseID = $"use{++useID}";

            FontStyle = "normal";
            FontWeight = "normal";
            FontSize = 12;
            FontFamily = "Roboto";

            HrefRectangle = href;
            Paragraphs = new List<FlowPara>();
            RenderParams = new RenderingParams
            {
                Fill = Color.White
            };
        }

        #endregion Public Constructors

        #region Public Properties

        public string FontFamily { get; set; }

        public int FontSize { get; private set; }

        public string FontStyle { get; set; }

        public string FontWeight { get; private set; }

        public Rectangle HrefRectangle { get; set; }

        public List<FlowPara> Paragraphs { get; set; }

        public string RegionID { get; set; }

        public RenderingParams RenderParams { get; set; }

        public string RootID { get; set; }

        public string UseID { get; set; }

        #endregion Public Properties

        #region Public Methods

        public XElement GetNode()
        {
            var cult = TextSource.UsedCulture;

            var style = $"font-style:{FontStyle};font-weight:{FontWeight};font-size:{FontSize}px;line-height:125%;font-family:{FontFamily};letter-spacing:0px;" +
                        $"word-spacing:0px;" + RenderParams.GetStyle(cult) +
                        $"stroke-linecap:butt;stroke-linejoin:miter;";

            var flowRoot = new XElement(Svg.ns + "flowRoot",
                new XAttribute(XNamespace.Xml + "space", "preserve"),
                new XAttribute("style", style),
                new XAttribute("id", RootID)
                );

            var flowRegion = new XElement(Svg.ns + "flowRegion",
                new XAttribute("id", RegionID)
              );

            var use = new XElement(Svg.ns + "use",
                new XAttribute("x", 0),
                new XAttribute("y", 0),
                //new XAttribute("width", "100%"),
                //new XAttribute("height", "100%"),
                new XAttribute("id", UseID),
                new XAttribute(Svg.xlink + "href", $"#{HrefRectangle.ID}")
                );

            flowRegion.Add(use);

            flowRoot.Add(flowRegion);

            foreach (var item in Paragraphs)
                flowRoot.Add(item.GetNode());

            return flowRoot;
        }

        #endregion Public Methods

        #region Internal Methods

        internal void SetBold()
        {
            FontWeight = "bold";
        }

        #endregion Internal Methods
    }
}