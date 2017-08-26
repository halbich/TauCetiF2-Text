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
                        schoolLogo.SetPadding(new Offset(10, 5));
                        var centerText = new HorizontalSplitter();

                        var c = centerText.AddChild(new[] { new Text(), new Text() }, 55, 15);

                        c[0].AppendText("TauCetiF2 – budovatelská počítačová hra se strategickými prvky").TextParams.SetH1();
                        var p = c[1].AppendText("autor: Pavel Halbich | vedoucí: Mgr. Pavel Ježek, Ph.D. | 2017").TextParams;
                        p.SetH2();
                        p.FontSize = 8;
                        p.SetMiddle();

                        var tcfLogo = new ImageHolder("TCF2Logo");
                        tcfLogo.SetPadding(new Offset(10,5));
                        var unrealLogo = new ImageHolder("UELogo") { IsSquare = true };
                        unrealLogo.SetPadding(new Offset(25, 10, 25, 0));

                        vs.AddChild(new GraphicalElement[] { schoolLogo, centerText, tcfLogo, unrealLogo }, 60, 457, 75, 30);

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