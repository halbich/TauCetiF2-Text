using System;
using System.Globalization;
using PosterCreator.Attributes;
using PosterCreator.BaseClasses;
using PosterCreator.PosterStructure;

namespace PosterCreator
{
    internal enum SourceType
    {
        Top,
        Úvod
    }

    internal static class TextSource
    {
        #region Public Fields

        public static CultureInfo UsedCulture = new CultureInfo("en-US");

        #endregion Public Fields

        #region Internal Methods

        internal static GraphicalElement GetSourceFor(SourceType type)
        {
            switch (type)
            {
                case SourceType.Top:
                    {
                        var vs = new VerticalSplitter();

                        var schoolLogo = new ImageHolder("MffLogo") { IsSquare = true };
                        schoolLogo.SetPadding(new Offset(10));
                        var centerText = new HorizontalSplitter();

                        var c = centerText.AddChild(new[] { new Text(), new Text() }, 20, 50);

                        c[0].AppendText("TauCetiF2").SetBold();
                        c[1].AppendText("Udělal");

                        var tcfLogo = new ImageHolder("TCF2Logo");
                        tcfLogo.SetPadding(new Offset(10));
                        var unrealLogo = new ImageHolder("UELogo") { IsSquare = true };
                        unrealLogo.SetPadding(new Offset(10));

                        vs.AddChild(new GraphicalElement[] { schoolLogo, centerText, tcfLogo, unrealLogo }, 70, 367, 110, 70);

                        return vs;
                    }

                case SourceType.Úvod:
                    {
                        var ut = new Text();
                        ut.AppendText("Lorem ipsum");
                        return ut;
                    }

                default:
                    throw new NotImplementedException();
            }
        }

        #endregion Internal Methods
    }
}