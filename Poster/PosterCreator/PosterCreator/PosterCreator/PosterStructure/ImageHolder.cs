using System;
using PosterCreator.Attributes;
using PosterCreator.BaseClasses;
using PosterCreator.Elements;

namespace PosterCreator.PosterStructure
{
    internal class ImageHolder : GraphicalElement
    {
        #region Private Fields

        private Rectangle debugRect;
        private string path;

        #endregion Private Fields

        #region Public Constructors

        public ImageHolder(string Path)
        {
            path = Path;
        }

        #endregion Public Constructors

        #region Public Properties

        public bool IsSquare { get; set; }

        #endregion Public Properties

        #region Public Methods

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

            var img = new Image(this, path);
            if (IsSquare)
            {
                var m = Math.Min(img.Dimensions.X, img.Dimensions.Y);
                img.Dimensions = new V2D(m, m);
            }

            t.Add(img);
        }

        #endregion Public Methods
    }
}