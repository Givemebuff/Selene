using System;
using System.Collections.Generic;
using System.Text;

namespace Selene.Graph
{
    public struct Ellipse<T> where T : struct
    {
        public Point<T> Center { get; set; }

        public T RadiuX { get; set; }
        public T RadiuY { get; set; }
    }
}
