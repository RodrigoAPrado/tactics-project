using Tactics.Domain.Interface.Unit;

namespace Tactics.Domain.Interface.Item.Data {
    public interface IWeaponData : IItemData {
        WeaponType WpnType { get; }
        DamageType DmgType { get; }
        WeaponRank WpnRank { get; }
        int Might { get; }
        int Hit { get; }
        int Crit { get; }
        int Weight { get; }
        int MinRange { get; }
        int MaxRange { get; }
        int WeaponExpGiven { get; }
        
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

    public enum DamageType {
        Physical = 0,
        Magical = 1
    }
}