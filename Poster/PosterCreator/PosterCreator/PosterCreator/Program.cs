using PosterCreator.Elements;
using PosterCreator.PosterStructure;

namespace PosterCreator
{
    internal class Program
    {
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
            poster.AddChild(new Border() { });
        }
    }
}