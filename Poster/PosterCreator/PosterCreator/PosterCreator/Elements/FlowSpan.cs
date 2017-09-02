using System.Xml.Linq;
using PosterCreator.Attributes;
using PosterCreator.Interfaces;

namespace PosterCreator.Elements
{
    internal class FlowSpan : IRenderableNode
    {
        #region Private Fields

        private static int flowSpanID;

        #endregion Private Fields

        #region Public Constructors

        public FlowSpan()
        {
            ID = $"flowSpan{++flowSpanID}";
            Params = new TextParams();
        }

        #endregion Public Constructors

        #region Public Properties

        public string ID { get; private set; }
        public TextParams Params { get; set; }
        public string Text { get; set; }

        #endregion Public Properties

        #region Public Methods

        public XElement GetNode()
        {
            var fp = new XElement(Svg.ns + "flowSpan",
             new XAttribute("id", ID),
             new XAttribute("style", Params.GetStyle()));

            fp.SetValue(Text);
            return fp;
        }

        #endregion Public Methods
    }
}