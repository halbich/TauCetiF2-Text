using System;
using System.Drawing;
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
        Cíle,
        Architektura,
        Obrázky,
        Závěr,
        Kod,
        Blueprint,
        Dotaznik
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
                        var vsTop = new VerticalSplitter();

                        var vsLogo = new VerticalSplitter().SetPadding(new Offset(10, 5));
                        var schoolLogo = new ImageHolder("MffLogo") { IsSquare = true };
                        vsLogo.AddChild(new[] { schoolLogo }, 90);

                        var centerText = new HorizontalSplitter();

                        var c = centerText.AddChild(new[] { new Text(), new Text() }, 55, 15);

                        c[0].AppendText("TauCetiF2 – budovatelská počítačová hra se strategickými prvky").TextParams.SetH1();
                        var p = c[1].AppendText("autor: Pavel Halbich | vedoucí: Mgr. Pavel Ježek, Ph.D. | 2017").TextParams;
                        p.SetH2();
                        p.FontSize = 8;
                        p.SetMiddle();

                        var vsLogos = new VerticalSplitter().SetPadding(new Offset(10, 5));
                        var tcfLogo = new ImageHolder("TCF2Logo").SetPadding(new Offset(0, 0));
                        var unrealLogo = (new ImageHolder("UELogo") { IsSquare = true }).SetPadding(new Offset(15, 0));
                        vsLogos.AddChild(new[] { tcfLogo, unrealLogo }, 70, 30);

                        vsTop.AddChild(new GraphicalElement[] { vsLogo, centerText, vsLogos }, 100, 427, 100);

                        return vsTop;
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
                        ut.AppendText("    Provedli jsme obsáhlou rešerši a zjistili jsme, že současné hry, jako třeba <Minecraft> nebo <Space Engineers>, mají společnou vlastnost — hráč může stavět pouze z bloků pevně dané velikosti. Zde vidíme prostor pro zlepšení. Dále jsme zjistili, že hráčův inventář vyžaduje manuální správu, což je s naší vizí neslučitelné.");
                        return ut;
                    }
                case SourceType.Cíle:
                    {
                        var ut = new Text();
                        ut.AppendText("    Práci můžeme rozdělit na tři zásadní cíle:");
                        ut.AppendText("  1.Návrh nových herních mechanik");
                        ut.AppendText("    • Systém dynamicky škálovatelných bloků");
                        ut.AppendText("    • Automatizovaná správa inventáře");
                        ut.AppendText("    • Koncepce tvorby škálovatelných bloků");
                        ut.AppendText("    • Herní mechaniky využívající škálovatelných bloků");
                        ut.AppendText("  2.Implementace navržených mechanik do nové hry");
                        ut.AppendText("    • Volba vhodného herního enginu");
                        ut.AppendText("    • Návrh a implementace vhodných datových struktur");
                        ut.AppendText("    • Implementace všech nutných herních mechanismů a součástí");
                        ut.AppendText("  3.Zhodnocení navržených mechanik a jejich implementace");
                        ut.AppendText("    • Připravit a vyhodnotit dotazník");

                        return ut;
                    }
                case SourceType.Architektura:
                    {
                        var hz = new HorizontalSplitter();
                        var ut = new Text();
                        ut.AppendText(new[]
                        {
                            "    V naší práci jsme využili obou způsobů vývoje počítačových her, které nám <Unreal Engine> nabízí. To jest možnosti implementace hry klasickým způsobem, tedy v jazyce <C++>, a dále pak možnosti implementace pomocí <Blueprintů>, což je vizuální editor kódu pro <Unreal Engine>. Využili jsme výhod obou přístupů a jejich vhodnou kombinací jsme dosáhli rychlého a efektivního vývoje celé hry.",

                            "    Na obrázku níže je možné vidět celkovou koncepci architektury hry. Vybrali jsme nejvýznamější části hry a do grafu jsme zaznamenali jejich vazby na ostatní významné části.",

                            //"    Dále jsme využili komponentový přístup. Kupříkladu implementací <kyslíkové> či <elektrické> komponenty jsme mohli tyto komponenty přiřadit jak k blokům, tak třeba k hráčově postavě. Tímto způsobem jsme se vyhnuli duplicitnímu kódu a mohli jsme s těmito mechanikami pracovat standardizovaným způsobem.",

                            //"    Dále byl ve hře systém bloků implementován takovým způsobem, že je možné rozšiřovat dostupné bloky pomocí <DLC>, tedy stahovatelného obsahu. Hra tedy nabízí alespoň základní možnosti uživatelkého rozšiřování.",
                            //"    Během práce na TCF2 jsme se maximálně snažili využít možností, které nám <Unreal Engine> nabízí. Proto jsme byli kupříkladu schopni poměrně rychle implementovat logiku, která ovládá systém počasí. Ten byl implementován pomocí rozhodovacího stromu, k čemuž jsme využili již existující nástroje, kterými <Unreal Engine> disponuje.",
                        });

                        var canvas = new Canvas();

                        var saveColor = Color.LightGray;
                        var defColor = Color.FromArgb(68, 101, 255);

                        var blocks = canvas.Add("Bloky", -70, -10, 25);
                        blocks.SetBackground(saveColor);

                        var blocksDef = canvas.Add("Definice bloků", -140, -70, 52);
                        blocksDef.SetBackground(defColor);

                        var vizualReprezBlocks = canvas.Add("Vizuální reprezentace\nškálovatelných bloků", -70, -70, 73, 22);
                        var worldReprez = canvas.Add("Reprezentace\nsvěta a bloků", 0, -10, 50, 22);
                        worldReprez.SetBackground(saveColor);

                        var aiWeather = canvas.Add("AI počasí", 0, -70, 36);
                        var logicWeather = canvas.Add("Logika počasí", 60, -30, 49);
                        logicWeather.SetBackground(saveColor);
                        var defWeather = canvas.Add("Definice počasí", 50, -70, 54);
                        defWeather.SetBackground(defColor);

                        var dayNight = canvas.Add("Denní / noční\ncyklus", 110, -70, 50, 22);
                        dayNight.SetBackground(saveColor);

                        var ctorObj = canvas.Add("Konstruktor objektů", 80, -10, 70);
                        var UI = canvas.Add("UI", 160, -70, 15);

                        var elComp = canvas.Add("Elektrická\nkomponenta", 40, 30, 47, 22);
                        elComp.SetBackground(saveColor);
                        var elNet = canvas.Add("Elektrická síť", 110, 30, 47);
                        var o2Comp = canvas.Add("Kyslíková\nkomponenta", -30, 30, 47, 22);
                        o2Comp.SetBackground(saveColor);

                        var character = canvas.Add("Hráčova\npostava", -10, 80, 33, 22);
                        character.SetBackground(saveColor);
                        var inventory = canvas.Add("Inventář", 160, 80, 34);
                        inventory.SetBackground(saveColor);
                        var blockLoadSys = canvas.Add("Systém načítání bloků", -140, -10, 75);
                        var interWorld = canvas.Add("Interakce se světem", -70, 80, 70);


                        canvas.AddR(blocks, blocksDef);
                        canvas.AddR(blocksDef, vizualReprezBlocks);
                        canvas.AddR(blockLoadSys, blocksDef);
                        canvas.AddR(blocks, worldReprez);

                        canvas.AddR(worldReprez, aiWeather);
                        canvas.AddR(worldReprez, elNet);
                        canvas.AddR(blocks, interWorld);

                        canvas.AddR(logicWeather, defWeather);
                        canvas.AddR(logicWeather, aiWeather);
                        canvas.AddR(logicWeather, dayNight);


                        canvas.AddR(UI, inventory);
                        canvas.AddR(UI, elNet);
                        canvas.AddR(UI, ctorObj);

                        canvas.AddR(ctorObj, worldReprez);

                        canvas.AddR(character, inventory);
                        canvas.AddR(character, interWorld);
                        canvas.AddR(character, elComp);
                        canvas.AddR(character, o2Comp);

                        canvas.AddR(blocks, o2Comp);
                        canvas.AddR(blocks, elComp);

                        canvas.AddR(elNet, elComp);


                        canvas.AddA("Editor (Blueprinty)", 0, -75, 365, 40);

                        canvas.AddA("C++", 0, 22.5f, 365, 145);

                        var l = canvas.AddA("Legenda", -145f, 57.5f, 70, 70);
                        l.OverrideOpacity = 1;
                        var c0 = 245;
                        l.SetBackground(Color.FromArgb(c0, c0, c0));

                        var legendSec = canvas.Add("Významná část", -145, 45, 60);
                        var legendDef = canvas.Add("Definice", -145, 62.5f, 60);
                        legendDef.SetBackground(defColor);
                        var legendSave = canvas.Add("Ukládání", -145, 80, 60);
                        legendSave.SetBackground(saveColor);

                        hz.AddChild(new GraphicalElement[] { ut, canvas }, 55, 217);

                        return hz;
                    }
                case SourceType.Kod:
                    {
                        var ut = new Text();
                        ut.AppendText("    Vzhledem k rychlosti, kterou <C++> nabízí, byly tímto způsobem naprogramovány všechny kritické části a komponenty hry. Definovali jsme zde například všechny vlastnosti (omezující konstanty), jejichž konkrétní hodnoty jsme následně mohli měnit v Editoru skrze <Blueprinty>.");

                        return ut;
                    }
                case SourceType.Blueprint:
                    {
                        var ut = new Text();
                        ut.AppendText("    Pomocí <Blueprintů> byly rychle implementovány nekritické části hry. Dále bylo <Blueprintů> využito jako nástroje, ve kterém byly definovány hodnoty omezujících konstant, jako například minimální a maximální velikosti bloků, vlastnosti bloků, cena stavby apod. Díky tomu, že jsme tyto konstanty definovali na této úrovni, mohli jsme snadno balancovat jednotlivé parametry bez nutnosti zdlouhavého procesu opětovné kompilace celého projektu. ");

                        return ut;
                    }
                case SourceType.Obrázky:
                    {
                        var vs = new VerticalSplitter().SetMargin(new Offset(5,0,0,0));

                        var hzl = new HorizontalSplitter();

                        var iml0 = new ImageWithTitle("Počáteční budova (lehká obtížnost)", "ImgL0");
                        var iml1 = new ImageWithTitle("Akumulátory, plnička kyslíku a kyslíkové bomby", "ImgL1");
                        var iml2 = new ImageWithTitle("Nápadité využití herních bloků", "ImgL2");

                        hzl.AddChild(new[] { iml0, iml1, iml2 });

                        var hzr = new HorizontalSplitter();

                        var imr0 = new ImageWithTitle("Noční pohled na budovy lehké a střední obtížnosti", "ImgR0");
                        var imr1 = new ImageWithTitle("Hráč může ve hře modelovat i každodenní předměty", "ImgR1");
                        var imr2 = new ImageWithTitle("Různé varianty konstruktoru objektů", "ImgR2");

                        hzr.AddChild(new[] { imr0, imr1, imr2 });

                        vs.AddChild(new[] { hzl, hzr });

                        return vs;
                    }
                case SourceType.Závěr:
                    {
                        var ut = new Text();
                        ut.AppendText("    Úspěšně se nám podařilo splnit všechny vytyčené cíle. Navrhli jsme a následně implementovali všechny námi požadované herní mechaniky, včetně doplňujících (lokalizace, hudba).");
                        ut.AppendText("    Tyto mechaniky jsme nechali posoudit veřejností v rámci připraveného dotazníku. Z jeho zhodnocení vyplývá, že myšlenka dynamicky škálovatelných bloků má svůj potenciál a případná dokončená hra by si našla své publikum. Zároveň jsme však díky dotazníku identifikovali problémy, které jsme mohli před dokončením naší práce vyřešit a tím jsme výrazně zlepšili celkovou kvalitu naší hry.");
                        return ut;
                    }
                case SourceType.Dotaznik:
                    {
                        var hz = new HorizontalSplitter();
                        var ut = new Text();
                        ut.AppendText("    Po dokončení implementace všech herních mechanik jsme připravili dotazník pro širokou veřejnost. Ačkoliv jsme získali pouze 24~odpovědí, díky průběžnému vyhodnocování jsme byli schopni výrazně zlepšit celkové vnímání hry.");

                        ut.AppendText("    Na grafu níže je možné vidět, jak dlouho respondenti hráli naši hru před vyplněním dotazníku.");

                        var im = new ImageWithTitle("Graf zobrazující délku hraní před vyplněním dotazníku.", "SurveyPlay");
                        im.SetMargin(new Offset(0, 0, 10, 0));

                        var res = new Text();
                        res.AppendText("    Na následujícím obrázku můžeme vidět výsledné hodnocení naší hry. [Medián] všech odpovědí je [7] a to navzdory tomu, že zhruba polovina odpovědí byla zodpovězena před výkonnostními optimalizacemi hry a zhruba tři čtvrtiny pak před implementací [tutoriálu]. Díky chybějícímu tutoriálu hráči nebyli seznámeni se všemi herními mechanikami a jejich frustrace se negativně projevila na výsledném hodnocení (tento závěr plyne ze získaného slovního hodnocení).");

                        var im1 = new ImageWithTitle("Výsledné hodnocení hry", "SurveyResults");

                        hz.AddChild(new GraphicalElement[] { ut, im, res, im1 }, 60, 110, 75, 110);

                        return hz;
                    }
                default:
                    throw new NotImplementedException();
            }
        }

        #endregion Internal Methods
    }
}