using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosterCreator.PosterStructure
{
    internal class OrderedText : Text
    {
        internal override Text AppendText(string v)
        {
            return base.AppendText($"  {Paragraphs.Count + 1}. " + v);
        }

      
    }
}
