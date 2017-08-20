using PosterCreator.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosterCreator.Elements
{
    class VerticalSplitter : GraphicalElement
    {
        public GraphicalElement[] Child { get; private set; }

        public T[] AddChild<T>(T[] elem, params float[] requiredHeights) where T : GraphicalElement
        {
            if (Child != null)
                throw new InvalidOperationException();

            var rh = requiredHeights.ToList();
            if (rh.Count < elem.Length)
            {
                var totalRequired = rh.Sum(e => e);
                var totalRem = Math.Max(Size.Y - Padding.Top - Padding.Bottom - totalRequired, 0);
                var rm = totalRem / (elem.Length - rh.Count);

                while (rh.Count != elem.Length)
                    rh.Add(rm);
            }


            rh[rh.Count - 1] = Math.Max(rh[rh.Count - 1] - Padding.Bottom, 0);

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

            for (int i = 0; i < elem.Length; i++)
            {
                var e = elem[i];
                var rhi = rh[i];

                e.Location = newXY.MoveXY(e.Margin.Left, e.Margin.Top);
                e.Size = newSize.MoveY(-newSize.Y + rhi- Padding.Bottom);

                newXY = newXY.MoveY(rhi + e.Margin.Bottom);
            }
            Child = elem;
            return elem;
        }

        public override void Render(Svg svg)
        {
            if (Child != null)
                foreach (var item in Child)
                    item.Render(svg);
        }
    }
}