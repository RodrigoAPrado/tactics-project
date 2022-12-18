using Tactics.Domain.Interface.Item.Data;
using Tactics.Domain.Item.Data.Weapon.Base;

namespace Tactics.Domain.Item.Data.Weapon.Axe {

    public class IronAxeData : BaseWeaponData {

        private static IWeaponData _instance { get; set; }

        public static IWeaponData Instance {
            get {
                if(_instance == null) {
                    _instance = new IronAxeData();
                }
                return _instance;
            }
        }

        public override WeaponCode WpnCode => WeaponCode.Iron_Axe;
        public override ItemType Type => ItemType.Weapon;
        public override int Uses => 50;
        public override int PricePerUse => 8;
        public override WeaponType WpnType => WeaponType.Axe;
        public override WeaponRank WpnRank => WeaponRank.E;
        public override int Might => 8;
        public override int Hit => 80;
        public override int Crit => 0;
        public override int Weight => 11;
        public override int MinRange => 1;
        public override int MaxRange => 1;
        public override int WeaponExpGiven => 1;
        private IronAxeData() {

        }
    }

}