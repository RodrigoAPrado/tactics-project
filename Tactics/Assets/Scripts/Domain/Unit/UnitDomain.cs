using System;
using System.Collections.Generic;
using Tactics.Domain.Interface.Unit;
using Tactics.Domain.Interface.Board;
using Tactics.Domain.Interface.Item.Data;
using Tactics.Domain.Interface.Item;

namespace Tactics.Domain.Unit{
    public class UnitDomain : IUnitDomain{
        public Guid Id { get; private set;}
        public string Name => UnitData.Name;
        public int Level => UnitData.Level;
        public int Exp => UnitData.Exp;
        public int MaxHitPoints => UnitData.HitPoints;
        public int CurrentHitPoints => MaxHitPoints - DamageSustained < 0 ? 0 : MaxHitPoints - DamageSustained;
        public int DamageSustained { get; private set; }
        public int Strength => UnitData.Strength;
        public int Magic => UnitData.Magic;
        public int Skill => UnitData.Skill;
        public int Speed => UnitData.Speed;
        public int Luck => UnitData.Luck;
        public int Defense => UnitData.Defense;
        public int Resistance => UnitData.Resistance;
        public int Weight => UnitData.Weight;
        public int Move => UnitData.Move;
        public int Constitution => UnitData.Constitution;
        public Affinity Affinity => UnitData.UnitAffinity;
        public ArmyType ArmyType => UnitData.UnitArmyType;
        public UnitState CurrentState { get; private set; }
        public ITileDomain TileBelowUnit { get; private set; }
        private IUnitData UnitData { get; }
        public event Action OnStateChange;

        public UnitDomain(IUnitData unitData, ITileDomain tileBelowUnit, IInventoryDomain inventory) {
            Id = Guid.NewGuid();
            UnitData = unitData;
            Inventory = inventory;
            CurrentState = UnitState.Ready;
            TileBelowUnit = tileBelowUnit;
            TileBelowUnit.AddUnitOnTile(this);
        }

        public MoveType GetMovementType() {
            return UnitData.MoveType;
        }

        public int GetWeaponExpByType(WeaponType type) {
            return UnitData.GetWeaponExpByType(type);
        }

        public void AddDamage(int damage) {
            DamageSustained += damage;
            if(DamageSustained < 0)
                DamageSustained = 0;
            if(DamageSustained > MaxHitPoints)
                CurrentState = UnitState.Defeated;
        }

        public void AddTileBelowUnit(ITileDomain tile) {
            if(!tile.Empty) {
                return;
            }
            TileBelowUnit.RemoveUnitFromTile();
            TileBelowUnit = tile;
            TileBelowUnit.AddUnitOnTile(this);
        }

        public void FinishTurn() {
            CurrentState = UnitState.Over;
            OnStateChange.Invoke();
        }

        public void AddListener(Action action) {
            OnStateChange += action;
        }

        public IInventoryDomain Inventory { get; set; }
        public IWeaponDomain EquippedWeapon => Inventory.EquippedWeapon();
        public string EquippedWeaponName => EquippedWeapon.Data.Name;
        public DamageType DmgType => EquippedWeapon.WpnData.DmgType;
        public int MaxRange => Inventory.MaxWeaponRange;
        public int MinRange => Inventory.MinWeaponRange;
        public int Attack => Strength + EquippedWeapon.WpnData.Might;
    }
}
