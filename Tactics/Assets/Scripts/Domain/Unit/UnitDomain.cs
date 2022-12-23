using System;
using System.Collections.Generic;
using Tactics.Domain.Interface.Unit;
using Tactics.Domain.Interface.Board;
using Tactics.Domain.Interface.Item.Data;

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

        public UnitDomain(IUnitData unitData, ITileDomain tileBelowUnit) {
            Id = Guid.NewGuid();
            UnitData = unitData;
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

        public DamageType DmgType => DamageType.Physical; //TODO;
        public int AttackRange => 1; //TODO:
        public int Attack => Strength + 10; //TODO;
    }
}
