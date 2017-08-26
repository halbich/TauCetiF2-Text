using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PosterCreator.BaseClasses;
using PosterCreator.Elements;

namespace PosterCreator.PosterStructure
{
    internal class ImageHolder : GraphicalElement
    {
        private Rectangle debugRect;

        public override void AfterInit()
        {
            base.AfterInit();
            debugRect = new Rectangle(this);
        }

        public override void Render(Svg svg)
        {
            var t = svg.GL(LayerType.Other);
            t.Add(debugRect);
        }
    }
}
