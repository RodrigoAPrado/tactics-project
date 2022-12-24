namespace Tactics.Domain.Interface.Item.Data {   
    public interface IItemData {
        ItemCode ItemCode { get; }
        string Name { get; }
        ItemType Type { get; }
        int Uses { get; }
        int PricePerUse { get; }
    }

    public enum ItemType {
        Empty = 0,
        Weapon = 1,
        Consumable = 2,
        Hold = 3
    }
}