using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace PosterCreator.Elements
{
    internal enum LayerType
    { Background, BorderBackground, Border, Text, Other }

    internal class Layer : RenderableNode
    {
        private static int layerID;

        public string ID { get; set; }
        public string Label { get; set; }
        public LayerType Type { get; private set; }

        public Layer(string label, LayerType type)
        {
            Label = label;
            ID = $"layer{++layerID}";
            Nodes = new List<RenderableNode>();
            Type = type;
        }

        internal RenderableNode Add(RenderableNode p)
        {
            Nodes.Add(p);
            return p;
        }

        private List<RenderableNode> Nodes { get; set; }

        public override XElement GetNode()
        {
            var g = new XElement(Svg.ns + "g",
                new XAttribute(Svg.ink + "groupmode", "layer"),
                new XAttribute("id", ID),
                new XAttribute(Svg.ink + "label", Label));

            foreach (var item in Nodes)
                g.Add(item.GetNode());

            return g;
        }
    }
}