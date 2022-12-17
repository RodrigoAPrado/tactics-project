using System.Collections.Generic;
using Tactics.Domain.Interface.Unit;

namespace Tactics.Domain.Interface.Board {
    public interface ITileDataDomain {
        bool UnitsCanStay { get; }
        bool Disabled { get; }
        bool Destroyable { get; }
        int DefenseBonus { get; }
        int ResistanceBonus { get; }
        int AvoidBonus { get; }
        TileType Type { get; }
        TileType TypeSpawnOnDestruction { get; }
        IList<ITileEffect> TileEffects { get; }

        void ApplyEffectsOnUnit(IUnitDomain unit);

        int CheckMoveCostByMoveType(MoveType moveType);

    }

    public interface ITileEffect {
        TileEffectTrigger Trigger { get; }

        void ApplyEffect(IUnitDomain unit);
        void RemoveEffect(IUnitDomain unit);
    }


    public enum TileType {
        Plains = 0,
        Disabled = 99
    }

    public enum TileEffectTrigger {
        TurnStart = 0,
        TurnEnd = 1,
        UnitApproaches = 2
    }

}