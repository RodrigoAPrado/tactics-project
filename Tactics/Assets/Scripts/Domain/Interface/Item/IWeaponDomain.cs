using System;
using Tactics.Domain.Interface.Item.Data;

namespace Tactics.Domain.Interface.Item {
    public interface IWeaponDomain : IItemDomain {
        IWeaponData WpnData { get; }
    }
}