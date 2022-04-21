namespace Tactics.Domain.Map {
    public abstract class MapData {
        public GridPoint Position { get; private set; }

        protected MapData(GridPoint position) {
            Position = position;
        }

        public void Move(GridPoint nextPosition) {
            Position = nextPosition;
        }
    }
}