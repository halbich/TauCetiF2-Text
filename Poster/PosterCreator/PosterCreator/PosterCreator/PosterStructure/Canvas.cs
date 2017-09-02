using System.Collections.Generic;
using PosterCreator.Attributes;
using PosterCreator.BaseClasses;
using PosterCreator.Elements;

namespace PosterCreator.PosterStructure
{
    internal class Canvas : GraphicalElement
    {
        #region Public Fields

        public List<CanvasElem> Elems;

        public List<CanvasElemRel> Rels;

        #endregion Public Fields

        #region Private Fields

        private Rectangle baseRectangle;
        private V2D center;

        #endregion Private Fields

        #region Public Constructors

        public Canvas()
        {
            Padding = new Offset(10);

            Elems = new List<CanvasElem>();
            Rels = new List<CanvasElemRel>();
        }

        #endregion Public Constructors

        #region Public Methods

        public CanvasElem Add(string text, float X, float Y, float Width, float Height = 14)
        {
            var n = new CanvasElem(new V2D(X, Y), new V2D(Width, Height)) { Text = text };
            Elems.Add(n);
            return n;
        }

        public override void AfterInit()
        {
            baseRectangle = new Rectangle(this);
            baseRectangle.RenderParams.Stroke = System.Drawing.Color.Black;
            baseRectangle.RenderParams.StrokeWidth = 1;

            center = baseRectangle.XY + new V2D(baseRectangle.Dimensions.X / 2.0f, baseRectangle.Dimensions.Y / 2.0f);

            base.AfterInit();
        }

        public override void Render(Svg svg)
        {
            baseRectangle.RenderParams.Stroke = System.Drawing.Color.Black;
            baseRectangle.RenderParams.StrokeWidth = 1;
            var t = svg.GL(LayerType.Other);
            t.Add(baseRectangle);

            foreach (var item in Rels)
            {
                var path = new Path("relation", item.Source.Loc + item.dSource, item.Target.Loc + item.dTarget);
            }

            foreach (var item in Elems)
            {
                var r = new Rectangle
                {
                    XY = center + new V2D(item.Loc.X - item.Scale.X / 2f, item.Loc.Y - item.Scale.Y / 2f),
                    Dimensions = item.Scale
                };
                var text = new Text()
                {
                    Location = r.XY,
                    Size = r.Dimensions,
                    Padding = new Offset(2, 4)
                };
                text.TextParams.SetMiddle();
                text.AppendText(item.Text.Split('\n'));
                text.AfterInit();
                text.OverrideLayer = LayerType.ImgText;
                text.Render(svg);
                r.RenderParams.Stroke = System.Drawing.Color.Black;
                r.RenderParams.StrokeWidth = 0.5f;
                r.RenderParams.Fill = System.Drawing.Color.White;
                t.Add(r);
            }
        }

        #endregion Public Methods
    }

    internal class CanvasElem
    {
        #region Public Constructors

        public CanvasElem(V2D loc, V2D scale)
        {
            Loc = loc;
            Scale = scale;
        }

        #endregion Public Constructors

        #region Public Properties

        public V2D Loc { get; set; }
        public V2D Scale { get; set; }

        public string Text { get; set; }

        #endregion Public Properties
    }

    internal class CanvasElemRel
    {
        #region Public Constructors

        public CanvasElemRel(CanvasElem source, CanvasElem target, float dsX = 0, float dsY = 0, float dtX = 0, float dtY = 0)
        {
            Source = source;
            Target = target;
            dSource = new V2D(dsX, dsY);
            dTarget = new V2D(dtX, dtY);
        }

        #endregion Public Constructors

        #region Public Properties

        public V2D dSource { get; private set; }
        public V2D dTarget { get; private set; }
        public CanvasElem Source { get; private set; }
        public CanvasElem Target { get; private set; }

        #endregion Public Properties
    }
}