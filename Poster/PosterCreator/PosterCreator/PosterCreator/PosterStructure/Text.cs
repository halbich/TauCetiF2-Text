using PosterCreator.BaseClasses;
using PosterCreator.Elements;

namespace PosterCreator.PosterStructure
{
    internal class Text : GraphicalElement
    {
        #region Public Properties

        public Rectangle Rectangle { get; set; }

        public FlowRoot Root { get; set; }

        #endregion Public Properties

        #region Public Methods

        public override void AfterInit()
        {
            base.AfterInit();
        }

        public override void Render(Svg svg)
        {
            var i = Location.X;
            var h = Size.X;
        }

        #endregion Public Methods
    }
}