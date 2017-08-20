﻿using System.Collections.Generic;
using PosterCreator.Attributes;

namespace PosterCreator.Elements
{
    internal class PrintMarker : GraphicalElementWithChild
    {
        public PrintMarker()
        {
            Margin = new Offset(10);
            Padding = new Offset(10);
        }

        private const float MarkerSize = 7;
        private const float StrokeWidth = 0.2f;

        public override void Render(Svg svg)
        {
            var layer = svg.GL(LayerType.Other);

            var ps = new List<Path>();

            ps.AddRange(getCrossFor(Location));

            ps.AddRange(getCrossFor(Location.MoveX(Size.X)));

            ps.AddRange(getCrossFor(Location.MoveY(Size.Y)));

            ps.AddRange(getCrossFor(Location.MoveXY(Size.X, Size.Y)));


            foreach (var item in ps)
                layer.Add(item);

            base.Render(svg);
        }

        private static List<Path> getCrossFor(V2D point)
        {
            List<Path> res = new List<Path> {
                new Path("CrossLine", point.MoveX(-MarkerSize), point.MoveX(MarkerSize)) { StrokeWidth = StrokeWidth},
                new Path("CrossLine", point.MoveY(-MarkerSize), point.MoveY(MarkerSize)) { StrokeWidth = StrokeWidth}
            };

            return res;
        }
    }
}