using Tactics.Domain.Interface.Item.Data;
using Tactics.Domain.Item.Data.Weapon.Base;

namespace Tactics.Domain.Item.Data.Weapon.Sword {

    public class IronSwordData : BaseWeaponData {

        private static IWeaponData _instance { get; set; }

        public static IWeaponData Instance {
            get {
                if(_instance == null) {
                    _instance = new IronSwordData();
                }
                return _instance;
            }
        }

        public override WeaponCode WpnCode => WeaponCode.Iron_Sword;
        public override DamageType DmgType => DamageType.Physical;
        public override ItemType Type => ItemType.Weapon;
        public override int Uses => 50;
        public override int PricePerUse => 7;
        public override WeaponType WpnType => WeaponType.Sword;
        public override WeaponRank WpnRank => WeaponRank.E;
        public override int Might => 6;
        public override int Hit => 90;
        public override int Crit => 0;
        public override int Weight => 7;
        public override int MinRange => 1;
        public override int MaxRange => 1;
        public override int WeaponExpGiven => 1;
        private IronSwordData() {

        }
    }

}