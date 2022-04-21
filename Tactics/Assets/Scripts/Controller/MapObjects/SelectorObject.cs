using Tactics.Domain.Map;

namespace Tactics.Controller.MapObjects {
    public class SelectorObject : DynamicMapObject<PositionData> {
        private void Awake() {
            objectData = new PositionData(new GridPoint((int) transform.position.x, (int) transform.position.y));     
        }
    }
}