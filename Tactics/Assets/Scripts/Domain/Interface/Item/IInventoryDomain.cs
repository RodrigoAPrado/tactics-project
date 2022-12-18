using System;
using System.Collections.Generic;
using Tactics.Domain.Interface.Item.Data;

namespace Tactics.Domain.Interface.Item {

    public interface IInventoryDomain {
        Guid Id { get; }
        IItemDomain[] Items { get; }
        bool HasWeapon { get; }
        bool IsEmpty { get; }
        bool IsFull { get; }
        bool AddItem (IItemDomain item);
        bool EquipWeapon(IWeaponDomain wpn);
        bool UnequipWeapon();
        void RearrangeItem (int pos1, int pos2);
        void DropItem(int pos);
        IItemDomain TradeItem(IItemDomain givenItem, int pos);
        IWeaponDomain EquippedWeapon();
    }

}