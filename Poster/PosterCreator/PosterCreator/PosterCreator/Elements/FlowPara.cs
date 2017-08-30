using System.Xml.Linq;
using PosterCreator.Interfaces;

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
            Text = text;
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

            var toReplace = new[] { "k", "s", "v", "z", "a" };

            var t = Text;

            foreach (var item in toReplace)
            {
                t = t.Replace($" {item} ", $" {item}\u00A0");
            }

            fp.SetValue(t);

            return fp;
        }

        #endregion Public Methods
    }
}