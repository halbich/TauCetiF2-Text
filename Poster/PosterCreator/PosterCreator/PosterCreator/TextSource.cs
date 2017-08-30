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
        Úvod,
        AktStav,
        Cíle,
        Architektura,
        Obrázky,
        Závěr
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
                        tcfLogo.SetPadding(new Offset(20, 5));
                        var unrealLogo = new ImageHolder("UELogo") { IsSquare = true };
                        unrealLogo.SetPadding(new Offset(25, 5));

                        vs.AddChild(new GraphicalElement[] { schoolLogo, centerText, tcfLogo, unrealLogo }, 80, 457, 50, 30);

                        return vs;
                    }

                case SourceType.Úvod:
                    {
                        var ut = new Text();
                        ut.AppendText(
                            @"V době vzniku této práce jsou velice populární hry s otevřeným světem. Lákají
hráče na obsáhlost světa a možnost nelineárního řešení problémů a herních
úkolů. Her s otevřeným světem najdeme nepřeberné množství v různých herních
žánrech. My se zaměříme na podmnožinu her, které kromě otevřeného světa nabízí
také možnosti budování struktur a vyžadují od hráče netriviální styl hraní,
který mu umožňuje ve hře přežít. V herním průmyslu se tyto hry často označují
jako sandboxové, s budováním, s průzkumem prostředí, o přežití. Autor této práce
má tento typ her v oblibě a rád by touto prací představil svoji vizi dalšího možného
rozvoje her tohoto žánru. Cílem práce by měla být implementace nového
herního principu stavění, které současné herní tituly nenabízí."
                        );
                        ut.AppendText(
                            @"V práci se budeme zabývat několika různými hrami, které však mají několik
společných vlastností. Jedním ze základních konceptů je využívání herních
bloků. Dalším význačným prvkem je způsob integrace herních bloků do herního
prostředí. Některé hry jsou celé tvořeny bloky, jiné se snaží dosáhnout vyššího
stupně realismu ve hře a bloky využívají pouze pro konstrukci různých herních
objektů. Důležitým tématem této práce tedy bude rozbor systému bloků a práce
s nimi a popis hráčských problémů způsobených danými koncepty. V další části
práce pak navrhneme a implementujeme vlastní řešení.");
                        return ut;
                    }
                case SourceType.AktStav:
                    {
                        var ut = new Text();
                        ut.AppendText("Lorem ipsum");
                        ut.AppendText("stav");
                        return ut;
                    }
                case SourceType.Cíle:
                    {
                        var ut = new Text();
                        ut.AppendText("Lorem ipsum");
                        ut.AppendText("cile");
                        return ut;
                    }
                case SourceType.Architektura:
                    {
                        var ut = new Text();
                        ut.AppendText("Lorem ipsum");
                        ut.AppendText("arch");
                        return ut;
                    }
                case SourceType.Obrázky:
                    {
                        var ut = new Text();
                        ut.AppendText("Lorem ipsum");
                        ut.AppendText("obrazky");
                        return ut;
                    }
                case SourceType.Závěr:
                    {
                        var ut = new Text();
                        ut.AppendText("Lorem ipsum");
                        ut.AppendText("zaver");
                        return ut;
                    }

                default:
                    throw new NotImplementedException();
            }
        }

        #endregion Internal Methods
    }
}