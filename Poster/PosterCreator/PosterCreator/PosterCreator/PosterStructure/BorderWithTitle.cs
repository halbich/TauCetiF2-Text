using PosterCreator.BaseClasses;

namespace PosterCreator.PosterStructure
{
    internal class BorderWithTitle : Border
    {
        #region Private Fields

        private HorizontalSplitter Vs;

        #endregion Private Fields

        #region Public Constructors

        public BorderWithTitle(string title)
        {
            Title = new Text();
            Title.AppendText(title);
            Title.TextParams.SetH2();
            Title.SetPadding(new Attributes.Offset(1, 2));
            Vs = new HorizontalSplitter();
            base.AddChild(Vs);
        }

        #endregion Public Constructors

        #region Public Properties

        public Text Title { get; set; }

        #endregion Public Properties

        #region Public Methods

        public override T AddChild<T>(T elem)
        {
            Vs.AddChild(new GraphicalElement[] { Title, elem }, 18);

            return elem;
        }

        public override void AfterInit()
        {
            if (Vs.Child == null)
                Vs.AddChild(new GraphicalElement[] { Title }, 30);

            base.AfterInit();
        }

        #endregion Public Methods
    }
}