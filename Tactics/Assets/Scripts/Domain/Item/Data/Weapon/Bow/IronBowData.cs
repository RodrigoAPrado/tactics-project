using Tactics.Domain.Interface.Item.Data;
using Tactics.Domain.Item.Data.Weapon.Base;

namespace Tactics.Domain.Item.Data.Weapon.Bow {

    public class IronBowData : BaseWeaponData {

        private static IWeaponData _instance { get; set; }

        public static IWeaponData Instance {
            get {
                if(_instance == null) {
                    _instance = new IronBowData();
                }
                return _instance;
            }
        }

        public override WeaponCode WpnCode => WeaponCode.Iron_Bow;
        public override DamageType DmgType => DamageType.Physical;
        public override ItemType Type => ItemType.Weapon;
        public override int Uses => 50;
        public override int PricePerUse => 15;
        public override WeaponType WpnType => WeaponType.Bow;
        public override WeaponRank WpnRank => WeaponRank.E;
        public override int Might => 6;
        public override int Hit => 85;
        public override int Crit => 0;
        public override int Weight => 8;
        public override int MinRange => 2;
        public override int MaxRange => 2;
        public override int WeaponExpGiven => 1;
        private IronBowData() {

        }
    }

}