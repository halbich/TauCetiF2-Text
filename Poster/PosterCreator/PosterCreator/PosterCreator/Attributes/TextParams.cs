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
        }

        #endregion Public Constructors

        #region Public Properties

        public string FontFamily { get; set; }

        public int FontSize { get; set; }

        public string FontStyle { get; set; }

        public string FontWeight { get; private set; }

        public string TextAnchor { get; set; }

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
        }

        public void SetH2()
        {
            FontSize = 12;
            SetBold();
        }

        public void SetMiddle()
        {
            TextAnchor = "middle";
        }

        #endregion Public Methods

        #region Internal Methods

        internal string GetStyle()
        {
            var r = $"font-style:{FontStyle};font-weight:{FontWeight};font-size:{FontSize}px;line-height:125%;font-family:{FontFamily};";
            if (TextAnchor != null)
                r += $"text-anchor:{TextAnchor};";

            return r;
        }

        #endregion Internal Methods
    }
}