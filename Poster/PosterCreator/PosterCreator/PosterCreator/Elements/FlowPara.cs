using System.Xml.Linq;

namespace PosterCreator.Elements
{
    internal class FlowPara : IRenderableNode
    {
        #region Private Fields

        private static int flowParaID;

        #endregion Private Fields

        #region Public Constructors

        public FlowPara(string text)
        {
            ID = $"flowPara{++flowParaID}";
        }

        #endregion Public Constructors

        #region Public Properties

        public string ID { get; set; }

        public string Text { get; set; }

        #endregion Public Properties

        #region Public Methods

        public XElement GetNode()
        {
            var fp = new XElement(Svg.ns + "flowPara",
              new XAttribute("id", ID));

            fp.SetValue(Text);

            return fp;
        }

        #endregion Public Methods
    }
}