
namespace Tactics.Domain.Map {

    public struct GridPoint 
    {
        public int X { get; set; }
        public int Y { get; set; }

        public GridPoint(int x, int y) {
            X = x;
            Y = y;
        }
    }
}