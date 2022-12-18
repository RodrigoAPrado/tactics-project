using System.Collections.Generic;
using Tactics.Domain.Interface.Item.Data;

namespace Tactics.Domain.Interface.Unit {
    public interface IUnitData {
        int Level { get; }
        int TotalLevel { get; }
        int Exp { get; }
        string Name { get; }
        int ArmyId { get; }
        int HitPoints { get; }
        int Strength { get; }
        int Magic { get; }
        int Skill { get; }
        int Speed { get; }
        int Luck { get; }
        int Defense { get; }
        int Resistance { get; }
        int Weight { get; }
        int Move { get; }
        int Constitution { get; }
        bool CanPromote { get; }
        ArmyType UnitArmyType { get; }
        UnitClass UnitClass { get; }
        MoveType MoveType { get; }
        Affinity UnitAffinity { get; }
        UnitClass PromotionClass { get; }
        int GetWeaponExpByType(WeaponType type);
    }

    public interface IUnitStats {
        int HitPoints { get; }
        int Strength { get; }
        int Magic { get; }
        int Skill { get; }
        int Speed { get; }
        int Luck { get; }
        int Defense { get; }
        int Resistance { get; }
        int Weight { get; }
        int Move { get; }
        int Constitution { get; }
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

    public enum Affinity {
        Dark = 0,
        Light = 1,
        Fire = 2,
        Wind = 3,
        Thunder = 4,
        Ice = 5,
        Anima = 6,
        Earth = 7,
    }
}