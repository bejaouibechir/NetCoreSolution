namespace WebMVCore
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        => $"Point({X},{Y})";
    }
}
