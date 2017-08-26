using System;
using System.Xml.Linq;

namespace PosterCreator.Elements
{
    internal class Text : GraphicalElement, IRenderableNode
    {
        #region Private Fields

        private static int flowRegID;

        #endregion Private Fields

        #region Public Methods

        public XElement GetNode()
        {
            throw new NotImplementedException();
        }

        public override void Render(Svg svg)
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}