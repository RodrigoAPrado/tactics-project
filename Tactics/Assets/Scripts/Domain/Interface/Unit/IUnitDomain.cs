using System;
using System.Collections.Generic;
using Tactics.Domain.Interface.Board;
using Tactics.Domain.Interface.Item.Data;
using Tactics.Domain.Interface.Item;

namespace Tactics.Domain.Interface.Unit {
    public interface IUnitDomain {
        Guid Id { get; }
        string Name { get; }
        int Level { get; }
        int Exp { get; }
        int MaxHitPoints { get; }
        int CurrentHitPoints { get; }
        int DamageSustained { get; }
        int Strength { get; }
        int Magic { get; }
        int Skill { get; }
        int Speed { get; }
        int Luck { get; }
        int Defense { get; }
        int Resistance { get; }
        int Weight { get; }
        int Move { get; }
        int Constitution { get; }
        Affinity Affinity { get; }
        ArmyType ArmyType { get; }
        string ClassName { get; }

        UnitState CurrentState { get; }
        ITileDomain TileBelowUnit { get; }

        MoveType GetMovementType();
        
        int GetWeaponExpByType(WeaponType type);
        void AddDamage(int damage);
        void AddTileBelowUnit(ITileDomain tile);
        void FinishTurn();
        void AddListener(Action action);
        //TODO: Add status condition;

        IInventoryDomain Inventory { get; }
        IWeaponDomain EquippedWeapon { get; }
        string EquippedWeaponName { get; }
        DamageType DmgType { get; }
        int MaxRange { get; }
        int MinRange { get; }
        int Attack { get; }
    }

    public class IUnitInventoryItem {
        public int ItemType { get; }
        public int ItemUses { get; }
    }

    public enum StatusCondition {
        Poison = 0
    }

    public enum UnitState {
        Ready,
        Acting,
        Over,
        Defeated
    }
}