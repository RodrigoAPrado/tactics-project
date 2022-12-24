using System;
using System.Collections.Generic;
using Tactics.Domain.Interface.Item.Data;

namespace Tactics.Domain.Interface.Item {

    public interface IInventoryDomain {
        Guid Id { get; }
        IItemDomain[] Items { get; }
        IWeaponDomain[] Weapons { get; }
        bool IsEmpty { get; }
        bool IsFull { get; }
        bool IsEquipped { get; }
        int MinWeaponRange { get; }
        int MaxWeaponRange { get; }
        bool AddItem (IItemDomain item);
        bool EquipWeapon (IWeaponDomain weaponToEquip);
        bool UnequipWeapon();
        void RearrangeItem (int pos1, int pos2);
        void DropItem(int pos);
        IItemDomain TradeItem(IItemDomain givenItem, int pos);
        IWeaponDomain EquippedWeapon();
    }

}