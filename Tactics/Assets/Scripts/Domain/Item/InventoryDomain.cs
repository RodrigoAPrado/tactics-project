using System;
using System.Collections.Generic;
using Tactics.Domain.Interface.Item.Data;
using Tactics.Domain.Interface.Item;
using Tactics.Domain.Item.Data.Weapon.Sword;

namespace Tactics.Domain.Item {

    public class InventoryDomain : IInventoryDomain {
        public Guid Id { get; private set; }
        public IItemDomain[] Items { get; private set; }

        public IWeaponDomain[] Weapons {
            get {
                var weapons = new List<IWeaponDomain>();
                foreach(var item in Items) {
                    if(item.Data.Type == ItemType.Weapon) {
                        weapons.Add((IWeaponDomain) item);
                    }
                }
                return weapons.ToArray();
            }
        }

        public bool IsEmpty {
            get {
                for(int i = 0; i< InventoryLimit; i++) {
                    if(Items[i] != null) {
                        return false;
                    }
                }
                return true;
            }
        }

        public bool IsFull {
            get {
                for(int i = 0; i< InventoryLimit; i++) {
                    if(Items[i] == null) {
                        return false;
                    }
                }
                return true;
            }
        }

        public bool IsEquipped => _equippedWeapon != null;

        public int MinWeaponRange {
            get {
                var minRange = -1;
                foreach (var weapon in Weapons) {
                    if(weapon.WpnData.MinRange < minRange || minRange == -1) 
                        minRange = weapon.WpnData.MinRange;
                }

                return minRange;
            }
        }

        public int MaxWeaponRange {
            get {
                var maxRange = -1;
                foreach (var weapon in Weapons) {
                    if(weapon.WpnData.MaxRange > maxRange || maxRange == -1) 
                        maxRange = weapon.WpnData.MaxRange;
                }
                return maxRange;
            }
        }

        private const int InventoryLimit = 8;

        private IWeaponDomain _equippedWeapon { get; set; }

        public InventoryDomain() {
            GenerateEmptyItems();
        }

        private void GenerateEmptyItems() {
            if(Items != null)
                throw new Exception("Inventory already set!");

            Items = new IItemDomain[InventoryLimit];
        }

        public bool AddItem (IItemDomain item) {
            var added = false;
            for(int i = 0; i<InventoryLimit; i++) {
                if(Items[i] == null) {
                    Items[i] = item;
                    added = true;
                    break;
                }
            }
            return added;
        }

        public bool EquipWeapon(IWeaponDomain weaponToEquip) {
            var weaponIndex = FindItemIndex(weaponToEquip);
            if(weaponIndex < 0)
                return false;

            return EquipWeapon(weaponIndex);
        }

        public bool EquipFirstAvailableWeapon() {
            var weapons = Weapons;
            if(weapons.Length > 0)
                return EquipWeapon(0);
            return false;
        }

        private int FindItemIndex(IItemDomain itemDomain) {
            for(var i = 0; i<Items.Length ; i++) {
                if(Items[i] == itemDomain){
                    return i;
                }
            }
            return -1;
        }

        private bool EquipWeapon (int itemIndex) {
            if(itemIndex < 0 || itemIndex >= InventoryLimit || Items[itemIndex] == null || Items[itemIndex].Data.Type != ItemType.Weapon)
                throw new InvalidOperationException();

            if(itemIndex == 0) {
                _equippedWeapon = (IWeaponDomain) Items[0];
                return true;
            }

            var weaponToEquip = Items[itemIndex];
            Items[itemIndex] = null;
            PutEmptySlotsAfterNonEmpty();
            if(RelieveFirstPosition()) {
                Items[0] = weaponToEquip;
                _equippedWeapon = (IWeaponDomain) Items[0];
                return true;
            }
            return false;
        }

        public bool UnequipWeapon () {
            if(!IsEquipped)
                return false;
            _equippedWeapon = null;
            return true;
        }

        public void RearrangeItem (int pos1, int pos2) {
            SwitchItems(pos1, pos2);
            PutEmptySlotsAfterNonEmpty();
        }

        public void DropItem(int pos) {
            if(Items[pos].Droppable) {
                Items[pos] = null;
                PutEmptySlotsAfterNonEmpty();
            }
        }

        public IItemDomain TradeItem(IItemDomain givenItem, int pos) {
            var itemTraded = Items[pos];
            Items[pos] = givenItem;
            PutEmptySlotsAfterNonEmpty();
            return itemTraded;
        }
        public IWeaponDomain EquippedWeapon() {
            return _equippedWeapon;
        }

        private void SwitchItems(int pos1, int pos2) {
            var item = Items[pos1];
            Items[pos1] = Items[pos2];
            Items[pos2] = item;
        }

        private void PutEmptySlotsAfterNonEmpty() {
            if(IsFull || IsEmpty)
                return;

            var helpArray = new List<IItemDomain>();
            for(var i = 0; i<InventoryLimit; i++) {
                if(Items[i] != null) {
                    helpArray.Add(Items[i]);
                }
            }

            for(var i = 0; i<InventoryLimit; i++) {
                if(helpArray.Count > i)
                    Items[i] = helpArray[i];
                else
                    Items[i] = null;
            }
        }

        private bool RelieveFirstPosition() {
            if(IsFull)
                throw new InvalidOperationException();
            if(IsEmpty)
                return true;
            
            for(var i = Items.Length-1; i > 0; i--) {
                Items[i] = Items[i-1];
            }

            Items[0] = null;

            return true;
        }
    }

}