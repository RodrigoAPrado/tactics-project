using System;
using Tactics.Domain.Interface.Item;
using Tactics.Domain.Interface.Item.Data;

namespace Tactics.Domain.Item {

    public class ItemDomain : IItemDomain {
        
        public Guid Id { get; }
        public int CurrentUses => Data.Uses - TimesUsed;
        public int TimesUsed { get; private set; }
        public bool Droppable { get; private set; }
        public bool Stealable { get; private set; }
        public bool Broken => CurrentUses <= 0;
        public IItemData Data { get; }

        public ItemDomain(IItemData data, Guid id, int timesUsed, bool droppable,
        bool stealable) {
            Data = data;
            Id = id;
            TimesUsed = timesUsed;
            Droppable = droppable;
            Stealable = stealable;
        }

        public void UseItem() {
            TimesUsed++;
        }
    }

}