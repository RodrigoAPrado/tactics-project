using Tactics.Domain.Interface.Item.Data;
using Tactics.Domain.Item.Data.Weapon.Base;

namespace Tactics.Domain.Item.Data.Weapon.Bow {

    public class IronLanceData : BaseWeaponData {

        private static IWeaponData _instance { get; set; }

        public static IWeaponData Instance {
            get {
                if(_instance == null) {
                    _instance = new IronLanceData();
                }
                return _instance;
            }
        }

        public override WeaponCode WpnCode => WeaponCode.Iron_Lance;
        public override DamageType DmgType => DamageType.Physical;
        public override ItemType Type => ItemType.Weapon;
        public override int Uses => 50;
        public override int PricePerUse => 12;
        public override WeaponType WpnType => WeaponType.Lance;
        public override WeaponRank WpnRank => WeaponRank.E;
        public override int Might => 7;
        public override int Hit => 85;
        public override int Crit => 0;
        public override int Weight => 9;
        public override int MinRange => 1;
        public override int MaxRange => 1;
        public override int WeaponExpGiven => 1;
        private IronLanceData() {

        }
    }

}