using System.Collections.Generic;
using System.Drawing;
using PosterCreator.Attributes;
using PosterCreator.BaseClasses;
using PosterCreator.PosterStructure;

namespace PosterCreator
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

    public static class Helpers

    {
        #region Public Methods

        public static string ToHex(this Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        public static string ToHex(this Color? c)
        {
            return c.HasValue ? c.Value.ToHex() : "none";
        }

        #endregion Public Methods

        #region Internal Methods

        internal static T SetMargin<T>(this T elem, Offset margin) where T : GraphicalElement
        {
            elem.Margin = margin;
            return elem;
        }

        internal static T SetPadding<T>(this T elem, Offset padding) where T : GraphicalElement
        {
            elem.Padding = padding;
            return elem;
        }

        #endregion Internal Methods
    }
}