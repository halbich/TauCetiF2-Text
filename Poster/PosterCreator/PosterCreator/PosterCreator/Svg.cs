using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using PosterCreator.Elements;
using PosterCreator.PosterStructure;

namespace PosterCreator
{
    internal class Svg
    {
        public static XNamespace ns = "http://www.w3.org/2000/svg";

        internal void FinalizeDoc()
        {
            foreach (var item in Layers)
            {
                doc.Root.Add(item.GetNode());
            }
        }

        public static XNamespace sp = "http://sodipodi.sourceforge.net/DTD/sodipodi-0.dtd";
        public static XNamespace ink = "http://www.inkscape.org/namespaces/inkscape";

        public static XNamespace dc = "http://purl.org/dc/elements/1.1/";
        public static XNamespace cc = "http://creativecommons.org/ns#";
        public static XNamespace rdf = "http://www.w3.org/1999/02/22-rdf-syntax-ns#";
        public static XNamespace xlink = "http://www.w3.org/1999/xlink";

        public XDocument doc { get; set; }

        public Svg()
        {
            doc = new XDocument(
                new XElement(ns + "svg",
                    new XAttribute("xmlns", ns.NamespaceName),
                    new XAttribute(XNamespace.Xmlns + "dc", dc.NamespaceName),
                    new XAttribute(XNamespace.Xmlns + "cc", cc.NamespaceName),
                    new XAttribute(XNamespace.Xmlns + "rdf", rdf.NamespaceName),
                    new XAttribute(XNamespace.Xmlns + "xlink", xlink.NamespaceName),
                    new XAttribute(XNamespace.Xmlns + "sodipodi", sp.NamespaceName),
                    new XAttribute(XNamespace.Xmlns + "inkscape", ink.NamespaceName),

                    new XAttribute("width", "707mm"),
                    new XAttribute("height", "1000mm"),
                    new XAttribute("viewBox", "0 0 707 1000"),
                    new XAttribute("version", "1.1"),
                    new XAttribute("id", "svg8"),
                    new XAttribute(ink + "version", "0.92.1 r15371"),
                    new XAttribute(sp + "docname", "out.svg")
                    ));

            var defs = new XElement(ns + "defs", new XAttribute("id", "defs2"));
            defs.Add(new XElement(ink + "path-effect",
                    new XAttribute("effect", "fill_between_many"),
                    new XAttribute("id", "path-effect3688"),
                    new XAttribute("is_visible", "true"),
                    new XAttribute("linkedpaths", "")));

            doc.Root.Add(defs);

            var nw = new XElement(sp + "namedview",
                new XAttribute("id", "base"),
                new XAttribute("pagecolor", "#ffffff"),
                new XAttribute("bordercolor", "#666666"),
                new XAttribute("borderopacity", "1.0"),
                new XAttribute(ink + "pageopacity", "0.0"),
                new XAttribute(ink + "pageshadow", "2"),
                new XAttribute(ink + "zoom", "0.175"),
                new XAttribute(ink + "cx", "243.08773"),
                new XAttribute(ink + "cy", "1835.642"),
                new XAttribute(ink + "document-units", "mm"),
                new XAttribute(ink + "current-layer", "layer2"),
                new XAttribute("showgrid", "true"),
                new XAttribute(ink + "window-width", "1920"),
                new XAttribute(ink + "window-height", "1017"),
                new XAttribute(ink + "window-x", "-8"),
                new XAttribute(ink + "window-y", "-8"),
                new XAttribute(ink + "window-maximized", "1"),
                new XAttribute("height", "999mm")
                );
            nw.Add(new XElement(ink + "grid",
                new XAttribute("type", "xygrid"),
                new XAttribute("id", "grid20")));

            doc.Root.Add(nw);

            var md = new XElement(ns + "metadata", new XAttribute("id", "metadata"));

            var _r = new XElement(rdf + "RDF");
            var w = new XElement(cc + "Work", new XAttribute(rdf + "about", ""));
            w.Add(new XElement(dc + "format", "image/svg+xml"));
            w.Add(new XElement(dc + "type", new XAttribute(rdf + "resource", "http://purl.org/dc/dcmitype/StillImage")));
            w.Add(new XElement(dc + "title", string.Empty));
            _r.Add(w);

            md.Add(_r);

            doc.Root.Add(md);

            Layers = new List<Layer>
            {
            new Layer("Background", LayerType.Background),
            new Layer("BorderBackground", LayerType.BorderBackground),
            new Layer("Border", LayerType.Border),
            new Layer("Text", LayerType.Text),
            new Layer("Other", LayerType.Other),
            };

            Poster = new MainStructure();
        }

        private List<Layer> Layers { get; set; }

        public MainStructure Poster { get; set; }

        public Layer GL(LayerType t)
        {
            return Layers.First(e => e.Type == t);
        }
    }
}