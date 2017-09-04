using System.Diagnostics;
using System.Text;
using System.Xml.Linq;
using PosterCreator.Attributes;
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

            t = t.Replace("~", "\u00A0");

            var i = 0;
            //t = t.Replace("<", "<svg:flowSpan id=\"flowSpan" + (i++) + "\" style=\"font-weight:bold\">").Replace(">", "</svg:flowSpan>");

            FlowSpan currentItalic = null;
            FlowSpan currentBold = null;
            FlowSpan currentWhitespace = null;

            var sb = new StringBuilder();
            foreach (var item in t)
            {
                switch (item)
                {
                    case '<':
                        {
                            Debug.Assert(currentItalic == null);
                            if (sb.Length > 0)
                            {
                                fp.Add(sb.ToString());
                                sb.Clear();
                            }

                            currentItalic = new FlowSpan();
                            currentItalic.Params.SetItalic();
                            break;
                        }
                    case '>':
                        {
                            Debug.Assert(currentItalic != null);
                            currentItalic.Text = sb.ToString();
                            sb.Clear();
                            fp.Add(currentItalic.GetNode());
                            currentItalic = null;
                            break;
                        }

                    case '[':
                        {
                            Debug.Assert(currentBold == null);
                            if (sb.Length > 0)
                            {
                                fp.Add(sb.ToString());
                                sb.Clear();
                            }

                            currentBold = new FlowSpan();
                            currentBold.Params.SetBold();
                            break;
                        }
                    case ']':
                        {
                            Debug.Assert(currentBold != null);
                            currentBold.Text = sb.ToString();
                            sb.Clear();
                            fp.Add(currentBold.GetNode());
                            currentBold = null;
                            break;
                        }

                    case ';':
                        {
                            Debug.Assert(currentWhitespace == null);
                            if (sb.Length > 0)
                            {
                                fp.Add(sb.ToString());
                                sb.Clear();
                            }

                            currentWhitespace = new FlowSpan();
                            currentWhitespace.Params = new WhiteSpaceParams();
                            break;
                        }
                    case '@':
                        {
                            Debug.Assert(currentWhitespace != null);
                            currentWhitespace.Text = "----";
                            sb.Clear();
                            fp.Add(currentWhitespace.GetNode());
                            currentWhitespace = null;
                            break;
                        }

                    default:
                        sb.Append(item);
                        break;
                }
            }

            fp.Add(sb.ToString());

            return fp;
        }

        #endregion Public Methods
    }
}