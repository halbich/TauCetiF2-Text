using System;
using PosterCreator.Attributes;

namespace PosterCreator.BaseClasses
{
    internal abstract class GraphicalElementWithChild : GraphicalElement
    {
        #region Public Properties

        public GraphicalElement Child { get; private set; }

        #endregion Public Properties

        #region Public Methods

        public T AddChild<T>(T elem) where T : GraphicalElement
        {
            if (Child != null)
                throw new InvalidOperationException();

            Child = elem;
            return elem;
        }

        public override void AfterInit()
        {
            base.AfterInit();

            if (Child == null)
                return;

            var myXY = Location;
            var mySize = Size;

            var newXY = new V2D
            {
                X = myXY.X + Padding.Left + Child.Margin.Left,
                Y = myXY.Y + Padding.Top + Child.Margin.Top
            };
            var newSize = new V2D
            {
                X = mySize.X - Padding.Left - Padding.Right - Child.Margin.Left - Child.Margin.Right,
                Y = mySize.Y - Padding.Top - Padding.Bottom - Child.Margin.Top - Child.Margin.Bottom
            };

            Child.Location = newXY;
            Child.Size = newSize;

            Child.AfterInit();
        }

        public override void Render(Svg svg)
        {
            if (Child != null)
                Child.Render(svg);
        }

        #endregion Public Methods
    }
}