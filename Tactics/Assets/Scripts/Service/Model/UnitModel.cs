using System.Collections.Generic;
using Tactics.Domain.Interface.Unit;

namespace Tactics.Service.Model {

    public class UnitSetModel {
        public List<UnitModel> units { get; set; }
    }

    public class UnitModel {
        public UnitPosition startingPosition { get; set; }
        public UnitClass unitClass { get; set; }
        public ArmyType armyType { get; set; }
        public string unitResource { get; set; }

    }

    public class UnitPosition {
        public int x { get; set; }
        public int y { get; set; }
    }
}