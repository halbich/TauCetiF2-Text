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

            ps.AddRange(getCrossFor(Location + new V2D(Size.X, 0)));

            ps.AddRange(getCrossFor(Location + new V2D(0, Size.Y)));

            ps.AddRange(getCrossFor(Location + new V2D(Size.X, Size.Y)));

            foreach (var item in ps)
                layer.Add(item);

            var bglayer = svg.GL(LayerType.Background);

            var p0 = new V2D(-10, -10);
            var p = new Path("background", p0, p0 + new V2D(727, 0), p0 + new V2D(727, 1020), p0 + new V2D(0, 1020));
            p.Closed = true;
            p.RenderParams.Fill = System.Drawing.Color.White;
            p.RenderParams.FillOpacity = 0.5f;
            bglayer.Add(p);
            base.Render(svg);
        }

        #endregion Public Methods

        #region Private Methods

        private static List<Path> getCrossFor(V2D point)
        {
            List<Path> res = new List<Path> {
                new Path("CrossLine", point + new V2D(-MarkerSize,0), point + new V2D(MarkerSize,0)),
                new Path("CrossLine", point + new V2D(0,-MarkerSize), point + new V2D(0,MarkerSize))
            };
            res[0].RenderParams.StrokeWidth = StrokeWidth;
            res[1].RenderParams.StrokeWidth = StrokeWidth;

            return res;
        }

        #endregion Private Methods
    }
}