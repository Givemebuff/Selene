using System;
using System.Collections.Generic;
using System.Text;

namespace Selene.Graph
{
    public struct Point<T> where T : struct
    {
        public T X { get; set; }
        public T Y { get; set; }
    }
}
