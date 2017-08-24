﻿using PosterCreator.Elements;

namespace PosterCreator.PosterStructure
{
    internal class MainStructure : GraphicalElementWithChild
    {
        #region Public Constructors

        public MainStructure()
        {
            Size = new Attributes.V2D { X = 707, Y = 1000 };
        }

        #endregion Public Constructors
    }
}