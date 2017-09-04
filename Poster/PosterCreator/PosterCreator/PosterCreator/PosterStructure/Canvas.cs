using System;
using System.Drawing;
using System.Collections.Generic;
using PosterCreator.Attributes;
using PosterCreator.BaseClasses;
using PosterCreator.Elements;
using Rect = PosterCreator.Elements.Rectangle;

namespace PosterCreator.PosterStructure
{
    internal class Canvas : GraphicalElement
    {
        #region Public Fields

        public List<CanvasElem> Elems;

        public List<CanvasElemRel> Rels;

        public List<AreaElem> Areas;

        #endregion Public Fields

        #region Private Fields

        private Rect baseRectangle;
        private V2D center;

        #endregion Private Fields

        #region Public Constructors

        public Canvas()
        {
            Padding = new Offset(10);

            Elems = new List<CanvasElem>();
            Rels = new List<CanvasElemRel>();

            Areas = new List<AreaElem>();
        }

        #endregion Public Constructors

        #region Public Methods

        public CanvasElem Add(string text, float X, float Y, float Width, float Height = 11)
        {
            var n = new CanvasElem(new V2D(X, Y), new V2D(Width, Height)) { Text = text };
            Elems.Add(n);
            return n;
        }

        public AreaElem AddA(string text, float X, float Y, float Width, float Height = 14)
        {
            var n = new AreaElem(new V2D(X, Y), new V2D(Width, Height)) { Text = text };
            Areas.Add(n);
            return n;
        }


        public override void AfterInit()
        {
            baseRectangle = new Rect(this);
            baseRectangle.RenderParams.Stroke = Color.Black;
            baseRectangle.RenderParams.StrokeWidth = 1;

            center = baseRectangle.XY + new V2D(baseRectangle.Dimensions.X / 2.0f, baseRectangle.Dimensions.Y / 2.0f);

            base.AfterInit();
        }

        public override void Render(Svg svg)
        {
            baseRectangle.RenderParams.Stroke = Color.Black;
            baseRectangle.RenderParams.StrokeWidth = 1;
            var t = svg.GL(LayerType.Other);
            t.Add(baseRectangle);

            var i = 0;
            var pL = svg.GL(LayerType.Other);
            foreach (var item in Rels)
            {
                var path = new Path("relation" + (++i), center + item.Source.Loc + item.dSource, center + item.Target.Loc + item.dTarget);
                path.RenderParams.StrokeWidth = 1;
                path.SetFillStroke(Color.Black);
                pL.Add(path);
            }

            foreach (var item in Areas)
            {
                var r = new Rect
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
                text.TextParams.SetBold();
                text.AppendText(item.Text);
                text.AfterInit();
                text.OverrideLayer = LayerType.ImgText;
                text.Render(svg);
                r.RenderParams.Stroke = Color.Black;
                r.RenderParams.StrokeWidth = 0.5f;
                r.RenderParams.StrokeOpacity = item.OverrideOpacity ?? 0.5f;

                if (item.OverideColor.HasValue)
                    r.RenderParams.Fill = item.OverideColor.Value;

                t.Add(r);
            }

            foreach (var item in Elems)
            {
                var r = new Rect
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

                if (text.Paragraphs.Count == 1)
                    text.TextParams.LineHeight = 125;

                text.AfterInit();
                text.OverrideLayer = LayerType.ImgText;
                text.Render(svg);
                r.RenderParams.Stroke = Color.Black;
                r.RenderParams.StrokeWidth = 0.5f;
                r.RenderParams.Fill = item.OverideColor ?? Color.White;
                t.Add(r);
            }
        }

        public CanvasElemRel AddR(CanvasElem source, CanvasElem target, float dsX = 0, float dsY = 0, float dtX = 0, float dtY = 0)
        {
            var r = new CanvasElemRel(source, target, dsX, dsY, dtX, dtY);
            Rels.Add(r);
            return r;
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

        public Color? OverideColor { get; set; }

        internal void SetBackground(Color overrideColor)
        {
            OverideColor = overrideColor;
        }

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

    internal class AreaElem : CanvasElem
    {
        public AreaElem(V2D loc, V2D scale) : base(loc, scale)
        {

        }

        public float? OverrideOpacity { get; set; }
    }
}