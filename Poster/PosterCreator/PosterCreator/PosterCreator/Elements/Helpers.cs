using System.Drawing;

namespace PosterCreator.Elements
{
    public static class Helpers

    {
        public static string ToHex(this Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }
    }
}