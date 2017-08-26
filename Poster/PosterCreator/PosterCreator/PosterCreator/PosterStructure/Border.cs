using System.Collections.Generic;
using System.Drawing;
using PosterCreator.Attributes;
using PosterCreator.BaseClasses;
using PosterCreator.Elements;

namespace PosterCreator.PosterStructure
{
    internal class Border : GraphicalElementWithChild
    {
        #region Public Constructors

        public Border() : base()
        {
            Radius = 10;
            BorderSize = 5;
            Padding = new Offset(15);
        }

        #endregion Public Constructors

        #region Public Properties

        public float BorderSize { get; set; }
        public float Radius { get; set; }

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

            var innerBorderColors = new[]
            {
                Color.FromArgb(48,29,94),
                Color.FromArgb(67,21,132),
                Color.FromArgb(90,12,165),
                Color.FromArgb(143,69,221),
                Color.FromArgb(163,77,237),
                Color.FromArgb(143,69,221),
                Color.FromArgb(90,13,165),
                Color.FromArgb(67,21,132)
            };

            var _B = svg.GL(LayerType.Border);
            for (int i = 0; i < 8; i++)
            {
                var ni = (i + 1) % 8;
                var outer = new Path("BOut", new[] { borderPathPoints[i], borderPathPoints[ni], borderPathPointsi[ni], borderPathPointsi[i] });
                outer.Closed = true;

                outer.SetFillStroke(Color.FromArgb(119, 27, 197));

                var inner = new Path("BIn", new[] { borderPathPointsi[i], borderPathPointsi[ni], bppii[ni], bppii[i] });
                inner.Closed = true;

                inner.SetFillStroke(innerBorderColors[i]);

                _B.Add(outer);
                _B.Add(inner);
            }

            var back = new Path("BorderBack", borderPathPointsi.ToArray());
            back.Closed = true;

            back.Fill = Color.Black;
            back.FillOpacity = 0.8f;

            svg.GL(LayerType.BorderBackground).Add(back);

            if (Child != null)
                Child.Render(svg);
        }

        #endregion Public Methods
    }
}