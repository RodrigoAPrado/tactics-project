using System;
using Tactics.Domain.Interface.Item;
using Tactics.Domain.Interface.Item.Data;

namespace Tactics.Domain.Item {


    public class WeaponDomain : ItemDomain, IWeaponDomain {
        public IWeaponData WpnData { get; private set; }

        public WeaponDomain(IWeaponData data, int timesUsed, bool droppable,
        bool stealable) : base(data, timesUsed, droppable, stealable) {
            WpnData = data;
        }
    }
}
