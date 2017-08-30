using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosterCreator.PosterStructure
{
    internal class ItemizeText : Text
    {
        internal override Text AppendText(string v)
        {
            return base.AppendText("  \u2022 " + v);
        }
    }
}
