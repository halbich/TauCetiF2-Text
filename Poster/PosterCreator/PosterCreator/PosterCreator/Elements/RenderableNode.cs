using System.Xml.Linq;

namespace PosterCreator.Elements
{
    internal abstract class RenderableNode
    {
        #region Public Methods

        public abstract XElement GetNode();

        #endregion Public Methods
    }
}