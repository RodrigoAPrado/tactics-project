namespace Tactics.Domain.Map {
    public class UnitData : MapData{

        public UnitArmyType ArmyType { get; private set; }

        public UnitData(GridPoint position, UnitArmyType armyType) : base(position) {
            ArmyType = armyType;
        }   
    }

    public enum UnitArmyType {
        Player = 0,
        Enemy = 1,
        Ally = 2,
        Other = 3
    }
}