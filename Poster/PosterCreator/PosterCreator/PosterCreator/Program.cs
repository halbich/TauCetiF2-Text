using System;
using PosterCreator.Attributes;
using PosterCreator.Elements;
using PosterCreator.PosterStructure;

namespace PosterCreator
{
    internal class Program
    {
        #region Private Methods

        private static void Main(string[] args)
        {
            var svg = new Svg();

            prepareContent(svg.Poster);

            svg.Poster.Render(svg);

            svg.FinalizeDoc();

            svg.doc.Save("../../../../../out.svg", System.Xml.Linq.SaveOptions.None);
        }

        private static void prepareContent(MainStructure poster)
        {
            poster.Padding = new Offset(10);
            var m = poster.AddChild(new PrintMarker());

            var mainHS = m.AddChild(new HorizontalSplitter());

            var top = getTopBorder();

            var contentAll = new VerticalSplitter().SetMargin(new Offset(0, 0, 10, 0));

            mainHS.AddChild(new GraphicalElement[] { top, contentAll }, 100, 810);

            var leftContent = new HorizontalSplitter().SetMargin(new Offset(0, 10, 0, 0));

            var rightContent = new HorizontalSplitter();
            contentAll.AddChild(new GraphicalElement[] { leftContent, rightContent }, 200, 437);

            var beginning = new Border().SetMargin(new Offset(0, 0, 10, 0));

            var b2 = new Border().SetMargin(new Offset(0, 0, 10, 0));

            var b3 = new Border().SetMargin(new Offset(0, 0, 10, 0));

            leftContent.AddChild(new Border[] { beginning, b2, b3 }, 100, 100);




            var b4 = new Border().SetMargin(new Offset(0, 0, 10, 0));

            var b5 = new Border().SetMargin(new Offset(0, 0, 10, 0));

            var b6 = new Border();

            rightContent.AddChild(new Border[] { b4, b5, b6 }, 200, 200);




        }

        private static Border getTopBorder()
        {
            return new Border().SetMargin(new Offset(0, 0, 10, 0));
        }

        #endregion Private Methods
    }
}