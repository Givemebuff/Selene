using System;
using System.Collections.Generic;
using System.Text;

namespace Selene.Graph
{
    public interface ICanvas
    {
        Size<double> Size { get; set; }

        void Draw(IDrawingContext context);
    }

    public interface IDrawingContext
    {
        void DrawPoints(Point<double>[] points);
        void DrawPoint(Point<double> point);
        void DrawRect(Rect<double> rect);
        void DrawLine(Line<double> line);
        void DrawLines(Line<double>[] lines);
        void DrawEllipse(Ellipse<double> ellipse);

    }
}
