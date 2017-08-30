using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PosterCreator.Attributes;
using PosterCreator.Interfaces;
using PosterCreator.PosterStructure;

namespace PosterCreator.Elements
{
    internal class FlowSpan : IRenderableNode
    {

        private static int flowSpanID;

        public TextParams Params { get; set; }

        public FlowSpan()
        {
            ID = $"flowSpan{++flowSpanID}";
            Params = new TextParams();
        }

        public string ID { get; private set; }

        public string Text { get; set; }

        public XElement GetNode()
        {
            var fp = new XElement(Svg.ns + "flowSpan",
             new XAttribute("id", ID),
             new XAttribute("style", Params.GetStyle()));

            fp.SetValue(Text);
            return fp;
        }
    }
}
