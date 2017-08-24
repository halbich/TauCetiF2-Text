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

        #endregion Public Methods
    }
}