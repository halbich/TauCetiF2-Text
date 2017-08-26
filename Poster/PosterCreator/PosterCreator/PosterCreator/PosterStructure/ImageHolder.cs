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
        private string path;

        public bool IsSquare { get; set; }

        public ImageHolder(string Path)
        {
            path = Path;
        }

        public override void AfterInit()
        {
            base.AfterInit();
            debugRect = new Rectangle(this);
        }

        public override void Render(Svg svg)
        {
            var t = svg.GL(LayerType.Other);
            t.Add(debugRect);

            if (string.IsNullOrEmpty(path))
                return;

            var img = new Image(this,path);
            if (IsSquare)
            {
                var m = Math.Min(img.Dimensions.X, img.Dimensions.Y);
                img.Dimensions = new Attributes.V2D(m, m);
            }


            t.Add(img);
        }
    }
}
