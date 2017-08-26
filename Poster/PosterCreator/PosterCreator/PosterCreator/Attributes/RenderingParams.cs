using System.Drawing;
using System.Globalization;

namespace PosterCreator.Attributes
{
    internal class RenderingParams
    {
        #region Public Constructors

        public RenderingParams()
        {
            StrokeOpacity = 1;
            FillOpacity = 1;
            StrokeWidth = 1;
        }

        #endregion Public Constructors

        #region Public Properties

        public Color? Fill { get; set; }
        public float FillOpacity { get; set; }

        public Color? Stroke { get; set; }

        public float StrokeOpacity { get; set; }
        public float StrokeWidth { get; set; }

        #endregion Public Properties

        #region Public Methods

        public RenderingParams SetFillStroke(Color c)
        {
            Fill = c;
            Stroke = c;
            return this;
        }

        #endregion Public Methods

        #region Internal Methods

        internal virtual string GetStyle(CultureInfo cult)
        {
            return $"fill:{Fill.ToHex()};fill-opacity:{FillOpacity.ToString(cult)};stroke:{Stroke.ToHex()};stroke-width:{StrokeWidth.ToString(cult)};stroke-opacity:{StrokeOpacity.ToString(cult)}";
        }

        #endregion Internal Methods
    }
}