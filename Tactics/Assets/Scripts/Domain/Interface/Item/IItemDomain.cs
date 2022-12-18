using System;
using Tactics.Domain.Interface.Item.Data;

namespace Tactics.Domain.Interface.Item {
    public interface IItemDomain {
        Guid Id { get; }
        int CurrentUses { get; }
        int TimesUsed { get; }
        bool Droppable { get; }
        bool Stealable { get; }
        bool Broken { get; }
        IItemData Data { get; }
        void UseItem();
    }
}
