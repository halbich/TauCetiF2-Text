using PosterCreator.BaseClasses;

namespace PosterCreator.PosterStructure
{
    internal class ImageWithTitle : GraphicalElementWithChild
    {
        #region Private Fields

        private HorizontalSplitter Vs;

        private ImageHolder img;

        #endregion Private Fields

        #region Public Constructors

        public ImageWithTitle(string title, string path)
        {
            Title = new Text();
            var p = Title.AppendText(title).TextParams;
            p.SetMiddle();
            Title.SetPadding(new Attributes.Offset(2, 2));
            Vs = new HorizontalSplitter();
            img = new ImageHolder(path).SetPadding(new Attributes.Offset(0,5));
            base.AddChild(Vs);
        }

        #endregion Public Constructors

        #region Public Properties

        public Text Title { get; set; }

        #endregion Public Properties

        #region Public Methods


        public override void AfterInit()
        {
            var popisSize = 14;
            Vs.AddChild(new GraphicalElement[] { img, Title }, Size.Y - popisSize, popisSize);

            base.AfterInit();
        }

        #endregion Public Methods
    }
}