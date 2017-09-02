namespace PosterCreator.PosterStructure
{
    internal class ItemizeText : Text
    {
        #region Internal Methods

        internal override Text AppendText(string v)
        {
            return base.AppendText("  \u2022 " + v);
        }

        #endregion Internal Methods
    }
}