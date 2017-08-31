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
        Blueprint,
        Nástroje
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
                            @"  V současné době jsou velice populární hry s otevřeným světem. Lákají
hráče na obsáhlost světa a možnost nelineárního řešení problémů a herních
úkolů. Her s otevřeným světem najdeme nepřeberné množství v různých herních
žánrech. My jsme se zaměřili na podmnožinu her, které kromě otevřeného světa nabízí
také možnosti budování struktur a vyžadují od hráče netriviální styl hraní,
který mu umožňuje ve hře přežít. V herním průmyslu se tyto hry často označují
jako <sandboxové>, <s budováním>, <s průzkumem prostředí>, <o přežití>. V této práci pak představujeme naši vizi dalšího možného
rozvoje her tohoto žánru."
                        );
                        return ut;
                    }
                case SourceType.AktStav:
                    {
                        var ut = new Text();
                        ut.AppendText("    Provedli jsme obsáhlou rešerši a zjistili jsme, že součesné hry, jako třeba <Minecraft> nebo <Space Engineers>, mají společnou vlastnost - hráč může stavět pouze z bloků pevně dané velikosti. Zde vidíme prostor pro zlepšení. Dále jsme zjistili, že hráčům inventář vyžaduje manuální správu, což je s naší vizí neslučitelné.");
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
                        ut.AppendText("    • Interakce hráče s bloky");
                        ut.AppendText("    • Denní cyklus");
                        ut.AppendText("    • Proměnlivé počasí");
                        ut.AppendText("    • Efektivní datové struktury pro bloky a herní svět");
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
                        ut.AppendText(
                            @"    V naší práci jsme využili obou způsobů vývoje počítačových her, které nám <Unreal Engine> nabízí. To jest možnosti implementace hry klasickým způsobem, tedy v jazyce <C++>, a dále pak možnosti implementace pomocí <Blueprintů>, což je vizuální editor kódu pro <Unreal Engine>. Využili jsme výhod obou přístupů a jejich vhodnou kombinací jsme dosáhli rychlého a efektivního vývoje celé hry.");

                        ut.AppendText("    Podařilo se nám dosáhnout plné spolupráce mezi kódem v <C++> a v <Blueprintu>. Jeden způsob byl triviální - <Blueprinty> mohou dědit z <C++> tříd a tudíž mohou volat metody svých předků. Z opačné strany jsme zvolili použití událostí, které byly vyvolávány ze strany <C++> kódu a jejichž obsluha byla definovaná v <Blueprintovém> kódu. Tímto způsobem jsme dosáhli oboustranné komunikace mezi všemi součástmi hry.");

                        ut.AppendText("    Dále jsme využili komponentový přístup. Kupříkladu implementací <kyslíkové> či <elektrické> komponenty jsme mohli tyto komponenty přiřadit jak k blokům, tak třeba k hráčově postavě. Tímto způsobem jsme se vyhnuli duplicitnímu kódu a mohli jsme s těmito mechanikami pracovat standardizovaným způsobem.");

                        ut.AppendText("    Dále byl ve hře systém bloků implementován takovým způsobem, že je možné rozšiřovat dostupné bloky pomocí <DLC>, tedy stahovatelného obsahu. Hra tedy nabízí alespoň základní možnosti uživatelkého rozšiřování.");
                        return ut;
                    }
                case SourceType.Kod:
                    {
                        var hz = new HorizontalSplitter();
                        var ut = new Text();
                        ut.AppendText("    Vzhledem k rychlosti, kterou <C++> nabízí, byly tímto způsobem naprogramovány všechny kritické části a komponenty hry. Definovali jsme zde například všechny vlastnosti (omezující konstanty), jejichž konkrétní hodnoty jsme následně mohli měnit v Editoru skrze <Blueprinty>.");
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
                        ut.AppendText("    Hlavním cílem <Blueprintů> bylo prototypování funkcionality (většina z těchto prototypů byla následně implementována do <C++>) a rychlá implementace nekritických částí hry. Dále bylo <Blueprintů> využito jako nástroje, ve kterém byly definovány omezující konstanty, jako například minimální a maximální velikosti bloků, vlastnosti bloků, cena stavby apod. Díky tomu, že jsme tyto konstanty definovali na této úrovni, mohli jsme snadno balancovat jednotlivé parametry bez nutnosti zdlouhavého procesu opětovné kompilace celého projektu. ");
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
                        ut.AppendText("    Úspěšně se nám podařilo splnit všechny vytyčené cíle. Navrhli jsme a následně implementovali všechny námi požadované herní mechaniky, včetně doplňujících (lokalizace, hudba).");
                        ut.AppendText("    Tyto mechaniky jsme nechali posoudit veřejností v rámci připraveného dotazníku. Z jeho zhodnocení vyplývá, že myšlenka dynamicky škálovatelných bloků má svůj potenciál a případná dokončená hra by si našla své publikum. Zároveň jsme však díky dotazníku identifikovali problémy, které jsme mohli před dokončením naší práce vyřešit a tím jsme výrazně zlepšili celkovou kvalitu naší hry.");
                        return ut;
                    }
                case SourceType.Nástroje:
                    {
                        var ut = new Text();
                        ut.AppendText("    Hlavním nástrojem, který jsme při našem vývoji použili, byl <Unreal Engine>. Díky této volbě jsme se nemuseli navíc zbývat vlastní implementací herního enginu a nemuseli jsme řešit tvorbu standardních mechanik a nástrojů, které jsme v naší práci využili (například nástroj pro tvorbu <stromů chování> pro implementaci umělé inteligence.");
                        ut.AppendText("    Dalším nástrojem, který jsme využili, byl 3D modelovací nástroj Cinema4D, kde jsme využili možnosti tvorby 3D modelů, které jsme následně importovali do <Unreal Enginu>. V souvislosti s grafikou jsme také využili grafického nástroje Gimp.");
                        return ut;
                    }
                default:
                    throw new NotImplementedException();
            }
        }

        #endregion Internal Methods
    }
}