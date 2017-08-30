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
        Závěr,
        Kod,
        Blueprint
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
                        unrealLogo.SetPadding(new Offset(20, 5));

                        vs.AddChild(new GraphicalElement[] { schoolLogo, centerText, tcfLogo, unrealLogo }, 80, 447, 50, 30);

                        return vs;
                    }

                case SourceType.Úvod:
                    {
                        var ut = new Text();
                        ut.AppendText(
                            @"  V době vzniku této práce jsou velice populární hry s otevřeným světem. Lákají
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
                            @"    V práci se budeme zabývat několika různými hrami, které však mají několik
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
                        ut.AppendText("  V rámci práce jsme identifikovali následující cíle práce:");
                        ut.AppendText("  1.Bloky a herní svět");
                        ut.AppendText("    • Způsob řešení proměnlivé velikosti bloků");
                        ut.AppendText("    • Umístění bloků v herním světě");
                        ut.AppendText("    • Skládání bloků do struktur");
                        ut.AppendText("    • Komunikace bloků");
                        ut.AppendText("    • Interakce s bloky");
                        ut.AppendText("    • Denní cyklus");
                        ut.AppendText("    • Proměnlivé počasí");
                        ut.AppendText("    • Použitelné datové struktury vzhledem k ostatním částem hry");
                        ut.AppendText("  2.Inventář");
                        ut.AppendText("    • Automatizovaná správa inventáře");
                        ut.AppendText("    • Stavitelné a umístitelné bloky");
                        ut.AppendText("  3.Herní postava");
                        ut.AppendText("    • Inventář herní postavy");
                        ut.AppendText("    • Vlastnosti postavy jako např. zdraví");
                        ut.AppendText("  4.Ostatní herní prvky");
                        ut.AppendText("    • Systém ukládání a načítání hry");
                        ut.AppendText("    • Kreativní herní mód");
                        ut.AppendText("    • Herní tutorial");
                        ut.AppendText("  5.Případné prvky navíc, které se ve hrách běžně vyskytují");
                        ut.AppendText("    • Lokalizace hry do různých jazyků");
                        ut.AppendText("    • Hudba ve hře");
                        ut.AppendText("  6.Zhodnocení práce");
                        ut.AppendText("    • Získat a zhodnotit zpětnou vazbu (dotazník)");

                        return ut;
                    }
                case SourceType.Architektura:
                    {
                        var ut = new Text();
                        ut.AppendText("Lorem ipsum");
                        ut.AppendText("arch");
                        return ut;
                    }
                case SourceType.Kod:
                    {
                        var hz = new HorizontalSplitter();
                        var ut = new Text();
                        ut.AppendText("Lorem ipsum");
                        ut.AppendText("arch");

                        var ut1 = new OrderedText();
                        ut1.AppendText("dolor sit");
                        ut1.AppendText("samet");

                        hz.AddChild(new GraphicalElement[] { ut, ut1 });
                        return hz;
                    }
                case SourceType.Blueprint:
                    {
                        var hz = new HorizontalSplitter();
                        var ut = new Text();
                        ut.AppendText("Lorem ipsum");
                        ut.AppendText("bp");

                        var ut1 = new ItemizeText();
                        ut1.AppendText("dolor sit");
                        ut1.AppendText("samet");

                        hz.AddChild(new GraphicalElement[] { ut, ut1 });
                        return hz;
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