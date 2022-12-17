using System;
using System.Collections.Generic;
using Tactics.Domain.Interface.Unit;
using Tactics.Domain.Interface.Board;

namespace Tactics.Domain.Unit{
    public class UnitDomain : IUnitDomain{
        public Guid Id { get; private set;}
        public string Name => UnitData.Name;
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
        public Affinity Affinity => UnitData.Affinity;
        public ArmyType ArmyType => UnitData.ArmyType;
        public IDictionary<WeaponType, int> WeaponExp => UnitData.WeaponExp;
        public UnitState CurrentState { get; private set; }
        public ITileDomain TileBelowUnit { get; private set; }
        private IUnitData UnitData { get; }

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

        public void AddDamage(int damage) {
            DamageSustained += damage;
            if(DamageSustained < 0)
                DamageSustained = 0;
            if(DamageSustained > MaxHitPoints)
                CurrentState = UnitState.Defeated;
        }

        public void AddTileBelowUnit(ITileDomain tile) {
            TileBelowUnit = tile;
        }
    }
}
