using PosterCreator.Attributes;

namespace PosterCreator.BaseClasses
{
    internal abstract class GraphicalElement
    {
        #region Public Properties

        public V2D Location { get; set; }
        public Offset Margin { get; set; }
        public Offset Padding { get; set; }
        public V2D Size { get; set; }

        #endregion Public Properties

        #region Public Methods

        public virtual void AfterInit()
        { }

        public abstract void Render(Svg svg);

        #endregion Public Methods
    }
}