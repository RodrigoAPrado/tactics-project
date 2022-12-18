using System;
using System.Collections.Generic;
using Tactics.Domain.Interface.Item.Data;
using Tactics.Domain.Interface.Item;

namespace Tactics.Domain.Item {

    public class InventoryDomain : IInventoryDomain {
        public Guid Id { get; private set; }
        public IItemDomain[] Items { get; private set; }
        public bool HasWeapon {
            get {
                for(int i = 0; i<InventoryLimit; i++) {
                    if(Items[i]?.Data?.Type == ItemType.Weapon) {
                        return true;
                    }
                }
                return false;
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
        private static int InventoryLimit => 8;

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
        public bool EquipWeapon (IWeaponDomain wpn) {
            throw new NotImplementedException();
        }
        
        public bool UnequipWeapon () {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
    }

}