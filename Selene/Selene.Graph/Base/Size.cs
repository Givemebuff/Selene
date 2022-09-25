using System;
using System.Collections.Generic;
using System.Text;

namespace Selene.Graph
{
    public struct Size<T> where T : struct
    {
        public T Width { get; set; }

        public T Height { get; set; }
    } 
}
