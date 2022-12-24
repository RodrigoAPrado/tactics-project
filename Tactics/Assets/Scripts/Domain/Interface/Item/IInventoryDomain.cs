using System;
using System.Collections.Generic;
using Tactics.Domain.Interface.Item.Data;
using Tactics.Domain.Interface.Unit;

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
        void Init(IUnitDomain owner);
        bool AddItem (IItemDomain item);
        bool EquipWeapon (IWeaponDomain weaponToEquip);
        bool EquipFirstAvailableWeapon();
        bool CanEquipWeapon(IWeaponDomain weapon);
        bool UnequipWeapon();
        void RearrangeItem (int pos1, int pos2);
        void DropItem(int pos);
        IItemDomain TradeItem(IItemDomain givenItem, int pos);
        IWeaponDomain EquippedWeapon();
    }

}