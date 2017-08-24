using PosterCreator.Attributes;
using System.Collections.Generic;

namespace PosterCreator.Elements
{
    public static class BHelpers
    {
        #region Internal Methods

        internal static List<V2D> MakeB(this Border b, List<V2D> bp, float coef = 1)
        {
            var BorderSize = b.BorderSize * coef;

            var bpi = new List<V2D> { bp[0].MoveXY(BorderSize, BorderSize), bp[1].MoveXY(-BorderSize, BorderSize), bp[2].MoveXY(-BorderSize, -BorderSize), bp[3].MoveXY(BorderSize, -BorderSize) };

            return bpi;
        }

        internal static List<V2D> MakeP(this Border b, List<V2D> bp, float coef = 1)
        {
            var Radius = b.Radius * coef;

            var borderPathPoints = new List<V2D> {
                bp[0].MoveY(Radius),
                bp[0].MoveX(Radius),
                bp[1].MoveX(-Radius),
                bp[1].MoveY(Radius),
                bp[2].MoveY(-Radius),
                bp[2].MoveX(-Radius),
                bp[3].MoveX(Radius),
                bp[3].MoveY(-Radius),
            };

            return borderPathPoints;
        }

        #endregion Internal Methods
    }

    internal class Border : GraphicalElement
    {
        #region Public Constructors

        public Border()
        {
            Radius = 10;
            BorderSize = 5;
        }

        #endregion Public Constructors

        #region Public Properties

        public float Radius { get; set; }

        public float BorderSize { get; set; }

        #endregion Public Properties

        #region Public Methods

        public override void Render(Svg svg)
        {
            var bp = new List<V2D> { Location, Location.MoveX(Size.X), Location.MoveXY(Size.X, Size.Y), Location.MoveY(Size.Y) };
            var bpi = this.MakeB(bp);
            var bpi1 = this.MakeB(bp, 2f);

            var borderPathPoints = this.MakeP(bp);

            var borderPathPointsi = this.MakeP(bpi, 0.9f);
            var bppii = this.MakeP(bpi1, 0.8f);

            var p = new Path("Border", borderPathPoints.ToArray());
            p.Closed = true;

            var p1 = new Path("Border", borderPathPointsi.ToArray());
            p1.Closed = true;

            var p2 = new Path("Border", bppii.ToArray());
            p2.Closed = true;

            var _B = svg.GL(LayerType.Border);
            _B.Add(p);
            _B.Add(p1);
            _B.Add(p2);
        }

        #endregion Public Methods
    }
}