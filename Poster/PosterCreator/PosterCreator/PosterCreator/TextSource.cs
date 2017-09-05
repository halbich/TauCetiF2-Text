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

                        var vsLogo = new VerticalSplitter().SetPadding(new Offset(0, 5));
                        var schoolLogo = new ImageHolder("MffLogo") { IsSquare = true };
                        vsLogo.AddChild(new[] { schoolLogo }, 90);

                        var centerText = new HorizontalSplitter().SetMargin(new Offset(2,0,0,0));

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
                            ";@V současné době jsou velice populární hry s otevřeným světem. Lákají hráče na obsáhlost světa a možnost nelineárního řešení problémů a herních úkolů. Her s otevřeným světem najdeme nepřeberné množství v různých herních žánrech. My jsme se zaměřili na podmnožinu her, které kromě otevřeného světa nabízí také možnosti budování struktur a vyžadují od hráče netriviální styl hraní, který mu umožňuje ve hře přežít. V herním průmyslu se tyto hry často označují jako <sandboxové>, <s budováním>, <s průzkumem prostředí>, <o přežití>. V této práci pak představujeme naši vizi dalšího možného rozvoje her tohoto žánru."
                        );
                        ut.AppendText(";@Provedli jsme obsáhlou rešerši a zjistili jsme, že současné hry, jako třeba <Minecraft> nebo <Space Engineers>, mají společnou vlastnost – hráč může stavět pouze z bloků pevně dané velikosti. Zde vidíme prostor pro zlepšení. Dále jsme zjistili, že hráčův inventář vyžaduje manuální správu, což je s naší vizí neslučitelné.");
                        return ut;
                    }
                case SourceType.Cíle:
                    {
                        var ut = new Text();
                        ut.AppendText(";@1. návrh nových herních mechanik");
                        ut.AppendText(";@~~• systém dynamicky škálovatelných bloků");
                        ut.AppendText(";@~~• automatizovaná správa inventáře");
                        ut.AppendText(";@~~• koncepce tvorby škálovatelných bloků");
                        ut.AppendText(";@~~• herní mechaniky využívající škálovatelných bloků");
                        ut.AppendText(";@2. implementace navržených mechanik do nové hry");
                        ut.AppendText(";@~~• volba vhodného herního enginu");
                        ut.AppendText(";@~~• návrh a implementace vhodných datových struktur");
                        ut.AppendText(";@~~• implementace všech nutných herních mechanismů a součástí");
                        ut.AppendText(";@3. zhodnocení navržených mechanik a jejich implementace");
                        ut.AppendText(";@~~• připravit a vyhodnotit dotazník");

                        return ut;
                    }
                case SourceType.Architektura:
                    {
                        var hz = new HorizontalSplitter();
                        var ut = new Text();
                        var canvas = new Canvas();
                        hz.AddChild(new GraphicalElement[] { ut, canvas }, 165, 217);

                        ut.AppendText(new[]
                        {
                            ";@Pro implementaci naší hry jsme zvolili <Unreal Engine>. Díky tomu jsme mohli plně využít jednoduchosti technologie <Blueprintů> a zároveň rychlost a sílu jazyka <C++>. Vhodnou kombinací obou technologií jsme dosáhli rychlého a efektivního vývoje celé hry. Navíc jsme měli k dispozici mnoho užitečných vývojových nástrojů (např. editor lokalizace, editor AI).",
                            "",
                            "[ C++]",
                            ";@V jazyce <C++> byly naprogramovány všechny části a komponenty hry, u nichž byl kladen důraz na výkon. Dále jsme zde definovali všechny definiční vlastnosti (omezující konstanty), jejichž konkrétní hodnoty jsme následně mohli měnit v Editoru skrze <Blueprinty>. A v neposlední řadě jsme zde implementovali některé bázové třídy, z nichž pak mohly <Blueprinty> dědit a mohly tak volat funkcionalitu implementovanou v <C++>.",
                            "",
                            "[ Blueprinty]",
                            ";@Pomocí <Blueprintů> byly rychle implementovány nekritické části hry. Dále bylo <Blueprintů> využito pro snadné balancování jednotlivých hodnot definičních vlastností (např. minimální a maximální velikosti bloků, vlastnosti bloků, cena stavby). Hodnoty jsme mohli měnit bez nutnosti zdlouhavého procesu opětovné kompilace celého projektu.",
                             "",
                            "[ Celková koncepce]",
                            ";@Na obrázku níže je možné vidět celkovou koncepci architektury hry. Vybrali jsme nejvýznamnější funkční celky hry a do grafu jsme zaznamenali jejich vazby. Navíc jsme zdůraznili funkční celky, které ukládají svůj stav během ukládání hry.",

                        });


                        var saveColor = Color.LightGray;
                        var defColor = Color.FromArgb(142, 161, 255);

                        var blocks = canvas.Add("Bloky", -60, -10, 25);
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
                        var o2Comp = canvas.Add("Kyslíková\nkomponenta", -25, 30, 47, 22);
                        o2Comp.SetBackground(saveColor);

                        var character = canvas.Add("Hráčova\npostava", 10, 80, 33, 22);
                        character.SetBackground(saveColor);
                        var inventory = canvas.Add("Inventář", 160, 80, 34);
                        inventory.SetBackground(saveColor);
                        var blockLoadSys = canvas.Add("Systém načítání bloků", -140, -10, 75);
                        var interWorld = canvas.Add("Interakce\nse světem", -60, 80, 40, 22);


                        canvas.AddR(blocks, blocksDef);
                        canvas.AddR(blocksDef, vizualReprezBlocks);
                        canvas.AddR(blockLoadSys, blocksDef);
                        canvas.AddR(blocks, worldReprez);

                        //canvas.AddR(worldReprez, aiWeather);
                        canvas.AddR(worldReprez, logicWeather);
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

                        var l = canvas.AddA("Legenda", -155f, 31.5f, 50); 
                        l.OverrideOpacity = 0;
                        l.SetMiddle = true;
                        var c0 = 245;
                        //l.SetBackground(Color.FromArgb(c0, c0, c0));

                        var legendSec = canvas.Add("Funkční celek", -155f, 42.5f, 50);
                        var legendSave = canvas.Add("Implementuje ukládání", -155f, 60, 50, 20);
                        legendSave.SetBackground(saveColor);
                        var legendDef = canvas.Add("Definiční vlastnosti", -155f, 82f, 50, 20);
                        legendDef.SetBackground(defColor);



                        return hz;
                    }
                case SourceType.Obrázky:
                    {
                        var vs = new VerticalSplitter().SetMargin(new Offset(5,0,0,0));

                        var hzl = new HorizontalSplitter();

                        var iml0 = new ImageWithTitle("Počáteční budova (lehká obtížnost)", "ImgL0");
                        var iml1 = new ImageWithTitle("Akumulátory, plnička kyslíku a kyslíkové bomby", "ImgL1");
                        var iml2 = new ImageWithTitle("Nápadité využití herních bloků pro tvorbu loga", "ImgL2");

                        hzl.AddChild(new[] { iml0, iml1, iml2 });

                        var hzr = new HorizontalSplitter();

                        var imr0 = new ImageWithTitle("Noční pohled na budovy lehké a střední obtížnosti", "ImgR0");
                        var imr1 = new ImageWithTitle("Hráč může ve hře modelovat i každodenní objekty", "ImgR1");
                        var imr2 = new ImageWithTitle("Různé varianty konstruktoru objektů", "ImgR2");

                        hzr.AddChild(new[] { imr0, imr1, imr2 });

                        vs.AddChild(new[] { hzl, hzr });

                        return vs;
                    }
                case SourceType.Závěr:
                    {
                        var ut = new Text();
                        ut.AppendText(";@Úspěšně se nám podařilo splnit všechny vytyčené cíle. Navrhli jsme a následně implementovali všechny námi požadované herní mechaniky, včetně doplňujících (lokalizace, hudba).");
                        ut.AppendText(";@Poznatky získané z dotazníku a během vývoje bychom rádi zužitkovali pro následující rozvoj této práce. ");
                        return ut;
                    }
                case SourceType.Dotaznik:
                    {
                        var hz = new HorizontalSplitter();
                        var ut = new Text();
                        ut.AppendText(
                            new[] { ";@Po dokončení implementace všech herních mechanik jsme připravili dotazník pro širokou veřejnost. Díky průběžnému vyhodnocování jsme mohli reagovat na respondenty udávané nedostatky a byli jsme tak schopni výrazně zlepšit celkové vnímání hry.",
                            ";@Zhruba polovina odpovědí byla zodpovězena před <výkonnostními optimalizacemi> hry a zhruba tři čtvrtiny pak před implementací <tutoriálu>. Tyto nejčastěji zmiňované nedostatky se negativně projevily na výsledném hodnocení (tento závěr plyne ze slovního hodnocení)."
                                });

                        ut.AppendText(";@Navzdory faktům uvedeným výše a poměrně malému počtu respondentů ([24]) jsme získali zajímavá data. Na grafu níže je možné vidět, jak dlouho respondenti hráli naši hru. Můžeme vidět, že 42%~respondentů hru hrálo více jak půl hodiny, což chápeme (vzhledem k malému počtu implementovaných bloků) jako skvělý výsledek.");

                        var im = new ImageWithTitle("Graf zobrazující délku hraní před vyplněním dotazníku.", "SurveyPlay");
                        im.SetMargin(new Offset(0, 0, 10, 0));

                        var res = new Text();
                        res.AppendText(";@Na následujícím obrázku můžeme vidět výsledné hodnocení naší hry. [Medián] všech odpovědí je [7]. (Škála: 1 = <Velice nepovedená, nikdy se k ní nevrátím>, 10 = <Zdařilá, rád/a bych si v budoucnu dokončenou hru zahrál/a>)");

                        var im1 = new ImageWithTitle("Výsledné hodnocení hry", "SurveyResults");
                        im1.SetMargin(new Offset(0, 0, 10, 0));

                        var result = new Text();
                        result.AppendText(";@Z celkového zhodnocení dotazníku vyplynulo, že myšlenka dynamicky škálovatelných bloků má svůj potenciál a případná dokončená hra by si našla své publikum.");
                        hz.AddChild(new GraphicalElement[] { ut, im, res, im1, result }, 150, 110, 40, 110, 30);

                        return hz;
                    }
                default:
                    throw new NotImplementedException();
            }
        }

        #endregion Internal Methods
    }
}