using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosterCreator.Attributes
{
    internal class WhiteSpaceParams : TextParams
    {
        internal override string GetStyle()
        {
            return "fill:#ffffff";
        }
    }
}
