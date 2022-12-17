using System.Collections.Generic;
using Tactics.Domain.Interface.Board;
using Tactics.Domain.Interface.Unit;

namespace Tactics.Domain.Board {

    public abstract class BaseTileDataDomain : ITileDataDomain {
        public virtual bool UnitsCanStay => true;
        public virtual bool Disabled => false;
        public virtual bool Destroyable => false;
        public virtual int DefenseBonus => 0;
        public virtual int ResistanceBonus => 0;
        public virtual int AvoidBonus => 0;
        public abstract TileType Type { get; }
        public virtual TileType TypeSpawnOnDestruction => Type;
        public IList<ITileEffect> TileEffects => _tileEffects.AsReadOnly();
        protected List<ITileEffect> _tileEffects  {get; set; } = new List<ITileEffect>();
        protected Dictionary<MoveType, int> MoveTypeDictionary { get; set; } = new Dictionary<MoveType, int>();


        public virtual int CheckMoveCostByMoveType(MoveType moveType) {
            int moveCost = 1;
            if(MoveTypeDictionary.ContainsKey(moveType))
                moveCost = MoveTypeDictionary[moveType];

            return moveCost;
        }

        public virtual void ApplyEffectsOnUnit(IUnitDomain unit) {
            foreach(var effect in _tileEffects) {
                effect.ApplyEffect(unit);
            }
        }
    }
}