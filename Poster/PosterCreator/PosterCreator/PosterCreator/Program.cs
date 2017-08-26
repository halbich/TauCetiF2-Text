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

            var b2 = new Border().SetMargin(new Offset(0, 0, 10, 0));

            var b3 = new Border().SetMargin(new Offset(0, 0, 10, 0));

            leftContent.AddChild(new Border[] { beginning, b2, b3 }, 100, 100, 610);
            return leftContent;
        }

        private static HorizontalSplitter getRightContent()
        {
            var rightContent = new HorizontalSplitter();
            var b4 = new Border().SetMargin(new Offset(0, 0, 10, 0));

            var b5 = new Border().SetMargin(new Offset(0, 0, 10, 0));

            var b6 = new Border();

            rightContent.AddChild(new Border[] { b4, b5, b6 }, 200, 200);
            return rightContent;
        }

        private static Border getTopBorder()
        {
            var b = new Border().SetMargin(new Offset(0, 0, 10, 0));

            var vs = b.AddChild(new VerticalSplitter());

            var schoolLogo = new ImageHolder("MffLogo") { IsSquare = true };
            var centerText = new HorizontalSplitter();

            var c = centerText.AddChild(new[] { new Text(), new Text() }, 20, 50);

            c[0].AppendText("TauCetiF2").SetBold();
            c[1].AppendText("Udělal");

            var tcfLogo = new ImageHolder("TCF2Logo");
            var unrealLogo = new ImageHolder("UELogo") { IsSquare = true };

            vs.AddChild(new GraphicalElement[] { schoolLogo, centerText, tcfLogo, unrealLogo }, 150, 150, 150 + 97, 70);

            return b;
        }

        private static void Main(string[] args)
        {
            var svg = new Svg();

            prepareContent(svg.Poster);

            svg.Poster.Render(svg);

            svg.FinalizeDoc();

            svg.doc.Save("../../../../../out.svg", System.Xml.Linq.SaveOptions.None);

            var ink = System.IO.Path.Combine(Environment.ExpandEnvironmentVariables("%ProgramW6432%"), "Inkscape", "inkscape.exe");
            var source = System.IO.Path.GetFullPath("../../../../../out.svg");
            var targetDir = System.IO.Path.GetFullPath("../../../../../out.png");

            Process.Start(ink, source + " -e " + targetDir);
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