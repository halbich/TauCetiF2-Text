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

            HrefRectangle = href;
            Paragraphs = new List<FlowPara>();
            RenderParams = new RenderingParams
            {
                Fill = Color.White
            };
            TextParams = new TextParams();
        }

        #endregion Public Constructors

        #region Public Properties

        public Rectangle HrefRectangle { get; set; }
        public List<FlowPara> Paragraphs { get; set; }
        public string RegionID { get; set; }
        public RenderingParams RenderParams { get; set; }
        public string RootID { get; set; }
        public TextParams TextParams { get; internal set; }
        public string UseID { get; set; }

        #endregion Public Properties

        #region Public Methods

        public XElement GetNode()
        {
            var cult = TextSource.UsedCulture;

            var style = "letter-spacing:0px;" + TextParams.GetStyle() + "word-spacing:0px;" + RenderParams.GetStyle(cult) + "stroke-linecap:butt;stroke-linejoin:miter;";

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
    }
}