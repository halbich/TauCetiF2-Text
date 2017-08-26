using System;
using System.Linq;
using PosterCreator.Attributes;
using PosterCreator.BaseClasses;

namespace PosterCreator.PosterStructure
{
    internal class VerticalSplitter : GraphicalElement
    {
        #region Private Fields

        private float[] requiredWidths;

        #endregion Private Fields

        #region Public Properties

        public GraphicalElement[] Child { get; private set; }

        #endregion Public Properties

        #region Public Methods

        public T[] AddChild<T>(T[] elem, params float[] RequiredWidths) where T : GraphicalElement
        {
            if (Child != null)
                throw new InvalidOperationException();

            requiredWidths = RequiredWidths.ToArray();
            Child = elem;
            return elem;
        }

        public override void AfterInit()
        {
            var rh = requiredWidths.ToList();
            if (rh.Count < Child.Length)
            {
                var totalRequired = rh.Sum(e => e);
                var totalRem = Math.Max(Size.X - Padding.Left - Padding.Right - totalRequired, 0);
                var rm = (int)(totalRem / (Child.Length - rh.Count));

                while (rh.Count != Child.Length)
                    rh.Add(rm);
            }

            rh[rh.Count - 1] = Math.Max(rh[rh.Count - 1] - Padding.Right, 0);

            var myXY = Location;
            var mySize = Size;

            var newXY = new V2D
            {
                X = myXY.X + Padding.Left,
                Y = myXY.Y + Padding.Top
            };
            var newSize = new V2D
            {
                X = mySize.X - Padding.Left - Padding.Right,
                Y = mySize.Y - Padding.Top - Padding.Bottom
            };

            for (int i = 0; i < Child.Length; i++)
            {
                var e = Child[i];
                var rhi = rh[i];

                e.Location = newXY.MoveXY(e.Margin.Left, e.Margin.Top);
                e.Size = newSize.MoveX(-newSize.X + rhi - Padding.Right);

                newXY = newXY.MoveX(rhi + e.Margin.Right);
                newSize = newSize.MoveX(-e.Margin.Right);
            }

            foreach (var item in Child)
                item.AfterInit();
        }

        public override void Render(Svg svg)
        {
            if (Child != null)
                foreach (var item in Child)
                    item.Render(svg);
        }

        #endregion Public Methods
    }
}