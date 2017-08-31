using PosterCreator.Attributes;
using PosterCreator.BaseClasses;
using PosterCreator.Elements;
using System.Collections.Generic;

namespace PosterCreator.PosterStructure
{
    internal class Text : GraphicalElement
    {
        #region Public Constructors

        public Text()
        {
            Paragraphs = new List<string>();
            TextParams = new TextParams();
        }

        #endregion Public Constructors

        #region Public Properties

        public List<string> Paragraphs { get; set; }
        public Rectangle Rectangle { get; set; }

        public FlowRoot Root { get; set; }

        public TextParams TextParams { get; set; }

        #endregion Public Properties

        #region Public Methods

        public override void AfterInit()
        {
            base.AfterInit();
            Rectangle = new Rectangle(this);
            Root = new FlowRoot(Rectangle);
            Root.TextParams = TextParams;
        }

        public override void Render(Svg svg)
        {
            var t = svg.GL(LayerType.Text);
            t.Add(Rectangle);

            foreach (var item in Paragraphs)
                Root.Paragraphs.Add(new FlowPara(item));

            t.Add(Root);
        }

        #endregion Public Methods

        #region Internal Methods

        internal Text AppendText(string[] v)
        {
            foreach (var item in v)
            {
                AppendText(item);
            }

            return this;
        }

        internal virtual Text AppendText(string v)
        {
            Paragraphs.Add(v);
            return this;
        }

        #endregion Internal Methods
    }
}