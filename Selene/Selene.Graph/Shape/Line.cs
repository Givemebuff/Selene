namespace Selene.Graph
{
    public struct Line<T> where T : struct
    {
        public Point<T> Orign { get; set; }
        public Point<T> Target { get; set; }
    }
}
