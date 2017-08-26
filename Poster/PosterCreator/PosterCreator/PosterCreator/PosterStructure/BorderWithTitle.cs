using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PosterCreator.BaseClasses;

namespace PosterCreator.PosterStructure
{
    internal class BorderWithTitle : Border
    {
        public Text Title { get; set; }

        private HorizontalSplitter Vs;

        public BorderWithTitle(string title)
        {
            Title = new Text();
            Title.AppendText(title);
            Vs = new HorizontalSplitter();
            base.AddChild(Vs);
        }

        public override T AddChild<T>(T elem)
        {
            Vs.AddChild(new GraphicalElement[] { Title, elem }, 30);

            return elem;
        }

        public override void AfterInit()
        {
            if(Vs.Child == null)
                Vs.AddChild(new GraphicalElement[] { Title }, 30);

            base.AfterInit();
        }
    }
}
