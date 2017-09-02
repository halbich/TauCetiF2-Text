namespace PosterCreator.PosterStructure
{
    internal class OrderedText : Text
    {
        #region Internal Methods

        internal override Text AppendText(string v)
        {
            return base.AppendText($"  {Paragraphs.Count + 1}. " + v);
        }

        #endregion Internal Methods
    }
}