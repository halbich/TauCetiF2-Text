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
            poster.Padding = new Attributes.Offset(10);
            var m = poster.AddChild(new PrintMarker());

            var vs = m.AddChild(new VerticalSplitter());

            var top = new Border();
            top.Margin = new Attributes.Offset(0, 0, 10, 0);

            var bottom = new Border();

            vs.AddChild(new Border[] { top, bottom }, 100);
        }

        #endregion Private Methods
    }
}