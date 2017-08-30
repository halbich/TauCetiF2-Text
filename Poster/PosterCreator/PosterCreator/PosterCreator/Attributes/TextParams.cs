namespace PosterCreator.Attributes
{
    internal class TextParams
    {
        #region Public Constructors

        public TextParams()
        {
            FontStyle = "normal";
            FontWeight = "500";
            FontSize = 6;
            FontFamily = "Roboto";
            LineHeight = 150;
            Justify = true;
        }

        #endregion Public Constructors

        #region Public Properties

        public string FontFamily { get; set; }

        public int FontSize { get; set; }

        public string FontStyle { get; set; }

        public string FontWeight { get; private set; }

        public string TextAnchor { get; set; }

        public int LineHeight { get; set; }

        public bool Justify { get; set; }

        #endregion Public Properties

        #region Public Methods

        public void SetBold()
        {
            FontWeight = "bold";
        }

        public void SetH1()
        {
            FontSize = 20;
            SetBold();
            SetMiddle();
            LineHeight = 125;
            Justify = false;
        }

        public void SetH2()
        {
            FontSize = 12;
            SetBold();
            LineHeight = 125;
            Justify = false;
        }

        public void SetMiddle()
        {
            TextAnchor = "middle";
        }

        #endregion Public Methods

        #region Internal Methods

        internal string GetStyle()
        {
            var r = $"font-style:{FontStyle};font-weight:{FontWeight};font-size:{FontSize}px;line-height:{LineHeight}%;font-family:{FontFamily};";
            if (TextAnchor != null)
                r += $"text-anchor:{TextAnchor};";

            if (Justify)
                r += "text-align:justify;";

            return r;
        }

        #endregion Internal Methods
    }
}