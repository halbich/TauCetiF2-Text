using System.Collections.Generic;
using PosterCreator.Attributes;
using PosterCreator.BaseClasses;
using PosterCreator.Elements;

namespace PosterCreator.PosterStructure
{
    internal class PrintMarker : GraphicalElementWithChild
    {
        #region Private Fields

        private const float MarkerSize = 7;

        private const float StrokeWidth = 0.2f;

        #endregion Private Fields

        #region Public Constructors

        public PrintMarker()
        {
            Margin = new Offset(10);
            Padding = new Offset(10);
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Render(Svg svg)
        {
            var layer = svg.GL(LayerType.Other);

            var ps = new List<Path>();

            ps.AddRange(getCrossFor(Location));

            ps.AddRange(getCrossFor(Location.MoveX(Size.X)));

            ps.AddRange(getCrossFor(Location.MoveY(Size.Y)));

            ps.AddRange(getCrossFor(Location.MoveXY(Size.X, Size.Y)));

            foreach (var item in ps)
                layer.Add(item);

            base.Render(svg);
        }

        #endregion Public Methods

        #region Private Methods

        private static List<Path> getCrossFor(V2D point)
        {
            List<Path> res = new List<Path> {
                new Path("CrossLine", point.MoveX(-MarkerSize), point.MoveX(MarkerSize)) { StrokeWidth = StrokeWidth},
                new Path("CrossLine", point.MoveY(-MarkerSize), point.MoveY(MarkerSize)) { StrokeWidth = StrokeWidth}
            };

            return res;
        }

        #endregion Private Methods
    }
}