using PosterCreator.Attributes;
using System.Drawing;

namespace PosterCreator.Elements
{
    public static class Helpers

    {
        #region Public Methods

        public static string ToHex(this Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

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

        #endregion Public Methods
    }
}