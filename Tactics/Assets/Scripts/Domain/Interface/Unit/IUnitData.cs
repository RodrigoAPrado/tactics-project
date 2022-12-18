using System.Collections.Generic;

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

    public enum WeaponType {
        Sword = 0,
        Axe = 1,
        Lance = 2,
        Knife = 3,
        Bow = 4,
        Fire = 5,
        Thunder = 6,
        Wind = 7,
        Light = 8,
        Dark = 9,
        Staves = 10,
        Dragon = 11,
        Monster = 12
    }

    public enum WeaponRank {
        None = 0,
        E = 1,
        D = 31,
        C = 71,
        B = 121,
        A = 181,
        S = 251
    }
}