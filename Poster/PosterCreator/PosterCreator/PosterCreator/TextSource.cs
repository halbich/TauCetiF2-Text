using System;
using PosterCreator.BaseClasses;
using PosterCreator.PosterStructure;

namespace PosterCreator
{
    internal enum SourceType
    {
        Úvod
    }

    internal static class TextSource
    {
        #region Internal Methods

        internal static GraphicalElement GetSourceFor(SourceType type)
        {
            switch (type)
            {
                case SourceType.Úvod:
                    var ut = new Text();
                    ut.AppendText("Lorem ipsum");
                    return ut;

                default:
                    throw new NotImplementedException();
            }
        }

        #endregion Internal Methods
    }
}