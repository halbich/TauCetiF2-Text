using System.Collections.Generic;
using System.Xml.Linq;
using PosterCreator.Interfaces;

namespace PosterCreator.Elements
{
    internal enum LayerType
    { Background, BorderBackground, Border, Text, Other }

    internal class Layer : IRenderableNode
    {
        #region Private Fields

        private static int layerID;

        #endregion Private Fields

        #region Public Constructors

        public Layer(string label, LayerType type)
        {
            Label = label;
            ID = $"layer{++layerID}";
            Nodes = new List<IRenderableNode>();
            Type = type;
        }

        #endregion Public Constructors

        #region Public Properties

        public string ID { get; set; }
        public string Label { get; set; }
        public LayerType Type { get; private set; }

        #endregion Public Properties

        #region Private Properties

        private List<IRenderableNode> Nodes { get; set; }

        #endregion Private Properties

        #region Public Methods

        public XElement GetNode()
        {
            var g = new XElement(Svg.ns + "g",
                new XAttribute(Svg.ink + "groupmode", "layer"),
                new XAttribute("id", ID),
                new XAttribute(Svg.ink + "label", Label));

            foreach (var item in Nodes)
                g.Add(item.GetNode());

            return g;
        }

        #endregion Public Methods

        #region Internal Methods

        internal IRenderableNode Add(IRenderableNode p)
        {
            Nodes.Add(p);
            return p;
        }

        #endregion Internal Methods
    }
}