using PosterCreator.Attributes;
using PosterCreator.Elements;

namespace PosterCreator.PosterStructure
{
    internal class MainStructure : GraphicalElementWithChild
    {
        #region Public Constructors

        public MainStructure()
        {
            Size = new V2D { X = 707, Y = 1000 };
        }

        public override void Render(Svg svg)
        {

            var img = new Image("BackgroundImage");
            img.Dimensions = new V2D(793.04443f, 1016);
            img.XY = new V2D(-2.8222258f, -4.7111111f);

            // TODO !
            //svg.GL(LayerType.Background).Add(img);

            base.Render(svg);
        }

        #endregion Public Constructors
    }
}