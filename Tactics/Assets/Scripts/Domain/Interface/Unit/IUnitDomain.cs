namespace Tactics.Domain.Interface.Unit {
    public interface IUnitDomain {
        MoveType MovementType { get; }
    }

    public enum MoveType {
        Infantry = 0,
        Armor = 1,
        Cavalry = 2,
        Flying = 3,
        Thief = 4,
        Mountain = 5,
        Sea = 6,
        Berserk = 7,
        Magic = 8,
        Almighty = 9,
        Monster = 10
    }

    public enum ArmyType {
        Player = 0,
        Enemy = 1,
        Ally = 2,
        Other = 3
    }
}