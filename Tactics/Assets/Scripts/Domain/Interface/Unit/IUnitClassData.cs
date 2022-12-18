using System.Collections.Generic;

namespace Tactics.Domain.Interface.Unit {
    public interface IUnitClassData {
        int ClassTier { get; }
        int MaxLevel { get; }
        IUnitStats BaseStats { get; }
        IUnitStats Growths { get; }
        IUnitStats MaxStats { get; }
        IUnitStats PromotionGains { get; }
        MoveType MoveType { get; }
        UnitClass UnitClass { get; }
        UnitClass PromotionClass { get; }
        bool CanPromote { get; }
        IDictionary<WeaponType, int> BaseWeaponExp { get; }
    }
}