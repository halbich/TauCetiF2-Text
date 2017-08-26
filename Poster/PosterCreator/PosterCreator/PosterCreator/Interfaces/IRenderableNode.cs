using System.Xml.Linq;

namespace PosterCreator.Interfaces
{
    internal interface IRenderableNode
    {
        #region Public Methods

        XElement GetNode();

        #endregion Public Methods
    }
}