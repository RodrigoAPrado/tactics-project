using Tactics.Domain.Interface.Item;
using Tactics.Domain.Interface.Item.Data;
using Tactics.Domain.Item;
using Tactics.Domain.Item.Data;
using Tactics.Domain.Item.Data.Weapon.Sword;
using Tactics.Domain.Item.Data.Weapon.Axe;
using Tactics.Domain.Item.Data.Weapon.Lance;
using Tactics.Domain.Item.Data.Weapon.Bow;

namespace Tactics.Domain.Factory {
    public static class ItemDomainFactory {
        public static IItemDomain CreateDomain(ItemCode itemCode, int timesUsed, bool droppable, bool stealable) {
            switch(itemCode) {
                case ItemCode.Iron_Sword:
                    return IronSword(timesUsed, droppable, stealable);
                case ItemCode.Iron_Axe:
                    return IronAxe(timesUsed, droppable, stealable);
                case ItemCode.Iron_Bow:
                    return IronBow(timesUsed, droppable, stealable);
                case ItemCode.Iron_Lance:
                    return IronLance(timesUsed, droppable, stealable);
            }
            return null;
        }

        private static IItemDomain IronSword(int timesUsed, bool droppable, bool stealable) {
            return new WeaponDomain(IronSwordData.Instance, timesUsed, droppable, stealable);
        }
        private static IItemDomain IronAxe(int timesUsed, bool droppable, bool stealable) {
            return new WeaponDomain(IronAxeData.Instance, timesUsed, droppable, stealable);
        }
        private static IItemDomain IronBow(int timesUsed, bool droppable, bool stealable) {
            return new WeaponDomain(IronBowData.Instance, timesUsed, droppable, stealable);
        }
        private static IItemDomain IronLance(int timesUsed, bool droppable, bool stealable) {
            return new WeaponDomain(IronLanceData.Instance, timesUsed, droppable, stealable);
        }
    }
}