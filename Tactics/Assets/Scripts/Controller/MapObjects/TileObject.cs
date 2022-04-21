using Tactics.Domain.Map;

namespace Tactics.Controller.MapObjects {
    
    public class TileObject : MapObject<TileData>
    {    
        private void Awake() {
            objectData = new TileData(new GridPoint((int) transform.position.x, (int) transform.position.y));     
        }    
    }
}
