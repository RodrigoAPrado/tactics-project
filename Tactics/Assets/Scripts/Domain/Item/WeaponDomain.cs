using System;
using Tactics.Domain.Interface.Item;
using Tactics.Domain.Interface.Item.Data;

namespace Tactics.Domain.Item {


    public class WeaponDomain : ItemDomain, IWeaponDomain {
        public IWeaponData WpnData { get; private set; }

        public WeaponDomain(IWeaponData data, Guid id, int timesUsed, bool droppable,
        bool stealable) : base(data, id, timesUsed, droppable, stealable) {
            WpnData = data;
        }
    }
}
