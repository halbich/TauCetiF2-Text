using System.Xml.Linq;

namespace PosterCreator.Elements
{
    internal interface IRenderableNode
    {
        #region Public Methods

        XElement GetNode();

        #endregion Public Methods
    }
}