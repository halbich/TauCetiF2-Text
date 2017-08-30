using System;
using System.Diagnostics;
using PosterCreator.Attributes;
using PosterCreator.BaseClasses;
using PosterCreator.PosterStructure;

namespace PosterCreator
{
    internal class Program
    {
        #region Private Methods

        private static VerticalSplitter getBodyContent()
        {
            var contentAll = new VerticalSplitter().SetMargin(new Offset(0, 0, 10, 0));
            var leftContent = getLeftContent();

            var rightContent = getRightContent();
            contentAll.AddChild(new GraphicalElement[] { leftContent, rightContent }, 230, 407);
            return contentAll;
        }

        private static HorizontalSplitter getLeftContent()
        {
            var leftContent = new HorizontalSplitter().SetMargin(new Offset(0, 10, 0, 0));
            var beginning = new BorderWithTitle("Úvod").SetMargin(new Offset(0, 0, 10, 0));
            beginning.AddChild(TextSource.GetSourceFor(SourceType.Úvod));

            var current = new BorderWithTitle("Současný stav").SetMargin(new Offset(0, 0, 10, 0));
            current.AddChild(TextSource.GetSourceFor(SourceType.AktStav));

            var targets = new BorderWithTitle("Cíle").SetMargin(new Offset(0, 0, 10, 0));
            targets.AddChild(TextSource.GetSourceFor(SourceType.Cíle));


            leftContent.AddChild(new Border[] { beginning, current, targets }, 300, 300, 210);
            return leftContent;
        }

        private static HorizontalSplitter getRightContent()
        {
            var rightContent = new HorizontalSplitter();
            var arch = new BorderWithTitle("Architektura").SetMargin(new Offset(0, 0, 10, 0));
            arch.AddChild(TextSource.GetSourceFor(SourceType.Architektura));

            var archc = new VerticalSplitter().SetMargin(new Offset(0,0,10,0));

            var code = new BorderWithTitle("C++").SetMargin(new Offset(0, 5, 0, 0));
            var bl = new BorderWithTitle("Blueprint").SetMargin(new Offset(0, 0, 0, 5));

            archc.AddChild(new[] { code, bl }, 198, 198);

            var obraz = new BorderWithTitle("Obrázky ze hry").SetMargin(new Offset(0, 0, 10, 0));
            obraz.AddChild(TextSource.GetSourceFor(SourceType.Obrázky));

            var zaver = new BorderWithTitle("Závěr");
            zaver.AddChild(TextSource.GetSourceFor(SourceType.Závěr));

            rightContent.AddChild(new GraphicalElement[] { arch, archc, obraz, zaver }, 160, 360, 200, 80);
            return rightContent;
        }

        private static Border getTopBorder()
        {
            var b = new Border().SetMargin(new Offset(0, 0, 10, 0));

            b.AddChild(TextSource.GetSourceFor(SourceType.Top));
            return b;
        }

        private static void Main(string[] args)
        {
            var svg = new Svg();

            prepareContent(svg.Poster);

            svg.Poster.Render(svg);

            svg.FinalizeDoc();

            svg.doc.Save("../../../../../out.svg", System.Xml.Linq.SaveOptions.None);

            var ink = "\"" + System.IO.Path.Combine(Environment.ExpandEnvironmentVariables("%ProgramW6432%"), "Inkscape", "inkscape.exe") + "\"";
            var source = System.IO.Path.GetFullPath("../../../../../out.svg");
            var targetDir = System.IO.Path.GetFullPath("../../../../../out.png");

            var parameters = source + " -e " + targetDir;

            Debug.WriteLine(ink + " " + parameters);

            Process.Start(ink, parameters);
        }

        private static void prepareContent(MainStructure poster)
        {
            poster.Padding = new Offset(10);

            var top = getTopBorder();

            var contentAll = getBodyContent();

            poster.AddChild(new PrintMarker()).AddChild(new HorizontalSplitter()).AddChild(new GraphicalElement[] { top, contentAll }, 100, 810);

            poster.AfterInit();
        }

        #endregion Private Methods
    }
}