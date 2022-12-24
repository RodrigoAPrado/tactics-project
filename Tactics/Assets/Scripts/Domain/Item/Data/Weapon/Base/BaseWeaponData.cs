using Tactics.Domain.Interface.Item.Data;

namespace Tactics.Domain.Item.Data.Weapon.Base {

    public abstract class BaseWeaponData : IWeaponData {
        public string Name => ItemCode.ToString().Replace("_", " ");

        public abstract ItemCode ItemCode { get; }
        public ItemType Type  => ItemType.Weapon;
        public abstract DamageType DmgType { get; }
        public abstract int Uses { get; }
        public abstract int PricePerUse { get; }
        public abstract WeaponType WpnType { get; }
        public abstract WeaponRank WpnRank { get; }
        public abstract int Might { get; }
        public abstract int Hit { get; }
        public abstract int Crit { get; }
        public abstract int Weight { get; }
        public abstract int MinRange { get; }
        public abstract int MaxRange { get; }
        public abstract int WeaponExpGiven { get; }
    }

}