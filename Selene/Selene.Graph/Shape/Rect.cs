using System;
using System.Collections.Generic;
using System.Text;

namespace Selene.Graph
{
    public struct Rect<T> where T : struct
    {
        public T Left { get; set; }
        public T Right { get; set; }
        public T Top { get; set; }
        public T Bottom { get; set; }

        public Point<T> LeftTop => new Point<T>() { X = Left, Y = Top };
        public Point<T> RightTop => new Point<T>() { X = Right, Y = Top };
        public Point<T> LeftBottom => new Point<T>() { X = Left, Y = Bottom };
        public Point<T> RightBottom => new Point<T>() { X = Right, Y = Bottom };
    }
}
