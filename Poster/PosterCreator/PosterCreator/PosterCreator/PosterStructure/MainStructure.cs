using PosterCreator.Attributes;
using PosterCreator.BaseClasses;

namespace PosterCreator.PosterStructure
{
    internal class MainStructure : GraphicalElementWithChild
    {
        #region Public Constructors

        public MainStructure()
        {
            Size = new V2D { X = 707, Y = 1000 };
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Render(Svg svg)
        {
#if !DEBUG
            var img = new Elements.Image("BackgroundImage");
            img.Dimensions = new V2D(793.04443f, 1016);
            img.XY = new V2D(-2.8222258f, -4.7111111f);
            img.PreserveAspectRatio = default(bool?);

            svg.GL(Elements.LayerType.Background).Add(img);
#endif
            base.Render(svg);
        }

        #endregion Public Methods
    }
}