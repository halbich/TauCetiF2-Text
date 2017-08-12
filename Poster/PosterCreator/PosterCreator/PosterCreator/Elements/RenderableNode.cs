using System.Xml.Linq;

namespace PosterCreator.Elements
{
    internal abstract class RenderableNode
    {
        public abstract XElement GetNode();
    }
}