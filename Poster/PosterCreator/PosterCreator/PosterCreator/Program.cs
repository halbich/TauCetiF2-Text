using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PosterCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            var svg = new Svg();

            svg.doc.Save("../../../../../out.svg", System.Xml.Linq.SaveOptions.None);
        }
    }
}
