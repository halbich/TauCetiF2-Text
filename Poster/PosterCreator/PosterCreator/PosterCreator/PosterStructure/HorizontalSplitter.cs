using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PosterCreator.Attributes;
using PosterCreator.BaseClasses;

namespace PosterCreator.PosterStructure
{
    internal class HorizontalSplitter : GraphicalElement
    {
        #region Private Fields

        private float[] requiredHeights;

        #endregion Private Fields

        #region Public Properties

        public GraphicalElement[] Child { get; private set; }

        #endregion Public Properties

        #region Public Methods

        public T[] AddChild<T>(T[] elem, params float[] requiredHeights) where T : GraphicalElement
        {
            if (Child != null)
                throw new InvalidOperationException();

            this.requiredHeights = requiredHeights.ToArray();
            Child = elem;
            return elem;
        }

        public override void AfterInit()
        {
            base.AfterInit();

            if (Child == null)
                return;

            var rh = requiredHeights.ToList();
            if (rh.Count < Child.Length)
            {
                var totalRequired = rh.Sum(e => e);
                var totalRem = Math.Max(Size.Y - Padding.Top - Padding.Bottom - totalRequired, 0);
                var rm = totalRem / (Child.Length - rh.Count);

                while (rh.Count != Child.Length)
                {
                    rh.Add(rm);
                    Debug.WriteLine("HS: " + rm);
                }
            }

            rh[rh.Count - 1] = Math.Max(rh[rh.Count - 1] - Padding.Bottom, 0);

            setChildProps(rh);

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

        #region Private Methods

        private void setChildProps(List<float> rh)
        {
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

                e.Location = newXY + e.Margin.LeftTop;
                e.Size = newSize + new V2D(0, -newSize.Y + rhi - Padding.Bottom);

                newXY = newXY + new V2D(0, rhi + e.Margin.Bottom);
                newSize = newSize + new V2D(0, -e.Margin.Bottom);
            }
        }

        #endregion Private Methods
    }
}