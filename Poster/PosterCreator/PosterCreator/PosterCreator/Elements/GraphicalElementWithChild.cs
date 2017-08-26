using System;
using PosterCreator.Attributes;

namespace PosterCreator.Elements
{
    internal class GraphicalElementWithChild : GraphicalElement
    {
        #region Public Properties

        public GraphicalElement Child { get; private set; }

        #endregion Public Properties

        #region Public Methods

        public T AddChild<T>(T elem) where T : GraphicalElement
        {
            if (Child != null)
                throw new InvalidOperationException();

            var myXY = Location;
            var mySize = Size;

            var newXY = new V2D
            {
                X = myXY.X + Padding.Left + elem.Margin.Left,
                Y = myXY.Y + Padding.Top + elem.Margin.Top
            };
            var newSize = new V2D
            {
                X = mySize.X - Padding.Left - Padding.Right - elem.Margin.Left - elem.Margin.Right,
                Y = mySize.Y - Padding.Top - Padding.Bottom - elem.Margin.Top - elem.Margin.Bottom
            };

            elem.Location = newXY;
            elem.Size = newSize;
            Child = elem;

            return elem;
        }

        public override void Render(Svg svg)
        {
            if (Child != null)
                Child.Render(svg);
        }

        #endregion Public Methods
    }
}